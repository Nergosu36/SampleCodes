using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ConsoleApp1
{
    
    class Html
    {
        public string path;
        public bool safe=true;

        public Html(bool safe)
        {
            this.safe = safe;
            this.path = "01.html";
            string kod = "<!DOCTYPE html>\n\r<html>\n\r<head><style>th, td {border: 1px solid black;}</style>\n\r<title> 01 </title>\n\r </head>\n\r ";
            Console.Write(kod);
            if(safe)
                File.WriteAllText(path, kod);
        }
        public Html(int n, int m, List<string> tekst, List<string> tekst2, List<string> teksty, bool safe)
        {
            this.safe = safe;
            this.path = tekst[0] + ".html";
            string kod = "<!DOCTYPE html>\n\r<html>\n\r<head><style>th, td {border: 1px solid black;}</style>\n\r<title> 01 </title>\n\r </head>\n\r ";
            Console.Write(kod);
            if (safe)
                File.WriteAllText(path, kod);
            Naglowek(tekst);
            for (int i = 0; i < n; i++)
            {
                Wiersz();
                for (int j = 0; j < m; j++)
                    Kolumna(teksty[j]);
                ZWiersz();
            }
            Stopka(tekst2);
        }
        public Html(int n, int m, List<string> tekst, List<string> tekst2, List<int> liczby, bool safe)
        {
            this.safe = safe;
            this.path = tekst[0] + ".html";
            string kod = "<!DOCTYPE html>\n\r<html>\n\r<head><style>th, td {border: 1px solid black;}</style>\n\r<title> 01 </title>\n\r </head>\n\r ";
            Console.Write(kod);
            if (safe)
                File.WriteAllText(path, kod);
            Naglowek(tekst);
            for (int i = 0; i < n; i++)
            {
                Wiersz();
                for (int j = 0; j < m; j++)
                    Kolumna(liczby[j]);
                ZWiersz();
            }
            Stopka(tekst2);
        }
        public Html()
        {
            this.path = "01.html";
            string kod = "<!DOCTYPE html>\n\r<html>\n\r<head><style>th, td {border: 1px solid black;}</style>\n\r<title> 01 </title>\n\r </head>\n\r ";
            Console.Write(kod);
            if (safe)
                File.WriteAllText(path, kod);
        }
        public Html(int n, int m, List<string> tekst, List<string> tekst2, List<string> teksty)
        {
            this.path = tekst[0] + ".html";
            string kod = "<!DOCTYPE html>\n\r<html>\n\r<head><style>th, td {border: 1px solid black;}</style>\n\r<title> 01 </title>\n\r </head>\n\r ";
            Console.Write(kod);
            if (safe)
                File.WriteAllText(path, kod);
            Naglowek(tekst);
            for (int i = 0; i < n; i++)
            {
                Wiersz();
                for (int j = 0; j < m; j++)
                    Kolumna(teksty[j]);
                ZWiersz();
            }
            Stopka(tekst2);
        }
        public Html(int n, int m, List<string> tekst, List<string> tekst2, List<int> liczby)
        {
            this.path = tekst[0] + ".html";
            string kod = "<!DOCTYPE html>\n\r<html>\n\r<head><style>th, td {border: 1px solid black;}</style>\n\r<title> 01 </title>\n\r </head>\n\r ";
            Console.Write(kod);
            if (safe)
                File.WriteAllText(path, kod);
            Naglowek(tekst);
            for (int i = 0; i < n; i++)
            {
                Wiersz();
                for (int j = 0; j < m; j++)
                    Kolumna(liczby[j]);
                ZWiersz();
            }
            Stopka(tekst2);
        }
        public int Naglowek(string teksty)
        {
            string kod = "<table style=\"border:solid\">\n\r<thead>";
            var cols = teksty.Split(';');
            kod += "<tr>\n\r";
            foreach (var col in cols)
            {
                kod += "<td>" + col + "</td>";
            }
            kod += "</tr></thead>\n\r";
            Console.Write(kod);
            if (safe)
                File.AppendAllText(path, kod);
            return 0;
        }
        public int Naglowek(List<string> teksty)
        {
            string kod = "<table style=\"border:solid\">\n\r<thead><tr>";
            for (int i = 0; i < teksty.Count; i++)
                kod += "<td>" + teksty[i] + "</td>";
            kod +="</tr></thead>\n\r";
            Console.Write(kod);
            if (safe)
                File.AppendAllText(path, kod);
            return 0;
        }
        public int Wiersz()
        {
            string kod = "<tr>\n\r";
            Console.Write(kod);
            if (safe)
                File.AppendAllText(path, kod);
            return 0;
        }
        public int ZWiersz()
        {
            string kod = "</tr>\n\r";
            Console.Write(kod);
            if (safe)
                File.AppendAllText(path, kod);
            return 0;
        }
        public int Kolumna()
        {
            string kod = "<td></td>\n\r";
            Console.Write(kod);
            if (safe)
                File.AppendAllText(path, kod);
            return 0;
        }
        public int Kolumna(int n)
        {
            string kod = "<td>"+n+ "</td>\n\r";
            Console.Write(kod);
            if (safe)
                File.AppendAllText(path, kod);
            return 0;
        }
        public int Kolumna(string s)
        {
            string kod = "<td>" + s + "</td>\n\r";
            Console.Write(kod);
            if (safe)
                File.AppendAllText(path, kod);
            return 0;
        }
        public int Stopka(string teksty)
        {
            string kod = "<tfoot><tr>";
            var cols = teksty.Split(';');
            foreach (var col in cols)
            {
                kod += "<td>" + col + "</td>";
            }
            kod += "</tr></tfoot>\n\r</table>\n\r</html>\n\r\n\r";
            Console.Write(kod);
            if (safe)
                File.AppendAllText(path, kod);
            return 0;
        }
        public int Stopka(List<string> teksty)
        {
            string kod = "<tfoot><tr>";
            for (int i = 0; i < teksty.Count; i++)
                kod += "<td>" + teksty[i] + "</td>";
            kod +="</tr></tfoot>\n\r</table>\n\r</html>\n\r\n\r";
            Console.Write(kod);
            if (safe)
                File.AppendAllText(path, kod);
            return 0;
        }
       
    }
    class Program
    {
        public static void test1()
        {
            List<int> liczby = new List<int> { 1, 2, 3, 4 };
            List<string> teksty = new List<string>(new string[] { "jeden", "dwa", "trzy" });
            Html t1 = new Html(2, 2, teksty, teksty, liczby, false); //liczby
        }
        public static void test2()
        {

            List<string> teksty = new List<string>(new string[] { "jeden", "dwa", "trzy" });
            Html t2 = new Html();
            t2.Naglowek(teksty);
            t2.Wiersz();
            t2.Kolumna("Witam");
            t2.Kolumna("Zero");
            t2.Kolumna("Jeden");
            t2.ZWiersz();

            t2.Wiersz();
            t2.Kolumna("Dwa");
            t2.Kolumna("Trzy");
            t2.Kolumna("Cztery");
            t2.ZWiersz();

            t2.Stopka(teksty);
        }
        public static void test3()
        {
            List<string> tekst = new List<string>(new string[] { "jeden", "dwa", "trzy", "cztery", "piec", "szesc", "siedem", "osiem", "dziewiec", "dziesiec" });
            List<string> teksty = new List<string>(new string[] { "jeden", "dwa", "trzy" });
            Html t3 = new Html(2, 5, teksty, teksty, tekst, true);
        }
        public static void test4(string file)
        {
            Html t4 = new Html();

            var lines = File.ReadAllLines(file);
            int j = 0;
            foreach (var line in lines)
            {
                var cols = line.Split(';');
                int i = 0;
                foreach (var col in cols)
                {
                    i++;
                    j++;
                    if (j == 1)
                        t4.Naglowek(line);
                    else if (i == 1)
                        t4.Wiersz();
                    if (j > cols.Length && j <= ((lines.Length * cols.Length) - cols.Length))
                        t4.Kolumna(col);
                    else if (i % cols.Length == 0)
                        t4.ZWiersz();
                    if (j == (lines.Length * cols.Length))
                        t4.Stopka(line);
                }
            }
        }
        static void Main(string[] args)
        {
            test1();
            test2();
            test3();
            test4("Zeszyt1.csv");          

            Console.ReadLine();
        }
    }
}