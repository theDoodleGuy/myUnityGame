using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager
{
	//Returns a list of cumulative scores, like a scorecard
	public static List<int> ScoreCumulative (List<int> rolls)
	{
		List<int> cumulativeScores = new List<int>();
		int runningTotal = 0;

		foreach (int frameScore in ScoreFrames(rolls))
		{
			runningTotal += frameScore;
			cumulativeScores.Add (runningTotal);
		}
		return cumulativeScores;
	}

	//Return a list of individual frame scores
	public static List<int> ScoreFrames (List<int> rolls)
	{
		List<int> frameScore = new List<int> ();

		for (int i = 0; i < rolls.Count; i += 2) {

			if (i + 1 != rolls.Count) {
				//handle strike
				if (rolls [i] == 10) {
					//if bonus value known
					if (i == 18) {
						frameScore.Add (10 + rolls [i + 1] + rolls [i + 2]);
					}
					else if (rolls.Count > i + 2) {
						frameScore.Add (10 + rolls [i + 1] + rolls [i + 2]);
						rolls.Insert ((i + 1), 0);
					}
					//if bonus value unknown
					else {
						return frameScore;
					}
				}
				// handle spare
				else if (rolls [i] + rolls [i + 1] == 10) {
					int frameTotal = rolls [i] + rolls [i + 1];
					//if bonus value known
					if (rolls.Count > i + 2) {
						frameScore.Add (frameTotal + rolls [i + 2]);
					}
					//if bonus value unknown
					else {
						return frameScore;
					}
				} else {
					frameScore.Add (rolls [i] + rolls [i + 1]);
				}
			} else {
				return frameScore;
			}
		}
		return frameScore;
	}
}