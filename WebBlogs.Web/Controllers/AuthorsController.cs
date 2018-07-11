using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBlogs.Core.Commands;
using WebBlogs.Core.DbContext;
using WebBlogs.Core.Models;
using WebBlogs.Web.Requests;
using WebBlogs.Web.ViewModels;

namespace WebBlogs.Web.Controllers
{
    [Route("api/[controller]")]
    public class AuthorsController : Controller
    {
        private readonly WebBlogsDbContext _dbContext;

        public AuthorsController(WebBlogsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet, Route(""), ProducesResponseType(typeof(IEnumerable<AuthorViewModel>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<AuthorViewModel>> GetAuthors()
        {
            return await _dbContext.Authors.Select(x => new AuthorViewModel(x)).ToListAsync();
        }

        [HttpGet, Route("{id:int}"), ProducesResponseType(typeof(AuthorViewModel), StatusCodes.Status200OK)]
        public async Task<AuthorViewModel> GetAuthor(int id)
        {
            var author = await _dbContext.Authors.FindAsync(id);
            return author == null ? null : new AuthorViewModel(author);
        }

        [HttpPost, Route(""), ProducesResponseType(typeof(AuthorViewModel), StatusCodes.Status200OK)]
        public async Task<AuthorViewModel> CreateNewAuthor([FromBody]CreateAuthorRequest request)
        {
            var cmd = new CreateAuthorCommand(request.FirstName, request.LastName);
            var author = new Author(cmd);
            await _dbContext.Authors.AddAsync(author);
            await _dbContext.SaveChangesAsync();
            return new AuthorViewModel(author);
        }

        private static void EnsureAuthorExists(Author author)
        {
            if (author == null)
            {
                throw new Exception("Author Not Found.");    // TODO: handle in your application.
            }
        }

        [HttpGet, Route("{id:int}/blogs"), ProducesResponseType(typeof(IEnumerable<BlogViewModel>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<BlogViewModel>> GetAuthorsBlogs(int id)
        {
            var author = await _dbContext.Authors.Include(x => x.Blogs).FirstOrDefaultAsync(x => x.Id == id);
            EnsureAuthorExists(author);
            return author.Blogs.Select(b => new BlogViewModel(b));
        }

        [HttpPost, Route("{id:int}/blogs"), ProducesResponseType(typeof(BlogViewModel), StatusCodes.Status200OK)]
        public async Task<BlogViewModel> WriteABlog(int id, [FromBody]CreateBlogRequest request)
        {
            var author = await _dbContext.Authors.FindAsync(id);
            EnsureAuthorExists(author);
            var cmd = new WriteBlogCommand(request.Title, request.Content);
            var blog = author.WriteBlog(cmd);
            await _dbContext.SaveChangesAsync();
            return new BlogViewModel(blog);
        }

        [HttpDelete, Route("{id:int}/blogs/{blogId:int}"), ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<bool> DeleteABlog(int id, int blogId)
        {
            var author = await _dbContext.Authors.Include(x => x.Blogs).FirstOrDefaultAsync(x => x.Id == id);
            EnsureAuthorExists(author);
            var blog = author.Blogs.FirstOrDefault(b => b.Id == blogId);
            if (blog == null)
            {
                throw new Exception("Blog Not Found");  // TODO:: Handle in your application
            }
            author.DeleteBlog(blog);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}

