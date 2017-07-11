using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ActionManager {
	public enum MyAction {Tidy, Reset, EndTurn, EndGame, Undefined};
	
	public static MyAction NextAction (List<int> rolls) {
		MyAction nextAction = MyAction.Undefined;
		
		for (int i = 0; i < rolls.Count; i++) { // Step through rolls
			
			if (i == 20) {
				nextAction = MyAction.EndGame;
			} else if ( i >= 18 && rolls[i] == 10 ){ // Handle last-frame special cases
				nextAction = MyAction.Reset;
			} else if ( i == 19 ) {
				if (rolls[18]==10 && rolls[19]==0) {
					nextAction = MyAction.Tidy;
				} else if (rolls[18] + rolls[19] == 10) {
					nextAction = MyAction.Reset;
				} else if (rolls [18] + rolls[19] >= 10) {  // Roll 21 awarded
					nextAction = MyAction.Tidy;
				} else {
					nextAction = MyAction.EndGame;
				}
			} else if (i % 2 == 0) { // First bowl of frame
				if (rolls[i] == 10) {
					rolls.Insert (i, 0); // Insert virtual 0 after strike
					nextAction = MyAction.EndTurn;
				} else {
					nextAction = MyAction.Tidy;
				}
			} else { // Second bowl of frame
				nextAction = MyAction.EndTurn;
			}
		}
		
		return nextAction;
	}
}