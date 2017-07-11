using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	List <int> rolls = new List <int> ();

	PinSetter pinsetter;
	Ball ball;
	ScoreDisplay scoreDisplay;


	void Start ()
	{
		pinsetter = GameObject.FindObjectOfType<PinSetter>();
		ball = GameObject.FindObjectOfType<Ball>();
		scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();
	}

	public void Bowl (int pinFall)
	{
		try {
			rolls.Add (pinFall);
			ball.Reset ();
			pinsetter.PinSetterAction (ActionManager.NextAction (rolls));
		} catch {
			Debug.LogWarning("Something went wrong with Bowl()");
		}

		try {
			scoreDisplay.FillRolls(rolls);
			scoreDisplay.FillFrames(ScoreManager.ScoreCumulative(rolls));
		} catch {
			Debug.LogWarning("Something went wrong with FillRollCard()");
		}
	}
}