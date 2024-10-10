using Microsoft.AspNetCore.Mvc;
using Persistence; 
using Domain; 
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly DataContext _context; 

        public PostsController(DataContext context) 
        {
            _context = context; 
        }

        [HttpGet("GetPosts")] 
        public ActionResult<List<Post>> Get() 
        {
            return this._context.Posts.ToList();
        }
    }
}
