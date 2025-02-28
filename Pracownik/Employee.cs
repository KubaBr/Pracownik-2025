using System.Reflection.Metadata;

namespace Pracownik
{
    public class Employee
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        private List<float> Oceny = new List<float>();



        public Employee(string imie, string nazwisko)
        {
            this.Imie = imie;
            this.Nazwisko = nazwisko;
        }

        public void NowaOcena(float pojOcena)
        {
            if (pojOcena >= 0 && pojOcena <= 100)
            {
                this.Oceny.Add(pojOcena);
            }
            else
            {
                Console.WriteLine("Błędna ocena");
            }
        }

        public void NowaOcena(double pojOcena)
        {
            if (pojOcena <= float.MaxValue)
            {
                float value = (float)pojOcena;
                this.NowaOcena(value);
            }
            else
            {
                Console.WriteLine("Liczba jest zbyt duża");
            }


        }

        public void NowaOcena(int pojOcena)
        {
            float value = (int)pojOcena;
            this.NowaOcena(value);
        }
        // dodać metodę NowaOcena long, 
        public void NowaOcena(string pojOcena)
        {
            if (float.TryParse(pojOcena, out float value))
            {
                this.NowaOcena(value);
            }
            else
            {
                Console.WriteLine("String nie jest zmiennoprzecinkowy.");
            }
        }

        public Statystyki GetStatystyki()
        {
            var statystyki = new Statystyki();
            statystyki.Srednia = 0;
            statystyki.Max = float.MinValue;
            statystyki.Min = float.MaxValue;
            //
            foreach (var ocenka in this.Oceny)
            {
                statystyki.Max = Math.Max(statystyki.Max, ocenka);
                statystyki.Min = Math.Min(statystyki.Min, ocenka);
                statystyki.Srednia += ocenka;

            }

            return statystyki;
        }

    }

}
