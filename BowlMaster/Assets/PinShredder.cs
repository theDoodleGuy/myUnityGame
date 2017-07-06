using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinShredder : MonoBehaviour
{
	void OnTriggerExit (Collider col)
	{
		if (col.GetComponent<Pin> ()) {
			Destroy (col.gameObject);
		}
	}
}