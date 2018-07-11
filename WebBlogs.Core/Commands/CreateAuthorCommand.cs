namespace WebBlogs.Core.Commands
{
    public class CreateAuthorCommand
    {
        public string FirstName { get; }
        public string LastName { get; }

        public CreateAuthorCommand(string firstName, string lastName)
        {
            // TODO:: Add Validations
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
