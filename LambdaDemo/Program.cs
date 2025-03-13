// See https://aka.ms/new-console-template for more information
using LambdaDemo.Models;
using LambdaDemo.Repositories;
using System.Runtime.Intrinsics.Arm;
IRepository<Customer> customerRepository = new Repository<Customer>();

Func<Individual, Customer> addIndividual = (obj) =>
{
    return customerRepository.AddCustomer(obj);
};
Individual individual = new Individual()
{
    AccountNo = Faker.RandomNumber.Next(1000, 9999),
    Name = new FullName()
    {
        FirstName = Faker.Name.First(),
        LastName = Faker.Name.Last()
    },
    DOB = new DateTime(new Random().Next(1950, 2000), new Random().Next(1, 12), new Random().Next(1, 28)),
    Email = Faker.Internet.Email(),
    PhoneNumber = new Random().Next(900000000, 999999999),
    AddressList = new List<Address>()
     {
         new Address()
         {
             AddressId=Faker.RandomNumber.Next(1000,9999),

                City=Faker.Address.City(),
                DoorNo=Faker.RandomNumber.Next(1,100).ToString(),
                StreetName=Faker.Address.StreetName(),
         }
     }
};
Console.WriteLine(addIndividual.Invoke(individual));


//LINQ Query
string[] names = { "TamilSelvan", "Dananjay", "Harry","Tom" };

IEnumerable<string> filteredNames =
  Enumerable
  .Where(names, n => n.Length >= 4)
  .OrderBy(n => n.Length)
  .Select(n => n.ToUpper());

filteredNames.ToList().ForEach(Console.WriteLine);

//Select Query
List<int> randNumbers = new List<int>();
for (int i = 0; i < 5; i++)
    randNumbers.Add(new Random().Next(1, 1000));
IEnumerable<int> numberQuery = randNumbers.Select(n => n * 10);
numberQuery.ToList().ForEach(Console.WriteLine);

//subquery
List<string> users = new List<string>();
users.Add("Parameswari Bala");
users.Add("Angelina Thomas");
users.Add("Sharmila Kumar");
users.Add("Arun Singh");
users.Add("Jyoti Tyagi");
users.OrderBy(u => u.Split().Last()).ToList().ForEach(Console.WriteLine);


//progressive sub query
IEnumerable<string> derivedNames = names.OrderBy(n => n.Length);
derivedNames.Select(n => n.Length).ToList().ForEach(Console.WriteLine);

(from n in names
 where n.Length ==
 (from n1 in names orderby n1.Length select n1.Length).First()
 select n).ToList().ForEach(Console.WriteLine);

/*


           foreach (string n in filteredNames)
               Console.Write(n + "|");            // Dick|Harry|

           // "Where" is an extension method in System.Linq.Enumerable:

           (new[] { "Tom", "Dick", "Harry" }).Where(n => n.Length >= 4);

           //Fluent
           string[] names1 = { "Tom", "Dick", "Harry", "Mary", "Jay" };

           IEnumerable<string> query = names1
             .Where(n => n.Contains("a"))
             .OrderBy(n => n.Length)
             .Select(n => n.ToUpper());



           // The same query constructed progressively:

           IEnumerable<string> filtered = names1.Where(n => n.Contains("a"));
           IEnumerable<string> sorted = filtered.OrderBy(n => n.Length);
           IEnumerable<string> finalQuery = sorted.Select(n => n.ToUpper());


           //Extension Methods
           string[] names2 = { "Tom", "Dick", "Harry", "Mary", "Jay" };

           IEnumerable<string> query2 =
             Enumerable.Select(
               Enumerable.OrderBy(
                 Enumerable.Where(
                   names2, n => n.Contains("a")
                 ), n => n.Length
               ), n => n.ToUpper()
             );

           //Type Inference

           names2.Select(n => n.Length).Dump
               ("Notice result is IEnumerable<Int32>; Int32 is inferred");


           //IEnumerable<string> sortedByLength, sortedAlphabetically;

           names.OrderBy(n => n.Length).Dump("Integer sorting key");
           names.OrderBy(n => n).Dump("String sorting key");

           int[] numbers = { 10, 9, 8, 7, 6 };

           // The natural ordering of numbers is honored, making the following queries possible:

           numbers.Take(3).Dump("Take(3) returns the first three numbers in the sequence");
           numbers.Skip(3).Dump("Skip(3) returns all but the first three numbers in the sequence");
           numbers.Reverse().Dump("Reverse does exactly as it says");


           // Element operators:

           numbers.First().Dump("First");
           numbers.Last().Dump("Last");

           numbers.ElementAt(1).Dump("Second number");
           numbers.OrderBy(n => n).First().Dump("Lowest number");
           numbers.OrderBy(n => n).Skip(1).First().Dump("Second lowest number");

           // Aggregation operators:

           numbers.Count().Dump("Count");
           numbers.Min().Dump("Min");

           // Quantifiers:

           numbers.Contains(9).Dump("Contains (9)");
           numbers.Any().Dump("Any");
           numbers.Any(n => n % 2 != 0).Dump("Has an odd numbered element");

           // Set based operators:

           int[] seq1 = { 1, 2, 3 };
           int[] seq2 = { 3, 4, 5 };
           seq1.Concat(seq2).Dump("Concat");
           seq1.Union(seq2).Dump("Union");


           //Basic Query
           IEnumerable<string> query1 =
                 from n in names
                 where n.Contains("a")   // Filter elements
                 orderby n.Length           // Sort elements
                 select n.ToUpper();       // Translate each element (project)

           query1.Dump();

           var names3 = new[] { "Tom", "Dick", "Harry", "Mary", "Jay" }.AsQueryable();

           IEnumerable<string> query3 =
             from n in names3
             where n.Contains("a")    // Filter elements
             orderby n.Length            // Sort elements
             select n.ToUpper();        // Translate each element (project)

           query3.Dump();

           //mixing syntax
           (from n in names where n.Contains("a") select n).Count()
 .Dump("Names containing the letter 'a'");

           string first = (from n in names orderby n select n).First()
             .Dump("First name, alphabetically");

           names.Where(n => n.Contains("a")).Count()
             .Dump("Original query, entirely in fluent syntax");

           names.OrderBy(n => n).First()
             .Dump("Second query, entirely in fluent syntax");
           //reevaluation
           var numbers4 = new List<int>() { 1, 2 };

           IEnumerable<int> query4 = numbers4.Select(n => n * 10);

           query4.Dump("Both elements are returned");

           numbers4.Clear();

           query4.Dump("All the elements are now gone!");

           //defeating reevaluation


           List<int> timesTen = numbers4
             .Select(n => n * 10)
             .ToList();                      // Executes immediately into a List<int>

           numbers4.Clear();
           timesTen.Count.Dump("Still two elements present");

           //captured variables 
           int factor = 10;
           IEnumerable<int> query5 = numbers4.Select(n => n * factor);
           factor = 20;
           query5.Dump("Notice both numbers are multiplied by 20, not 10");

           IEnumerable<char> query6 = "Not what you might expect";
           string vowels = "aeiou";

           foreach (char vowel in vowels)
               query6 = query6.Where(c => c != vowel);

           foreach (char c in query6) Console.Write(c);

           //subqueries
           names.Where(n => n.Length == names.OrderBy(n2 => n2.Length)
    .Select(n2 => n2.Length).First())
    .Dump();

           var query7 =
             from n in names
             where n.Length == (from n2 in names orderby n2.Length select n2.Length).First()
             select n;

           query7.Dump("Same thing as a query expression");

           query7 =
             from n in names
             where n.Length == names.OrderBy(n2 => n2.Length).First().Length
             select n;

           query7.Dump("Reformulated");

           query7 =
             from n in names
             where n.Length == names.Min(n2 => n2.Length)
             select n;

           query7.Dump("Same result, using Min aggregation");

           //avoiding sub queries


           int shortest = names.Min(n => n.Length);
           (
             from n in names
             where n.Length == shortest
             select n
           )
           .Dump("No subquery");
      */     