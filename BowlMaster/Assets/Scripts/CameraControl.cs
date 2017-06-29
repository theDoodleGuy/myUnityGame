using UnityEngine;

public class CameraControl : MonoBehaviour
{
	public Ball ball;
	public GameObject headPin;
	float maxZ;

	Vector3 offset;

	void Start ()
	{
		offset = transform.position - ball.transform.position;
		maxZ = headPin.transform.position.z + offset.z;
	}

	void Update ()
	{
		if (ball.transform.position.z <= maxZ)
		{
			transform.position = ball.transform.position + offset;
		}
	}
}