using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PracticeCSharp
{
    public class Student
    {
        public int RollNumber { get; set; }
        public string Name { get; set; }
    }

    class Program
    {
        Student[] studentObj = new Student[6];
        int currentIndex = 0;

        public void Start()
        {
            int choice;

            do
            {
                Console.WriteLine("\n Choose an option :");
                Console.WriteLine(" 1 - Insert");
                Console.WriteLine(" 2 - List");
                Console.WriteLine(" 3 - Search");
                Console.WriteLine(" 4 - Update");
                Console.WriteLine(" 5 - Delete");
                Console.WriteLine(" 6 - Exit");
                Console.Write(" Enter your choice : ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Insert();
                        break;

                    case 2:
                        List();
                        break;

                    case 3:
                        Search();
                        break;

                    case 4:
                        Update();
                        break;

                    case 5:
                        Delete();
                        break;

                    case 6:
                        Console.WriteLine("Exiting..");
                        break;

                    default:
                        Console.WriteLine("Invalid choice made..");
                        break;

                }

            } while (choice != 6);
        }

        public void Insert()
        {
            if (currentIndex < studentObj.Length)
            {
                Console.Write("\nENTER STUDENT DETAILS : ");
                Console.Write("\nName : ");
                string name = Console.ReadLine();
                Console.Write("Roll Number : ");
                int rollNumber = Convert.ToInt32(Console.ReadLine());

                studentObj[currentIndex++] = new Student { Name = name, RollNumber = rollNumber };
                Console.WriteLine("Details inserted successfully..");
            }

            else
            {
                Console.WriteLine("Memory full..");
            }
        }

        public void List()
        {
            Console.WriteLine("\n LIST OF STUDENTS : ");
            for (int i = 0; i < currentIndex; i++)
            {
                Console.WriteLine("Name : " + studentObj[i].Name + " and Roll Number  : " + studentObj[i].RollNumber);
            }
        }

        public void Search()
        {
            Console.WriteLine("\nSEARCH FOR STUDENT : ");
            Console.Write("Enter Roll Number to Search : ");
            int rollNum = Convert.ToInt32(Console.ReadLine());

            bool found = false;
            for (int i = 0; i < currentIndex; i++)
            {
                if (studentObj[i].RollNumber == rollNum)
                {
                    Console.WriteLine("Record found..");
                    Console.WriteLine("Name : " + studentObj[i].Name);
                    Console.WriteLine("Roll Number : " + studentObj[i].RollNumber);
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Record not found..");
            }
        }

        public void Update()
        {
            Console.WriteLine("\nUPDATE STUDENT DETAILS : ");
            Console.Write("Enter Roll Number to Update : ");
            int rollNum = Convert.ToInt32(Console.ReadLine());

            int option;
            for (int i = 0; i < currentIndex; i++)
            {
                if (studentObj[i].RollNumber == rollNum)
                {
                    Console.WriteLine("Current Name : " + studentObj[i].Name);
                    Console.WriteLine("Current Roll Number : " + studentObj[i].RollNumber);

                    Console.WriteLine("Select option : ");
                    Console.WriteLine("1 - Name");
                    Console.WriteLine("2 - Roll Number");
                    Console.Write("Enter your choice : ");
                    option = Convert.ToInt32(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            Console.Write("Enter New Name : ");
                            studentObj[i].Name = Console.ReadLine();
                            break;

                        case 2:
                            Console.Write("Enter New Roll Number : ");
                            studentObj[i].RollNumber = Convert.ToInt32(Console.ReadLine());
                            break;

                        default:
                            Console.WriteLine("Invalid option..");
                            break;
                    }
                    Console.WriteLine("Update successfully..");
                }
            }
        }

        public void Delete()
        {
            Console.WriteLine("\nDELETE STUDENT RECORD : ");
            Console.Write("Enter Roll Number to Delete : ");
            int rollNum = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < currentIndex; i++)
            {
                if (studentObj[i].RollNumber == rollNum)
                {
                    for (int j = i; j < currentIndex - 1; j++)
                    {
                        studentObj[i] = studentObj[j + 1];
                    }
                    currentIndex--;
                    Console.WriteLine("Record of student with Roll Number : " + rollNum + " deleted successfully");
                }
            }
            Console.WriteLine("Sudent with Roll Number : " + rollNum + " not found");
        }

        static void Main(string[] args)
        {
            Program programObj = new Program();
            programObj.Start();
        }
    }
}
