using BlazorChatApp.Server.Persistence.Models;

namespace BlazorChatApp.Server.Persistence.Repositories
{
    public interface IChatUserRepository
    {
        ChatUser GetUserByUsername(string username);
    }
}