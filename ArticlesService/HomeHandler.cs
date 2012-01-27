namespace ArticlesService
{
    public class HomeHandler
    {
        public object Get()
        {
            return new HomeResource { Title = "CQRS Demo" };
        }
    }
}