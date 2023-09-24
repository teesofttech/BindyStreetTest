using BindyStreet.Application.DTOs.PostComment.Request;
using BindyStreet.Application.Features.PostCommentFeatures.Commands.CreatePostComment;
using BindyStreet.Application.Features.PostCommentFeatures.Commands.DeletePostComment;
using BindyStreet.Application.Features.PostCommentFeatures.Commands.UpdatePostComment;
using BindyStreet.Application.Features.PostCommentFeatures.Queries.GetAllComments;
using BindyStreet.Application.Features.PostCommentFeatures.Queries.GetAllCommentsByPostId;
using BindyStreet.Application.Features.PostCommentFeatures.Queries.GetCommentById;
using BindyStreet.Application.Validator;
using Microsoft.AspNetCore.Mvc;

namespace BindyStreet.API.Controllers.Controllers
{
    /// <summary>
    /// Endpoint for Post Comment
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CommentController : BaseController
    {

        /// <summary>
        /// This is the endpoint to create comment record
        /// </summary>
        /// <param name="createPostCommentRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreatePostComment")]
        public async Task<IActionResult> CreatePostComment(CreatePostCommentRequest createPostCommentRequest)
        {
            var postCommentRequestValidator = new CreatePostCommentRequestValidator();
            var result = postCommentRequestValidator.Validate(createPostCommentRequest);

            if (result.IsValid)
            {
                var request = new CreatePostCommentCommand() { CreatePostCommentRequest = createPostCommentRequest };
                var postComment = await Mediator.Send(request);
                return Ok(postComment);
            }

            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            return BadRequest(errorMessages);
        }


        /// <summary>
        /// This is the endpoint to return comment record
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllComments")]
        public async Task<IActionResult> GetAllComments()
        {
            var result = await Mediator.Send(new GetAllPostCommentQuery());
            return Ok(result);
        }


        /// <summary>
        /// This is the endpoint to return comment record by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetPostComment/{id}")]
        public async Task<IActionResult> GetPostComment(int id)
        {
            if (id == 0)
            {
                return BadRequest("Id cannot be zero");
            }
            else
            {
                var result = await Mediator.Send(new GetPostCommentByIdQuery(id));
                return Ok(result);
            }
        }

        /// <summary>
        /// This is the endpoint to delete post comment record by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeletePostComment/{id}")]
        public async Task<IActionResult> DeletePostComment(int id)
        {
            if (id == 0)
            {
                return BadRequest("Id cannot be zero");
            }
            else
            {
                var result = await Mediator.Send(new DeletePostCommentCommand(id));
                return Ok(result);
            }
        }

        /// <summary>
        /// This is the endpoint to update post comment record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatePostRequest"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdatePostComment")]
        public async Task<IActionResult> UpdatePostComment(int id, UpdatePostCommentRequest updatePostCommentRequest)
        {
            if (id != updatePostCommentRequest.Id)
            {
                return BadRequest();
            }

            var result = await Mediator.Send(new UpdatePostCommentCommand()
            {
                UpdatePostCommentRequest = updatePostCommentRequest
            });
            return Ok(result);
        }


        /// <summary>
        /// This is the endpoint to return all comments by post id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllPostComments/{postId}")]
        public async Task<IActionResult> GetAllPostComments(int postId)
        {
            if (postId == 0)
            {
                return BadRequest("Id cannot be zero");
            }
            else
            {
                var result = await Mediator.Send(new GetAllCommentsByPostIdQuery(postId));
                return Ok(result);
            }
        }
    }
}
