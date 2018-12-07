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
			string[] Documents = new string[]
                {
					"Application",
					"Permission"
				};
            Console.Write("Введите ваше имя >> ");
            UserName = Console.ReadLine();
            Console.Write("Введите вашу Фамилию >> ");
            UserSurname = Console.ReadLine();
			Console.Write("Введите ваш возраст >> ");
			Int32.TryParse(Console.ReadLine(), out UserAge);
			Console.WriteLine($"Привет, {UserName} {UserSurname}");
			Console.WriteLine($"Ваш возраст >> {UserAge}");

			Console.ReadKey();
        }
	}
}
