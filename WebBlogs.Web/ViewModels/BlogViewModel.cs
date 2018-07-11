using WebBlogs.Core.Models;

namespace WebBlogs.Web.ViewModels
{
    public class BlogViewModel
    {
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Content { get; set; }

        public BlogViewModel(Blog blog)
        {
            Title = blog.Title;
            AuthorName = blog.Author.FirstName + " " + blog.Author.LastName;
            Content = blog.Content;
        }
    }
}
