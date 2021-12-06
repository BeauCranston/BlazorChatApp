using BlazorChatApp.Server.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorChatApp.Server.Persistence.Repositories
{
    interface IChatRoomRepository
    {
        ChatRoom GetByRoomName(string roomName);
        IEnumerable<ChatRoom> GetPrivateRooms();
        IEnumerable<ChatUser> GetRoomMembers(object id);
    }
}
