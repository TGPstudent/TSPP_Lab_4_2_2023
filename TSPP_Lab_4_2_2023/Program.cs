//TSPP_Lab_4_2_2023 Робота з базою данних через меню консолі
using System;
using System.Text;
using System.IO;

namespace TSPP_Lab_4_2_2023
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            string pathInpFile = ("E:\\BUK_UNIVER\\II_kurs(II sem)\\ТСПП\\Laboratorni\\Lab4\\TSPP_Lab_4_2_2023\\Basa.txt");
            if (!File.Exists(pathInpFile))
            {
                Console.WriteLine("Файл:\n" + pathInpFile + "\n не можливо відкрити! Перевірьте його існування.");
                return;
            }
            else
                Console.WriteLine("Файл: ...//Basa.txt успішно відкрито!");
            
            string Line;
            int n=0, i=0;
            n = File.ReadAllLines(pathInpFile).Length;
            FilmLibrary[] Fbas = new FilmLibrary[n];
            try
            {
                StreamReader file = new StreamReader(File.Open(pathInpFile, FileMode.Open));
                while ((Line = file.ReadLine()) != null)
                {
                 Fbas[i] = new FilmLibrary(Line);
                 ++i;
                }

                if(i == 0) Console.WriteLine("Файл: ...//Basa.txt порожній! Перевірьте та збережіть в ньому текст");
                n = i;
                file.Close();

            }
            catch (IndexOutOfRangeException)
            {
               Console.WriteLine("Дуже великий файл!");
               return;
            }
            catch (Exception e)
            {
                Console.WriteLine("Упс!: " + e.Message);
                return;
            }
            int N;
            do
            {
                Console.WriteLine("\n _________________МEНЮ:__________________________________");
                Console.WriteLine(" Натисність 1 - для додавання записів");
                Console.WriteLine(" Натисність 2 - для редагування обраних полів записів");
                Console.WriteLine(" Натисність 3 - для редагування запису");
                Console.WriteLine(" Натисність 4 - для знищення записів");
                Console.WriteLine(" Натисність 5 - для пошук фільмів за заданим роком випуску");
                Console.WriteLine(" Натисність 6 - для сортування списку за Назвою картини");
                Console.WriteLine(" Натисність 7 - Вивести базу на екран");
                Console.WriteLine(" Натисність Enter - для виходу з програми");
                Console.WriteLine(" __________________________________________________________");
                string sws = Console.ReadLine();
                if (sws.Trim() != "") N = int.Parse(sws);
                else N = 0;
                switch (N)
                {
                    case 1:
                        {//додавання записів
                            Console.WriteLine("Введіть інформацію про фільм для внесення його в базу:");
                            Array.Resize(ref Fbas, ++n);
                            FilmLibrary temp = new FilmLibrary();
                            Fbas[n-1] = temp.Inp();
                        }
                        break;
                    case 2:
                        {//редагування полів запису
                            string k;
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("База даних містить наступні записи:");
                                FilmLibrary.Print(Fbas, n);
                                Console.Write("\n Оберіть № запису, який потрібно відредагувати:");
                                int nl = Convert.ToInt32(Console.ReadLine());
                                FilmLibrary temp = new FilmLibrary();
                                Fbas[nl-1] = temp.Correct_Bas(Fbas[nl-1]);
                                Console.Clear();
                                Console.WriteLine("Скоригована база даних містить наступні записи:");
                                FilmLibrary.Print(Fbas, n);
                                Console.WriteLine("Бажаєте відредагувати ще? т-TAK? для закiнчення натисність ENTER");
                                k = Console.ReadLine();
                            }
                            while (k == "т");
                        }
                        break;

                    case 3:
                        {//Редагування запису цілком
                            string k;
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("База даних містить наступні записи:");
                                FilmLibrary.Print(Fbas,n);
                                Console.Write("\n Оберіть № запису, який потрібно відредагувати:");
                                int nl = Convert.ToInt32(Console.ReadLine());
                                FilmLibrary temp = new FilmLibrary();
                                Fbas[nl-1] = temp.All_Corect(Fbas[nl-1]);
                                Console.Clear();
                                Console.WriteLine("Скоригована база даних містить наступні записи:");
                                FilmLibrary.Print(Fbas, n);
                                Console.WriteLine("Бажаєте відредагувати ще? т-TAK? для закінчення натисність ENTER");
                                k = Console.ReadLine();
                            }
                            while (k == "т");
                        }
                        break;
                    case 4:
                        {//знищення записів
                            string k;
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("База даних містить наступні записи:");
                                FilmLibrary.Print(Fbas, n);
                                Console.Write("Оберіть № запису, який потрібно видалити:");
                                int nl = Convert.ToInt32(Console.ReadLine());
                                Fbas[nl-1] = new FilmLibrary();
                                n = FilmLibrary.Sort(Fbas,n);
                                Console.Clear();
                                Console.WriteLine("Оновлена база даних містить наступні записи:");
                                FilmLibrary.Print(Fbas, n);
                                Console.WriteLine("Бажаєте вилучити ще один запис? т-TAK? для закінчення натисність ENTER");
                                k = Console.ReadLine();
                            }
                            while (k == "т");
                            
                        }
                        break;
                    case 5:
                        {//пошук записів по полю year
                            Console.Clear();
                            Console.WriteLine("База даних містить наступні записи:");
                            FilmLibrary.Print(Fbas,n);
                            Console.Write("Введіть рік виходу фільму для пошуку: ");
                            int yaer = Convert.ToInt32(Console.ReadLine());
                            FilmLibrary.Search(Fbas, yaer, n);
                        }
                        break;

                    case 6:
                        {//сортування записів по полю name
                            Console.Clear();
                            FilmLibrary.Sorting(Fbas,n);
                            Console.WriteLine("База даних відсортована за алфавітом по полю назви фільму:");
                            FilmLibrary.Print(Fbas,n);
                        }
                        break;

                    case 7:
                        {//виведення на екран
                            Console.Clear();
                            FilmLibrary.Print(Fbas,n);
                        }
                        break;

                    default:
                        {//вихід з програми
                            Console.Clear();
                            Console.WriteLine("Зараз база даних має наступний вигляд:");
                            FilmLibrary.Print(Fbas,n);
                            Console.WriteLine("\n Ви бажаєте зберегти цю інформацію у файл? Натисніть т-(Так), для виходу натисніть ENTER");
                            string kay = Console.ReadLine(); ;
                            if (kay == "т")
                            {
                                StreamWriter f = new StreamWriter("E:\\BUK_UNIVER\\II_kurs(II sem)\\ТСПП\\Laboratorni\\Lab4\\TSPP_Lab_4_2_2023\\Basa.txt");
                                for (int j =0; j<n; j++)
                                {
                                    f.WriteLine(String.Format($"{Fbas[j].Name}; {Fbas[j].Last_name}; {Fbas[j].Year}; {Fbas[j].Studio}; {Fbas[j].Time}; \n"));
                                }
                                f.Close();
                                Console.WriteLine("Інформацію записано у файл:E:\\BUK_UNIVER\\II_kurs(II sem)\\ТСПП\\Laboratorni\\Lab4\\TSPP_Lab_4_2_2023\\Basa.txt ");
                            }
                        }
                        break;
                }
            }
            while (N != 0);
            Console.ReadLine();
        }
    }
}
