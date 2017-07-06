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

		foreach (int frameScore in ScoreFrames(rolls)) {
			runningTotal += frameScore;
			cumulativeScores.Add (runningTotal);
		}
		return cumulativeScores;
	}

	//Return a list of individual frame scores
	public static List<int> ScoreFrames (List<int> rolls)
	{
		List<int> frameList = new List<int> ();
	
		//code
	
		return frameList;
	}
}