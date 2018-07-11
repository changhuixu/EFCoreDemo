using WebBlogs.Core.Commands;

namespace WebBlogs.Core.Models
{
    public class Blog
    {
        public int Id { get; protected set; }
        public string Title { get; protected set; }
        public string Content { get; protected set; }
        public int AuthorId { get; protected set; }
        public Author Author { get; protected set; }

        protected Blog() { }

        public Blog(CreateBlogCommand cmd)
        {
            Author = cmd.Author;
            Title = cmd.Title;
            Content = cmd.Content;
        }
    }
}
