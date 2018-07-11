namespace WebBlogs.Core.Commands
{
    public class WriteBlogCommand
    {
        public string Title { get; }
        public string Content { get; }
        public WriteBlogCommand(string title, string content)
        {
            // TODO:: Add Validations
            Title = title;
            Content = content;
        }
    }
}
