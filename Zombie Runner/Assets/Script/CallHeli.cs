using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallHeli : MonoBehaviour
{
	bool heliCalled = false;
	AudioSource audioSource;

	void Start ()
	{
		audioSource = GetComponent<AudioSource>();
	}

	void Update ()
	{
		if (Input.GetButton ("CallHeli") && !heliCalled) {
			Vector3 callLocation = transform.position;
			audioSource.Play();
			heliCalled = true;
		}
	}
}