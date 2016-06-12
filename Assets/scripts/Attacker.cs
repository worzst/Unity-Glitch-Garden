using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

	[Tooltip ("Average number of seconds between appearances")]
	public float seenEverySeconds;
	private float currentSpeed;
	private GameObject currentTarget;
	private Animator anim;

	// Use this for initialization
	void Start () {
		//Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D>();
		//myRigidbody.isKinematic = true;
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update() {
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
		if (!currentTarget) {
			anim.SetBool("isAttacking", false);
		}
	}

	void OnTriggerEnter2D () {
		//Debug.Log (name + " trigger enter");
	}

	public void SetSpeed (float speed) {
		currentSpeed = speed;
	}

	// called from the animator at the time of actual blow
	public void StrikeCurrentTarget(float damage) {
		//Debug.Log(name + " caused damage: " + damage);
		if (currentTarget) {
			Health health = currentTarget.GetComponent<Health>();
			if (health) {
				health.DealDamage(damage);
			}
		}
	}

	public void Attack(GameObject obj) {
		currentTarget = obj;
	}
}
