using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorChatApp.Server.Persistence.Repositories
{
    interface IChatRoomRepository
    {
        void GetByRoomName(string roomName);
        void FilterPrivateRooms();
        void GetRoomMembers();
    }
}
