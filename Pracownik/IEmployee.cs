﻿using static Pracownik.EmployeeBase;

namespace Pracownik
{
    public interface IEmployee
    {
        string Imie { get; }
        string Nazwisko { get; }


        void NowaOcena(float pojOcena);
        void NowaOcena(double pojOcena);
        void NowaOcena(int pojOcena);
        void NowaOcena(char pojOcena);
        void NowaOcena(string pojOcena);

        event DodanoNowaOceneDel DodanoNowaOcene;


        public Statystyki GetStatystyki();

    }
}
