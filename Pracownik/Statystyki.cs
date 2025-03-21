
namespace Pracownik
{
    public class Statystyki
    {
        public float Min { get; private set; }
        public float Max { get; private set; }
        public int Licznik { get; private set; }

        public float Suma { get; private set; }
        public float Srednia
        {
            get
            {
                return this.Suma / this.Licznik;
            }

        }
        public char SredniaLitera
        {
            get
            {
                switch (this.Srednia)
                {
                    case var srednia when srednia >= 80:
                        return 'A';
                    case var srednia when srednia >= 60:
                        return 'B';
                    case var srednia when srednia >= 40:
                        return 'C';
                    case var srednia when srednia >= 20:
                        return 'D';
                    default:
                        return 'E';
                }
            }

        }

        public Statystyki()
        {
            this.Licznik = 0;
            this.Suma = 0;
            this.Max = float.MinValue;
            this.Min = float.MaxValue;
        }

        public void DodajOcene(float pojOcena)
        {
            this.Licznik++;
            this.Suma += pojOcena;
            this.Min = Math.Min(pojOcena, this.Min);
            this.Max = Math.Max(pojOcena, this.Max);

        }
        public void DodajOcene(string pojOcena)
        {
            if (float.TryParse(pojOcena, out float value))
            {
                DodajOcene(value);
            }
            else
            {
                throw new Exception("String nie jest zmiennoprzecinkowy.");
                //Console.WriteLine("String nie jest zmiennoprzecinkowy.");
            }
        }
    }
}




