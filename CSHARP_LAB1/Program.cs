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
			bool MultiVisa = false;
			bool PassValid2Years = false;
			bool PassValid3Month = false;
			bool PassValid2Pages = false;
			bool RegEmbassy = false;			//Регистрация на прием в посольство
			bool FillForm = false;				//Анкета
			bool FormPhoto = false;             //Фото для анкеты
			bool FormPhotoGlued = false;        //Фотография вклеена?

			bool TripDurationShort = false;		//Продолжительность планируемой поездки
			bool HotelBooked = false;           //Отель забронирован

			bool ParrentsPermission = false;    //Разрешение от родителе

			bool VisaPhoto = false;             //Фотография для визы 
			bool VisaPhotoOld = false;			//Фото для визы старое
			bool VisaPhotoUsed = false;         //Фото раньше использовалось
			

			bool GoToEmbassy = true;
			bool InEmbassy = false;
			/*
			string[] Documents = new string[]
				{
					"Application",
					"Permission"
				};
			*/

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
			RegEmbassy = CheckRegistration();
			TripDurationShort = CheckTripDuration();
			if(!TripDurationShort)
			{
				HotelBooked = CheckHotel();
			}
			FillForm = CheckFillForm();
			if (FillForm)
			{
				FormPhoto = CheckFormPhoto();
				if (FormPhoto)
				{
					FormPhotoGlued = CheckFormPhotoGlued();
				}
				else
				{
					FormPhotoGlued = false;
				}
			}
			else
			{
				FormPhoto = CheckFormPhoto();
				FormPhotoGlued = false;
			}
			if(UserAge < 18)
			{
				ParrentsPermission = CheckPermission();
			}

			Console.WriteLine("==============================================");
			Console.WriteLine("=========== РЕЗУЛЬТАТЫ =======================");
			Console.WriteLine("==============================================");
			Console.WriteLine("Вам необходимо:");

			if(((MultiVisa && PassValid2Years) || (!MultiVisa && PassValid3Month)) && PassValid2Pages)
			{
				Console.WriteLine("--- Заменить паспорт");
				GoToEmbassy = false;
			}
			if(!RegEmbassy)
			{
				Console.WriteLine("--- Выполнить регистрацию на сайте посольства(записаться на прием)");
				GoToEmbassy = false;
			}
			if(!TripDurationShort)
			{
				if(!HotelBooked)
				{
					Console.WriteLine("--- Забронировать отель");
					GoToEmbassy = false;
				}
			}
			if(FillForm)
			{
				if(FormPhoto)
				{
					if(!FormPhotoGlued)
					{
						Console.WriteLine("--- Вклеить фото в анкету");
						GoToEmbassy = false;
					}
				}
				else
				{
					
					Console.WriteLine("--- Сделать фото для анкеты");
					Console.WriteLine("--- Вклеить фото в анкету");
					GoToEmbassy = false;
				}
			}
			else
			{
				Console.WriteLine("--- Заполнить анкету");
				GoToEmbassy = false;
				if (FormPhoto)
				{
					if (!FormPhotoGlued)
					{
						Console.WriteLine("--- Вклеить фото в анкету");
					}
				}
				else
				{
					Console.WriteLine("--- Сделать фото для анкеты");
					Console.WriteLine("--- Вклеить фото в анкету");
				}
			}
			if((!ParrentsPermission) && (UserAge < 18))
			{
				Console.WriteLine("--- Получить разрешение от родителей");
				GoToEmbassy = false;
			}

			if(GoToEmbassy)
			{
				Console.WriteLine("--- Пойти в посольство");
				Console.WriteLine("");
				Console.WriteLine("======================================================");
				Console.ReadKey();
				while(!InEmbassy)
				{
					InEmbassy = CheckInEmbassy();
				}
				VisaPhoto = CheckVisaPhoto();
				if(VisaPhoto)
				{
					VisaPhotoOld = CheckVisaPhotoOld();
					if (!VisaPhotoOld)
					{
						VisaPhotoUsed = CheckVisaPhotoUsed();
						if(!VisaPhotoUsed)
						{
							Console.WriteLine("Поздравляем!!! Считайте что виза уже у Вас в кармане(в паспорте)!!!");
						}
						else
						{
							Console.WriteLine("Вам необходимо пройти в фотокомнату. Считайте что виза уже у Вас в кармане(в паспорте)!!!");
						}
					}
					else
					{
						VisaPhotoUsed = false;
						Console.WriteLine("Вам необходимо пройти в фотокомнату. Считайте что виза уже у Вас в кармане(в паспорте)!!!");
					}
				}
				else
				{
					VisaPhotoOld = false;
					VisaPhotoUsed = false;
					Console.WriteLine("Вам необходимо пройти в фотокомнату. Считайте что виза уже у Вас в кармане(в паспорте)!!!");
				}
			}

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
				Console.WriteLine("Срок действия Вашего паспорта истекает раньше чем через 2 года? Y/N");
				Answer = Console.ReadKey(true).Key;
				if (Answer == ConsoleKey.Y)
				{
					Console.ForegroundColor = ConsoleColor.Green;            //Задаем цвет фона консоли.
					Console.WriteLine("Срок действия Вашего паспора истекает раньше чем через 2 года");
					Console.ResetColor();
					return (true);
				}
				if (Answer == ConsoleKey.N)
				{
					Console.ForegroundColor = ConsoleColor.Green;            //Задаем цвет фона консоли.
					Console.WriteLine("Срок действия Вашего паспорта истекает позже чем через 2 года");
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
		static bool CheckRegistration()
		{
			for (ConsoleKey Answer; ;)
			{
				Console.WriteLine("Вы регистрировались(записывались) на сайте посольства ? Y/N");
				Answer = Console.ReadKey(true).Key;
				if (Answer == ConsoleKey.Y)
				{
					Console.ForegroundColor = ConsoleColor.Green;            //Задаем цвет фона консоли.
					Console.WriteLine("Вы зарегистрированы на прием");
					Console.ResetColor();
					return (true);
				}
				if (Answer == ConsoleKey.N)
				{
					Console.ForegroundColor = ConsoleColor.Green;            //Задаем цвет фона консоли.
					Console.WriteLine("Вы не зарегистрированы на прием");
					Console.ResetColor();
					return (false);
				}
				Console.WriteLine("Ошибочный ввод.");                       //Если введен неверный символ

			}
		}
		static bool CheckFillForm()
		{
			for (ConsoleKey Answer; ;)
			{
				Console.WriteLine("Вы заполнили анкету ? Y/N");
				Answer = Console.ReadKey(true).Key;
				if (Answer == ConsoleKey.Y)
				{
					Console.ForegroundColor = ConsoleColor.Green;            //Задаем цвет фона консоли.
					Console.WriteLine("Вы заполнили анкету");
					Console.ResetColor();
					return (true);
				}
				if (Answer == ConsoleKey.N)
				{
					Console.ForegroundColor = ConsoleColor.Green;            //Задаем цвет фона консоли.
					Console.WriteLine("Вы не заполнили анкету");
					Console.ResetColor();
					return (false);
				}
				Console.WriteLine("Ошибочный ввод.");                       //Если введен неверный символ

			}
		}
		static bool CheckFormPhoto()
		{
			for (ConsoleKey Answer; ;)
			{
				Console.WriteLine("У Вас есть фото для анкеты ? Y/N");
				Answer = Console.ReadKey(true).Key;
				if (Answer == ConsoleKey.Y)
				{
					Console.ForegroundColor = ConsoleColor.Green;            //Задаем цвет фона консоли.
					Console.WriteLine("У Вас есть фотография для анкеты");
					Console.ResetColor();
					return (true);
				}
				if (Answer == ConsoleKey.N)
				{
					Console.ForegroundColor = ConsoleColor.Green;            //Задаем цвет фона консоли.
					Console.WriteLine("У Вас нет фотографии для анкеты");
					Console.ResetColor();
					return (false);
				}
				Console.WriteLine("Ошибочный ввод.");                       //Если введен неверный символ

			}
		}
		static bool CheckFormPhotoGlued()
		{
			for (ConsoleKey Answer; ;)
			{
				Console.WriteLine("Вы вклеили фотографию в анкету ? Y/N");
				Answer = Console.ReadKey(true).Key;
				if (Answer == ConsoleKey.Y)
				{
					Console.ForegroundColor = ConsoleColor.Green;            //Задаем цвет фона консоли.
					Console.WriteLine("Вы вклеили фото в анкету");
					Console.ResetColor();
					return (true);
				}
				if (Answer == ConsoleKey.N)
				{
					Console.ForegroundColor = ConsoleColor.Green;            //Задаем цвет фона консоли.
					Console.WriteLine("Вы не вклеили фото в анкету");
					Console.ResetColor();
					return (false);
				}
				Console.WriteLine("Ошибочный ввод.");                       //Если введен неверный символ

			}
		}

		static bool CheckPermission()
		{
			for (ConsoleKey Answer; ;)
			{
				Console.WriteLine("У Вас есть разрешение от родителей ? Y/N");
				Answer = Console.ReadKey(true).Key;
				if (Answer == ConsoleKey.Y)
				{
					Console.ForegroundColor = ConsoleColor.Green;            //Задаем цвет фона консоли.
					Console.WriteLine("У Вас есть разрешение от родителей");
					Console.ResetColor();
					return (true);
				}
				if (Answer == ConsoleKey.N)
				{
					Console.ForegroundColor = ConsoleColor.Green;            //Задаем цвет фона консоли.
					Console.WriteLine("У Вас нет разрешения от родителей");
					Console.ResetColor();
					return (false);
				}
				Console.WriteLine("Ошибочный ввод.");                       //Если введен неверный символ

			}
		}
		static bool CheckTripDuration()
		{
			for (ConsoleKey Answer; ;)
			{
				Console.WriteLine("Вы планируете поездку продолжительностью до 10 дней ? Y/N");
				Answer = Console.ReadKey(true).Key;
				if (Answer == ConsoleKey.Y)
				{
					Console.ForegroundColor = ConsoleColor.Green;            //Задаем цвет фона консоли.
					Console.WriteLine("Ваша поездка продлиться меньше 10 дней");
					Console.ResetColor();
					return (true);
				}
				if (Answer == ConsoleKey.N)
				{
					Console.ForegroundColor = ConsoleColor.Green;            //Задаем цвет фона консоли.
					Console.WriteLine("Ваша поездка продлиться больше 10 дней");
					Console.ResetColor();
					return (false);
				}
				Console.WriteLine("Ошибочный ввод.");                       //Если введен неверный символ

			}
		}
		static bool CheckHotel()
		{
			for (ConsoleKey Answer; ;)
			{
				Console.WriteLine("Вы забронировали отель ? Y/N");
				Answer = Console.ReadKey(true).Key;
				if (Answer == ConsoleKey.Y)
				{
					Console.ForegroundColor = ConsoleColor.Green;            //Задаем цвет фона консоли.
					Console.WriteLine("Какой вы молодец! Вы забронировали отель");
					Console.ResetColor();
					return (true);
				}
				if (Answer == ConsoleKey.N)
				{
					Console.ForegroundColor = ConsoleColor.Green;            //Задаем цвет фона консоли.
					Console.WriteLine("Вы не забронировали отель");
					Console.ResetColor();
					return (false);
				}
				Console.WriteLine("Ошибочный ввод.");                       //Если введен неверный символ

			}
		}
		static bool CheckInEmbassy()
		{
			for (ConsoleKey Answer; ;)
			{
				Console.WriteLine("Вы пришли в посольство ? Y/N");
				Answer = Console.ReadKey(true).Key;
				if (Answer == ConsoleKey.Y)
				{
					Console.ForegroundColor = ConsoleColor.Green;            //Задаем цвет фона консоли.
					Console.WriteLine("Какой Вы молодец! Вы Уже в посольстве");
					Console.ResetColor();
					return (true);
				}
				if (Answer == ConsoleKey.N)
				{
					Console.ForegroundColor = ConsoleColor.Green;            //Задаем цвет фона консоли.
					Console.WriteLine("Чего Вы ждете? Идите в посольство !!!");
					Console.ResetColor();
					return (false);
				}
				Console.WriteLine("Ошибочный ввод.");                       //Если введен неверный символ

			}
		}
		static bool CheckVisaPhoto()
		{
			for (ConsoleKey Answer; ;)
			{
				Console.WriteLine("У Вас есть фото для визы ? Y/N");
				Answer = Console.ReadKey(true).Key;
				if (Answer == ConsoleKey.Y)
				{
					Console.ForegroundColor = ConsoleColor.Green;            //Задаем цвет фона консоли.
					Console.WriteLine("Здорово! У Вас есть фотография для визы");
					Console.ResetColor();
					return (true);
				}
				if (Answer == ConsoleKey.N)
				{
					Console.ForegroundColor = ConsoleColor.Green;            //Задаем цвет фона консоли.
					Console.WriteLine("У Вас нет фотографии для визы.");
					Console.ResetColor();
					return (false);
				}
				Console.WriteLine("Ошибочный ввод.");                       //Если введен неверный символ

			}
		}
		static bool CheckVisaPhotoOld()
		{
			for (ConsoleKey Answer; ;)
			{
				Console.WriteLine("Ваше фото для визы старше 3 месяцев? Y/N");
				Answer = Console.ReadKey(true).Key;
				if (Answer == ConsoleKey.Y)
				{
					Console.ForegroundColor = ConsoleColor.Green;            //Задаем цвет фона консоли.
					Console.WriteLine("Ваша фотография старая...Для визы не пойдет");
					Console.ResetColor();
					return (true);
				}
				if (Answer == ConsoleKey.N)
				{
					Console.ForegroundColor = ConsoleColor.Green;            //Задаем цвет фона консоли.
					Console.WriteLine("Здорово. Ваше фото подходит!!!");
					Console.ResetColor();
					return (false);
				}
				Console.WriteLine("Ошибочный ввод.");                       //Если введен неверный символ

			}
		}
		static bool CheckVisaPhotoUsed()
		{
			for (ConsoleKey Answer; ;)
			{
				Console.WriteLine("Вы уже использовали где-нибудь фотографию для визы? ? Y/N");
				Answer = Console.ReadKey(true).Key;
				if (Answer == ConsoleKey.Y)
				{
					Console.ForegroundColor = ConsoleColor.Green;            //Задаем цвет фона консоли.
					Console.WriteLine("Ваша фотография уже использовалась. Она не подходит!!!");
					Console.ResetColor();
					return (true);
				}
				if (Answer == ConsoleKey.N)
				{
					Console.ForegroundColor = ConsoleColor.Green;            //Задаем цвет фона консоли.
					Console.WriteLine("Замечательно. Ваша фотография подходит.");
					Console.ResetColor();
					return (false);
				}
				Console.WriteLine("Ошибочный ввод.");                       //Если введен неверный символ

			}
		}
	}
}
