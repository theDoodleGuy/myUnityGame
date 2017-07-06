using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager
{
	public enum MyAction {Tidy, Reset, EndTurn, EndGame};

	private int[] bowls = new int[21];
	private int bowl = 1;

	public static MyAction NextAction (List<int> pinfFalls)
	{
		ActionManager am = new ActionManager ();
		MyAction currentAction = new MyAction ();

		foreach (int pinFall in pinfFalls)
		{
			currentAction = am.Bowl (pinFall);
		}

		return currentAction;
	}

	MyAction Bowl (int pins)

	{
		if (pins < 0 || pins > 10)
		{
			throw new UnityException ("Invalid pins");
		}

		bowls [bowl - 1] = pins;

		if (bowl == 21)
		{
			return MyAction.EndGame;
		}

		// Handle last-frame special cases
		if ( bowl >= 19 && pins == 10 )
		{
			bowl++;
			return MyAction.Reset;
		}
		else if ( bowl == 20 )
		{
			bowl++;
			if (bowls[19-1]==10 && bowls[20-1]==0)
			{
				return MyAction.Tidy;
			}
			else if (bowls[19-1] + bowls[20-1] == 10)
			{
				return MyAction.Reset;
			}
			else if ( Bowl21Awarded() )
			{
				return MyAction.Tidy;
			}
			else
			{
				return MyAction.EndGame;
			}
		}

		if (bowl % 2 != 0) // First bowl of frame
		{
			if (pins == 10)
			{
				bowl += 2;
				return MyAction.EndTurn;
			}
			else
			{
				bowl += 1;
				return MyAction.Tidy;
			}
		}
		else if (bowl % 2 == 0) // Second bowl of frame
		{
			bowl += 1;
			return MyAction.EndTurn;
		}

		throw new UnityException ("Not sure what action to return!");
	}

	private bool Bowl21Awarded ()
	{
		// Remember that arrays start counting at 0
		return (bowls [19-1] + bowls [20-1] >= 10);
	}
}