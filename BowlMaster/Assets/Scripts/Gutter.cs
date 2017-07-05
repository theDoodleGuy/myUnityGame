using UnityEngine;

public class Gutter : MonoBehaviour
{
	PinSetter pinSetter;

	void Start ()
	{
		pinSetter = FindObjectOfType<PinSetter>();
	}

	void OnTriggerExit (Collider col)
	{
		if (col.GetComponent<Ball> ()) {
			pinSetter.ballLeftBox = true;
			pinSetter.pinCount.color = Color.red;
		}
	}
}