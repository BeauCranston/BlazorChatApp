using BlazorChatApp.DataTransfer;
using BlazorChatApp.Server.Application;
using BlazorChatApp.Server.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorChatApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatUserController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly IChatUserRepository _chatUserRepository;
        public ChatUserController(ILoginService loginService, IChatUserRepository chatUserRepository)
        {
            _chatUserRepository = chatUserRepository;
            _loginService = loginService;
        }
        [HttpGet]
        public async Task GetUser(int id)
        {
            //await _chatUserRepository.GetUserById(id);
            await _loginService.CreateNewAccountAsync();
        }
        [HttpGet]
        public async Task GetUserByName(string username){
            //await _chatUserRepository.GetUserByUsername(username);
            await _loginService.CreateNewAccountAsync();
        }

        [HttpPost("login")]
        public async Task<ActionResult<ChatUser>> Login(ChatUserDTO chatUser){
            ChatUser user =  await _loginService.LoginUser(chatUser);
            return user;
        }

        [HttpPost("Create")]
        public async Task CreateAccount(){
            await _loginService.CreateNewAccountAsync();
        }


    }
}
