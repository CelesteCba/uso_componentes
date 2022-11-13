using System;

namespace mvc_project.Models.Login
{
    public class LoginViewModel
    {
        public string userName { get; set; }
        
        public bool isLogged { get; set; }

        public string message { get; set; }
    }
}
