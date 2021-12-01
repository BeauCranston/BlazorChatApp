using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorChatApp.Server.Persistence.Models
{
    public partial class ChatRoomUser
    {
        public ChatRoomUser()
        {
            ChatMessages = new HashSet<ChatMessage>();
        }

        public int? ChatRoomId { get; set; }
        public int? ChatUserId { get; set; }
        public int ChatRoomUserId { get; set; }

        public virtual ChatRoom ChatRoom { get; set; }
        public virtual ChatUser ChatUser { get; set; }
        public virtual ICollection<ChatMessage> ChatMessages { get; set; }
    }
}
