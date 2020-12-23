using CompanyStructLib.Models;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company();
            var consoleModelCreation = new ConsoleModelCreation();

            var consoleCompany = new ConsoleCompany(company, consoleModelCreation);

            consoleCompany.Run();

        }
    }
}
