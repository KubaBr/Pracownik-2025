using Pracownik;

var pracownik = new Employee("Kuba", "Brózda");
pracownik.NowaOcena(5);
pracownik.NowaOcena(7);


var statystyki = pracownik.GetStatystyki();
Console.WriteLine("Maksymalna wartość: " + statystyki.Max);
Console.WriteLine($"Minimalna wartość:  {statystyki.Min}"); // interpolacja
Console.WriteLine($"Wartość średnia: {statystyki.Srednia:N2}");

