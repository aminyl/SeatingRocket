using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Posing : MonoBehaviour
{
	public GameObject targetObj;
	public string[] targetParts;
	public Transform[] partsObj;
	public Quaternion[] quaternion;


	// Use this for initialization
	void Start ()
	{
		targetParts = new string[] {
			"EthanRightShoulder",
			"EthanRightArm",
			"EthanRightForeArm",
			"EthanLeftShoulder",
			"EthanLeftArm",
			"EthanLeftForeArm",
			"EthanRightUpLeg",
			"EthanRightLeg",
			"EthanRightFoot",
			"EthanLeftUpLeg",
			"EthanLeftLeg",
			"EthanLeftFoot"
		};
		partsObj = new Transform[targetParts.Length];
		quaternion = new Quaternion[targetParts.Length];
		Transform[] children = targetObj.GetComponentsInChildren<Transform> ();
		foreach (Transform c in children)
			for (int i = 0; i < targetParts.Length; i++) {
				if (c.name == targetParts [i]) {
					partsObj [i] = c;
					break;
				}
			}
		for (int i = 0; i < targetParts.Length; i++) {
			quaternion [i] = partsObj [i].rotation;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
