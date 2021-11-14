using System.ComponentModel.DataAnnotations;

namespace WebAppAssignmentDATABASE_5.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ReturnUrl { get; set; }

        public bool RememberLogin { get; set; }

        public LoginViewModel()
        {

        }
        public LoginViewModel(string password, string username)
        {
            this.UserName = username;
            this.Password = password;
        }
    }
}