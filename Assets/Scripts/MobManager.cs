using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobManager : MonoBehaviour
{
	public GameObject mobPrehab, seatPrehab, seatWallPrehab;
	public GameObject[] mobs, seats;
	public PositionManager posmanager;
	MobAction[] mobActions;

	// Use this for initialization
	public void Initialize (int seatNum, int[] mobPos)
	{
		mobs = new GameObject[mobPos.Length];
		seats = new GameObject[seatNum];
		GenSeats (seatNum);
		GenMobs (mobPos);
	}

	void GenSeats (int seatNum)
	{
		float offset = 1f;
		Vector3 pos = Vector3.zero;
		for (int i = 0; i < seatNum; i++) {
			seats [i] = Instantiate (seatPrehab);
			seats [i].transform.position = pos;
			pos.z += offset;
		}
		GenSeatWalls ();
	}

	void GenSeatWalls ()
	{
		GameObject tmp;
		tmp = Instantiate (seatWallPrehab);
		tmp.transform.parent = seats [0].transform;
		tmp.transform.localPosition = posmanager.seatWallLPosition;
		tmp.transform.localRotation = posmanager.seatWallLRotation;

		tmp = Instantiate (seatWallPrehab);
		tmp.transform.parent = seats [seats.Length - 1].transform;
		tmp.transform.localPosition = posmanager.seatWallRPosition;
		tmp.transform.localRotation = posmanager.seatWallRRotation;
	}

	void GenMobs (int[] mobPos)
	{
		for (int i = 0; i < mobPos.Length; i++) {
			mobs [i] = Instantiate (mobPrehab);
			mobs [i].transform.parent = seats [mobPos [i]].transform;
			mobs [i].transform.localPosition = posmanager.mobPosition;
			mobs [i].transform.localRotation = posmanager.mobRotation;
			mobs [i].transform.parent = null;
		}
	}

	public void StandUp ()
	{
		for (int i = 0; i < mobs.Length - 1; i++)
			mobs [i].GetComponent<MobAction> ().Initialize (Random.Range (0.0f, 0.4f), Random.Range (0.4f, 0.4f));
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.S))
			Initialize (15, new int[]{ 1, 3, 5, 6, 7 });

		if (Input.GetKeyDown (KeyCode.D))
			StandUp ();
	}
}