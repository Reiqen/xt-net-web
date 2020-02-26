using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.GitHub.Reiqen.Task10_11.Entities
{
    public class User
    {
        public int user_id { get; set; }
        public int role_id { get; set; }
        public string role { get; set; }
        public string login { get; set; }
        public string password { get; set; }

        public override string ToString() => "Login: " + login + ". Role: " + role + ".";
    }
}