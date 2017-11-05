using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
	public MobManager mobManager;
	public PlayerManager playerManager;
	PlayerAction playerAction;
	int seatNum, playerPos;
	int[] mobPos;
	Vector3 playerVelocity;
	float playerPower;
	Vector3 cameraPos, cameraEulear;
	public Camera MainCamera;

	// Use this for initialization
	void Start ()
	{
		SetParam (2);
	}

	void SetParam (int m)
	{
		switch (m) {
		case 0:
			SetParam_0 ();
			break;
		case 1:
			SetParam_1 ();
			break;
		case 2:
			SetParam_2 ();
			break;
		case 3:
			SetParam_3 ();
			break;
		default:
			SetParamSample ();
			break;
		}
	}

	void SetParamSample ()
	{
		seatNum = 15;
		mobPos = new int[]{ 1, 3, 5, 6, 7 };
		playerPos = 12;
		playerVelocity = new Vector3 (0, 2f, -1);
		playerPower = 0.3f;
		cameraPos = new Vector3 (13, 13, 13);
		cameraEulear = new Vector3 (40, -116, 0);
	}

	void SetParam_0 ()
	{
		seatNum = 7;
		mobPos = new int[]{ 0, 6 };
		playerPos = 1;
		playerVelocity = new Vector3 (0, 0.9f, -1);
		playerPower = 2.4f;
		cameraPos = new Vector3 (5.8f, 7.7f, 5.6f);
		cameraEulear = new Vector3 (51, -115, 0);
	}

	void SetParam_1 ()
	{
		seatNum = 7;
		mobPos = new int[]{ 0, 1, 2, 3, 4, 6 };
		playerPos = 5;
		playerVelocity = new Vector3 (0, 0.3f, -1);
		playerPower = 13;
		cameraPos = new Vector3 (5.8f, 7.7f, 5.6f);
		cameraEulear = new Vector3 (51, -115, 0);
	}

	void SetParam_2 ()
	{
		seatNum = 30;
		mobPos = new int[]{ 0, 1, 2, 3, 4, 5, 7, 9, 10, 14, 17, 18, 19, 20, 21, 23, 24, 25, 26, 27, 29};
		playerPos = 28;
		playerVelocity = new Vector3 (0, 0.1f, -1);
		playerPower = 40;
		cameraPos = new Vector3 (20.2f, 21.4f, 28.2f);
		cameraEulear = new Vector3 (48, -120, 0);
	}

	void SetParam_3 ()
	{
		seatNum = 30;
		mobPos = new int[]{ 0, 1, 2, 3, 4, 5, 7, 9, 10, 14, 17, 18, 19, 20, 21, 23, 24, 25, 26, 27, 29};
		playerPos = 28;
		playerVelocity = new Vector3 (0, 0.1f, -1);
		playerPower = 40;
		cameraPos = new Vector3 (0.4f, 2.4f, -2.4f);
		cameraEulear = new Vector3 (23, 4, 0);
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Z))
			mobManager.Initialize (seatNum, mobPos);
		if (Input.GetKeyDown (KeyCode.X))
			playerManager.GenPlayer (playerPos);
		if (Input.GetKeyDown (KeyCode.C))
			mobManager.StandUp ();
		if (Input.GetKeyDown (KeyCode.V))
			playerManager.player.transform.FindChild ("b").GetComponent<PlayerAction> ().Move ();
		if (Input.GetKeyDown (KeyCode.B))
			StartCoroutine (Run ());
	}

	IEnumerator Run ()
	{
		MainCamera.transform.position = cameraPos;
		MainCamera.transform.eulerAngles = cameraEulear;

		mobManager.Initialize (seatNum, mobPos);
		playerManager.GenPlayer (playerPos);
		yield return new WaitForSeconds (2f);
		mobManager.StandUp ();
		yield return new WaitForSeconds (2f);
		PlayerAction playerAction = playerManager.player.transform.FindChild ("b").GetComponent<PlayerAction> ();
		playerAction.Initialize (playerVelocity, playerPower);
		playerAction.Move ();
		yield return null;
	}
}
