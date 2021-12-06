using BlazorChatApp.Server.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorChatApp.Server.Persistence.Repositories
{
    public class ChatRoomRepository : GenericRepository<ChatRoom>, IChatRoomRepository
    {
        public ChatRoomRepository(BlazorChatDbContext context) : base(context)
        {
        }

        public IEnumerable<ChatRoom> GetPrivateRooms()
        {
            return base.Get(room => room.IsPrivate == true);
        }

        public ChatRoom GetByRoomName(string roomName)
        {
            //get the room with the name passed in
            return dbset.Where(room => room.ChatRoomName.Equals(roomName)).FirstOrDefault();
        }

        public IEnumerable<ChatUser> GetRoomMembers(object id)
        {
            //return the users from the room
            return dbset.Find(id).ChatRoomUsers.Select(chatRoomUser => chatRoomUser.ChatUser);
        }

    }
}
