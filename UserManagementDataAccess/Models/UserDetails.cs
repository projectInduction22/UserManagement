﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagementDataAccess.Models
{
   public class UserDetails
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int ID { get; set; }
        public string UserName { get; set; }
        public int Password { get; set; }
    }
}
