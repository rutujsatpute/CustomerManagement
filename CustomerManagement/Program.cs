using System.Runtime.InteropServices;

using System.Xml.Linq;
namespace CustomerManagement
{
    class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
    }
    class Management
    {
        List<Customer> customers;
        public Management()
        {

            customers = new List<Customer>()
 {

                new Customer { Id = 1, FirstName="Rutuj", LastName="Satpute", Email="rutujsatoute@gmail.com", Age =23, Phone = "8830217371", City = "Kolhapur"},

                new Customer { Id = 2, FirstName="Malhar", LastName="Jadhav", Email="malharjadhav@gmail.com", Age =23, Phone = "2354675424", City = "Pune"},

 };
        }
        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
        }
        public int GenerateCustomerId(string firstName, string lastName)
        {
            Random rand = new Random();
            int randomNumber = rand.Next(1, 9999);
            return randomNumber;
        }
        public Customer GetCustomer(int id)
        {
            foreach (Customer c in customers)
            {
                if (c.Id == id)
                    return c;
            }
            return null;
        }
        public bool UpdateDetails(int id)
        {
            foreach (Customer c in customers)
            {
                if (c.Id == id)
                {
                    Console.WriteLine("Enter the New Details");
                    Console.WriteLine("Enter First Name");
                    c.FirstName = Console.ReadLine();
                    Console.WriteLine("Enter Last Name");
                    c.LastName = Console.ReadLine();
                    Console.WriteLine("Enter Email Id: ");
                    c.Email = Console.ReadLine();
                    Console.WriteLine("Enter Age");
                    c.Age = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("Enter Phone Number:");
                    string num = Console.ReadLine();
                    if (num.Length != 10)
                    {
                        Console.WriteLine("Invalid Number!! Enter the number again: ");
                        c.Phone = Console.ReadLine();
                    }
                    Console.WriteLine("Enter City");
                    c.City = Console.ReadLine();
                    return true;
                }
            }
            return false;
        }
        public List<Customer> GetCustomers()
        {
            return customers;
        }
        public bool DeleteCustomer(int id)
        {
            foreach (Customer c in customers)
            {
                if (c.Id == id)
                {
                    customers.Remove(c);
                    return true;
                }
            }
            return false;
        }
    }
internal class Program
    {
        static void Main(string[] args)
        {
            Management obj = new Management();
            string ans = "";
            do
            {
                Console.WriteLine("Welcome to Customer Management App");
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. Get Customer Detail By Id");
                Console.WriteLine("3. Get All Customer Details");
                Console.WriteLine("4. Delete Customer By Id");
                Console.WriteLine("5. Update Customer Details");
                int choice = Convert.ToInt16(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter First Name");
                            string firstname = Console.ReadLine();
                            Console.WriteLine("Enter Last Name");
                            string lastname = Console.ReadLine();
                            Console.WriteLine("Enter Email Id: ");
                            string email = Console.ReadLine();
                            Console.WriteLine("Enter Age");
                            int age = Convert.ToInt16(Console.ReadLine());
                            Console.WriteLine("Enter Phone Number:");
                            string num = Console.ReadLine();
                            if (num.Length != 10)
                            {
                                Console.WriteLine("Invalid Number!! Enter the number again: ");
                                num = Console.ReadLine();
                            }
                            Console.WriteLine("Enter City");
                            string city = Console.ReadLine();
                            int cid = obj.GenerateCustomerId(firstname, lastname);
                            Console.WriteLine($"Your Customer ID is {cid}");
                            obj.AddCustomer(new Customer() { Id = cid, FirstName = firstname, LastName = lastname, Email = email, Age = age, Phone = num, City = city });
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Enter Customer Id");
                            int id = Convert.ToInt16(Console.ReadLine());
                            Customer? c = obj.GetCustomer(id);
                            if (c == null)
                            {
                                Console.WriteLine("Customer with specified id does not exists");
                            }
                            else
                            {
                                Console.WriteLine($"{c.Id} {c.FirstName} {c.LastName} {c.Email} {c.Age} {c.Phone} {c.City}");
                            }
                            break;
                        }
                    case 3:
                        {
                            foreach (var c in obj.GetCustomers())
                            {
                                Console.WriteLine($"{c.Id} {c.FirstName} {c.LastName} {c.Email} {c.Age} {c.Phone} {c.City}");
                            }
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Enter Customer Id");
                            int id = Convert.ToInt16(Console.ReadLine());
                            if (obj.DeleteCustomer(id))
                            {
                                Console.WriteLine("Customer Details Deleted Successfully");
                            }
                            else
                            {
                                Console.WriteLine("Customer with specified id does not exist");
                            }
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Enter Customer ID");
                            int id = Convert.ToInt16(Console.ReadLine());
                            if (obj.UpdateDetails(id))
                            {
                                Console.WriteLine("Customer Detail Updated Successfully!!");
                            }
                            else
                            {
                                Console.WriteLine("Customer with specified id does not exist");
                            }
                            break;
                        }
                       default:
                        {
                            Console.WriteLine("Invalid choice!!!!");
                            break;
                        }
                }
                Console.WriteLine("Do you wish to continue? [y/n] ");
                ans = Console.ReadLine();
            } while (ans.ToLower() == "y");
        }
    }
}


