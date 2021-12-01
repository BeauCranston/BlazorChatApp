using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorChatApp.Server.Persistence.Repositories
{
    interface IChatRoomUserRepository
    {
        void GetAllChatRoomsUserBelongsTo(int id);
        void GetAllChatRoomsUserBelongsTo(string username);

    }
}
