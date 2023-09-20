using System;
using Godot;

public class Goblin
{
    public string FirstLetter { get; set; }
    public string ThirdLetter { get; set; }
	public int Stab { get; set; }
	public int Sneak { get; set; }
	public int Magic { get; set; }
	public int Health { get; set; }
	public int Teeth { get; set; }
	public int Hex { get; set; }

    public bool isCreated { get; set; }

    public Goblin()
    {
        FirstLetter = "G";
        ThirdLetter = "B";
    }
}