using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball))]
public class DragLaunch : MonoBehaviour
{
	Ball ball;
	Vector3 dragStart, dragEnd;
	float startTime, endTime;
	public float xMin, xMax;

	void Start ()
	{
		ball = GetComponent<Ball>();
	}

	public void MoveStart (float amount) {
		if ( ! ball.ballInPlay) {
			float xPos = Mathf.Clamp(ball.transform.position.x + amount, -50f, 50f);
			float yPos = ball.transform.position.y;
			float zPos = ball.transform.position.z;
			ball.transform.position = new Vector3 (xPos, yPos, zPos);
		}
	}

	public void DragStart ()
	{
		if (ball.ballInPlay)
			return;
		// Capture time and position of drag start
		dragStart = Input.mousePosition;
		startTime = Time.time;
	}

	public void DragEnd ()
	{
		if (ball.ballInPlay)
			return;
		// Launch the ball
		dragEnd = Input.mousePosition;
		endTime = Time.time;

		float dragDuration = endTime - startTime;

		float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
		float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;

		Vector3 launchVelocity = new Vector3(launchSpeedX, 0 , launchSpeedZ);

		ball.LaunchBall(launchVelocity);
		ball.ballInPlay = true;
	}
}