using BlazorChatApp.Server.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorChatApp.Server.Persistence.Repositories
{
    public class ChatUserRepository : GenericRepository<ChatUser>, IChatUserRepository
    {
        public ChatUserRepository(BlazorChatDbContext context) : base(context)
        {
        }

        public void GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }
    }
}
