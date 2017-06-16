namespace Coconut.Web
{
    public class AppSettings
    {
        public string Message { get; set; }
    }

    public class GlobalSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public Author Author { get; set; }
    }
    public class ConnectionStrings
    {
        public string Ef { get; set; }
    }

    public class Author
    {
        public string Name { get; set; }
        public string Job { get; set; }
    }

}