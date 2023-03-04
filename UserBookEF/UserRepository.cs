using Microsoft.EntityFrameworkCore;

namespace UserBookEF
{
    public class UserRepository
    {
        AppContext db;
        User user;
        public UserRepository()
        {
            user = new User();
            db = new AppContext();
        }

        public void AddUser()
        {
            Console.WriteLine("Введите имя:");
            user.Name = Console.ReadLine();
            Console.WriteLine("Укажите электронную почту:");
            user.Email = Console.ReadLine();
            if (db.Users.Any(a => a.Name == user.Name && a.Email == user.Email))
            {
                Console.WriteLine("Пользователь с таким именем и почтой уже есть, введите другое имя или почту");
            }
            else
            {
                db.Add(user);
                Console.WriteLine($"Пользователь {user.Name} добавлен в БД");
                db.SaveChanges();
            }
        }

        public void UserDelete()
        {
            Console.Write("Пользователя(ей) с каким именем вы хотите удалить?\nВведите здесь => ");
            string name = Console.ReadLine();
            if (db.Users.Any(a => a.Name == name) == false)
            {
                Console.WriteLine("Некорректный ввод!");
            }
            else
            {
                var nameDelet = db.Users.Where(x => x.Name == name).ToList();
                db.RemoveRange(nameDelet);
                Console.WriteLine($"Пользователи с именем {name} удалены из БД");
                db.SaveChanges();
            }
        }
        public void ChangeNameId()
        {
            Console.WriteLine("Введите Id пользователя для изменения имени:");
            int userID = Convert.ToInt32(Console.ReadLine());
            var userRe = db.Users.FirstOrDefault(u => u.Id == userID);
            Console.WriteLine($"Введите новое имя для {userRe.Name}:");
            userRe.Name = Convert.ToString(Console.ReadLine());
            db.SaveChanges();
        }
        public void HandBook()
        {
            Console.WriteLine("Введите имя пользователя:");
            string nameUser = Console.ReadLine();
            var user = db.Users.FirstOrDefault(n => n.Name == nameUser);
            var book = user.Books.Where(b => b.Title != null).ToList();
            Console.WriteLine($"Книги на руках у пользователя {user.Name} :");
            foreach (Book b in book)
            {
                Console.WriteLine("______________________");
                Console.WriteLine($"{b.Title}");
            }
            Console.WriteLine("______________________");
        }
        public void MenuUser()
        {
            Console.WriteLine("Выберите действие:\n1.Добавить нового пользователя" +
                "\n2.Удалить пользователя" +
                "\n3.Изменить имя пользователя по Id" +
                "\n4.Книги на руках у пользователя" +
                "\n0.Назад");
            string key = Console.ReadLine();
            string[] keyArray = { "1", "2", "3", "4", "0" };
            if (keyArray.Contains(key))
            {
                switch (key)
                {
                    case "1"://Добавление объекта User
                        AddUser();
                        db.SaveChanges();
                        break;
                    case "2"://Удаление объекта User
                        UserDelete();
                        db.SaveChanges();
                        break;
                    case "3"://Изменение объекта User
                        ChangeNameId();
                        db.SaveChanges();
                        break;
                    case "4":
                        HandBook();//Книги на руках 
                        break;
                    case "0":
                        break;
                }
            }
            else
            {
                Console.WriteLine("Введите значение от 0 до 4");
            }
        }
    }
}
