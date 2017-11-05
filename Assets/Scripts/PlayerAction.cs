using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
	[SerializeField]
	Vector3 v;
	[SerializeField]
	float power;
	Rigidbody rb;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
	}

	public void Initialize(Vector3 _v, float _power){
		v = _v;
		power = _power;
	}

	public void Move ()
	{
		rb.AddForce (v * power, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.A))
			Move ();
	}
}