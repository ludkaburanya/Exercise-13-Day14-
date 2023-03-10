using System;

// Класс для хранения имени и генерации событий об изменении имени
class MyInfo
{
    private string name;

    // Событие, которое будет генерироваться при изменении имени
    public event EventHandler NameChanged;

    public MyInfo(string name)
    {
        this.name = name;
    }

    // Свойство для получения и установки имени
    public string Name
    {
        get { return name; }
        set
        {
            name = value;
            OnNameChanged();
        }
    }

    // Метод для генерации события об изменении имени
    protected virtual void OnNameChanged()
    {
        if (NameChanged != null)
        {
            NameChanged(this, EventArgs.Empty);
        }
    }
}

class Program
{
    static void Main()
    {
        MyInfo info = new MyInfo("Людка");

        // Подписываемся на событие об изменении имени
        info.NameChanged += Info_NameChanged;

        // Изменяем имя
        info.Name = "Даша";
        Console.ReadLine();
    }

    static void Info_NameChanged(object sender, EventArgs e)
    {
        Console.WriteLine("Имя было изменено!");
    }
}