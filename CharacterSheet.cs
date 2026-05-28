using Godot;
using System;
using System.Drawing;

public partial class CharacterSheet : Node2D
{
	public Goblin goblin { get; set;}

	private Button buttonDZG;
	private Button buttonSKR;
	private Button buttonCZA;
	private Button buttonHP;
	private Button buttonZB;

	private Label textStab;

	private Label textSneak;

	private Label textMagic;

	private Label textHealth;

	private Label textTeeth;

	public CharacterSheet()
	{
			buttonDZG = new Button();
			buttonDZG.Text = "Rzuć na Stab";
			buttonDZG.Pressed += InitStab;
			buttonDZG.Position = Position with { X = 225.0f,  Y = 140.0f  };

			buttonSKR = new Button();
			buttonSKR.Text = "Rzuć na Sneak";
			buttonSKR.Pressed += InitSneak;
			buttonSKR.Position = Position with { X = 225.0f,  Y = 210.0f  };

			buttonCZA = new Button();
			buttonCZA.Text = "Rzuć na Magie";
			buttonCZA.Pressed += InitMagic;
			buttonCZA.Position = Position with { X = 225.0f,  Y = 275.0f  };

			buttonHP = new Button();
			buttonHP.Text = "Rzuć na HP";
			buttonHP.Pressed += InitHealth;
			buttonHP.Position = Position with { X = 565.0f,  Y = 230.0f  };

			buttonZB = new Button();
			buttonZB.Text = "Rzuć na zęby";
			buttonZB.Pressed += InitTeeth;
			buttonZB.Position = Position with { X = 675.0f,  Y = 230.0f  };
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if(goblin is null)
		{
			goblin = new Goblin();
		}

		var firstLetter = new TextEdit();
		var thirdLetter = new TextEdit();
		firstLetter.Position = Position with { X = 530.0f,  Y = 50.0f  };
		thirdLetter.Position = Position with { X = 570.0f,  Y = 50.0f  };
		firstLetter.Text = goblin.FirstLetter;
		thirdLetter.Text = goblin.ThirdLetter;
		firstLetter.Size = new Vector2() { X = 30, Y = 40};
		thirdLetter.Size = new Vector2() { X = 30, Y = 40};

		AddChild(firstLetter);
		AddChild(thirdLetter);

		if(goblin.isCreated == false)
		{
			InitButtons();
		}

	}

	private void InitButtons()
	{

			AddChild(buttonDZG);


			AddChild(buttonSKR);


			AddChild(buttonCZA);


			AddChild(buttonHP);


			AddChild(buttonZB);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	private void InitStab()
	{
		goblin.Stab = Dice.RollD6();

		RemoveChild(buttonDZG);

		textStab = new Label
		{
			Text = goblin.Stab.ToString(),
			Position = Position with { X = 225.0f, Y = 140.0f },
			LabelSettings = new LabelSettings() { FontColor = Colors.Black }
		};
		AddChild(textStab);
	}
	private void InitSneak()
	{
		goblin.Sneak = Dice.RollD6();

		
		RemoveChild(buttonSKR);

		textSneak = new Label
		{
			Text = goblin.Sneak.ToString(),
			Position = Position with { X = 225.0f, Y = 210.0f },
			LabelSettings = new LabelSettings() { FontColor = Colors.Black }
		};
		AddChild(textSneak);
	}
	private void InitMagic()
	{
		goblin.Magic = Dice.RollD6();

		
		RemoveChild(buttonCZA);

		textMagic = new Label
		{
			Text = goblin.Magic.ToString(),
			Position = Position with { X = 225.0f, Y = 275.0f },
			LabelSettings = new LabelSettings() { FontColor = Colors.Black }
		};
		AddChild(textMagic);
	}
	private void InitHealth()
	{
		goblin.Health = Dice.RollD6() + 4;

		
		RemoveChild(buttonHP);

		textHealth = new Label
		{
			Text = goblin.Health.ToString(),
			Position = Position with { X = 565.0f, Y = 230.0f },
			LabelSettings = new LabelSettings() { FontColor = Colors.Black }
		};
		AddChild(textHealth);
	}
	private void InitTeeth()
	{
		goblin.Teeth = Dice.RollD6() + Dice.RollD6() + 10;

		
		RemoveChild(buttonZB);

		textTeeth = new Label()
		{
			Text = goblin.Teeth.ToString(),
			Position = Position with { X = 675.0f, Y = 230.0f },
			LabelSettings = new LabelSettings() { FontColor = Colors.Black }
		};
		AddChild(textTeeth);
	}
}
