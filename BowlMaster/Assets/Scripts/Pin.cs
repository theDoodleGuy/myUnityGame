using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
	public float standingThreshold = 15f;
	public float distToRaise;

	void Start ()
	{
		PinSetter pinSetter = GameObject.FindObjectOfType<PinSetter>();
		distToRaise = pinSetter.raiseHeight;
	}

	public bool IsStanding ()
	{
		Vector3 rotationInEuler = transform.rotation.eulerAngles;

		float tiltX = Mathf.Abs (rotationInEuler.x - 270);

		//cHeck if fallen over
		if (tiltX < standingThreshold) {
			return true;
		}
		return false;
	}

	public void Raise ()
	{
		if (IsStanding ()) {
			transform.Translate(new Vector3 (0, distToRaise, 0),Space.World );
			GetComponent<Rigidbody>().useGravity = false;
			GetComponent<Rigidbody> ().isKinematic = true;
			transform.rotation = Quaternion.Euler(270,0,0);
		}
	}

	public void Lower ()
	{
		if (IsStanding ()) {
			transform.Translate(new Vector3 (0, -distToRaise, 0),Space.World );
			GetComponent<Rigidbody>().useGravity = true;
			GetComponent<Rigidbody> ().isKinematic = false;
		}
	}
}