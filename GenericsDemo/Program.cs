// See https://aka.ms/new-console-template for more information
using GenericsDemo.Models;
using GenericsDemo.Repository;



List<Employee> employees = new List<Employee>();
for(int i = 0; i < 10; i++)
{
    employees.Add(new Employee
    {
        EmployeeId = Faker.RandomNumber.Next(10,100000),
        EmployeeName = Faker.Name.FullName(),
        EmployeeDepartment = Faker.Lorem.GetFirstWord(),
        EmployeeDesignation = Faker.Company.BS(),
        EmployeeSalary = Faker.RandomNumber.Next(10000,10000000),
        EmployeeLocation = Faker.Country.Name()
    });
}

GenericRepository<Employee> repository = new GenericRepository<Employee>();
repository.GetValues(employees);


PrivilegedMemberBuilder privilegedMemberBuilder = new PrivilegedMemberBuilder();
//chain of operations
privilegedMemberBuilder.SetName(Faker.Name.FullName()).SetRole("Admin").Show();

Console.ReadKey();
