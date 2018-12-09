using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHARP_LAB1
{
	class Program
	{

		static void Main(string[] args)
		{
			string UserName;
			string UserSurname;
			int UserAge;
			bool MultiVisa;
			bool PassValid2Years;
			bool PassValid3Month;
			bool PassValid2Pages;

			string[] Documents = new string[]
				{
					"Application",
					"Permission"
				};

			// Шапка
			//========================================================
			Console.WriteLine("====================================");
			Console.WriteLine("=    Горностаев Павел Андреевич    =");
			Console.WriteLine("=    Gornostaev Pavel Andreevich   =");
			Console.WriteLine("=    -B1-P4/4. СheckPhotoCode      =");
			Console.WriteLine("=    GROUP 03.12.2018              =");
			Console.WriteLine("====================================");
			Console.WriteLine("");
			//=========================================================

			Console.Write("Введите ваше имя >> ");
			UserName = Console.ReadLine();
			Console.Write("Введите вашу Фамилию >> ");
			UserSurname = Console.ReadLine();
			Console.Write("Введите ваш возраст >> ");
			Int32.TryParse(Console.ReadLine(), out UserAge);        //Получаем строку с возрастом и преобразуем её в число
			Console.WriteLine($"Привет, {UserName} {UserSurname}");
			Console.WriteLine($"Ваш возраст >> {UserAge}");
			MultiVisa = CheckMultiVisa();
			if(MultiVisa)
			{
				PassValid2Years = CheckPassport2Years();
			}
			else
			{
				PassValid3Month = CheckPassport3Month();
			}
			PassValid2Pages = CheckPassport2Pages();

			Console.ReadKey();


		}
		static bool CheckMultiVisa()
		{
			for (ConsoleKey Answer; ;)
			{
				Console.WriteLine("Хотите получить многократную визу? Y/N");
				Answer = Console.ReadKey(true).Key;
				if (Answer == ConsoleKey.Y)
				{
					Console.ForegroundColor = ConsoleColor.Green;            //Задаем цвет фона консоли.
					Console.WriteLine("Вы выбрали многократную визу");
					Console.ResetColor();
					return (true);
				}
				if (Answer == ConsoleKey.N)
				{
					Console.ForegroundColor = ConsoleColor.Green;            //Задаем цвет фона консоли.
					Console.WriteLine("Вы выбрали разовую визу");
					Console.ResetColor();
					return (false);
				}
				Console.WriteLine("Ошибочный ввод.");						//Если введен неверный символ
			}

		}
		static bool CheckPassport2Years()
		{
			for (ConsoleKey Answer; ;)
			{
				Console.WriteLine("Срок действия паспорта истекает раньше чем через 2 года? Y/N");
				Answer = Console.ReadKey(true).Key;
				if (Answer == ConsoleKey.Y)
				{
					Console.ForegroundColor = ConsoleColor.Green;            //Задаем цвет фона консоли.
					Console.WriteLine("Срок действия Ввашего паспора истекает раньше чем через 2 года");
					Console.ResetColor();
					return (true);
				}
				if (Answer == ConsoleKey.N)
				{
					Console.ForegroundColor = ConsoleColor.Green;            //Задаем цвет фона консоли.
					Console.WriteLine("Срок действия Вашего паспорта истекает позжечем через 2 года");
					Console.ResetColor();
					return (false);
				}
				Console.WriteLine("Ошибочный ввод.");						//Если введен неверный символ
			}

		}
		static bool CheckPassport3Month()
		{
			for (ConsoleKey Answer; ;)
			{
				Console.WriteLine("Срок действия Вашего паспорта больше срока действия визы на 3 месяца? Y/N");
				Answer = Console.ReadKey(true).Key;
				if (Answer == ConsoleKey.Y)
				{
					Console.ForegroundColor = ConsoleColor.Green;            //Задаем цвет фона консоли.
					Console.WriteLine("Срок действия Вашего паспора истекает раньше, чем через 3 месяца после истечения срока действия визы.");
					Console.ResetColor();
					return (true);
				}
				if (Answer == ConsoleKey.N)
				{
					Console.ForegroundColor = ConsoleColor.Green;            //Задаем цвет фона консоли.
					Console.WriteLine("Срок действия Вашего паспора истекает позже, чем через 3 месяца после истечения срока действия визы.");
					Console.ResetColor();
					return (false);
				}
				Console.WriteLine("Ошибочный ввод.");                       //Если введен неверный символ
			}

		}
		static bool CheckPassport2Pages()
		{
			for (ConsoleKey Answer; ;)
			{
				Console.WriteLine("В вашем паспорте свободно менее 2х страниц? Y/N");
				Answer = Console.ReadKey(true).Key;
				if (Answer == ConsoleKey.Y)
				{
					Console.ForegroundColor = ConsoleColor.Green;            //Задаем цвет фона консоли.
					Console.WriteLine("В Вашем паспорте свободно менее 2х страниц");
					Console.ResetColor();
					return (true);
				}
				if (Answer == ConsoleKey.N)
				{
					Console.ForegroundColor = ConsoleColor.Green;            //Задаем цвет фона консоли.
					Console.WriteLine("В Вашем паспорте свободно более 2х страниц");
					Console.ResetColor();
					return (false);
				}
				Console.WriteLine("Ошибочный ввод.");                       //Если введен неверный символ
			}

		}
	}
}
