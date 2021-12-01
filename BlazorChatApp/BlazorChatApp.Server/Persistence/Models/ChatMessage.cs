using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorChatApp.Server.Persistence.Models
{
    public partial class ChatMessage
    {
        public int ChatMessageId { get; set; }
        public int? ChatRoomUserId { get; set; }
        public string ChatMessageContent { get; set; }

        public virtual ChatRoomUser ChatRoomUser { get; set; }
    }
}
