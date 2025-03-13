// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using DelegatesDemo.Models;


DelegateProcessor.PerformDelegation();
Transaction transaction1 = new Transaction
{
    FromAccount = Faker.NameFaker.FirstName(),
    ToAccount = Faker.NameFaker.FirstName(),
    Amount = new Random().Next(1000, 10000)

};

Account account1 = new Account
{
    AccountNumber = Faker.NumberFaker.Number(1000000),
    Balance = new Random().Next(10000, 100000)
};
MulticastDelegateProcessor.ProcessTransaction(transaction1, account1);

List<Transaction> transactions = new List<Transaction>();
Account account = new Account
{
    AccountNumber = Faker.NumberFaker.Number(1000000),
    Balance = new Random().Next(10000, 100000)
};
for (int i = 0;i<10; i++)
{
    Transaction transactionV2 = new Transaction
    {
        FromAccount = Faker.NameFaker.FirstName(),
        ToAccount = Faker.NameFaker.FirstName(),
        Amount = new Random().Next(1000, 10000)
    };
    transactions.Add(transactionV2);
}

DelegatePluginProcessor.ProcessDelegatePlugin(transactions, account);


GenericDelegatesProcessor.ProcessGenericDelegate(transactions, account);

EventProcessor.ProcessTransactionEvent(transaction1);

SimpleEvent.ProcessEvent(9999);
Console.ReadKey();



