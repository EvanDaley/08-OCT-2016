using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private NavMeshRunner navMeshRunner;
	private CombatScript combatScript;

	void Start () {
		navMeshRunner = GetComponent<NavMeshRunner> ();
		combatScript = GetComponent<CombatScript> ();
	}

	public void SetMoveTarget(Vector3 position)
	{
		navMeshRunner.SetTarget (position);
	}

	public void Attack(Vector3 position)
	{
		combatScript.Attack (position);
	}
}
