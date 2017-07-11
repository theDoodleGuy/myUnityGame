using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
	public Text[] rollScoreDisplay, frameScoreDisplay;

	public void FillRolls (List<int> rolls)
	{
		string scoreString = FormatRolls(rolls);
		for (int i = 0; i < scoreString.Length; i++) {
			rollScoreDisplay[i].text = scoreString[i].ToString();
		}
	}

	public void FillFrames (List<int> frames)
	{
		for (int i = 0; i < frames.Count; i++) {
			frameScoreDisplay[i].text = frames[i].ToString();
		}
	}

	public static string FormatRolls (List<int> rolls)
	{
		string output = "";

		for (int i = 0; i < rolls.Count; i += 2) {
			if (rolls [i] == 10) {
				output += "X";
				output += " ";
				i--;
			}
			else if (i + 1 < rolls.Count) {
				if (rolls [i] + rolls [i + 1] == 10) {
					output += rolls [i].ToString ();
					output += "/";
				} else {
					output += rolls [i].ToString ();
					output += rolls [i + 1].ToString ();
				}
			} else {
				output += rolls [i].ToString ();
			}
		}

		return output;
	}
}