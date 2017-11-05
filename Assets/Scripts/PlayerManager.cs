using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	public GameObject player, playerPrehab;
	public MobManager mobManager;
	public PositionManager posmanager;

	public void GenPlayer (int pos)
	{
		GameObject seat = mobManager.seats [pos];
		player = Instantiate (playerPrehab);
		player.transform.parent = seat.transform;
		player.transform.localPosition = posmanager.playerPosition;
		player.transform.localRotation = posmanager.playerRotation;
		player.transform.parent = null;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.F))
			GenPlayer (mobManager.seats.Length - 3);
	}
}