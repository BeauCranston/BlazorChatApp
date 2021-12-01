using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorChatApp.Server.Persistence.Models
{
    public partial class ChatUser
    {
        public ChatUser()
        {
            ChatRoomUsers = new HashSet<ChatRoomUser>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<ChatRoomUser> ChatRoomUsers { get; set; }
    }
}
