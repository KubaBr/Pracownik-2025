namespace Pracownik
{
    class Kierownik : IEmployee
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Stanowisko { get; set; }

        private List<float> Oceny = new List<float>();

        public Kierownik(string imie, string nazwisko)
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
                //Console.WriteLine("Błędna ocena");
                throw new Exception("Błędna ocena");
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
                throw new Exception("Liczba jest zbyt duża");
                //Console.WriteLine("Liczba jest zbyt duża");
            }
        }

        public void NowaOcena(int pojOcena)
        {
            float value = (int)pojOcena;
            this.NowaOcena(value);
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

        public void NowaOcena(string pojOcena)
        {
            //List<char> Znaki = new List<char> ();
            int wynik = 0;
            char[] znaki = new char[pojOcena.Length];
            znaki = pojOcena.ToCharArray();
            foreach (char znakson in znaki)
            {
                if (znakson == '+')
                {
                    wynik += 5;
                }
                else if (znakson == '-')
                {
                    wynik -= 5;
                }
            }
            foreach (char znakson2 in znaki)
            {
                switch (znakson2)
                {
                    case '6':
                        this.Oceny.Add(100 + wynik);
                        break;
                    case '5':
                        this.Oceny.Add(80 + wynik);
                        break;
                    case '4':
                        this.Oceny.Add(60 + wynik);
                        break;
                    case '3':
                        this.Oceny.Add(40 + wynik);
                        break;
                    case '2':
                        this.Oceny.Add(20 + wynik);
                        break;
                    case '1':
                        this.Oceny.Add(0 + wynik);
                        break;
                }

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

        // kierownicy mogą być oceniani jak w szkole
        // 1-6, 6 - 100, 1 to 0,
        // +- to 5 pkt mniej lub więcej, 
        //DodajOcene w stringu,
    }
}
