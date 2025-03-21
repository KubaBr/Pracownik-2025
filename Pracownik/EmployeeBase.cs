namespace Pracownik
{
    public abstract class EmployeeBase : IEmployee
    {
        public delegate void DodanoNowaOceneDel(object sender, EventArgs args);

        public abstract event DodanoNowaOceneDel DodanoNowaOcene;
        public string Imie { get; private set; }

        public string Nazwisko { get; private set; }

        public EmployeeBase(string imie, string nazwisko)
        {
            this.Imie = imie;
            this.Nazwisko = nazwisko;
        }


        public abstract Statystyki GetStatystyki();

        public abstract void NowaOcena(float pojOcena);

        public abstract void NowaOcena(double pojOcena);

        public abstract void NowaOcena(int pojOcena);

        public abstract void NowaOcena(char pojOcena);

        public abstract void NowaOcena(string pojOcena);


    }
}
