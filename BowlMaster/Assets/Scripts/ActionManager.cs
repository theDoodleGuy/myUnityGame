using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager
{
	public enum MyAction {Tidy, Reset, EndTurn, EndGame};
	//MyAction myAction = 0;

	int[] bowls = new int [21];
	public int bowl = 1;

	//New myAction method REFACTOR
	public static MyAction NextAction (List<int> pinFalls)
	{
		//code goes here
		ActionManager actionManager = new ActionManager();
		MyAction currentAction = new MyAction();

		foreach (int pinFall in pinFalls)
		{
			currentAction = actionManager.Bowl(pinFall);
		}
		return currentAction;
	}

	//TODO make private
	public MyAction Bowl (int pins)
	{
		//invalid values
		if (pins > 10 && pins < 0)
			throw new UnityException (pins + " is an invalid value for pins");

		bowls [bowl - 1] = pins;

		//Always end game after bowl 21
		if (bowl == 21)
			return MyAction.EndGame;

		//Handle last frame special cases
		if (bowl == 19 && pins == 10) {
			bowl++;
			return MyAction.Reset;
		} else if (bowl == 20) {
			bowl++;
			if (TwoStrikesLastFrame ()) {
				return MyAction.Reset;
			} else if (Bowl21Awarded ()) {
				return MyAction.Tidy;
			} else {
				return MyAction.EndGame;
			}
		}

		//End turn on strike
		if (bowl % 2 != 0 && pins == 10) {
			bowl += 2;
			return MyAction.EndTurn;
		}
		//Tidy if not a strike on first bowl of frame
		if (bowl % 2 != 0) {
			bowl++;
			return MyAction.Tidy;
		} else if (bowl % 2 == 0) {
			bowl++;
			return MyAction.EndTurn;
		}	
		throw new UnityException ("Not sure what action to return!");
	}

	bool Bowl21Awarded ()
	{
		return (bowls [19-1] + bowls [20-1] >= 10);
	}

	bool TwoStrikesLastFrame ()
	{
		return ((bowls [19-1] + bowls [20-1]) % 10 == 0 && bowls[20-1] != 0);
	}
}