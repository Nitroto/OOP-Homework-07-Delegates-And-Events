using System;

namespace StudentClass
{
    class StudentClassMain
    {
        static void Main()
        {
            Student student = new Student("Petar", 22);
            student.PropertyChanged += (sender, eventArgs) =>
            {
                Console.WriteLine("Propery changed: {0} (from {1} to {2})",
                    eventArgs.PropertyName, eventArgs.OldValue, eventArgs.NewValue);
            };
            student.Name = "Maria";
            student.Age = 19;
        }
    }
}
