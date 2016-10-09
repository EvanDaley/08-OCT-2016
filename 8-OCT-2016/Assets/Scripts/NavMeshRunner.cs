using UnityEngine;
using System.Collections;

public class NavMeshRunner : MonoBehaviour {

	public Transform target;
	private NavMeshAgent NavMeshAgent;

	void Start () 
	{
		NavMeshAgent = GetComponent<NavMeshAgent> ();
		NavMeshAgent.updateRotation = false;
	}
	
	public void SetTarget (Transform target)
	{
		this.target = target;

		if(target != null)
			NavMeshAgent.SetDestination (target.transform.position);
	}

	public void SetTarget (Vector3 target)
	{
		NavMeshAgent.SetDestination (target);
	}

}
