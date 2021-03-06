// <auto-generated />
using System;
using BlazorChatApp.Server.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BlazorChatApp.Server.Persistence.Migrations
{
    [DbContext(typeof(BlazorChatDbContext))]
    [Migration("20211123152620_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "English_United States.1252")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("BlazorChatApp.Server.Persistence.Models.ChatMessage", b =>
                {
                    b.Property<int>("ChatMessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("chat_message_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ChatMessageContent")
                        .HasMaxLength(750)
                        .HasColumnType("character varying(750)")
                        .HasColumnName("chat_message_content");

                    b.Property<int?>("ChatRoomUserId")
                        .HasColumnType("integer")
                        .HasColumnName("chat_room_user_id");

                    b.HasKey("ChatMessageId");

                    b.HasIndex("ChatRoomUserId");

                    b.ToTable("chat_message");
                });

            modelBuilder.Entity("BlazorChatApp.Server.Persistence.Models.ChatRoom", b =>
                {
                    b.Property<int>("ChatRoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("chat_room_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ChatRoomName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("chat_room_name");

                    b.Property<bool>("IsPrivate")
                        .HasColumnType("boolean")
                        .HasColumnName("is_private");

                    b.Property<string>("Password")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("password");

                    b.HasKey("ChatRoomId");

                    b.ToTable("chat_room");
                });

            modelBuilder.Entity("BlazorChatApp.Server.Persistence.Models.ChatRoomUser", b =>
                {
                    b.Property<int>("ChatRoomUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("chat_room_user_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ChatRoomId")
                        .HasColumnType("integer")
                        .HasColumnName("chat_room_id");

                    b.Property<int?>("ChatUserId")
                        .HasColumnType("integer")
                        .HasColumnName("chat_user_id");

                    b.HasKey("ChatRoomUserId");

                    b.HasIndex("ChatRoomId");

                    b.HasIndex("ChatUserId");

                    b.ToTable("chat_room_user");
                });

            modelBuilder.Entity("BlazorChatApp.Server.Persistence.Models.ChatUser", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("user_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("password");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("username");

                    b.HasKey("UserId")
                        .HasName("chat_user_pkey");

                    b.HasIndex(new[] { "Username" }, "UsernameConstraint")
                        .IsUnique();

                    b.ToTable("chat_user");
                });

            modelBuilder.Entity("BlazorChatApp.Server.Persistence.Models.ChatMessage", b =>
                {
                    b.HasOne("BlazorChatApp.Server.Persistence.Models.ChatRoomUser", "ChatRoomUser")
                        .WithMany("ChatMessages")
                        .HasForeignKey("ChatRoomUserId")
                        .HasConstraintName("chat_message_chat_room_user_id_fkey");

                    b.Navigation("ChatRoomUser");
                });

            modelBuilder.Entity("BlazorChatApp.Server.Persistence.Models.ChatRoomUser", b =>
                {
                    b.HasOne("BlazorChatApp.Server.Persistence.Models.ChatRoom", "ChatRoom")
                        .WithMany("ChatRoomUsers")
                        .HasForeignKey("ChatRoomId")
                        .HasConstraintName("chat_room_user_chat_room_id_fkey");

                    b.HasOne("BlazorChatApp.Server.Persistence.Models.ChatUser", "ChatUser")
                        .WithMany("ChatRoomUsers")
                        .HasForeignKey("ChatUserId")
                        .HasConstraintName("chat_room_user_chat_user_id_fkey");

                    b.Navigation("ChatRoom");

                    b.Navigation("ChatUser");
                });

            modelBuilder.Entity("BlazorChatApp.Server.Persistence.Models.ChatRoom", b =>
                {
                    b.Navigation("ChatRoomUsers");
                });

            modelBuilder.Entity("BlazorChatApp.Server.Persistence.Models.ChatRoomUser", b =>
                {
                    b.Navigation("ChatMessages");
                });

            modelBuilder.Entity("BlazorChatApp.Server.Persistence.Models.ChatUser", b =>
                {
                    b.Navigation("ChatRoomUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
