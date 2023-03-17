internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

class PaintballGun
{
    public const int MAGAZINE_SIZE = 16;

    private int balls = 0;
    private int ballsLoaded = 0;

    public int GetBallsLoaded() { return ballsLoaded; }

    public bool IsEmpty() { return ballsLoaded == 0; }


}