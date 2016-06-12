using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
public class Fox : MonoBehaviour {

	private Animator anim;
	private Attacker attacker;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col) {
		//Debug.Log("Fox collided with " + col);

		GameObject obj = col.gameObject;

		//Leave if not colliding with defender
		if (!obj.GetComponent<Defenders>()) {
			return;
		}

		if (obj.GetComponent<Stone>()) {
			anim.SetTrigger("jump trigger");
		} else {
			anim.SetBool("isAttacking", true);
			attacker.Attack (obj);
		}
	}
}
