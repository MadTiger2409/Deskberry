namespace Deskberry.Helpers
{
    public static class Session
    {
        public static int Id { get; set; }
        public static string Login { get; set; }

        public static void Clear()
        {
            Id = 0;
            Login = null;
        }

        public static void Set(int id, string login)
        {
            Id = id;
            Login = login;
        }
    }
}