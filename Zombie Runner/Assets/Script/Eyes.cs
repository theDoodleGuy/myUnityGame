using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
	Camera eyes;
	float defaultFOV;

	void Start ()
	{
		eyes = GetComponent<Camera>();
		defaultFOV = eyes.fieldOfView;
	}

	void Update ()
	{
		if (Input.GetButton ("Zoom")) {
			eyes.fieldOfView = defaultFOV / 1.5f;
		} else {
			eyes.fieldOfView = defaultFOV;
		}
	}
}