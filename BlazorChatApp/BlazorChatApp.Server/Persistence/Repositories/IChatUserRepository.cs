namespace BlazorChatApp.Server.Persistence.Repositories
{
    public interface IChatUserRepository
    {
        void GetUserByUsername(string username);
    }
}