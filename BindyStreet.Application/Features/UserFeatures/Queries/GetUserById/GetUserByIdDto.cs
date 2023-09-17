using BindyStreet.Application.DTOs.User.UserRequest;

namespace BindyStreet.Application.Features.UserFeatures.Queries.GetUserById
{
    public class GetUserByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public AddressDto Address { get; set; }
        public CompanyDto Company { get; set; }
    }
}
