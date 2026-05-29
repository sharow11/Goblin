using Godot;
using System;
using System.Drawing;

public partial class CharacterSheet : Node2D
{
	public Goblin goblin { get; set;}

	private Button buttonSTB;
	private Button buttonSNK;
	private Button buttonMAG;
	private Button buttonHP;
	private Button buttonTeeth;

	private Label textStab;

	private Label textSneak;

	private Label textMagic;

	private Label textHealth;

	private Label textTeeth;

	private bool areStatsRolled = false;

	private int statRolledCount = 0;

	public CharacterSheet()
	{

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
		else
		{
			InitLabels();
		}
	}

	private void InitButtons()
	{			
		buttonSTB = new Button();
		buttonSTB.Text = "Roll Stab";
		buttonSTB.Pressed += InitStab;
		buttonSTB.Position = Position with { X = 225.0f,  Y = 140.0f  };

		buttonSNK = new Button();
		buttonSNK.Text = "Roll Sneak";
		buttonSNK.Pressed += InitSneak;
		buttonSNK.Position = Position with { X = 225.0f,  Y = 210.0f  };

		buttonMAG = new Button();
		buttonMAG.Text = "Roll Magic";
		buttonMAG.Pressed += InitMagic;
		buttonMAG.Position = Position with { X = 225.0f,  Y = 275.0f  };

		buttonHP = new Button();
		buttonHP.Text = "Roll Health";
		buttonHP.Pressed += InitHealth;
		buttonHP.Position = Position with { X = 565.0f,  Y = 230.0f  };

		buttonTeeth = new Button();
		buttonTeeth.Text = "Roll Teeth";
		buttonTeeth.Pressed += InitTeeth;
		buttonTeeth.Position = Position with { X = 675.0f,  Y = 230.0f  };

		AddChild(buttonSTB);


		AddChild(buttonSNK);


		AddChild(buttonMAG);


		AddChild(buttonHP);


		AddChild(buttonTeeth);
	}

	private void InitLabels()
	{
		textStab = new Label
		{
			Text = goblin.Stab.ToString(),
			Position = Position with { X = 225.0f, Y = 140.0f },
			LabelSettings = new LabelSettings() { FontColor = Colors.Black }
		};

		AddChild(textStab);

		textSneak = new Label
		{
			Text = goblin.Sneak.ToString(),
			Position = Position with { X = 225.0f, Y = 210.0f },
			LabelSettings = new LabelSettings() { FontColor = Colors.Black }
		};
		AddChild(textSneak);

		textMagic = new Label
		{
			Text = goblin.Magic.ToString(),
			Position = Position with { X = 225.0f, Y = 275.0f },
			LabelSettings = new LabelSettings() { FontColor = Colors.Black }
		};
		AddChild(textMagic);

		textTeeth = new Label()
		{
			Text = goblin.Teeth.ToString(),
			Position = Position with { X = 675.0f, Y = 230.0f },
			LabelSettings = new LabelSettings() { FontColor = Colors.Black }
		};
		AddChild(textTeeth);

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	private void InitStab()
	{
		goblin.Stab = Dice.RollStat();

		RemoveChild(buttonSTB);

		textStab = new Label
		{
			Text = goblin.Stab.ToString(),
			Position = Position with { X = 225.0f, Y = 140.0f },
			LabelSettings = new LabelSettings() { FontColor = Colors.Black }
		};
		AddChild(textStab);
		statRolledCount++;
		if(statRolledCount == 5)
		{
			InitHat();
		}
	}
	private void InitSneak()
	{
		goblin.Sneak = Dice.RollStat();

		
		RemoveChild(buttonSNK);

		textSneak = new Label
		{
			Text = goblin.Sneak.ToString(),
			Position = Position with { X = 225.0f, Y = 210.0f },
			LabelSettings = new LabelSettings() { FontColor = Colors.Black }
		};
		AddChild(textSneak);

		statRolledCount++;
		if(statRolledCount == 5)
		{
			InitHat();
		}
	}
	private void InitMagic()
	{
		goblin.Magic = Dice.RollStat();

		
		RemoveChild(buttonMAG);

		textMagic = new Label
		{
			Text = goblin.Magic.ToString(),
			Position = Position with { X = 225.0f, Y = 275.0f },
			LabelSettings = new LabelSettings() { FontColor = Colors.Black }
		};
		AddChild(textMagic);
		statRolledCount++;
		if(statRolledCount == 5)
		{
			InitHat();
		}
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
		statRolledCount++;
		if(statRolledCount == 5)
		{
			InitHat();
		}
	}
	private void InitTeeth()
	{
		goblin.Teeth = Dice.RollD6() + Dice.RollD6() + 10;

		
		RemoveChild(buttonTeeth);

		textTeeth = new Label()
		{
			Text = goblin.Teeth.ToString(),
			Position = Position with { X = 675.0f, Y = 230.0f },
			LabelSettings = new LabelSettings() { FontColor = Colors.Black }
		};
		AddChild(textTeeth);
		statRolledCount++;
		if(statRolledCount == 5)
		{
			InitHat();
		}
	}
	private void InitHat()
	{
		Button btnTin = null;
		Button btnDirty = null;
		Button btnPointy = null;

		btnTin = new Button();
		btnTin.Text = "Tin Hat";
		btnTin.Position = Position with { X = 200.0f, Y = 500.0f };
		btnTin.Pressed += () =>
		{
			goblin.Hat = GoblinHat.TinHat;
			RemoveChild(btnTin);
			RemoveChild(btnDirty);
			RemoveChild(btnPointy);
			goblin.isCreated = true;
		};

		btnDirty = new Button();
		btnDirty.Text = "Dirty Hood";
		btnDirty.Position = Position with { X = 300.0f, Y = 500.0f };
		btnDirty.Pressed += () =>
		{
			goblin.Hat = GoblinHat.DirtyHood;
			RemoveChild(btnTin);
			RemoveChild(btnDirty);
			RemoveChild(btnPointy);
			goblin.isCreated = true;
		};

		btnPointy = new Button();
		btnPointy.Text = "Pointy Hat";
		btnPointy.Position = Position with { X = 400.0f, Y = 500.0f };
		btnPointy.Pressed += () =>
		{
			goblin.Hat = GoblinHat.PointyHat;
			RemoveChild(btnTin);
			RemoveChild(btnDirty);
			RemoveChild(btnPointy);
			goblin.isCreated = true;
		};

		AddChild(btnTin);
		AddChild(btnDirty);
		AddChild(btnPointy);
	}
}
