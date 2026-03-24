using Bogus;
using M007_EFCore_DBFirst.Models;

namespace M007_EFCore_DBFirst;

/// <summary>
/// EF Core Power Tools
/// 
/// Visual Studio Extension
/// Right Click the project -> EF Core Power Tools -> Reverse Engineer
/// 
/// Create connection, EF Core 8/9 (depending on project .NET version), select tables
/// Standard names for DBContext and models, DataAnnotations, connection string, packages
/// </summary>
internal class Program
{
	static void Main(string[] args)
	{
		PersonDBContext context = new PersonDBContext(); //Create database connector
		
		List<Personen> p = [];
		Faker<Personen> faker = new Faker<Personen>();
		//faker.RuleFor(e => e.Id, e => e.IndexFaker); //Not working because auto increment
		faker.RuleFor(e => e.FirstName, e => e.Name.FirstName());
		faker.RuleFor(e => e.LastName, e => e.Name.LastName());
		faker.RuleFor(e => e.Address, e => e.Address.StreetAddress());
		faker.RuleFor(e => e.City, e => e.Address.City());
		faker.RuleFor(e => e.Region, e => e.Address.State());
		faker.RuleFor(e => e.PostalCode, e => e.Address.ZipCode());
		faker.RuleFor(e => e.Country, e => e.Address.Country());
		p = faker.Generate(1000);

		context.AddRange(p); //This command does not write changes to the db
		context.SaveChanges(); //Here we do database changes
	}
}
