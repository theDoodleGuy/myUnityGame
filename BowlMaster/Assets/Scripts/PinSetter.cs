using UnityEngine.UI;
using UnityEngine;

public class PinSetter : MonoBehaviour
{
	public GameObject pinSet;
	public float raiseHeight = 40f;

	Animator anim;
	PinCounter pinCounter;

	void Start ()
	{
		anim = GetComponent<Animator>();
		pinCounter = FindObjectOfType<PinCounter> ();
	}

	public void PinSetterAction (ActionManager.MyAction myAction)
	{
		switch (myAction)
		{
			case ActionManager.MyAction.Tidy:
				anim.SetTrigger("tidyPinsTrigger");
				break;
			case ActionManager.MyAction.Reset:
				anim.SetTrigger("resetPinsTrigger");
				pinCounter.Reset();
				break;
			case ActionManager.MyAction.EndTurn:
				anim.SetTrigger("resetPinsTrigger");
				pinCounter.Reset();
				break;
			case ActionManager.MyAction.EndGame:
				Debug.Log("Don't know how to handle EndGame yet!");
				break;
			default:
				break;
		}
	}

	//Animator functions
	public void RaisePins ()
	{
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			if (pin.IsStanding ()) {
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
			}
		}
	}
}