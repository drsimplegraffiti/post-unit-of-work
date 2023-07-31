using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PosterunitOfwork.Core.IRepositories.IConfiguration;
using PosterunitOfwork.Models;

namespace PosterunitOfwork.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
          private readonly IUnitOfWork _unitOfWork;

        public PostsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _unitOfWork.Posts.GetAll();
            return Ok(posts);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var post = await _unitOfWork.Posts.GetById(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Post post)
        {
            if (post == null)
            {
                return BadRequest();
            }

            await _unitOfWork.Posts.Add(post);
            await _unitOfWork.CompleteAsync(); // Assuming this method saves changes to the database

            return CreatedAtAction(nameof(GetById), new { id = post.Id }, post);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Post updatedPost)
        {
            if (updatedPost == null || id != updatedPost.Id)
            {
                return BadRequest();
            }

            var existingPost = await _unitOfWork.Posts.GetById(id);
            if (existingPost == null)
            {
                return NotFound();
            }

            existingPost.Title = updatedPost.Title;

            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var post = await _unitOfWork.Posts.GetById(id);
            if (post == null)
            {
                return NotFound();
            }

            _unitOfWork.Posts.Delete(id);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}