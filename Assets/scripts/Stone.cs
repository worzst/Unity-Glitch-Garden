using UnityEngine;
using System.Collections;

public class Stone : MonoBehaviour {

	private Animator anim;

	void Start() {
		anim = GetComponent<Animator>();
	}

	void Update() {
		
	}

	void OnTriggerStay2D (Collider2D col) {
		Attacker attacker = col.gameObject.GetComponent<Attacker>();

		if (attacker) {
			anim.SetTrigger("underAttack trigger");
		}
	}

}
