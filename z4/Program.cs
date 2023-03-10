using System;

delegate void MyEventHandler();

// Класс, генерирующий событие
class MyClass
{
    public event MyEventHandler MyEvent;

    // Метод, генерирующий событие
    public void DoSomething()
    {
        Console.WriteLine("Вызов метода DoSomething()");

        // Если есть подписчики на событие, вызываем его
        if (MyEvent != null)
        {
            MyEvent();
        }
    }
}

class Observer1
{
    public void OnMyEvent1()
    {
        Console.WriteLine("Наблюдатель №1: Событие произошло!");
    }

    public void OnMyEvent2()
    {
        Console.WriteLine("Наблюдатель №1: Событие произошло еще раз!");
    }
}

class Observer2
{
    public void OnMyEvent1()
    {
        Console.WriteLine("Наблюдатель №2: Событие произошло!");
    }
}

class Program
{
    static void Main(string[] args)
    {
       
        MyClass obj = new MyClass();

        Observer1 observer1 = new Observer1();
        Observer2 observer2 = new Observer2();

        obj.MyEvent += observer1.OnMyEvent1;
        obj.MyEvent += observer1.OnMyEvent2;
        obj.MyEvent += observer2.OnMyEvent1;

        obj.DoSomething();

        obj.MyEvent -= observer1.OnMyEvent2;

        obj.DoSomething();
    }
}