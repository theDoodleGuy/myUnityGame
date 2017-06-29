using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
	public float standingThreshold = 35f;
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

		//ceck if fallen over
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
		}
	}

	public void Lower ()
	{
		if (IsStanding ()) {
			transform.Translate(new Vector3 (0, -distToRaise, 0),Space.World );
			GetComponent<Rigidbody>().useGravity = true;
		}
	}
}