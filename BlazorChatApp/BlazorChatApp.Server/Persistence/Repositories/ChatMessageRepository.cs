using BlazorChatApp.Server.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorChatApp.Server.Persistence.Repositories
{
    public class ChatMessageRepository : GenericRepository<ChatMessage>
    {
        public ChatMessageRepository(BlazorChatDbContext context) : base(context)
        {
        }
    }
}
