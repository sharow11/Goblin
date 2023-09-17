using Godot;
using System;

public partial class MainMenu : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var button = new Button();
		button.Text = "Click me";
		button.Pressed += ButtonPressed;
		button.Position = Position with { X = 100.0f,  Y = 100.0f  };
		AddChild(button);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	private void ButtonPressed()
	{
		GD.Print("Hello world!");
	}
}
