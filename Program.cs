internal class Program
{
    private static void Main(string[] args)
    {
        PaintballGun gun = new PaintballGun();
        while (true)
        {
            Console.WriteLine($"{gun.GetBalls()} balls, {gun.GetBallsLoaded()} loaded");
            if (gun.IsEmpty())
                Console.WriteLine("WARNING: out of ammo");
            Console.WriteLine("Space to shoot, r to reload, + to add ammo, q to quit");
            char key = Console.ReadKey(true).KeyChar;
            if (key == ' ')
                Console.WriteLine($"Shooting returned {gun.Shoot()}");
            else if (key == 'r')
                gun.Reload();
            else if (key == '+')
                gun.SetBalls(gun.GetBalls() + PaintballGun.MAGAZINE_SIZE);
            else if (key == 'q') 
                return;
        }
    }
}

class PaintballGun
{
    public const int MAGAZINE_SIZE = 16;

    private int balls = 0;
    private int ballsLoaded = 0;

    public int GetBallsLoaded() { return ballsLoaded; }

    public bool IsEmpty() { return ballsLoaded == 0; } //redundant

    public int GetBalls() { return balls; }

    public void SetBalls(int numberOfBalls)
    {
        if (numberOfBalls > 0)
            balls = numberOfBalls;
        Reload();
    }

    public void Reload()
    {
        if (balls > MAGAZINE_SIZE)
            ballsLoaded = MAGAZINE_SIZE;
        else
            ballsLoaded = balls;
    }

    public bool Shoot()
    {
        if (ballsLoaded == 0) 
            return false;
        ballsLoaded--;
        balls--;
        return true;
    }
}