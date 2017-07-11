using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	List <int> bowls = new List <int> ();

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
			bowls.Add (pinFall);
			ball.Reset ();
			pinsetter.PinSetterAction (ActionManager.NextAction (bowls));
		} catch {
			Debug.LogWarning("Something went wrong with Bowl()");
		}

		try {
			scoreDisplay.FillRollCard(bowls);
		} catch {
			Debug.LogWarning("Something went wrong with FillRollCard()");
		}
	}
}