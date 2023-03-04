namespace UserBookEF
{
    public class BookRepository
    {
        AppContext db;
        Book book;
        public BookRepository()
        {
            book = new Book();
            db = new AppContext();
        }
        public void AddBook()
        {
            Console.WriteLine("Введите название книги:");
            book.Title = Console.ReadLine();
            if (String.IsNullOrEmpty(book.Title))
            {
                Console.WriteLine("Имя не может быть пустым");
                throw new ArgumentNullException();
            }
            Console.WriteLine("Укажите год:");
            book.Year = Convert.ToInt32(Console.ReadLine());
            if (book.Year < 0)
            {
                throw new ArgumentNullException();
            }
            Console.WriteLine("Добавьте автора:");
            book.Author = Console.ReadLine();
            Console.WriteLine("Укажите жанр:");
            book.Genre = Console.ReadLine();

            db.Books.AddRange(book);
            Console.WriteLine($"Книга {book.Title} добавлена в БД");

            db.SaveChanges();
            Console.WriteLine("Нажмите ENTER");
            Console.ReadKey();
        }
        public void BookDelete()
        {
            Console.WriteLine("Введите название книги, которую надо удалить:\nВведите здесь=> ");
            string title = Console.ReadLine();
            if (db.Books.Any(a => a.Title == book.Title) == true)
            {
                var TitleDelete = db.Books.Where(u => u.Title == title).ToList();
                db.RemoveRange(TitleDelete);
                Console.WriteLine($"Книга {title} удалена из библиотеки!");
                db.SaveChanges();
                Console.WriteLine("Нажмите любую клавишу");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"Книги *| {title} |* нет в библиотеке!");
            }
        }
        public void ChangeYearId()
        {
            Console.WriteLine("Укажите Id книги:");
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                int idBook = result;
                var yaerRe = db.Books.FirstOrDefault(u => u.Id == idBook);
                Console.WriteLine($"Укажите новый год издания {yaerRe.Title}:");
                if (int.TryParse(Console.ReadLine(), out int year))
                {
                    yaerRe.Year = year;
                    Console.WriteLine("Изменения сохранены!");
                    db.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Ошибка ввода!");
                }
            }
            else
            {
                Console.WriteLine("Такого Id нет!");
            }

        }
        public void ExtraditionBook()
        {
            // поиск книги
            Console.WriteLine("Введите название книги:");
            string title = Console.ReadLine();
            if (db.Books.Any(t => t.Title == title) == true)
            {
                Book books = db.Books.FirstOrDefault(d => d.Title == title);
                // поиск пользователя
                Console.WriteLine("Введите имя пользователя:");
                string nameUser = Console.ReadLine();
                if (db.Users.Any(u => u.Name == nameUser) == true)
                {
                    User user = db.Users.FirstOrDefault(d => d.Name == nameUser);
                    // запись
                    user.Books.Add(new Book { Title = books.Title, Author = books.Author, Year = books.Year, Genre = books.Genre });
                    db.SaveChanges();
                    Console.WriteLine("_______________________");
                    foreach (Book b in user.Books)
                    {
                        Console.Write($"Книга *|{b.Title}|* у пользователя {user.Name}!");
                    }
                }
            }
        }
        public void MenuBook()
        {
            try
            {
                Console.WriteLine("Действия с книгой:\n1.Добавить книгу\n2.Удалить книгу\n3.Изменить год издания по Id книги\n4.Выдать книгу\n0.Назад");
                string key = Console.ReadLine();
                string[] keyArray = { "1", "2", "3", "4", "0" };
                if (keyArray.Contains(key))
                {
                    switch (key)
                    {
                        case "1":
                            AddBook();
                            db.SaveChanges();
                            break;
                        case "2":
                            BookDelete();
                            db.SaveChanges();
                            break;
                        case "3":
                            ChangeYearId();
                            db.SaveChanges();
                            break;
                        case "4":
                            ExtraditionBook();
                            db.SaveChanges();
                            break;
                        case "0":
                            break;
                    }
                }
                else Console.WriteLine("Введите значение от 0 до 4");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Warning! {e}");
            }
        }
    }
}
