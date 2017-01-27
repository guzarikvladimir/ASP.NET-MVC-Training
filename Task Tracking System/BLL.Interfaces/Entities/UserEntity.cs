﻿using System;
using System.Collections.Generic;

namespace BLL.Interfaces.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public List<TaskEntity> Tasks { get; set; }
    }
}