using BindyStreet.Application.DTOs.User.UserRequest;
using BindyStreet.Application.Features.UserFeatures.Commands.CreateUser;
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
        /// Endpoint to create user 
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
        /// Get All Users
        /// </summary>
        /// <param name="_mediator"></param>
        /// <returns></returns>
        public async Task<IResult> GetAllUsers(IMediator _mediator)
        {
            var result = await _mediator.Send(new GetAllUsersQuery());
            return Results.Ok(result);

        }

        /// <summary>
        /// Endpoint to fetch user by id
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

        ///// <summary>
        ///// This endpoint for deleting bedroom
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="houseService"></param>
        ///// <returns></returns>
        //public async Task<Results<Ok<MyHttpResponse<bool>>, NotFound<string>>> DeleteBedroom(int id, IBedroomService bedroomService)
        //{
        //    if (id == 0)
        //    {
        //        return TypedResults.NotFound("Id cannot be zero");
        //    }
        //    else
        //    {
        //        var result = await bedroomService.DeleteBedroom(id);
        //        if (result.data)
        //            return TypedResults.Ok(result);
        //        else
        //            return TypedResults.NotFound("No data found");
        //    }
        //}

        ///// <summary>
        ///// This endpoint is for updating bedroom
        ///// </summary>
        ///// <param name="houseDto"></param>
        ///// <param name="houseService"></param>
        ///// <returns></returns>
        //public async Task<Results<Ok<MyHttpResponse<BedroomDto>>, NotFound<string>>> UpdateBedroom(BedroomDto bedroomDto, IBedroomService bedroomService)
        //{
        //    if (bedroomDto == null)
        //    {
        //        return TypedResults.NotFound("Bedroom Properties cannot be null");
        //    }
        //    else
        //    {
        //        var result = await bedroomService.UpdateBedroom(bedroomDto);
        //        return TypedResults.Ok(result);
        //    }
        //}

        /// <summary>
        /// Routes setup for House Module
        /// </summary>
        /// <param name="app"></param>
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("api/v1/user", CreateUser);

            app.MapGet("api/v1/users", GetAllUsers);

            app.MapGet("api/v1/users/{id}", GetUser);

            //group.MapPut("", UpdateBedroom);

            //group.MapDelete("{id}", DeleteBedroom);

        }
    }
}
