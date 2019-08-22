using System;
using System.Linq.Expressions;
using WebBlogs.Core.Models;

namespace WebBlogs.Web.ViewModels
{
    public class AuthorViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public AuthorViewModel()
        {
        }
        public AuthorViewModel(Author author)
        {
            Id = author.Id;
            FirstName = author.FirstName;
            LastName = author.LastName;
        }

        public static Expression<Func<Author, AuthorViewModel>> Projection1
            => x => new AuthorViewModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName
            };
        public static Expression<Func<Author, AuthorViewModel>> Projection2
            => x => new AuthorViewModel(x);
    }
}
