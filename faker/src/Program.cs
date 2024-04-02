

namespace faker {

    public class Program
    {
        public static void Main(){

            var config = new FakerConfigImpl();
            config.add<Person, string, CityGenerator>(person => person.City);
            var faker = new FakerImpl(config);
            Person person = faker.create<Person>();
            Console.WriteLine(person.Name);
            Console.WriteLine(person.Salary);
            Console.WriteLine(person.HasChildren);
            Console.WriteLine(person.Birthday);
            Console.WriteLine(person.City);
        }
    }


    class CityGenerator : ICustomGenerator<string>
    {
        public string generate()
        {
            Random random = new Random();
            string[] cities = ["Minsk", "London", "Paris"];
            return cities[random.Next(3)];
        }
    }

    class FillableClass(int i = 0)
    {
        public int getI() {
            return i;
        }
    }

    public class Person
    {
        public string Name { get; }
        public int Salary { get; set; }
        public bool HasChildren { get; set; }
        public DateTime Birthday { get; }
        public string City { get; set; }


        public Person(string name, int salary, bool hasChildren, DateTime birthday, string city)
        {
            Name = name;
            Salary = salary;
            HasChildren= hasChildren;
            Birthday = birthday;
            City = city;
        }
    }


}