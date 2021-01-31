using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EU
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 2. feladat
            StreamReader Olvas = new StreamReader("EUcsatlakozas.txt", Encoding.Default);
            List<Tagallam> csatlakozas = new List<Tagallam>();
            while (!Olvas.EndOfStream)
            {
                csatlakozas.Add(new Tagallam(Olvas.ReadLine()));
            }
            Olvas.Close();
            #endregion
            #region 3. feladat
            Console.WriteLine($"3. feladat: EU tagallamainak szama: {csatlakozas.Count} db");
            #endregion

            #region 4. feladat
            int csatlakozott = 0;
            for (int i = 0; i < csatlakozas.Count; i++)
            {
                if (csatlakozas[i].ev.Year == 2007)
                {
                    csatlakozott++;
                }
                else{}
            }
            Console.WriteLine($"4. feladat: 2007-ben {csatlakozott} orszag csatlakozott.");
            #endregion

            #region 5. feladat
            for (int i = 0; i < csatlakozas.Count; i++)
            {
                if (csatlakozas[i].orszag == "Magyarország")
                {
                    Console.WriteLine($"5. feladat: Magyarorszag csatlakozasanak datuma: {csatlakozas[i].ev.ToString("yyyy.MM.dd")}");
                }
            }
            #endregion

            #region 6. feladat
            int KeresettIndex = 0;
            bool majusE = false;
            for (int i = 0; i < csatlakozas.Count; i++)
            {
                if (csatlakozas[i].ev.Month == 05)
                {
                    KeresettIndex = i;
                    majusE = true;
                }
            }
            if (majusE == true)
            {
                Console.WriteLine("6. feladat: Majusban volt csatlakozas!");
            }
            else
            {
                Console.WriteLine("6. feladat: Majusban NEM volt csatlakozas!");
            }
            #endregion

            #region 7. feladat
            Tagallam legutolso = csatlakozas.OrderByDescending(a => a.ev).First();
            Console.WriteLine($"7. feladat: Legutoljara csatlakozott orszag: {legutolso.orszag}");
            #endregion

            #region 8. feladat
            Console.WriteLine("8. feladat: Statisztika");
            List<DateTime> evLista = new List<DateTime>();
            for (int i = 0; i < csatlakozas.Count; i++)
            {
                bool SzerepelE = false;
                for (int j = 0; j < evLista.Count; j++)
                {
                    if (csatlakozas[i].ev == evLista[j])
                    {
                        SzerepelE = true;
                    }
                }
                if (SzerepelE == false)
                {
                    evLista.Add(csatlakozas[i].ev);
                }
            }
            int[] evListaSeged = new int[evLista.Count];
            for (int i = 0; i < csatlakozas.Count; i++)
            {
                for (int j = 0; j < evLista.Count; j++)
                {
                    if (csatlakozas[i].ev == evLista[j])
                    {
                        evListaSeged[j]++;
                    }
                }
            }
            for (int i = 0; i < evListaSeged.Length; i++)
            {
                Console.WriteLine("\t" + evLista[i].Year + ": " + evListaSeged[i] + " orszag");
            }
            #endregion
            Console.ReadKey();
        }
    }
    class Tagallam
    {
        public string orszag;
        public DateTime ev;

        public Tagallam(string AdatSor)
        {
            string[] AdatSorElemek = AdatSor.Split(';');
            this.orszag = AdatSorElemek[0];
            this.ev = Convert.ToDateTime(AdatSorElemek[1]);
        }
    }
}
