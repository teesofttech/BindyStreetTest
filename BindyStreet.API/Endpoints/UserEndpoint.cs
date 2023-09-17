using BindyStreet.Application.DTOs.User.Request;
using BindyStreet.Application.DTOs.User.UserRequest;
using BindyStreet.Application.Features.UserFeatures.Commands.CreateUser;
using BindyStreet.Application.Features.UserFeatures.Commands.DeleteUser;
using BindyStreet.Application.Features.UserFeatures.Commands.UpdateUser;
using BindyStreet.Application.Features.UserFeatures.Queries.GetAllUsers;
using BindyStreet.Application.Features.UserFeatures.Queries.GetUserById;
using BindyStreet.Application.Validator;
using Carter;
using MediatR;

namespace BindyStreet.API.Endpoints
{
    /// <summary>
    /// User Module
    /// </summary>
    public class UserEndpoint : ICarterModule
    {
        private string UserModule { get; set; } = "User Module";

        /// <summary>
        /// This is the endpoint to create user record 
        /// </summary>
        /// <param name="createUserRequest"></param>
        /// <param name="_sender"></param>
        /// <returns></returns>
        public async Task<IResult> CreateUser(CreateUserRequest createUserRequest, IMediator _mediator)
        {
            var userRequestValidator = new CreateUserRequestValidator();
            var result = userRequestValidator.Validate(createUserRequest);

            if (result.IsValid)
            {
                var resuest = new CreateUserCommand() { CreateUserRequest = createUserRequest };
                var userId = await _mediator.Send(resuest);
                return Results.Ok(userId);
            }

            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            return Results.BadRequest(errorMessages);
        }

        /// <summary>
        /// This is the endpoint to return users record
        /// </summary>
        /// <param name="_mediator"></param>
        /// <returns></returns>
        public async Task<IResult> GetAllUsers(IMediator _mediator)
        {
            var result = await _mediator.Send(new GetAllUsersQuery());
            return Results.Ok(result);

        }

        /// <summary>
        /// This is the endpoint to return user record by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="_mediator"></param>
        /// <returns></returns>
        public async Task<IResult> GetUser(int id, IMediator _mediator)
        {
            if (id == 0)
            {
                return Results.BadRequest("Id cannot be zero");
            }
            else
            {
                var result = await _mediator.Send(new GetUserByIdQuery(id));
                return Results.Ok(result);
            }
        }

        /// <summary>
        /// This is the endpoint to delete user record by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="_mediator"></param>
        /// <returns></returns>
        public async Task<IResult> DeleteUser(int id, IMediator _mediator)
        {
            if (id == 0)
            {
                return Results.BadRequest("Id cannot be zero");
            }
            else
            {
                var result = await _mediator.Send(new DeleteUserCommand(id));
                return Results.Ok(result);
            }
        }

        /// <summary>
        /// This is the endpoint to update user record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateUserRequest"></param>
        /// <param name="_mediator"></param>
        /// <returns></returns>
        public async Task<IResult> UpdateUser(int id, UpdateUserRequest updateUserRequest, IMediator _mediator)
        {
            if (id != updateUserRequest.Id)
            {
                return Results.BadRequest();
            }

            var result = await _mediator.Send(new UpdateUserCommand() { UpdateUserRequest = updateUserRequest });
            return Results.Ok(result);
        }

        /// <summary>
        /// Routes setup for User Module
        /// </summary>
        /// <param name="app"></param>
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("api/v1/user", CreateUser);

            app.MapGet("api/v1/users", GetAllUsers);

            app.MapGet("api/v1/users/{id}", GetUser);

            app.MapPut("api/v1/users", UpdateUser);

            app.MapDelete("api/v1/users/{id}", DeleteUser);

        }
    }
}
