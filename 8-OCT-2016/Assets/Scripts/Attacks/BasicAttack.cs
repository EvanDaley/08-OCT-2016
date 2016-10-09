using UnityEngine;
using System.Collections;

public class BasicAttack : MonoBehaviour {

	public Rigidbody rbody;
	public float moveForce = 100;

	public void SetTarget(Vector3 position)
	{
		Vector3 direction = (position - transform.position).normalized;
		rbody.AddForce (direction * moveForce);
	}
}
