using WebBlogs.Core.Models;

namespace WebBlogs.Core.Commands
{
    public class CreateBlogCommand
    {
        public Author Author { get; }
        public string Title { get; }
        public string Content { get; }

        public CreateBlogCommand(Author author, string title, string content)
        {
            // TODO:: Add validations
            Author = author;
            Title = title;
            Content = content;
        }
    }
}
