using BlazorChatApp.DataTransfer;
using BlazorChatApp.Server.Persistence;
using BlazorChatApp.Server.Persistence.Models;
using BlazorChatApp.Server.Persistence.Repositories;
using Microsoft.AspNetCore.Cors;
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
    [EnableCors("_myAllowedOrigins")]
    public class ChatUserController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        [HttpGet("{id}")]
        
        public async Task<ActionResult<ChatUserDTO>> GetUser(int id)
        {
            var task = Task.Run(() => unitOfWork.ChatUserRepository.GetById(id));
            Console.WriteLine("The user is being retrieved");
            ChatUser user = await task;
            ChatUserDTO userDTO = new ChatUserDTO
            {
                Username = user.Username,
                Password = user.Password
            };
            Console.WriteLine("amazing");
            return Ok(userDTO);
        }
        //[HttpGet]
        //public async Task<ActionResult<ChatUser>> GetUserByName(string username){
        //    var task = Task.Run(() => unitOfWork.ChatUserRepository.GetUserByUsername(username));

        //    Console.WriteLine("The user is being retrieved");
        //    Console.WriteLine("amazing");
        //    ChatUser user = await task;

        //    return Ok(user);
        //}

        [HttpPost("login")]
        public async Task<ActionResult<ChatUser>> Login(ChatUser chatUser){
            
            return Ok(chatUser);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAccount(ChatUser user){
            var task = Task.Run(()=>unitOfWork.ChatUserRepository.Create(user));
            await task;
            return Ok("user ahas been created");
        }


    }
}
