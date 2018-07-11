using System.Collections.Generic;
using WebBlogs.Core.Commands;

namespace WebBlogs.Core.Models
{
    public class Author
    {
        public int Id { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        private readonly List<Blog> _blogs = new List<Blog>();
        public IReadOnlyCollection<Blog> Blogs => _blogs;

        protected Author() { }

        public Author(CreateAuthorCommand cmd)
        {
            FirstName = cmd.FirstName;
            LastName = cmd.LastName;
        }

        public Blog WriteBlog(WriteBlogCommand cmd)
        {
            var blog = new Blog(new CreateBlogCommand(this, cmd.Title, cmd.Content));
            _blogs.Add(blog);
            return blog;
        }

        public void DeleteBlog(Blog blog)
        {
            _blogs.Remove(blog);
        }
    }
}
