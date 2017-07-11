using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
	public Text[] rollScoreDisplay, frameScoreDisplay;

	public void FillRollCard (List<int> rolls)
	{
		rolls[-1] = 1;
	}
}