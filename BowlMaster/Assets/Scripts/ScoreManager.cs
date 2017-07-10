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

		//set second roll as zero if strike
		for (int i = 0; i < rolls.Count; i++) {

			if (rolls [i] == 10) {
				rolls.Insert ((i + 1), 0);
			}
		}

		//loop through every 2 rolls to get frame total
		for (int i = 0; i < rolls.Count; i += 2) {
			int frameTotal;

			if (i + 1 != rolls.Count) {
				frameTotal = rolls [i] + rolls [i + 1];

				if (frameTotal == 10) {

					Debug.Log ("roll1 = " + rolls [i]);
					Debug.Log ("roll2 = " + rolls [i + 1]);
					Debug.Log ("total = " + frameTotal);

					//handle strike
					if (rolls [i] == 10) {
						Debug.Log ("Strike");
						//if bonus value known
						if (rolls.Count > i + 3) {

							Debug.Log ("NEXT FRAME roll1 = " + rolls [i + 2]);
							Debug.Log ("NEXT FRAME roll2 = " + rolls [i + 3]);

							int strikeBonus = rolls [i + 2] + rolls [i + 3];
							frameScore.Add (frameTotal + strikeBonus);
						}
						//if bonus value unknown
						else {
							return frameScore;
						}
					}
					// handle spare
					else {
						Debug.Log ("Spare");
						//if bonus value known
						if (rolls.Count > i + 2) {
							int spareBonus = rolls [i + 2];
							frameScore.Add (frameTotal + spareBonus);
						}
						//if bonus value unknown
						else {
							return frameScore;
						}
					}
				}

				else {
					frameScore.Add (frameTotal);
				}
			} else {
				return frameScore;
			}
		}

		return frameScore;
	}
}