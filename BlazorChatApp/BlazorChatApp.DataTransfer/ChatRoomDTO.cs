using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorChatApp.DataTransfer
{
    public class ChatRoomDTO
    {
        public string ChatRoomName { get; set; }
        public bool IsPrivate { get; set; }
        public string Password { get; set; }

        public int RoomSize { get; set; }
    }
}
