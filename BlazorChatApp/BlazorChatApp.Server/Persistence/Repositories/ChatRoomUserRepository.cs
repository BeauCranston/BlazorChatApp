using BlazorChatApp.Server.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorChatApp.Server.Persistence.Repositories
{
    public class ChatRoomUserRepository : GenericRepository<ChatRoomUser>, IChatRoomUserRepository
    {
        public ChatRoomUserRepository(BlazorChatDbContext context) : base(context)
        {
                
        }
        public void GetAllChatRoomsUserBelongsTo(int id)
        {
            throw new NotImplementedException();
        }

        public void GetAllChatRoomsUserBelongsTo(string username)
        {
            throw new NotImplementedException();
        }
    }
}
