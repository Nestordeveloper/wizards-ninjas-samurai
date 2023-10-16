class Human
{
    public string Name { get; set; }
    public int Strength { get; set; }
    public int Intelligence { get; set; }
    public int Dexterity { get; set; }
    public int Health { get; set; }

    public Human(string name, int str, int intel, int dex, int hp)
    {
        Name = name;
        Strength = str;
        Intelligence = intel;
        Dexterity = dex;
        Health = hp;
    }

    public virtual int Attack(Human target)
    {
        int dmg = Strength * 3;
        target.Health -= dmg;
        Console.WriteLine($"¡{Name} ataco a {target.Name} por {dmg} de daño!");
        return target.Health;
    }
}

class Wizard : Human
{
    public Wizard(string name) : base(name, 3, 25, 3, 50)
    {
    }

    public override int Attack(Human target)
    {
        int dmg = Intelligence * 3;
        target.Health -= dmg;
        Health += dmg;
        Console.WriteLine($"¡{Name} conjuro un hechizo sobre {target.Name} por {dmg} de daño!");
        return target.Health;
    }

    public void Heal(Human target)
    {
        int healAmount = Intelligence * 3;
        target.Health += healAmount;
        Console.WriteLine($"¡{Name} curo a {target.Name} por {healAmount} de vida!");
    }
}

class Ninja : Human
{
    public Ninja(string name) : base(name, 3, 3, 75, 100)
    {
    }

    public override int Attack(Human target)
    {
        int dmg = Dexterity;
        if (new Random().Next(0, 5) == 0)
        {
            dmg += 10;
            Console.WriteLine("¡Golpe Critico!");
        }
        target.Health -= dmg;
        Console.WriteLine($"¡{Name} ataco a {target.Name} por {dmg} de daño!");
        return target.Health;
    }

    public void Steal(Human target)
    {
        target.Health -= 5;
        Health += 5;
        Console.WriteLine($"{Name} robó 5 de vida a {target.Name}!");
    }
}

class Samurai : Human
{
    public Samurai(string name) : base(name, 5, 3, 3, 200)
    {
    }

    public override int Attack(Human target)
    {
        int remainingHealth = base.Attack(target);
        if (remainingHealth < 50)
        {
            target.Health = 0;
            Console.WriteLine($"{target.Name} tiene menos de 50 de salud. ¡Golpe final!");
        }
        return target.Health;
    }

    public void Meditate()
    {
        Health = 200;
        Console.WriteLine($"{Name} medito y restauro su vida completamente.");
    }
}

class Program
{
    static void Main()
    {
        Wizard wizard = new Wizard("Gandalf");
        Ninja ninja = new Ninja("Hanzo");
        Samurai samurai = new Samurai("Kenshin");

        Human target = new Human("Objetivo", 5, 5, 5, 100);

        wizard.Attack(target);
        wizard.Heal(target);

        ninja.Attack(target);
        ninja.Steal(target);

        samurai.Attack(target);
        samurai.Meditate();
    }
}
