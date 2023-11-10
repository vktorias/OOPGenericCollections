using Microsoft.VisualBasic.FileIO;
using System.ComponentModel;
using System.Linq.Expressions;

namespace OOPGenericCollections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Skapar 5 olika anställda där jag tilldelar de en variabel "E1, E2 osv"
            //Sätter värden på egenskaperna
            Employee E1 = new Employee
            {
                Id = 101,
                Name = "Viktoria",
                Gender = "Female",
                Salary = 25000
            };

            Employee E2 = new Employee
            {
                Id = 102,
                Name = "Andreas",
                Gender = "Male",
                Salary = 20000
            };

            Employee E3 = new Employee
            {
                Id = 103,
                Name = "Stina",
                Gender = "Female",
                Salary = 27000
            };

            Employee E4 = new Employee
            {
                Id = 104,
                Name = "Jonas",
                Gender = "Male",
                Salary = 24000
            };

            Employee E5 = new Employee
            {
                Id = 105,
                Name = "Karolina",
                Gender = "Female",
                Salary = 33000
            };
            //Skapar en stack för Employee och som får variabelnamnet "employeeStack"
            Stack<Employee> employeeStack = new Stack<Employee>();
            //Lägger till de objekt jag skapat i stacken med hjälp av metoden Push()
            employeeStack.Push(E1);
            employeeStack.Push(E2);
            employeeStack.Push(E3);
            employeeStack.Push(E4);
            employeeStack.Push(E5);

            //Skapar en foreach-loop för att skriva ut alla element i stacken
            foreach (Employee employee in employeeStack)
            {
                Console.WriteLine($"Id: {employee.Id}, Name: {employee.Name}, Gender: {employee.Gender}, Salary: {employee.Salary}");
                //Efter varje rad så skrivs det ut hur många objekt som är kvar i stacken
                //med hjälp av employeeStack.Count som räknar objekten i stacken
                Console.WriteLine($"Items left in the stack = {employeeStack.Count}");
            }
            Console.WriteLine("--------------------------------------------------------");

            //Skapar en while-loop som tar bort objekt från stacken (pop-metoden) till stacken är tom
            while (employeeStack.Count > 0)
            {
                Console.WriteLine("Retrive Using Pop Method");
                Employee employee = employeeStack.Pop(); //Hämtar och tar bort det översta objektet i stacken
                Console.WriteLine($"Id: {employee.Id}, Name: {employee.Name}, Gender: {employee.Gender}, Salary: {employee.Salary}");
                //Efter varje rad så skrivs det ut hur många objekt som är kvar i stacken
                //med hjälp av employeeStack.Count som räknar objekten i stacken
                Console.WriteLine($"Items left in the stack = {employeeStack.Count}");
            }

            //Hämtar alla objekt i stacken igen med hjälp av Push-metoden
            employeeStack.Push(E1);
            employeeStack.Push(E2);
            employeeStack.Push(E3);
            employeeStack.Push(E4);
            employeeStack.Push(E5);

            Console.WriteLine("--------------------------------------------------------");

            //En for-loop som hämtar och skriver ut information om de två översta objekten i stacken
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Retrive Using Peek Method");
                Employee employee = employeeStack.Peek(); //Hämtar två objekt med Peek-metoden utan att ta bort dom från stacken
                Console.WriteLine($"Id: {employee.Id}, Name: {employee.Name}, Gender: {employee.Gender}, Salary: {employee.Salary}");
                Console.WriteLine($"Items left in the stack = {employeeStack.Count}");
                employeeStack.Peek(); //Anropar stacken med Peek-metoden utan att lagra resultatet
            }

            Console.WriteLine("--------------------------------------------------------");

            //Hämtar ett objekt från stacken på position 2 (baserat på nollbaserat index)
            Employee itemToCheck = employeeStack.ElementAtOrDefault(2);
            if (itemToCheck != null)
            {
                Console.WriteLine("Item number 3 is in the stack.");
            }
            else
            {
                Console.WriteLine("Item number 3 is not in the stack.");
            }

            Console.WriteLine("--------------------------------------------------------");

            //Skapar en List<Employee> och fyller den med de tidigare skapade Employee-objekten
            List<Employee> employees = new List<Employee>() { E1, E2, E3, E4, E5 };

            //Kollar om Employee E2 finns i listan med hjälp av Contains-metoden
            if (employees.Contains(E2))
            {
                //Om E2 finns i listan så skriv ut denna information
                Console.WriteLine("Employee 2 exists in the list.");
            }
            else
            {
                //Om inte E2 finns i listan så skriv ut denna information
                Console.WriteLine("Employee 2 does not exist in the list.");
            }

            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("The first male Employee in the list: ");

            //Använder Find-metoden från LINQ för att söka igenom listan "employees" 
            //Villkoret är att den anställdas kön måste vara lika med "Male".
            Employee firstMaleEmployee = employees.Find(employee => employee.Gender == "Male");

            //En if-sats används för att hantera om ingen manlig anställd hittas
            //är "firstMaleEmployee" inte lika med null
            if (firstMaleEmployee != null)
            {
                //Så skrivs detta ut
                Console.WriteLine($"ID = {firstMaleEmployee.Id}, Name = {firstMaleEmployee.Name}, Gender = {firstMaleEmployee.Gender}, " +
                    $"Salary = {firstMaleEmployee.Salary}");
            }
            else
            {
                //Är "firstMaleEmployee" lika med null så skrivs detta ut
                Console.WriteLine("No male employees is found.");
            }

            //Använder FindAll-metoden från LINQ för att söka igenom listan "employees" 
            //och hämta en lista som jag skapat för att lägga till alla employees som är män "allMaleEmployees"
            //Villkoret är att den anställdas kön måste vara lika med "Male".
            List<Employee> allMaleEmployees = employees.FindAll(employee => employee.Gender == "Male");

            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("All male Employee in the list: ");

            //Skapar en if-sats som som kontrollerar om det finns manliga anställda i listan
            if (allMaleEmployees.Count > 0)
            {
                //Finns det manliga anställda i listan så skrivs de ut genom en foreach-loop
                foreach (var allMaleEmployee in allMaleEmployees)
                {
                    Console.WriteLine($"ID = {allMaleEmployee.Id}, Name = {allMaleEmployee.Name}, Gender = {allMaleEmployee.Gender}, " +
                    $"Salary = {allMaleEmployee.Salary}");
                }
            }
            else
            {   //Annars skrivs det ut att det inte finns manliga anställda 
                Console.WriteLine("No male employees is found.");
            }
            
        }
    }
}