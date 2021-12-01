using BlazorChatApp.Server.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorChatApp.Server.Persistence.Repositories
{
    public class ChatRoomRepository : GenericRepository<ChatRoom>, IChatRoomRepository
    {
        public ChatRoomRepository(BlazorChatDbContext context) : base(context)
        {
        }

        public void FilterPrivateRooms()
        {
            throw new NotImplementedException();
        }

        public void GetByRoomName(string roomName)
        {
            throw new NotImplementedException();
        }

        public void GetRoomMembers()
        {
            throw new NotImplementedException();
        }
    }
}
