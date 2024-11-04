using Microsoft.AspNetCore.Mvc;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using Persistence;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly DataContext _context;

        public PostsController(DataContext context) => _context = context;

        // GET: api/Posts
        [HttpGet(Name = "GetPosts")]
        public ActionResult<List<Post>> Get()
        {
            var posts = _context.Posts.ToList();
            return Ok(posts);
        }

        // GET: api/Posts/{id}
        [HttpGet("{id}", Name = "GetById")]
        public ActionResult<Post> GetById(Guid id)
        {
            var post = _context.Posts.Find(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }
    }
}