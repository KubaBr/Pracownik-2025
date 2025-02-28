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

        public void NowaOcena(char pojOcena)
        {
            switch (pojOcena)
            {
                case 'A':
                case 'a':
                    this.Oceny.Add(100);
                    break;
                case 'B':
                case 'b':
                    this.Oceny.Add(80);
                    break;
                case 'C':
                    this.Oceny.Add(60);
                    break;
                case 'D':
                    this.Oceny.Add(40);
                    break;
                case 'E':
                    this.Oceny.Add(20);
                    break;
                default:
                    Console.WriteLine("Niepoprawna wartość");
                    break;
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
            statystyki.Srednia /= this.Oceny.Count;

            switch (statystyki.Srednia)
            {
                case var a when a >= 80:
                    statystyki.SredniaLitera = 'A';
                    break;
                case var a when a >= 60:
                    statystyki.SredniaLitera = 'B';
                    break;
                case var a when a >= 40:
                    statystyki.SredniaLitera = 'C';
                    break;
                case var a when a >= 20:
                    statystyki.SredniaLitera = 'D';
                    break;
                default:
                    statystyki.SredniaLitera = 'E';
                    break;

            }


            return statystyki;
        }

    }

}
