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
		text.text = "D'oh!";
		rend.enabled = false;
		text.gameObject.transform.parent.gameObject.AddComponent<DieAfterTime> ();
	}
}
