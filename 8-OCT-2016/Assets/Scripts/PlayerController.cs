using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour {

	public Player player;
	public Image moveModeImage;
	public Image attackModeImage;

	private bool attackModeOn = false;
	private bool moveModeOn = false;

	public LayerMask layerMask;

	public bool MoveModeOn
	{
		get
		{
			return moveModeOn;
		}

		set
		{ 
			moveModeOn = value;
			if (value == true)
			{
				AttackModeOn = false;
				moveModeImage.color = Color.grey;
			} 
			else
			{
				moveModeImage.color = Color.white;
			}
		}
	}

	public bool AttackModeOn
	{
		get
		{
			return attackModeOn;
		}

		set
		{ 
			attackModeOn = value;
			if (value == true)
			{
				MoveModeOn = false;
				attackModeImage.color = Color.grey;
			} 
			else
			{
				attackModeImage.color = Color.white;
			}
			
		}
	}

	void Start () 
	{
	}
	
	void Update () 
	{
		if (EventSystem.current.IsPointerOverGameObject ())
		{
		} else
		{

			if (Application.platform == RuntimePlatform.WindowsEditor)
			{
				if (Input.GetButtonDown ("Fire1"))
				{
					RaycastHit hit;
					Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
					if (Physics.Raycast (ray, out hit, 100, layerMask))
					{
						HandleTouch (hit.point);
					}
				}
			}


			for (int i = 0; i < Input.touchCount; i++)
			{
				Touch touch = Input.GetTouch (i);
				if (touch.phase == TouchPhase.Began)
				{
					if (touch.position.x < (Screen.width / 4) || touch.position.y < (3*Screen.height / 4))
					{
						RaycastHit hit;
						Ray ray = Camera.main.ScreenPointToRay (touch.position);
						if (Physics.Raycast (ray, out hit, 100, layerMask))
						{
							HandleTouch (hit.point);
						}
					}
				}
			}
		}
	}

	void HandleTouch(Vector3 position)
	{
		if (MoveModeOn)
		{
			player.SetMoveTarget (position);
		}

		if (AttackModeOn)
		{
			player.Attack (position);
		}
	}
}
