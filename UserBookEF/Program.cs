namespace UserBookEF
{
    class Program
    {
        public static void Main(string[] args)
        {
            var db = new AppContext();
            User user = new User();
            Book book = new Book();
            var _user = new UserRepository();
            var _book = new BookRepository();
            LinqMenu _linq = new LinqMenu();
            MainMenu menu = new MainMenu();
            while (true)
            {
                db.SaveChanges();
                Console.WriteLine("\n1.Работа с базой\n2.Выход");
                string key = Console.ReadLine();
                if (key == "2") break;
                if (key != "2" && key != "1") Console.WriteLine("Нажмите 1 или 2");
                switch (key)
                {
                    case "1":
                        menu.Menu(_user, _book, _linq);
                        break;
                }
            }
        }
    }
}