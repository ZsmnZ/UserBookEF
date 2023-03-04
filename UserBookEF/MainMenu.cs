using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserBookEF
{
   public class MainMenu
    {
        public void Menu(UserRepository reposUser, BookRepository reposBook, LinqMenu linqMenu)
        {
            Console.WriteLine("\n1.Меню пользователя\n2.Меню книги\n3.LinqMenu\n0.Назад");
            string key = Console.ReadLine();
            string[] keyArray = { "1", "2", "3", "0" };
            if (keyArray.Contains(key))
            {
                switch (key)
                {
                    case "1":
                        reposUser.MenuUser();
                        break;
                    case "2":
                        reposBook.MenuBook();
                        break;
                    case "3":
                        linqMenu.Menu();
                        break;
                }
            }
            else Console.WriteLine("Введите значение от 0 до 3");
        }
    }
}
