namespace UserBookEF
{
    public class LinqMenu
    {
        public AppContext db;
        public LinqMenu()
        {
            db = new AppContext();  
        }
        
        public void Menu()
        {
            Console.WriteLine("\n1.Список книг по жанру и между годами\n2.Количество книг определенного автора\n3.Получить количество книг определенного жанра" +
                "\n4.Получить булевый флаг о том, есть ли книга у определенного автора и с определенным названием в библиотеке" +
                "\n5.Получать булевый флаг о том, есть ли определенная книга на руках у пользователя" +
                "\n6.Получать количество книг на руках у пользователя" +
                "\n7.Получение последней вышедшей книги." +
                "\n8.Получение списка всех книг, отсортированного в алфавитном порядке по названию" +
                "\n9.Получение списка всех книг, отсортированного в порядке убывания года их выхода");
            string key = Console.ReadLine();
            string[] keyArray = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            if (keyArray.Contains(key))
            {
                switch (key)
                {
                    case "1":
                        Console.WriteLine("Введите жанр:");
                        string genre = Console.ReadLine();
                        var bookList = db.Books.Where(u => u.Genre == genre).ToList();
                        Console.WriteLine("Укажите мин дату издания:");
                        int minYear = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Укажите последний год издания:");
                        int maxYear = Convert.ToInt32(Console.ReadLine());
                        var bookListM = bookList.Where(m => m.Year >= minYear && m.Year <= maxYear);
                        foreach (var book in bookListM)
                        {
                            Console.WriteLine($"{book.Title}\t {book.Year}");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Укажите автора:");
                        string author = Console.ReadLine();
                        int authorTop = db.Books.Where(a => a.Author == author).Count();
                        Console.WriteLine($"{authorTop}");
                        break;
                    case "3":
                        Console.WriteLine("Укажите жанр:");
                        string ganre = Console.ReadLine();
                        int ganreTop = db.Books.Where(a => a.Genre == ganre).Count();
                        Console.WriteLine($"{ganreTop}");
                        break;
                    case "4":
                        Console.WriteLine("Укажите автора:");
                        string _author = Console.ReadLine();
                        Console.WriteLine("Укажите книгу:");
                        string boolBook = Console.ReadLine();
                        var flag = db.Books.Where(a => a.Author == _author).ToList();
                        bool _flag = flag.Any(a => a.Title == boolBook);
                        Console.WriteLine($"{_flag}");
                        break;
                    case "5":
                        Console.WriteLine("Укажите имя пользователя:");
                        string userName = Console.ReadLine();
                        var user = db.Users.ToList().FirstOrDefault(a => a.Name == userName);
                        Console.WriteLine("Введите название книги:");
                        string _bookTitle = Console.ReadLine();
                        //bool b = user.Books.Any(u => u.Title == _bookTitle);
                        Console.WriteLine($"{user.Books.Any(u => u.Title == _bookTitle)}");
                        break;
                    case "6":
                        Console.WriteLine("Укажите имя пользователя:");
                        string _userName = Console.ReadLine();
                        var _user = db.Users.FirstOrDefault(a => a.Name == _userName);
                        int countBook = _user.Books.Count();
                        Console.WriteLine($"У пользоателя {_user.Name} на руках {countBook} книг");
                        break;
                    case "7":
                        int year = db.Books.Max(a => a.Year);
                        Console.WriteLine($"Последняя книга вышла {year}");
                        break;
                    case "8":
                        var sortBook = db.Books.ToList().OrderBy(a => a.Title);
                        foreach (Book bi in sortBook)
                        {
                            Console.WriteLine($"{bi.Title}\t{bi.Author}\t{bi.Genre}\t{bi.Year}");
                        }
                        break;
                    case "9":
                        var sortYear = db.Books.ToList().OrderByDescending(a => a.Year);
                        foreach (Book yr in sortYear)
                        {
                            Console.WriteLine($"{yr.Year}\t{yr.Title}\t{yr.Author}\t{yr.Genre}");
                        }
                        break;
                }
            }
            else
            {
                Console.WriteLine("Введите значение от 1 до 9");
            }
        }
    }
}
