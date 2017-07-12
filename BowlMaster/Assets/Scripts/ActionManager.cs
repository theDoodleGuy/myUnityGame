using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ActionManager {
	public enum MyAction {Tidy, Reset, EndTurn, EndGame, Undefined};

	private static int[] bowls = new int[21];
    private static int bowl = 1;

	public static MyAction NextAction(int pins) {
        if (pins < 0 || pins > 10) throw new UnityException("Invalid pin count must be between 1 and 10"); // Make sure we are not sending in an invalid number of pins
 
        bowls[bowl - 1] = pins;
 
        Debug.Log("Bowl: " + bowl + ": " + bowls[bowl - 1]);
 
        //Last Frame
        if (bowl == 19)
        {
            if (pins == 10)
            {
                bowl += 1;
                return MyAction.Reset;
            }
 

        }
 
        else if (bowl == 20)
        {
 
            if (bowls[18] + bowls[19] >= 10)
            {
                bowl += 1;
                if (pins < 10)
                {
                    return MyAction.Tidy;
                }
                else return MyAction.Reset;
            }
            else return MyAction.EndGame;
        }
 
 
        else if (bowl == 21)
        {
            return MyAction.EndGame;
        }
 
 
        if (pins == 10)
        {// if bowled 10
           if (bowl % 2 == 0) {
            bowl ++ ;
        }  else bowl+=2;
 
            return MyAction.EndTurn;
 
        }
       
       
        if (bowl % 2 != 0)
        { // First part of a frame
 
            bowl += 1;
             
             return MyAction.Tidy;
           
        } else if (bowl % 2 == 0)
        { // Second half of a frame
            bowl += 1;
            return MyAction.EndTurn;
        }
 
        //Catch all exception
        throw new UnityException("Not Sure what action to return!");
    }
	
	//public static MyAction NextAction (List<int> rolls) {
	//	MyAction nextAction = MyAction.Undefined;
	//	//List<int> frames = new List<int> ();
	//	
	//	for (int i = 0; i < rolls.Count; i++) { // Step through rolls
	//		if (i == 20) {
	//			nextAction = MyAction.EndGame;
	//		} else if ( i >= 18 && rolls[i] == 10 ){ // Handle last-frame special cases
	//			nextAction = MyAction.Reset;
	//		} else if ( i == 19 ) {
	//			if (rolls[18]==10 && rolls[19]==0) {
	//				nextAction = MyAction.Tidy;
	//			} else if (rolls[18] + rolls[19] == 10) {
	//				nextAction = MyAction.Reset;
	//			} else if (rolls [18] + rolls[19] >= 10) {  // Roll 21 awarded
	//				nextAction = MyAction.Tidy;
	//			} else {
	//				nextAction = MyAction.EndGame;
	//			}
	//		} else if (i % 2 == 0) { // First bowl of frame
	//			if (rolls[i] == 10) {
	//				rolls.Insert (i + 1, 0); // Insert virtual 0 after strike
	//				//i++;
	//				nextAction = MyAction.EndTurn;
	//			} else {
	//				nextAction = MyAction.Tidy;
	//			}
	//		} else { // Second bowl of frame
	//			nextAction = MyAction.EndTurn;
	//		}
	//	}
	//	
	//	return nextAction;
	//}
}