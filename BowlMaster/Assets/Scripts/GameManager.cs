using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	List <int> bowls = new List <int> ();

	PinSetter pinsetter;
	Ball ball;


	void Start ()
	{
		pinsetter = GameObject.FindObjectOfType<PinSetter>();
		ball = GameObject.FindObjectOfType<Ball>();
	}

	public void Bowl (int pinFall)
	{
		bowls.Add (pinFall);

		ActionManager.MyAction nextAction = ActionManager.NextAction (bowls);
		pinsetter.PinSetterAction(nextAction);
		ball.Reset();
	}
}