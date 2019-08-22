using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WebBlogs.Core.Commands;

namespace WebBlogs.Core.Models
{
    public class Author
    {
        public int Id { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public AuthorMembership AuthorMembership { get; protected set; }
        private readonly List<Blog> _blogs = new List<Blog>();
        public IReadOnlyCollection<Blog> Blogs => _blogs;

        public static Expression<Func<Author, bool>> GoldAndUp = x =>
            x.AuthorMembership == AuthorMembership.Gold || x.AuthorMembership == AuthorMembership.Platinum;
        

        protected Author()
        {
            AuthorMembership = AuthorMembership.Bronze;
        }

        public Author(CreateAuthorCommand cmd) : this()
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

        public void UpdateMembership(AuthorMembership membership)
        {
            // add validations.
            AuthorMembership = membership;
        }
    }

    public enum AuthorMembership
    {
        Bronze,
        Silver,
        Gold,
        Platinum
    }
}
