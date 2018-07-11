using WebBlogs.Core.Models;

namespace WebBlogs.Web.ViewModels
{
    public class AuthorViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public AuthorViewModel(Author author)
        {
            Id = author.Id;
            FirstName = author.FirstName;
            LastName = author.LastName;
        }
    }
}
