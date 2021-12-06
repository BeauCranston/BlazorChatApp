using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorChatApp.DataTransfer
{
    class ChatMessageDTO
    {
        public int ChatRoomUserId { get; set; }
        public string ChatMessageContent { get; set; }
    }
}
