using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace BlazorChatApp.Server.Persistence.Models
{
    public partial class BlazorChatDbContext : DbContext
    {
        private readonly IConfiguration _config; 
        public BlazorChatDbContext()
        {
        }

        public BlazorChatDbContext(DbContextOptions<BlazorChatDbContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<ChatMessage> ChatMessages { get; set; }
        public virtual DbSet<ChatRoom> ChatRooms { get; set; }
        public virtual DbSet<ChatRoomUser> ChatRoomUsers { get; set; }
        public virtual DbSet<ChatUser> ChatUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Database=Unamed-Chat-App;Username=postgres;Password=admin");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "English_United States.1252");

            modelBuilder.Entity<ChatMessage>(entity =>
            {
                entity.ToTable("chat_message");

                entity.Property(e => e.ChatMessageId).HasColumnName("chat_message_id");

                entity.Property(e => e.ChatMessageContent)
                    .HasMaxLength(750)
                    .HasColumnName("chat_message_content");

                entity.Property(e => e.ChatRoomUserId).HasColumnName("chat_room_user_id");

                entity.HasOne(d => d.ChatRoomUser)
                    .WithMany(p => p.ChatMessages)
                    .HasForeignKey(d => d.ChatRoomUserId)
                    .HasConstraintName("chat_message_chat_room_user_id_fkey");
            });

            modelBuilder.Entity<ChatRoom>(entity =>
            {
                entity.ToTable("chat_room");

                entity.Property(e => e.ChatRoomId).HasColumnName("chat_room_id");

                entity.Property(e => e.ChatRoomName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("chat_room_name");

                entity.Property(e => e.IsPrivate).HasColumnName("is_private");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<ChatRoomUser>(entity =>
            {
                entity.ToTable("chat_room_user");

                entity.Property(e => e.ChatRoomUserId).HasColumnName("chat_room_user_id");

                entity.Property(e => e.ChatRoomId).HasColumnName("chat_room_id");

                entity.Property(e => e.ChatUserId).HasColumnName("chat_user_id");

                entity.HasOne(d => d.ChatRoom)
                    .WithMany(p => p.ChatRoomUsers)
                    .HasForeignKey(d => d.ChatRoomId)
                    .HasConstraintName("chat_room_user_chat_room_id_fkey");

                entity.HasOne(d => d.ChatUser)
                    .WithMany(p => p.ChatRoomUsers)
                    .HasForeignKey(d => d.ChatUserId)
                    .HasConstraintName("chat_room_user_chat_user_id_fkey");
            });

            modelBuilder.Entity<ChatUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("chat_user_pkey");

                entity.ToTable("chat_user");

                entity.HasIndex(e => e.Username, "UsernameConstraint")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
