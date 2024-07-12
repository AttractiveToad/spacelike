using Godot;
using System;

public partial class GameManager : Node
{
	private Label _myScoreLabel;
	private int _score = 0;

	public override void _Ready()
	{
		_myScoreLabel = GetNode<Label>("ScoreLabel");
	}
	public void AddPoint()
	{
		_score++;
		_myScoreLabel.Text = "You collected " + _score + " coins.";
	}
}
