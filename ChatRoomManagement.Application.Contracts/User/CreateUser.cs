﻿using _01_framework.Application;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ChatRoomManagement.Application.Contracts.User
{
    public class CreateAccount
    {


        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string RePassword { get; set; }
       
    }

    public class EditAccount:CreateAccount
    {
        public int Id { get; set; }
    }

    public interface IUserApplication
    {
        OperationResult CreateAccount(CreateAccount command);
        OperationResult EditAccount(EditAccount command);
        bool SignIn(SignInViewModel signInViewModel);
        void LogOut();

    }

    public class SignInViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
