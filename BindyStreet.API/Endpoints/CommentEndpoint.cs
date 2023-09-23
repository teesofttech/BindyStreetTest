using BindyStreet.Application.DTOs.Post.Request;
using BindyStreet.Application.DTOs.PostComment.Request;
using BindyStreet.Application.Features.PostCommentFeatures.Commands.CreatePostComment;
using BindyStreet.Application.Features.PostCommentFeatures.Commands.DeletePostComment;
using BindyStreet.Application.Features.PostCommentFeatures.Commands.UpdatePostComment;
using BindyStreet.Application.Features.PostCommentFeatures.Queries.GetAllComments;
using BindyStreet.Application.Features.PostCommentFeatures.Queries.GetAllCommentsByPostId;
using BindyStreet.Application.Features.PostCommentFeatures.Queries.GetCommentById;
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
    /// Comment Module
    /// </summary>
    public class CommentEndpoint : ICarterModule
    {
        private string CommentModule { get; set; } = "Comment Module";
        /// <summary>
        /// This is the endpoint to create comment record
        /// </summary>
        /// <param name="createPostRequest"></param>
        /// <param name="_mediator"></param>
        /// <returns></returns>
        public async Task<IResult> CreatePostComment(CreatePostCommentRequest createPostCommentRequest, IMediator _mediator)
        {
            var postCommentRequestValidator = new CreatePostCommentRequestValidator();
            var result = postCommentRequestValidator.Validate(createPostCommentRequest);

            if (result.IsValid)
            {
                var request = new CreatePostCommentCommand() { CreatePostCommentRequest = createPostCommentRequest };
                var postId = await _mediator.Send(request);
                return Results.Ok(postId);
            }

            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            return Results.BadRequest(errorMessages);
        }

        /// <summary>
        /// This is the endpoint to return comment record
        /// </summary>
        /// <param name="_mediator"></param>
        /// <returns></returns>
        public async Task<IResult> GetAllComments(IMediator _mediator)
        {
            var result = await _mediator.Send(new GetAllPostCommentQuery());
            return Results.Ok(result);

        }

        /// <summary>
        /// This is the endpoint to return comment record by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="_mediator"></param>
        /// <returns></returns>
        public async Task<IResult> GetPostComment(int id, IMediator _mediator)
        {
            if (id == 0)
            {
                return Results.BadRequest("Id cannot be zero");
            }
            else
            {
                var result = await _mediator.Send(new GetPostCommentByIdQuery(id));
                return Results.Ok(result);
            }
        }

        /// <summary>
        /// This is the endpoint to delete post comment record by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="_mediator"></param>
        /// <returns></returns>
        public async Task<IResult> DeletePostComment(int id, IMediator _mediator)
        {
            if (id == 0)
            {
                return Results.BadRequest("Id cannot be zero");
            }
            else
            {
                var result = await _mediator.Send(new DeletePostCommentCommand(id));
                return Results.Ok(result);
            }
        }

        /// <summary>
        /// This is the endpoint to update post comment record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatePostRequest"></param>
        /// <param name="_mediator"></param>
        /// <returns></returns>
        public async Task<IResult> UpdatePostComment(int id, UpdatePostCommentRequest updatePostCommentRequest, IMediator _mediator)
        {
            if (id != updatePostCommentRequest.Id)
            {
                return Results.BadRequest();
            }

            var result = await _mediator.Send(new UpdatePostCommentCommand() { UpdatePostCommentRequest = updatePostCommentRequest });
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
        /// Routes setup for Comment Module
        /// </summary>
        /// <param name="app"></param>
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("api/v1/comments", CreatePostComment);

            app.MapGet("api/v1/comments", GetAllComments);

            app.MapGet("api/v1/comments/{id}", GetPostComment);

            app.MapPut("api/v1/comments", UpdatePostComment);

            app.MapDelete("api/v1/comments/{id}", DeletePostComment);
        }
    }
}
