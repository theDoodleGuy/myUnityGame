using UnityEngine;

public class Ball : MonoBehaviour
{
	Rigidbody myRigidbody;
	AudioSource audiosource;
	Vector3 ballStartPos;

	public bool ballInPlay = false;

	void Start ()
	{
		ballStartPos = transform.position;
		myRigidbody = GetComponent<Rigidbody>();
		audiosource = GetComponent<AudioSource>();
		myRigidbody.useGravity = false;
	}

	public void LaunchBall (Vector3 velocity)
	{
		myRigidbody.useGravity = true;
		myRigidbody.velocity = velocity;
		audiosource.Play();
	}

	public void Reset ()
	{
		ballInPlay = false;
		myRigidbody.useGravity = false;
		myRigidbody.velocity = Vector3.zero;
		myRigidbody.angularVelocity = Vector3.zero;
		transform.position = ballStartPos;
	}
}