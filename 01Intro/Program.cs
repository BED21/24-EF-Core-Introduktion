
using _01Intro.Data;
using _01Intro.Models;


WriteToDb();
ReadFromDb();

Console.ReadKey();


void WriteToDb()
{
    using (var db = new DbNameContext())
    {
        db.Persons.Add(new Person() { FirstName = "Claes", LastName = "Engelin" });

        db.Persons.AddRange(new[]
                {
                new Person(){FirstName="Tom", LastName="Sawyer"},
                new Person(){FirstName="Huckelberry", LastName="Finn"},
                new Person(){FirstName="Charlie", LastName="Brown"}
            });

        db.SaveChanges();
    }
}


static void ReadFromDb()
{
    //var db = new DbNameContext();

    using (var db = new DbNameContext())
    {
        var persons = db.Persons
            .Where(p => p.FirstName.StartsWith("C")).ToList();

        foreach (var person in persons)
        {
            Console.WriteLine($"{person.FirstName} {person.LastName}");
        }
    }

}
