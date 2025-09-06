using System;

namespace StudentLibrary.List
{
    public class Student
    {
        public int ID;
        public string Name;
        public string Course;
        public int YearLevel;
        public double GPA;

        public void Display()
        {
            Console.WriteLine($"{ID} - {Name}, {Course}, Year {YearLevel}, GPA: {GPA}");
        }
    }

    public class StudentNode
    {
        public Student Student;
        public StudentNode Next;

        public StudentNode(Student student)
        {
            Student = student;
            Next = null;
        }
    }

    public class LinkedList
    {
        private StudentNode head;

        public void AddAtBeginning(Student student)
        {
            if (Exists(student.ID))
            {
                Console.WriteLine("Duplicate ID not allowed.");
                return;
            }

            StudentNode newNode = new StudentNode(student);
            newNode.Next = head;
            head = newNode;
            Console.WriteLine("Student added at beginning.");
        }

        public void AddAtEnd(Student student)
        {
            if (Exists(student.ID))
            {
                Console.WriteLine("Duplicate ID not allowed.");
                return;
            }

            StudentNode newNode = new StudentNode(student);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                StudentNode temp = head;
                while (temp.Next != null)
                    temp = temp.Next;

                temp.Next = newNode;
            }

            Console.WriteLine("Student added at end.");
        }
        public void AddAtPosition(Student student, int position)
        {
            if (Exists(student.ID))
            {
                Console.WriteLine(" Duplicate ID not allowed.");
                return;
            }

            StudentNode newNode = new StudentNode(student);

            if (position <= 1 || head == null)
            {
                newNode.Next = head;
                head = newNode;
                Console.WriteLine("Student added at beginning.");
                return;
            }

            StudentNode current = head;
            int count = 1;

            while (current != null && count < position - 1)
            {
                current = current.Next;
                count++;
            }

            if (current == null)
            {
                Console.WriteLine("Position out of range. Adding at end.");
                AddAtEnd(student);
                return;
            }

            newNode.Next = current.Next;
            current.Next = newNode;
            Console.WriteLine($"Student inserted at position {position}.");
        }


        public void DeleteByID(int id)
        {
            if (head == null)
            {
                Console.WriteLine("List is empty.");
                return;
            }

            if (head.Student.ID == id)
            {
                Console.WriteLine($"Deleted: {head.Student.Name}");
                head = head.Next;
                return;
            }

            StudentNode current = head;
            while (current.Next != null)
            {
                if (current.Next.Student.ID == id)
                {
                    Console.WriteLine($"Deleted: {current.Next.Student.Name}");
                    current.Next = current.Next.Next;
                    return;
                }
                current = current.Next;
            }

            Console.WriteLine("Student not found.");
        }

        public void DisplayAll()
        {
            if (head == null)
            {
                Console.WriteLine("No student records.");
                return;
            }

            StudentNode temp = head;
            Console.WriteLine("\nStudent Records:");
            while (temp != null)
            {
                temp.Student.Display();
                temp = temp.Next;
            }
        }

        public void Search(string key)
        {
            StudentNode temp = head;
            while (temp != null)
            {
                if (temp.Student.ID.ToString() == key || temp.Student.Name.Equals(key, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Student found:");
                    temp.Student.Display();
                    return;
                }
                temp = temp.Next;
            }

            Console.WriteLine("Student not found.");
        }

        private bool Exists(int id)
        {
            StudentNode temp = head;
            while (temp != null)
            {
                if (temp.Student.ID == id)
                    return true;
                temp = temp.Next;
            }
            return false;
        }
    }
}
