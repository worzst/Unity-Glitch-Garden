﻿using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	[Range(0f, 500f)]
	public float health = 100f;

	public void DealDamage(float damage) {
		health -= damage;
		if (health <= 0) {
			// Optionally trigger animation
			DestroyObject(gameObject);
		}
	}
}
