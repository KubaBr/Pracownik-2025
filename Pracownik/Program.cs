using Pracownik;

var pracownik = new EmployeeInFile("Kuba", "Brózda");
//pracownik.NowaOcena(5);
//pracownik.NowaOcena(7);
//pracownik.NowaOcena('A');
//pracownik.NowaOcena('A');
Console.WriteLine("Witamy w Programie Afabus");
Console.WriteLine("=========================");
Console.WriteLine("");
Console.WriteLine("Wprowadź ocenę pracownika: ");

pracownik.DodanoNowaOcene += PracownikOcenaDodana;

void PracownikOcenaDodana(object sender, EventArgs args)
{
    Console.WriteLine("Dodano ocene!");
}


while (true)
{
 
    var input = Console.ReadLine();

    if (input == "q")
    {
        break;
    }
    try
    {

    }
    catch (Exception e)
    {
        Console.WriteLine($"Exeption catched: {e.Message}");
    }

    pracownik.NowaOcena(input);
    Console.WriteLine("Wprowadź kolejną ocenę pracownika. Aby przerwać kliknij q ");

}

var statystyki = pracownik.GetStatystyki();
Console.WriteLine("Maksymalna wartość: " + statystyki.Max);
Console.WriteLine($"Minimalna wartość:  {statystyki.Min}"); // interpolacja
Console.WriteLine($"Wartość średnia: {statystyki.Srednia:N2}");
Console.WriteLine($"Średnia wyroażona poprzez literkę: {statystyki.SredniaLitera}");

