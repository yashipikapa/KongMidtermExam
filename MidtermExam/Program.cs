using System;
using StudentLibrary.List;

class Program
{
    static void Main()
    {
        LinkedList studentList = new LinkedList();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n--- Student Record Manager ---");
            Console.WriteLine("1. Add Student at Beginning");
            Console.WriteLine("2. Add Student at End");
            Console.WriteLine("3. Add Student at Specific Position");
            Console.WriteLine("4. Delete Student by ID");
            Console.WriteLine("5. Display All Students");
            Console.WriteLine("6. Search Student");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    studentList.AddAtBeginning(CreateStudent());
                    break;
                case "2":
                    studentList.AddAtEnd(CreateStudent());
                    break;
                case "3":
                    Console.Write("Enter position to insert: ");
                    if (int.TryParse(Console.ReadLine(), out int pos) && pos > 0)
                        studentList.AddAtPosition(CreateStudent(), pos);
                    else
                        Console.WriteLine("Invalid position.");
                    break;
                case "4":
                    Console.Write("Enter ID to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int delId))
                        studentList.DeleteByID(delId);
                    else
                        Console.WriteLine("Invalid ID.");
                    break;
                case "5":
                    studentList.DisplayAll();
                    break;
                case "6":
                    Console.Write("Enter ID or Name to search: ");
                    string key = Console.ReadLine();
                    studentList.Search(key);
                    break;
                case "7":
                    running = false;
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    static Student CreateStudent()
    {
        Student student = new Student();

        while (true)
        {
            Console.Write("Enter ID: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int id) && id > 0)
            {
                student.ID = id;
                break;
            }
            Console.WriteLine("Invalid ID.");
        }

        while (true)
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
            {
                student.Name = name.Trim();
                break;
            }
        }

       
        while (true)
        {
            Console.Write("Enter Course: ");
            string course = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(course))
            {
                student.Course = course.Trim();
                break;
            }
        }

        while (true)
        {
            Console.Write("Enter Year Level (1–5): ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int year) && year >= 1 && year <= 5)
            {
                student.YearLevel = year;
                break;
            }
            Console.WriteLine("❌ Invalid year level. Must be between 1 and 5.");
        }

        while (true)
        {
            Console.Write("Enter GPA (0.0–4.0): ");
            string input = Console.ReadLine();
            if (double.TryParse(input, out double gpa) && gpa >= 0.0 && gpa <= 4.0)
            {
                student.GPA = gpa;
                break;
            }
            Console.WriteLine("❌ Invalid GPA. Must be between 0.0 and 4.0.");
        }

        return student;
    }

}
