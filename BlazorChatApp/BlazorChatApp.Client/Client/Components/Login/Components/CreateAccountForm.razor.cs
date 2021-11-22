using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorChatApp.Client.Components.General.Alert;
using Microsoft.AspNetCore.Components;

namespace BlazorChatApp.Client.Components.Login.Components
{
    public partial class CreateAccountForm
    {
        private string? username = "";
        private string? password = "";
        private string? confirmedPassword = "";
        private AlertModel createAccountFormAlert = new AlertModel();
        private bool validated = false;
        public bool isValidInput()
        {
            validated = true;
            if (!ConfirmPasswordMatches())
            {
                createAccountFormAlert.AlertMessage = "Passwords Don't Match";
                return false;
            }
            if (username.Length > 50)
            {
                createAccountFormAlert.AlertMessage = "Username can't be more than 50 characters long";
                return false;
            }
            return true;


        }
        private async void CreateAccount()
        {

            //if (isValidInput())
            //{
            //    try
            //    {
            //        ChatUserData chatUser = new ChatUserData(username, password);
            //        HttpResponseMessage response = await http.PostAsync("https://localhost:8001/api/ChatUsers", JsonContent.Create(chatUser));
            //    }
            //    catch (HttpRequestException e)
            //    {
            //        createAccountFormAlert.AlertMessage = e.Message;

            //    }
            //}
            //else
            //{
            //    createAccountFormAlert.AlertMessage = "Passwords Don't Match";
            //}
        }
        private bool ConfirmPasswordMatches()
        {
            return password.Equals(confirmedPassword);
        }
    }
}
