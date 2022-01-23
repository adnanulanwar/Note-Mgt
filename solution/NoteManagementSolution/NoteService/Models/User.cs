using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteService.Models
{
    public class User
    {
        public User()
        {
                
        }

        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ErrorMessage { get; set; }
        public string Key { get; set; }

    }
}
