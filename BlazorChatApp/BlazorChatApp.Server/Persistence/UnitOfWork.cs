using BlazorChatApp.Server.Persistence.Models;
using BlazorChatApp.Server.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorChatApp.Server.Persistence
{
    /// <summary>
    /// A class to encapsulate all repositories so changes can be saved once.
    /// database changes can now be used as custom transactions
    /// </summary>

    public class UnitOfWork : IDisposable
    {
        private BlazorChatDbContext context = new BlazorChatDbContext();
        private ChatMessageRepository chatMessageRepository = new ChatMessageRepository();
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
