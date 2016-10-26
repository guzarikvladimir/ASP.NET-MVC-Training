using System;
using Fruits;

class Program
{
    static void Main()
    {
        Apple obj1 = new Apple();
        obj1.Info();

	Banana obj = new Banana();
        obj.Info();
	
	Orange obj2 = new Orange();
	obj2.Info();
	
        Console.ReadLine();
    }
}