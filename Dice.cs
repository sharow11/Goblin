using System;

public class Dice
{
    private static Random rnd = new Random();
    public static int RollD6()
    {
        return rnd.Next(1,6);
    }
}