using BindyStreet.Application.DTOs.Post.Request;
using BindyStreet.Application.Features.PostCommentFeatures.Queries.GetAllCommentsByPostId;
using BindyStreet.Application.Features.PostFeatures.Commands.CreatePost;
using BindyStreet.Application.Features.PostFeatures.Commands.DeletePost;
using BindyStreet.Application.Features.PostFeatures.Commands.UpdatePost;
using BindyStreet.Application.Features.PostFeatures.Queries.GetAllPosts;
using BindyStreet.Application.Features.PostFeatures.Queries.GetPostById;
using BindyStreet.Application.Validator;
using Microsoft.AspNetCore.Mvc;

namespace BindyStreet.API.Controllers.Controllers
{
    /// <summary>
    /// Endpoint for Posts
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PostsController : BaseController
    {
        /// <summary>
        /// This is the endpoint to create post record
        /// </summary>
        /// <param name="createPostRequest"></param>
        /// <param name="_mediator"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreatePost(CreatePostRequest createPostRequest)
        {
            var postRequestValidator = new CreatePostRequestValidator();
            var result = postRequestValidator.Validate(createPostRequest);

            if (result.IsValid)
            {
                var resuest = new CreatePostCommand() { CreatePostRequest = createPostRequest };
                var postId = await Mediator.Send(resuest);
                return Ok(postId);
            }

            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            return BadRequest(errorMessages);
        }

        /// <summary>
        /// This is the endpoint to return post record
        /// </summary>
        /// <param name="_mediator"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var result = await Mediator.Send(new GetAllPostsQuery());
            return Ok(result);

        }

        /// <summary>
        /// This is the endpoint to return post record by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="_mediator"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            if (id == 0)
            {
                return BadRequest("Id cannot be zero");
            }
            else
            {
                var result = await Mediator.Send(new GetPostByIdQuery(id));
                return Ok(result);
            }
        }

        /// <summary>
        /// This is the endpoint to delete post record by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="_mediator"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (id == 0)
            {
                return BadRequest("Id cannot be zero");
            }
            else
            {
                var result = await Mediator.Send(new DeletePostCommand(id));
                return Ok(result);
            }
        }

        /// <summary>
        /// This is the endpoint to update post record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatePostRequest"></param>
        /// <param name="_mediator"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdatePost(int id, UpdatePostRequest updatePostRequest)
        {
            if (id != updatePostRequest.Id)
            {
                return BadRequest();
            }

            var result = await Mediator.Send(new UpdatePostCommand() { UpdatePostRequest = updatePostRequest });
            return Ok(result);
        }


        /// <summary>
        /// This is the endpoint to return all comments by post id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="_mediator"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}/Comments")]
        public async Task<IActionResult> GetAllPostComments(int id)
        {
            if (id == 0)
            {
                return BadRequest("Id cannot be zero");
            }
            else
            {
                var result = await Mediator.Send(new GetAllCommentsByPostIdQuery(id));
                return Ok(result);
            }
        }

    }
}
