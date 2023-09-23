using BindyStreet.Application.DTOs.Post.Request;
using BindyStreet.Application.Features.PostCommentFeatures.Queries.GetAllCommentsByPostId;
using BindyStreet.Application.Features.PostFeatures.Commands.CreatePost;
using BindyStreet.Application.Features.PostFeatures.Commands.DeletePost;
using BindyStreet.Application.Features.PostFeatures.Commands.UpdatePost;
using BindyStreet.Application.Features.PostFeatures.Queries.GetAllPosts;
using BindyStreet.Application.Features.PostFeatures.Queries.GetPostById;
using BindyStreet.Application.Validator;
using Carter;
using MediatR;

namespace BindyStreet.API.Endpoints
{
    /// <summary>
    /// Post Module
    /// </summary>
    public class PostEndpoint : ICarterModule
    {
        private string PostModule { get; set; } = "Post Module";
        /// <summary>
        /// This is the endpoint to create post record
        /// </summary>
        /// <param name="createPostRequest"></param>
        /// <param name="_mediator"></param>
        /// <returns></returns>
        public async Task<IResult> CreatePost(CreatePostRequest createPostRequest, IMediator _mediator)
        {
            var postRequestValidator = new CreatePostRequestValidator();
            var result = postRequestValidator.Validate(createPostRequest);

            if (result.IsValid)
            {
                var resuest = new CreatePostCommand() { CreatePostRequest = createPostRequest };
                var postId = await _mediator.Send(resuest);
                return Results.Ok(postId);
            }

            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            return Results.BadRequest(errorMessages);
        }

        /// <summary>
        /// This is the endpoint to return post record
        /// </summary>
        /// <param name="_mediator"></param>
        /// <returns></returns>
        public async Task<IResult> GetAllPosts(IMediator _mediator)
        {
            var result = await _mediator.Send(new GetAllPostsQuery());
            return Results.Ok(result);

        }

        /// <summary>
        /// This is the endpoint to return post record by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="_mediator"></param>
        /// <returns></returns>
        public async Task<IResult> GetPost(int id, IMediator _mediator)
        {
            if (id == 0)
            {
                return Results.BadRequest("Id cannot be zero");
            }
            else
            {
                var result = await _mediator.Send(new GetPostByIdQuery(id));
                return Results.Ok(result);
            }
        }

        /// <summary>
        /// This is the endpoint to delete post record by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="_mediator"></param>
        /// <returns></returns>
        public async Task<IResult> DeletePost(int id, IMediator _mediator)
        {
            if (id == 0)
            {
                return Results.BadRequest("Id cannot be zero");
            }
            else
            {
                var result = await _mediator.Send(new DeletePostCommand(id));
                return Results.Ok(result);
            }
        }

        /// <summary>
        /// This is the endpoint to update post record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatePostRequest"></param>
        /// <param name="_mediator"></param>
        /// <returns></returns>
        public async Task<IResult> UpdatePost(int id, UpdatePostRequest updatePostRequest, IMediator _mediator)
        {
            if (id != updatePostRequest.Id)
            {
                return Results.BadRequest();
            }

            var result = await _mediator.Send(new UpdatePostCommand() { UpdatePostRequest = updatePostRequest });
            return Results.Ok(result);
        }


        /// <summary>
        /// This is the endpoint to return all comments by post id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="_mediator"></param>
        /// <returns></returns>
        public async Task<IResult> GetAllPostComments(int id, IMediator _mediator)
        {
            if (id == 0)
            {
                return Results.BadRequest("Id cannot be zero");
            }
            else
            {
                var result = await _mediator.Send(new GetAllCommentsByPostIdQuery(id));
                return Results.Ok(result);
            }
        }


        /// <summary>
        /// Routes setup for Post Module
        /// </summary>
        /// <param name="app"></param>
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("api/v1/posts", CreatePost);

            app.MapGet("api/v1/posts", GetAllPosts);

            app.MapGet("api/v1/posts/{id}", GetPost);

            app.MapPut("api/v1/posts", UpdatePost);

            app.MapDelete("api/v1/posts/{id}", DeletePost);

            app.MapGet("api/v1/posts/{id}/comments", GetAllPostComments);

        }
    }
}
