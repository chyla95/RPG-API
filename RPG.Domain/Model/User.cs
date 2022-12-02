using System.ComponentModel.DataAnnotations;
using BC = BCrypt.Net.BCrypt;

namespace RPG.Domain.Model
{
#pragma warning disable CS8618
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5), MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MinLength(5), MaxLength(50)]
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
