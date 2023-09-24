using BindyStreet.Application.DTOs.User.Request;
using BindyStreet.Application.DTOs.User.UserRequest;
using BindyStreet.Application.Features.UserFeatures.Commands.CreateUser;
using BindyStreet.Application.Features.UserFeatures.Commands.DeleteUser;
using BindyStreet.Application.Features.UserFeatures.Commands.UpdateUser;
using BindyStreet.Application.Features.UserFeatures.Queries.GetAllUsers;
using BindyStreet.Application.Features.UserFeatures.Queries.GetUserById;
using BindyStreet.Application.Validator;
using Microsoft.AspNetCore.Mvc;

namespace BindyStreet.API.Controllers.Controllers
{
    /// <summary>
    /// Endpoint for User 
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {

        /// <summary>
        /// This is the endpoint to create user record 
        /// </summary>
        /// <param name="createUserRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserRequest createUserRequest)
        {
            var userRequestValidator = new CreateUserRequestValidator();
            var result = userRequestValidator.Validate(createUserRequest);

            if (result.IsValid)
            {
                var request = new CreateUserCommand() { CreateUserRequest = createUserRequest };
                var userResult = await Mediator.Send(request);
                return Ok(userResult);
            }

            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            return BadRequest(errorMessages);
        }

        /// <summary>
        /// This is the endpoint to return users record
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await Mediator.Send(new GetAllUsersQuery());
            return Ok(result);

        }

        /// <summary>
        /// This is the endpoint to return user record by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            if (id == 0)
            {
                return BadRequest("Id cannot be zero");
            }
            else
            {
                var result = await Mediator.Send(new GetUserByIdQuery(id));
                return Ok(result);
            }
        }

        /// <summary>
        /// This is the endpoint to delete user record by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (id == 0)
            {
                return BadRequest("Id cannot be zero");
            }
            else
            {
                var result = await Mediator.Send(new DeleteUserCommand(id));
                return Ok(result);
            }
        }

        /// <summary>
        /// This is the endpoint to update user record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateUserRequest"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserRequest updateUserRequest)
        {
            if (id != updateUserRequest.Id)
            {
                return BadRequest();
            }

            var result = await Mediator.Send(new UpdateUserCommand() { UpdateUserRequest = updateUserRequest });
            return Ok(result);
        }

    }
}
