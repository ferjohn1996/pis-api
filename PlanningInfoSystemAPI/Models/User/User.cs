﻿namespace PlanningInfoSystemAPI.Models.User
{
    public class UserTbl
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}
