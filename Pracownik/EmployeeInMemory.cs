namespace Pracownik
{
    public class EmployeeInMemory : EmployeeBase
    {
        public override event DodanoNowaOceneDel DodanoNowaOcene;

        private List<float> Oceny = new List<float>();

        public EmployeeInMemory(string imie, string nazwisko)
            :base (imie, nazwisko)
        {

        }


        public override Statystyki GetStatystyki()
        {
            var statystyki = new Statystyki();

            foreach(var ocena in this.Oceny)
            {
                statystyki.DodajOcene(ocena);
            }

            return statystyki;
        }

        public override void NowaOcena(float pojOcena)
        {

            if (pojOcena >= 0 && pojOcena <= 100)
            {
                this.Oceny.Add(pojOcena);
                if (DodanoNowaOcene != null)
                {
                    DodanoNowaOcene(this, new EventArgs());
                }
            }
            else
            {
                //Console.WriteLine("Błędna ocena");
                throw new Exception("Błędna ocena");
            }

        }

        public override void NowaOcena(double pojOcena)
        {
            if (pojOcena <= float.MaxValue)
            {
                float value = (float)pojOcena;
                this.NowaOcena(value);
            }
            else
            {
                throw new Exception("Liczba jest zbyt duża");
                //Console.WriteLine("Liczba jest zbyt duża");
            }
        }

        public override void NowaOcena(int pojOcena)
        {
            float value = (int)pojOcena;
            this.NowaOcena(value);
        }

        public override void NowaOcena(char pojOcena)
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
                case 'c':
                    this.Oceny.Add(60);
                    break;
                case 'D':
                case 'd':
                    this.Oceny.Add(40);
                    break;
                case 'E':
                case 'e':
                    this.Oceny.Add(20);
                    break;
                default:
                    throw new Exception("Niepoprawna wartość");
                    //Console.WriteLine("Niepoprawna wartość");

            }
        }

        public override void NowaOcena(string pojOcena)
        {
            if (float.TryParse(pojOcena, out float value))
            {
                this.NowaOcena(value);
            }
            else if (char.TryParse(pojOcena, out char znak))
            {
                this.NowaOcena(znak);
            }

            else
            {
                throw new Exception("String nie jest zmiennoprzecinkowy.");
                //Console.WriteLine("String nie jest zmiennoprzecinkowy.");
            }
        }
    }
}
