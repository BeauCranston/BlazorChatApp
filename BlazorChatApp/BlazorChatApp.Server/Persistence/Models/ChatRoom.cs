using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorChatApp.Server.Persistence.Models
{
    public partial class ChatRoom
    {
        public ChatRoom()
        {
            ChatRoomUsers = new HashSet<ChatRoomUser>();
        }

        public int ChatRoomId { get; set; }
        public string ChatRoomName { get; set; }
        public bool IsPrivate { get; set; }
        public string Password { get; set; }
        public int RoomSize{ get; set; }
        public virtual ICollection<ChatRoomUser> ChatRoomUsers { get; set; }
    }
}
