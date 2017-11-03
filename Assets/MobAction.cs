using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAction : MonoBehaviour
{
	Animator animator;
	float delay_0, delay_1;

	// Use this for initialization
	void Start ()
	{
		animator = GetComponent<Animator> ();
	}

	public void Initialize(float d_0, float d_1){
		delay_0 = d_0;
		delay_1 = d_1;
		StartCoroutine (Move());
	}

	IEnumerator Move1(){
		yield return new WaitForSeconds(delay_0);
		animator.SetBool ("isStanding", true);
		yield return new WaitForSeconds(delay_1);
		animator.SetBool ("isWalking", true);
		yield return null;
	}

	IEnumerator Move(){
		float t = 0;
		while (t < delay_0) {
			t += Time.deltaTime;
			yield return null;
		}
		animator.SetBool ("isStanding", true);

		t = 0;
		while (t < delay_1) {
			t += Time.deltaTime;
			yield return null;
		}
		animator.SetBool ("isWalking", true);
		yield return null;
	}
}