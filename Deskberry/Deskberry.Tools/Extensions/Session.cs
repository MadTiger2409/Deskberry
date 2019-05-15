namespace Deskberry.Tools.Extensions
{
    public static class Session
    {
        public static int Id { get; set; }
        public static string Login { get; set; }

        public static void Set(int id, string login)
        {
            Id = id;
            Login = login;
        }

        public static void Clear()
        {
            Id = 0;
            Login = null;
        }
    }
}
