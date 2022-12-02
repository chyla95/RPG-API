using System.ComponentModel.DataAnnotations;
using BC = BCrypt.Net.BCrypt;

namespace RPG.Domain.Model.General
{
#pragma warning disable CS8618
    public abstract class User : Entity
    {
        [Required]
        [MinLength(5), MaxLength(100)]
        public string Email { get; set; }
        [Required]
        [MinLength(5), MaxLength(100)]
        public string Password
        {
            get { return _password; }
            set { _password = EncryptPassword(value); }
        }
        private string _password;

        private static string EncryptPassword(string password)
        {
            string encryptedPassword = BC.HashPassword(password);
            return encryptedPassword;
        }
        public bool ComparePassword(string password)
        {
            bool doesPasswordMatch = BC.Verify(password, Password);
            return doesPasswordMatch;
        }
    }
#pragma warning restore CS8618
}
