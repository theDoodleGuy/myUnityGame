using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager
{
	public enum myAction {Tidy, Reset, EndTurn, EndGame};

	int[] bowls = new int [21];
	public int bowl = 1;

	public myAction Bowl (int pins)
	{
		//invalid values
		if (pins > 10 && pins < 0)
			throw new UnityException (pins + " is an invalid value for pins");

		bowls [bowl - 1] = pins;

		//Always end game after bowl 21
		if (bowl == 21)
			return myAction.EndGame;

		//Handle last frame special cases
		if (bowl == 19 && pins == 10) {
			bowl++;
			return myAction.Reset;
		} else if (bowl == 20) {
			bowl++;
			if (AllPinsKnockedDown ()) {
				return myAction.Reset;
			} else if (Bowl21Awarded ()) {
				return myAction.Tidy;
			} else {
				return myAction.EndGame;
			}
		}

		//End turn on strike
		if (bowl % 2 != 0 && pins == 10) {
			bowl += 2;
			return myAction.EndTurn;
		}
		//Tidy if not a strike on first bowl of frame
		if (bowl % 2 != 0) {
			bowl++;
			return myAction.Tidy;
		} else if (bowl % 2 == 0) {
			bowl++;
			return myAction.EndTurn;
		}	
		throw new UnityException ("Not sure what action to return!");
	}

	bool Bowl21Awarded ()
	{
		return (bowls [19-1] + bowls [20-1] >= 10);
	}

	bool AllPinsKnockedDown ()
	{
		return ((bowls [19-1] + bowls [20-1]) % 10 == 0);
	}
}