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
			buttonDZG.Text = "Rzuć1";
			buttonDZG.Pressed += InitStab;
			buttonDZG.Position = Position with { X = 140.0f,  Y = 60.0f  };

			buttonSKR = new Button();
			buttonSKR.Text = "Rzuć2";
			buttonSKR.Pressed += InitSneak;
			buttonSKR.Position = Position with { X = 140.0f,  Y = 100.0f  };

			buttonCZA = new Button();
			buttonCZA.Text = "Rzuć3";
			buttonCZA.Pressed += InitMagic;
			buttonCZA.Position = Position with { X = 140.0f,  Y = 140.0f  };

			buttonHP = new Button();
			buttonHP.Text = "Rzuć4";
			buttonHP.Pressed += InitHealth;
			buttonHP.Position = Position with { X = 325.0f,  Y = 60.0f  };

			buttonZB = new Button();
			buttonZB.Text = "Rzuć5";
			buttonZB.Pressed += InitTeeth;
			buttonZB.Position = Position with { X = 325.0f,  Y = 100.0f  };
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

		textStab = new Label();
		textStab.Text = goblin.Stab.ToString();
		textStab.Position = Position with { X = 140.0f,  Y = 60.0f  };
		AddChild(textStab);
	}
	private void InitSneak()
	{
		goblin.Sneak = Dice.RollD6();

		
		RemoveChild(buttonSKR);

		textSneak = new Label();
		textSneak.Text = goblin.Sneak.ToString();
		textSneak.Position = Position with { X = 140.0f,  Y = 100.0f  };
		AddChild(textSneak);
	}
	private void InitMagic()
	{
		goblin.Magic = Dice.RollD6();

		
		RemoveChild(buttonCZA);

		textMagic = new Label();
		textMagic.Text = goblin.Magic.ToString();
		textMagic.Position = Position with { X = 140.0f,  Y = 140.0f  };
		AddChild(textMagic);
	}
	private void InitHealth()
	{
		goblin.Health = Dice.RollD6() + 4;

		
		RemoveChild(buttonHP);

		textHealth = new Label();
		textHealth.Text = goblin.Health.ToString();
		textHealth.Position = Position with { X = 325.0f,  Y = 60.0f  };
		AddChild(textHealth);
	}
	private void InitTeeth()
	{
		goblin.Teeth = Dice.RollD6() + Dice.RollD6() + 10;

		
		RemoveChild(buttonZB);

		textTeeth = new Label();
		textTeeth.Text = goblin.Teeth.ToString();
		textTeeth.Position = Position with { X = 325.0f,  Y = 90.0f  };
		AddChild(textTeeth);
	}
}
