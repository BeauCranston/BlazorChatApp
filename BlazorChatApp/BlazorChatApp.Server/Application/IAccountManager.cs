using BlazorChatApp.DataTransfer;
using BlazorChatApp.Server.Controllers;
using System.Threading.Tasks;

namespace BlazorChatApp.Server.Application
{
    public interface ILoginService
    {
        Task<ChatUser> LoginUser(ChatUserDTO chatUser);
        Task CreateNewAccountAsync();
    }
}