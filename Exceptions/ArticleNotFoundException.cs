namespace Frontend.Exceptions
{
    public class ArticleNotFoundException : Exception
    {
        public ArticleNotFoundException(string? message) : base(message)
        {
        }
    }
}
