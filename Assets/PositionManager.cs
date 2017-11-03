using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour {
	public GameObject seat;
	public GameObject seatWallL, seatWallR, mob;
	public Vector3 seatWallLPosition, seatWallRPosition, mobPosition;
	public Quaternion seatWallLRotation, seatWallRRotation, mobRotation;

	// Use this for initialization
	void Start () {
		seatWallLPosition = seatWallL.transform.localPosition;
		seatWallRPosition = seatWallR.transform.localPosition;
		seatWallLRotation = seatWallL.transform.localRotation;
		seatWallRRotation = seatWallR.transform.localRotation;
		mobPosition = mob.transform.localPosition;
		mobRotation = mob.transform.localRotation;
		Destroy (seat.gameObject);
	}
}