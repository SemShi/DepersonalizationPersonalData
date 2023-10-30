﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepersonalizationPersonalData.Models.Helpers
{
    public class UserInfo
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public List<UserPermission> Permissions { get; set; }
        public UserInfo(User user, List<UserPermission> permission)
        {
            Login = user.Login;
            Name = $"{user.FirstName} {user.LastName}";
            Permissions = permission;
        }
    }
}
