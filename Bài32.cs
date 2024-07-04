namespace Bài32
{

    public abstract class Person {
        public string Name { get; set; }
    }

    public interface KPI
    {
        void kpi();
    }


    public class Student: Person, KPI
    {
        public string Major { get; set; }

        public void kpi()
        {
            Console.WriteLine($"KPI method called for student {Name} in major {Major}. ");
        }

        class Program
        {
            static void Main(string[] args)
            {
                Person obs = new Person
                {
                    Name = "Nguyen Van Nam",
                    Major = "ICT"
                };

                if (obs is Student student)
                {
                    student.kpi();
                }
            }
        }
    }
}
