using UnityEngine;
using System.Collections;

public class CombatScript : MonoBehaviour {

	public GameObject spell;
	private GameObject spellInstance;
	private BasicAttack basicAttackInstance;

	void Start () 
	{
	
	}
	
	void Update () 
	{
	
	}

	public void Attack(Vector3 position)
	{
		Vector3 attackStart = Vector3.MoveTowards (transform.position, position, 2f);
		spellInstance = GameObject.Instantiate (spell, attackStart, transform.rotation) as GameObject;
		basicAttackInstance = spellInstance.GetComponent<BasicAttack> ();
		basicAttackInstance.SetTarget (position);
	}


}
