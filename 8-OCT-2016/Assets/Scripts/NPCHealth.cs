using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NPCHealth : MonoBehaviour {

	public Text text;
	public float health = 100f;
	public bool alive = true;
	public Renderer rend;
	
	// Update is called once per frame
	void Update () 
	{
		if (health < 1 && alive)
		{
			alive = false;
			Die ();
		}
	}

	void OnCollisionEnter()
	{
		health -= 10;
	}

	void Die()
	{
		if (text != null)
		{
			text.text = "D'oh!";
			text.gameObject.transform.parent.gameObject.AddComponent<DieAfterTime> ();
		}

		if(rend!= null)
			rend.enabled = false;

		Rigidbody rbody = gameObject.AddComponent<Rigidbody> ();
		rbody.AddForce (Vector3.back);
	}
}
