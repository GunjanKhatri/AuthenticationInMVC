using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthenticationInMVC.Models
{
    public static class Repository
    {
        static List<UserModel> users = new List<UserModel>() {

            new UserModel() {Email="abc@gmail.com",Roles="Admin,Editor",Password="abcadmin" },
            new UserModel() {Email="xyz@gmail.com",Roles="Editor",Password="xyzeditor" }
        };

        public static UserModel GetUserDetails(UserModel user)
        {
            return users.Where(u => u.Email.ToLower() == user.Email.ToLower() &&
            u.Password == user.Password).FirstOrDefault();
        }
    }
}