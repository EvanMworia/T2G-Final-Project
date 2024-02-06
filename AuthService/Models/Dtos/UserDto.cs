using System.ComponentModel.DataAnnotations;

namespace AuthService.Models.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty; //might comment this out later

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;
        public string? Role { get; set; } = "Bidder";
    }
}
