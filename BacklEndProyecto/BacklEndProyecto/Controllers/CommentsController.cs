using BacklEndProyecto.Models;
using BacklEndProyecto.Services;
using Microsoft.AspNetCore.Mvc;

namespace BacklEndProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsService _commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            _commentsService = commentsService;
        }

        // GET: api/Comments
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Comments>>> GetAllComments()
        {
            var comments = await _commentsService.GetAllCommentsAsync();
            return Ok(comments);
        }

        // GET: api/Comments/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Comments>> GetCommentById(int id)
        {
            var comment = await _commentsService.GetCommentByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }

        // POST: api/Comments
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateComment([FromForm] int productId, string commentText, int userId, int commentType, DateTime commentDate, bool isDeleted)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Comments comment = new Comments
            {
                ProductId = productId,
                CommentText = commentText,
                UserId = userId,
                CommentType = commentType,
                CommentDate = commentDate,
                IsDeleted = isDeleted,
                Produts = null
            };

            await _commentsService.CreateCommentAsync(comment);
            return CreatedAtAction(nameof(GetCommentById), new { id = comment.CommentId }, comment);
        }

        // PUT: api/Comments/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateComment(int id, [FromForm] int productId, string commentText, int userId, int commentType, DateTime commentDate, bool isDeleted)
        {
            var existingComment = await _commentsService.GetCommentByIdAsync(id);
            if (existingComment == null)
            {
                return NotFound();
            }

            existingComment.ProductId = productId;
            existingComment.CommentText = commentText;
            existingComment.UserId = userId;
            existingComment.CommentType = commentType;
            existingComment.CommentDate = commentDate;
            existingComment.IsDeleted = isDeleted;

            await _commentsService.UpdateCommentAsync(existingComment);
            return NoContent();
        }

        // DELETE: api/Comments/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteComment(int id)
        {
            var comment = await _commentsService.GetCommentByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            await _commentsService.DeleteCommentAsync(id);
            return NoContent();
        }
    }

}
