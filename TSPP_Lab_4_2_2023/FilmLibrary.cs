using System;

namespace TSPP_Lab_4_2_2023
{
    class FilmLibrary
    {
        private string name;
        private string last_name;
        private int year;
        private string studio;
        private DateTime time;
        public FilmLibrary() //Конструктор без параметрів
        { }

        //Конструктор з параметрами
        public FilmLibrary(string Str)
        {
            string[] row = Str.Split(new char[] { ';' });
            Name = row[0];
            Last_name = row[1];
            Year = row[2];
            Studio = row[3];
            Time = row[4];
        }
        //Методи:
        //Виведення бази в консоль
        static public void Print(FilmLibrary[] fbas, int n)
        {
            Console.WriteLine("  __________________________________________________________________________________________________________________________");
            Console.WriteLine(" |   №\t|  Назва фільму\t\t\t|  Прізвище режисера\t|  Рік виходу\t|    Кіностудія\t\t\t| Тривалість фільму |");
            Console.WriteLine(" |______|_______________________________|_______________________|_______________|_______________________|___________________|");
            if (fbas.Length > 1)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine(String.Format($" | {i+1,-4} |{fbas[i].Name, -30} |  {fbas[i].Last_name,-21}|  {fbas[i].Year, -13}|  {fbas[i].Studio, -21}|  {fbas[i].Time, -17}|"));
                }
                Console.WriteLine(" |______|_______________________________|_______________________|_______________|_______________________|___________________|");
            }
            else Console.WriteLine("Записи в базі відсутні");
        }
        //Додавання запису
        public FilmLibrary Inp ()
        {
            FilmLibrary inp = new FilmLibrary();
            Console.Write("Введіть Назву фільму: ");
            inp.Name = Console.ReadLine();
            Console.Write("Введіть прізвище режисера: ");
            inp.Last_name = Console.ReadLine();
            Console.Write("Введіть рік випуску картини: ");
            inp.Year = Console.ReadLine();
            Console.Write("Введіть назву студії: ");
            inp.Studio = Console.ReadLine();
            Console.Write("Введіть час тривалостіі фільму у форматі (ГГ:ХХ:СС): ");
            inp.Time = Console.ReadLine();
            return inp;
        }
        //Рeдагування полів запису з обранням потрібного
        public FilmLibrary Correct_Bas (FilmLibrary _inp)
        {
            FilmLibrary inp = new FilmLibrary();
            inp = _inp;
            int N;
            do
            {
                Console.WriteLine(" Оберіть поле, яке потребує коригування: ");
                Console.WriteLine(" Натисність 1 - для редагування назви фільму");
                Console.WriteLine(" Натисність 2 - для редагування прізвища кінорежисера");
                Console.WriteLine(" Натисність 3 - для редагування року випуску");
                Console.WriteLine(" Натисність 4 - для редагування студії");
                Console.WriteLine(" Натисність 5 - для для редагування тривалості картини");
                Console.WriteLine(" Натисність Enter - для закінчення редагуванн цього запису");
                string p = Console.ReadLine();
                if (p.Trim() != "") N = int.Parse(p);
                else N = 0;
                switch (N)
                {
                    case 1:
                        {
                            Console.Write("Введіть Назву фільму: ");
                            inp.Name = Console.ReadLine();
                        }
                        break;
                    case 2:
                        {
                            Console.Write("Введіть прізвище режисера: ");
                            inp.Last_name = Console.ReadLine();
                        }
                        break;
                    case 3:
                        {
                            Console.Write("Введіть рік випуску картини: ");
                            inp.Year = Console.ReadLine();
                        }
                        break;
                    case 4:
                        {
                            Console.Write("Введіть назву студії: ");
                            inp.Studio = Console.ReadLine();
                        }
                        break;
                    case 5:
                        {
                            Console.Write("Введіть час тривалості фільму у форматі (ГГ:ХХ:СС): ");
                            inp.Time = Console.ReadLine();
                        }
                        break;
                    default: Console.Write("Редагування запису закінчено"); break;
                }
            }
            while (N != 0);
         return (inp);
        }
        //Редагування запису цілком
        public FilmLibrary All_Corect(FilmLibrary _inp)
        {
            FilmLibrary inp = new FilmLibrary();
            Console.Write("Введіть Назву фільму: ");
            inp.Name = Console.ReadLine();
            Console.Write("Введіть прізвище режисера: ");
            inp.Last_name = Console.ReadLine();
            Console.Write("Введіть рік випуску картини: ");
            inp.Year = Console.ReadLine();
            Console.Write("Введіть назву студії: ");
            inp.Studio = Console.ReadLine();
            Console.Write("Введіть час тривалостіі фільму у форматі (ГГ:ХХ:СС): ");
            inp.Time = Console.ReadLine();
            return inp;
        }
        //Пошук по року випуску
        static public void Search (FilmLibrary[] fbas, int _year, int n)
        {
            Console.WriteLine("В рік заданий Вами випущено наступні картини:");
            Console.WriteLine("  ___________________________________________________________________________________________________________________");
            Console.WriteLine(" |  Назва фільму \t\t |  Прізвище режисера\t |  Рік виходу \t |   Кіностудія\t\t | Тривалість фільму |");
            Console.WriteLine(" |_______________________________|_______________________|_______________|_______________________|___________________|");
           for (int i = 0; i < n; i++)
            {
                if (fbas[i].year == _year)
                    Console.WriteLine(String.Format($" |{fbas[i].Name,-30} |  {fbas[i].Last_name,-21}|  {fbas[i].Year,-13}|  {fbas[i].Studio,-21}|  {fbas[i].Time,-17}|"));
            }
            Console.WriteLine(" |_______________________________|_______________________|_______________|_______________________|___________________|");
        }
        //Сортування по полю Name 
        static public void Sorting(FilmLibrary[] fbas, int n)
        {
            FilmLibrary temp = new FilmLibrary();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (string.Compare(fbas[i].name, fbas[j].name) < 0)
                    {
                        temp = fbas[i];
                        fbas[i] = fbas[j];
                        fbas[j] = temp;
                    }
                }
            }
        }
        //Сортування строк масиву з видаленням пустих
        public static int Sort (FilmLibrary[] fbas, int n)
        {
            int i;
            for (i = 0; i < n-1; i++)
            {
                if (fbas[i].Name == null && fbas[i + 1].Name != null)
                {
                    fbas[i] = fbas[i + 1];
                    fbas[i + 1] = new FilmLibrary();
                }
            }
            n = i;
            return n;
        }

        //Властивості
        public string Name
        {
            get { return name; }
            set {
                if (value.Trim() != "")
                    name = value.Trim();
                else throw new Exception("Не вдалось считати назву фільму!");
            }
        }
        public string Last_name
        {
            get { return last_name; }
            set
            {
                if (value.Trim() != "")
                    last_name = value.Trim();
                else throw new Exception ("Не вдалось считати прізвище автора!");
            }
        }
        public string Year
        {
            get {return year.ToString(); }
            set
            {
                if (value.Trim() != " " && Convert.ToInt32(value) > 0) year = Convert.ToInt32(value);
                else throw new Exception("Не вдалось считати рік випуску фільму чи рік задано не коректно!");
            }
        }
        public string Studio
        {
            get { return studio; }
            set
            {
                if (value.Trim() != " ")
                    studio = value.Trim();
                else throw new Exception("Не вдалось считати назву студії!");
            }
        }
        public string Time
        {
            get { return time.ToString("T"); }
            set
            {
                if (value.Trim() != "" && DateTime.TryParse(value, out time) && time != null)
                 DateTime.TryParse(value, out time);
                else throw new Exception("Не вдалось считати тривалість стрічки чи час некоректний!");
            }
        }
    }
}
