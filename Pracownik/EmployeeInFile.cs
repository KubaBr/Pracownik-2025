namespace Pracownik
{
    class EmployeeInFile : EmployeeBase
    {
        private const string fileName = "oceny.txt";
        public override event DodanoNowaOceneDel DodanoNowaOcene;

        public EmployeeInFile(string imie, string nazwisko)
            : base(imie, nazwisko)
        {

        }

        public override Statystyki GetStatystyki()
        {

            var statystyki = new Statystyki();

            if (File.Exists(fileName))
            {
                using (var reader = File.OpenText(fileName))
                {
                    var line = reader.ReadLine();

                    while (line != null)
                    {

                        statystyki.DodajOcene(line);
                        line = reader.ReadLine();

                    }


                }
            }

            return statystyki;
        }

        public override void NowaOcena(float pojOcena)
        {
            if (pojOcena >= 0 && pojOcena <= 100)
            {
                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine(pojOcena);

                }
                if (DodanoNowaOcene != null)
                {
                    DodanoNowaOcene(this, new EventArgs());
                }
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
                    this.NowaOcena(100);
                    break;
                case 'B':
                case 'b':
                    this.NowaOcena(80);
                    break;
                case 'C':
                case 'c':
                    this.NowaOcena(60);
                    break;
                case 'D':
                case 'd':
                    this.NowaOcena(40);
                    break;
                case 'E':
                case 'e':
                    this.NowaOcena(20);
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
