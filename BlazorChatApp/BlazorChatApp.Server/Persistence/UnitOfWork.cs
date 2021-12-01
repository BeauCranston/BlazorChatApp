using BlazorChatApp.Server.Persistence.Models;
using BlazorChatApp.Server.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorChatApp.Server.Persistence
{
    /// <summary>
    /// Coordinates the work of all repositories that are used and executes them as a single unit of work so that the whole transaction is saved at once
    /// database changes can now be used as custom transactions
    /// </summary>

    public class UnitOfWork : IDisposable
    {
        private BlazorChatDbContext context = new BlazorChatDbContext();
        private ChatMessageRepository chatMessageRepository;
        private ChatRoomRepository chatRoomRepository;
        private ChatUserRepository chatUserRepository;
        private ChatRoomUserRepository chatRoomUserRepository;

        public ChatMessageRepository ChatMessageRepository {
            get {
                if(chatMessageRepository is null)
                    chatMessageRepository = new ChatMessageRepository(context);

                return chatMessageRepository;
            }
        }
        public ChatRoomRepository ChatRoomRepository {
            get
            {
                if (chatRoomRepository is null)
                    chatRoomRepository = new ChatRoomRepository(context);

                return chatRoomRepository;
            }
        }
        public ChatUserRepository ChatUserRepository {
            get
            {
                if (chatUserRepository is null)
                    chatUserRepository = new ChatUserRepository(context);

                return chatUserRepository;
            }
        }
        public ChatRoomUserRepository ChatRoomUserRepository {
            get
            {
                if (chatRoomUserRepository is null)
                    chatRoomUserRepository = new ChatRoomUserRepository(context);

                return chatRoomUserRepository;
            }
        }




        public async Task Save(){
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
