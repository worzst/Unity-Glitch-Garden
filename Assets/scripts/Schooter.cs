using UnityEngine;
using System.Collections;

public class Schooter : MonoBehaviour {

	public GameObject projectile, gun;

	private GameObject projectileParent;

	private Animator anim;

	private Spawner myLaneSpawner;

	void Start() {
		anim = GetComponent<Animator>();

		SetMyLaneSpawner();

		//Creates a parent for projectiles if necessary
		projectileParent = GameObject.Find("Projectiles");
		if (!projectileParent) {
			projectileParent = new GameObject("Projectiles");
		}
	}

	void Update() {
		if (IsAttackerAheadInLane()) {
			anim.SetBool("isAttacking", true);
		} else {
			anim.SetBool("isAttacking", false);
		}
	}

	void SetMyLaneSpawner() {
		Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();

		foreach (Spawner spawner in spawnerArray) {
			if (spawner.transform.position.y == transform.position.y) {
				myLaneSpawner = spawner;
				Debug.Log("Spawner found: " + spawner);
				return;
			}
		}
		Debug.LogError (name + " can't find spawner in lane");
	}

	bool IsAttackerAheadInLane() {
		//Exit if no attackers in lane
		if (myLaneSpawner.transform.childCount <= 0) {
			return false;
		}

		//IF there are attackers, are they ahead?
		foreach (Transform attacker in myLaneSpawner.transform) {
			if (attacker.transform.position.x > transform.position.x) {
				return true;
			}
		}

		//attackers in lane but behind us
		return false;
	}

	private void Fire() {
		GameObject newProjectile = Instantiate (projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
}
