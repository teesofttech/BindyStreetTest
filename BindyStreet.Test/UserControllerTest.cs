using BindyStreet.Application.DTOs.User.UserRequest;
using BindyStreet.Test.Models;
using BindyStreet.Test.Responses;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Text;

namespace BindyStreet.Test
{
    public class UserControllerTest
    {
        [Fact]
        public async Task CreateUser_ValidRequest_ReturnsOkResult()
        {
            using var application = new WebApplicationFactory<Program>();
            var client = application.CreateClient();
            var createUserRequest = new CreateUserRequest
            {
                Name = "Test",
                Address = new AddressDto
                {
                    City = "Test",
                    Geo = new GeoDto
                    {
                        Lat = "2.344",
                        Lng = "4.56"
                    },
                    Street = "Test",
                    Suite = "Test",
                    ZipCode = "Test"
                },
                Company = new CompanyDto
                {
                    Bs = "Test",
                    CatchPhrase = "Test",
                    Name = "Test",
                },
                Email = "test@test.com",
                Phone = "Test",
                Username = "Test",
                Website = "test.com"
            };

            var content = new StringContent(JsonConvert.SerializeObject(createUserRequest), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/v1/users", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var userResult = JsonConvert.DeserializeObject<PostUserResponse>(responseContent);
            Assert.Equal("User Created.", userResult?.messages[0]);
        }


        [Fact]
        public async Task GetUser_ValidId_ReturnsOkResult()
        {
            using var application = new WebApplicationFactory<Program>();
            var client = application.CreateClient();
            int validUserId = 1;
            var response = await client.GetAsync($"/api/v1/users/{validUserId}");
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GetUserByIdResponse>(responseContent);
            Assert.True(result?.succeeded);
        }

        [Fact]
        public async Task GetUsers_ReturnsOkResult()
        {
            using var application = new WebApplicationFactory<Program>();
            var client = application.CreateClient();
            var response = await client.GetAsync($"/api/v1/users");
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GetUsersResponse>(responseContent);
            Assert.True(result?.succeeded);
            Assert.NotNull(result?.data);
        }

        [Fact]
        public async Task DeleteUser_Return_Not_Null()
        {
            using var application = new WebApplicationFactory<Program>();
            var client = application.CreateClient();
            int validUserId = 1;
            var response = await client.DeleteAsync($"/api/v1/users/{validUserId}");
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<DeleteUserResponse>(responseContent);
            Assert.NotNull(result?.data);
        }
    }
}