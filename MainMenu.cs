using Godot;
using System;

public partial class MainMenu : Node2D
{
	public override void _EnterTree()
	{
		base._EnterTree();
	}
	// Called when the node enters the scene tree for the first time.
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var button = new Button();
		button.Text = "Nowa Gra";
		button.Pressed += ButtonPressed;
		button.Position = Position with { X = 200.0f,  Y = 200.0f  };
		AddChild(button);

		var button2 = new Button();
		button2.Text = "Wyjście";
		button2.Pressed += ButtonExit;
		button2.Position = Position with { X = 200.0f,  Y = 300.0f  };
		AddChild(button2);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	private void ButtonPressed()
	{
		GetTree().ChangeSceneToFile("res://CharacterSheet.tscn");
	}

	private void ButtonExit()
	{
		GetTree().Quit();
	}
}
