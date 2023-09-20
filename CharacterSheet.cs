using Godot;
using System;
using System.Drawing;

public partial class CharacterSheet : Node2D
{
	public Goblin goblin { get; set;}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if(goblin is null)
		{
			goblin = new Goblin();
		}

		var firstLetter = new TextEdit();
		var thirdLetter = new TextEdit();
		firstLetter.Position = Position with { X = 310.0f,  Y = 38.0f  };
		thirdLetter.Position = Position with { X = 345.0f,  Y = 38.0f  };
		firstLetter.Text = goblin.FirstLetter;
		thirdLetter.Text = goblin.ThirdLetter;
		firstLetter.Size = new Vector2() { X = 30, Y = 40};
		thirdLetter.Size = new Vector2() { X = 30, Y = 40};

		AddChild(firstLetter);
		AddChild(thirdLetter);

		if(goblin.isCreated == false)
		{
			var buttonDZG = new Button();
			buttonDZG.Text = "Rzuć";
			buttonDZG.Name = "DZG";
			buttonDZG.Pressed += InitStab;
			buttonDZG.Position = Position with { X = 140.0f,  Y = 60.0f  };
			AddChild(buttonDZG);

			var buttonSKR = new Button();
			buttonSKR.Text = "Rzuć";
			buttonSKR.Pressed += InitSneak;
			buttonSKR.Position = Position with { X = 140.0f,  Y = 100.0f  };
			AddChild(buttonSKR);

			var buttonCZA = new Button();
			buttonCZA.Text = "Rzuć";
			buttonCZA.Pressed += InitMagic;
			buttonCZA.Position = Position with { X = 140.0f,  Y = 140.0f  };
			AddChild(buttonCZA);

			var buttonHP = new Button();
			buttonHP.Text = "Rzuć";
			buttonHP.Pressed += InitHealth;
			buttonHP.Position = Position with { X = 325.0f,  Y = 60.0f  };
			AddChild(buttonHP);

			var buttonZB = new Button();
			buttonZB.Text = "Rzuć";
			buttonZB.Pressed += InitTeeth;
			buttonZB.Position = Position with { X = 325.0f,  Y = 100.0f  };
			AddChild(buttonZB);
		}

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	private void InitStab()
	{
		goblin.Stab = Dice.RollD6();
		foreach(var x in GetChildren())
		{
			if(string.Equals(x.Name, "DZG"))
			{
				RemoveChild(x);
				break;
			}
		}
		var textStab = new Label();
		textStab.Text = goblin.Stab.ToString();
		textStab.Position = Position with { X = 140.0f,  Y = 60.0f  };
		AddChild(textStab);
	}
	private void InitSneak()
	{
		goblin.Sneak = Dice.RollD6();
	}
	private void InitMagic()
	{
		goblin.Magic = Dice.RollD6();
	}
	private void InitHealth()
	{
		goblin.Health = Dice.RollD6() + 4;
	}
	private void InitTeeth()
	{
		goblin.Stab = Dice.RollD6() + Dice.RollD6() + 10;
	}
}
