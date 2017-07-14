using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public bool respawn;
	public Transform[] spawnPoints;

	void Start ()
	{
		spawnPoints = GameObject.Find ("PlayerSpawnPoints").GetComponentsInChildren<Transform> ();
		respawn = true;
	}

	void Update ()
	{
		if (respawn) {
			SpawnPlayer();
		}
	}

	void SpawnPlayer ()
	{
		int spawn = Random.Range(1,spawnPoints.Length-1);
		Vector3 spawnPos = spawnPoints[spawn].transform.position;
		transform.position = spawnPos;
		respawn = false;
	}

}