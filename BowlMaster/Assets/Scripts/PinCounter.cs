using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour
{
	Text pinCount;

	float lastChangeTime;
	int lastStandingCount = -1;
	int lastSettledCount;
	bool ballLeftBox = false;

	GameManager gameManager;

	void Start ()
	{
		gameManager = GameObject.FindObjectOfType<GameManager>();

		lastSettledCount = CountStanding();
		pinCount = GameObject.Find("PinsStandingDisplay").GetComponent<Text>();
		pinCount.text = lastSettledCount.ToString ();
	}

	void Update ()
	{
		if (ballLeftBox) {
			Debug.Log ("Ball out!");
			CheckStanding ();
			pinCount.text = CountStanding ().ToString ();

			return;
		}
		Debug.Log("Ball in!");
	}

	void OnTriggerExit (Collider col)
	{
		if (col.GetComponent<Ball> ()) {
			ballLeftBox = true;
			pinCount.color = Color.red;
		}
	}

	public void Reset ()
	{
		lastSettledCount = 10;
	}

	void CheckStanding ()
	{
		int currentStanding = CountStanding ();

		if (currentStanding != lastStandingCount) {
			lastChangeTime = Time.time;
			lastStandingCount = currentStanding;
			return;
		}

		float settleTime = 3f;		// How long to wait to consider pins settled
		if ((Time.time - lastChangeTime) > settleTime) { //If last change > 3s ago
			PinsHaveSettled ();
		}
	}

	void PinsHaveSettled ()
	{
		int standing = CountStanding ();
		int pinFall = lastSettledCount - standing;
		lastSettledCount = standing;

		gameManager.Bowl(pinFall);

		lastStandingCount = -1;		//Indicates pins have settled, and ball not back in box
		pinCount.color = Color.green;
		ballLeftBox = false;
	}

	int CountStanding ()
	{
		int standing = 0;
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			if (pin.IsStanding ()) {
				standing ++;
			}
		}
		return standing;
	}
}