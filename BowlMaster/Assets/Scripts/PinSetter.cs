using UnityEngine.UI;
using UnityEngine;

public class PinSetter : MonoBehaviour
{
	public Text pinCount;
	public GameObject pinSet;
	public float raiseHeight = 40f;
	public bool ballLeftBox = false;

	float lastChangeTime;
	int lastStandingCount = -1;
	int lastSettledCount = 10;

	ActionManager actionManager = new ActionManager();

	Ball ball;
	Animator anim;

	void Start ()
	{
		ball = GameObject.FindObjectOfType<Ball>();
		pinCount.text = CountStanding ().ToString ();
		anim = GetComponent<Animator>();
	}

	void Update ()
	{
		if (ballLeftBox) {
			CheckStanding();
			pinCount.text = CountStanding ().ToString ();
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
		int standing = CountStanding ();
		int pinFall = lastSettledCount - standing;
		lastSettledCount = standing;
		ActionManager.MyAction myAction = actionManager.Bowl(pinFall);

		switch (myAction)
		{
			case ActionManager.MyAction.Tidy:
				Debug.Log("TIDY");
				anim.SetTrigger("tidyPinsTrigger");
				break;
			case ActionManager.MyAction.Reset:
				Debug.Log("RESET");
				anim.SetTrigger("resetPinsTrigger");
				lastSettledCount = 10;
				break;
			case ActionManager.MyAction.EndTurn:
				Debug.Log("ENDTURN");
				anim.SetTrigger("resetPinsTrigger");
				lastSettledCount = 10;
				break;
			case ActionManager.MyAction.EndGame:
				Debug.Log("Don't know how to handle EndGame yet!");
				break;
			default:
				break;
		}
		Debug.Log("bowl = " + actionManager.bowl);

		lastStandingCount = -1;		//Indicates pins have settled, and ball not back in box
		ballLeftBox = false;
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

	void OnTriggerExit (Collider col)
	{
		if (col.GetComponent<Pin> ()) {
			Destroy (col.gameObject);
		}
	}

	//Animator functions
	public void RaisePins ()
	{
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			if (pin.IsStanding ()) {
				pin.GetComponent<Rigidbody> ().isKinematic = true;
				pin.transform.rotation = Quaternion.Euler(270,0,0);
				pin.Raise ();
			}
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
			if (pin.IsStanding ()) {
				pin.Lower();
				pin.GetComponent<Rigidbody> ().isKinematic = false;
			}
		}
	}
}