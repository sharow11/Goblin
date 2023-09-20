using Godot;
using System;
using System.Drawing;

public partial class CharacterSheet : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var firstLetter = new TextEdit();
		var thirdLetter = new TextEdit();
		firstLetter.Position = Position with { X = 310.0f,  Y = 38.0f  };
		thirdLetter.Position = Position with { X = 345.0f,  Y = 38.0f  };
		firstLetter.Text = "G";
		thirdLetter.Text = "B";
		firstLetter.Size = new Vector2() { X = 30, Y = 40};
		thirdLetter.Size = new Vector2() { X = 30, Y = 40};

		AddChild(firstLetter);
		AddChild(thirdLetter);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
