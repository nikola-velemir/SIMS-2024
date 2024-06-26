using App.Back.Domain;
using App.Back.Service;
using System.Windows;
namespace App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var a = new IzvodjacService();
            for (int i = 0; i < 10; i++) {
                a.Create(GenerateRandomIzvodjac());
            }
        }
        private static Random random = new Random();

        private static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            char[] stringChars = new char[length];

            for (int i = 0; i < length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(stringChars);
        }

        private static string GenerateRandomJMBG()
        {
            const string digits = "0123456789";
            char[] jmbgChars = new char[13];

            for (int i = 0; i < 13; i++)
            {
                jmbgChars[i] = digits[random.Next(digits.Length)];
            }

            return new string(jmbgChars);
        }

        private static DateOnly GenerateRandomDate()
        {
            int year = random.Next(1950, 2010);
            int month = random.Next(1, 13);
            int day = random.Next(1, DateTime.DaysInMonth(year, month) + 1);
            return new DateOnly(year, month, day);
        }

        private static Polovi GenerateRandomPol()
        {
            Array values = Enum.GetValues(typeof(Polovi));
            return (Polovi)values.GetValue(random.Next(values.Length));
        }

        public static Izvodjac GenerateRandomIzvodjac()
        {
            int id = random.Next(1, 1000);
            string ime = GenerateRandomString(5);
            string prezime = GenerateRandomString(7);
            string jmbg = GenerateRandomJMBG();
            DateOnly datumRodjenja = GenerateRandomDate();
            Polovi pol = GenerateRandomPol();

            return new Izvodjac(id, ime, prezime, jmbg, datumRodjenja, pol);
        }
    }
}