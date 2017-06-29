using UnityEngine.UI;
using UnityEngine;

public class PinSetter : MonoBehaviour
{
	public int lastStandingCount = -1;
	public Text pinCount;
	public float raiseHeight = 40f;
	public GameObject pinSet;

	float lastChangeTime;
	bool ballEnteredBox = false;
	Ball ball;

	void Start ()
	{
		ball = GameObject.FindObjectOfType<Ball>();
		pinCount.text = CountStanding ().ToString ();
	}

	void Update ()
	{
		if (ballEnteredBox) {
			CheckStanding();
			pinCount.text = CountStanding ().ToString ();
		}
	}

	public void RaisePins ()
	{
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			pin.Raise();
		}
	}

	public void RenewPins()
	{
		Instantiate(pinSet, new Vector3( 0, raiseHeight, 1829f ), Quaternion.identity);
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			pin.GetComponent<Rigidbody>().useGravity = false;
		}
	}

	public void LowerPins ()
	{
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()){
			pin.Lower();
		}
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
		lastStandingCount = -1;		//Indicates pins have settled, and ball not back in box
		ballEnteredBox = false;
		pinCount.color = Color.green;
		ball.Reset();
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

	void OnTriggerEnter (Collider col)
	{
		if (col.GetComponent<Ball> () && !ballEnteredBox) {
			ballEnteredBox = true;
			pinCount.color = Color.red;
		}
	}

	void OnTriggerExit (Collider col)
	{
		if (col.GetComponent<Pin> ()) {
			Destroy (col.gameObject);
		}
	}
}