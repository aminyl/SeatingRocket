using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour
{
	public GameObject seat_1, seat_2;
	public GameObject seatWallL, seatWallR, mob, player;
	public Vector3 seatWallLPosition, seatWallRPosition, mobPosition, playerPosition;
	public Quaternion seatWallLRotation, seatWallRRotation, mobRotation, playerRotation;

	// Use this for initialization
	void Start ()
	{
		seatWallLPosition = seatWallL.transform.localPosition;
		seatWallRPosition = seatWallR.transform.localPosition;
		seatWallLRotation = seatWallL.transform.localRotation;
		seatWallRRotation = seatWallR.transform.localRotation;
		mobPosition = mob.transform.localPosition;
		mobRotation = mob.transform.localRotation;
		playerPosition = player.transform.localPosition;
		playerRotation = player.transform.localRotation;
		Destroy (seat_1.gameObject);
		Destroy (seat_2.gameObject);
	}
}