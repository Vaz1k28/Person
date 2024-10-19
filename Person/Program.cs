using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

}
class Person
{
    private string name;
    private DateTime birthYear;

    public string Name
    {
        get { return name; }
    }

    public int BirthYear
    {
        get { return birthYear.Year; }
    }

    public Person()
    {
        name = "";
        birthYear = DateTime.MinValue;
    }

    public Person(string name, int birthYear)
    {
        this.name = name;
        this.birthYear = new DateTime(birthYear, 1, 1);
    }

    public int Age()
    {
        return DateTime.Now.Year - birthYear.Year;
    }

    public void Input()
    {
        Console.Write("Введіть ім'я: ");
        name = Console.ReadLine();
        Console.Write("Введіть рік народження: ");
        birthYear = new DateTime(int.Parse(Console.ReadLine()), 1, 1);
    }

    public void ChangeName(string newName)
    {
        name = newName;
    }

    public override string ToString()
    {
        return $"Ім'я: {name}, Вік: {Age()}";
    }

    public void Output()
    {
        Console.WriteLine(ToString());
    }

    public static bool operator ==(Person person1, Person person2)
    {
        if (ReferenceEquals(person1, person2))
        {
            return true;
        }

        if (ReferenceEquals(person1, null) || ReferenceEquals(person2, null))
        {
            return false;
        }

        return person1.name == person2.name;
    }

    public static bool operator !=(Person person1, Person person2)
    {
        return !(person1 == person2);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Person[] persons = new Person[6];
        for (int i = 0; i < persons.Length; i++)
        {
            persons[i] = new Person();
            persons[i].Input();
        }

        foreach (var person in persons)
        {
            Console.WriteLine(person.ToString());
            if (person.Age() < 16)
            {
                person.ChangeName("Very Young");
            }
        }

        Console.WriteLine("\nОсоби з однаковими іменами:");
        for (int i = 0; i < persons.Length - 1; i++)
        {
            for (int j = i + 1; j < persons.Length; j++)
            {
                if (persons[i] == persons[j])
                {
                    Console.WriteLine(persons[i].ToString());
                }
            }
        }
    }
}