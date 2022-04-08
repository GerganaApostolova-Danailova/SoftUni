using System;

namespace DefiningClasses
{
     public class StartUp
    {
        public static void Main(string[] args)
        {
            Person person = new Person();
            Person person2 = new Person(20);
            Person person3 = new Person("Geri", 32);
        }
    }
}
