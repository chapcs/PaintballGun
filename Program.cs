internal class Program
{
    private static void Main(string[] args)
    {
        int numberOfBalls = ReadInt(20, "Number of balls");
        int magazineSize = ReadInt(16, "Magazine size");

        Console.Write($"Loaded [false]: ");
        bool.TryParse(Console.ReadLine(), out bool isLoaded);

        PaintballGun gun = new PaintballGun(numberOfBalls, magazineSize, isLoaded);
        while (true)
        {
            Console.WriteLine($"{gun.Balls} balls, {gun.BallsLoaded} loaded");
            if (gun.IsEmpty())
                Console.WriteLine("WARNING: out of ammo");
            Console.WriteLine("Space to shoot, r to reload, + to add ammo, q to quit");
            char key = Console.ReadKey(true).KeyChar;
            if (key == ' ')
                Console.WriteLine($"Shooting returned {gun.Shoot()}");
            else if (key == 'r')
                gun.Reload();
            else if (key == '+')
                gun.Balls += gun.MagazineSize; 
            else if (key == 'q') 
                return;
        }
    }

    static int ReadInt(int lastUsedValue, string prompt)
    {
        Console.Write(prompt + " [" + lastUsedValue + "]: ");
        string line = Console.ReadLine();
        if (int.TryParse(line, out int value))
        {
            Console.WriteLine("   using value " + value);
            return value;
        }
        else
        {
            Console.WriteLine("   using default value " + lastUsedValue);
            return lastUsedValue;
        }
    }
}

class PaintballGun
{
    public PaintballGun(int balls, int magazineSize, bool loaded)
    {
        this.balls = balls; // this keyword is used to refer to the field, balls is the parameter in this constructor
        MagazineSize = magazineSize;
        if (!loaded) Reload();
    }

    // this was changed from a const to an auto-property as well with an assigned value at the end
    public int MagazineSize { get; private set; } = 16;

    private int balls = 0;

    // changed the GetBallsLoaded method to a property and use the existing field as a backing field
    // then used the 'prop' code snippet to create an auto-implemented property seen below
    // we make the setter private below to maintain the encapsulation we had before, this is now a read-only property
    public int BallsLoaded { get; private set; }

    public bool IsEmpty() { return BallsLoaded == 0; } //redundant

    public int Balls
    {   
        get { return balls; }
        set
        {
            if (value > 0)
                balls = value;
            Reload();
        }
    }

    public void Reload()
    {
        if (balls > MagazineSize)
            BallsLoaded = MagazineSize;
        else
            BallsLoaded = balls;
    }

    public bool Shoot()
    {
        if (BallsLoaded == 0) 
            return false;
        BallsLoaded--;
        balls--;
        return true;
    }
}