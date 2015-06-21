using System;

namespace StudentClass
{
    public class Student
    {
        private string name;
        private int age;
        public event PropertyChangedEventHandler PropertyChanged;

        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("name", "Name cannot be empty!");
                }

                PropertyChangedEventArg propEvent = new PropertyChangedEventArg("Name", this.Name, value);
                this.OnPropertyChanged(this, propEvent);
                this.name = value;
            }
        }
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 4 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("age", "The age must be in the range from 4 to 100");
                }
                PropertyChangedEventArg propEvent = new PropertyChangedEventArg("Age", this.Age, value);
                this.OnPropertyChanged(this, propEvent);
                this.age = value;
            }
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArg args)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(sender, args);
            }
        }
    }
}
