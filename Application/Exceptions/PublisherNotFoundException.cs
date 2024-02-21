namespace Application.Exceptions
{
    public class PublisherNotFoundException : ApplicationException
    {
        public PublisherNotFoundException(string name, object key) : base($"Entity {name} - {key} is not found.")
        {

        }
    }
}
