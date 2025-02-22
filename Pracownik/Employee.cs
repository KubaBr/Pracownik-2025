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
            this.Oceny.Add(pojOcena);
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
            //statystyki.Srednia = statystyki.Srednia / this.Oceny.Count; // to samo co niżej
            statystyki.Srednia /=  this.Oceny.Count;

            return statystyki;
        }

    }

}
