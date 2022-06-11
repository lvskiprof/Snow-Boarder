using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float torqueAmount = 10.0f;
	[SerializeField]
	float boostSpeed = 30.0f;
	[SerializeField]
	float baseSpeed = 15.0f;
	bool canMove = true;

	Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;

    /***
    *       Start is called before the first frame update
    ***/
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
		surfaceEffector2D.speed = baseSpeed;
    }   // Start()

    /***
    *       Update is called once per frame
    ***/
    void Update()
	{
		if (canMove)
		{	// Check for control key inputs is they are allowed
			RotatePlayer();
			RespondToBoost();
		}	// if
	}   // Update()

	/***
	*       DisableControls is called when another script wants to disable the ability to affect the snowboarder by pressing keys.
	***/

	public void DisableControls()
	{
		canMove = false;
	}   // DisableControls()

	/***
    *       RespondToBoostchecks for the key to boost the speed of the snowboarder.
    ***/
	void RespondToBoost()
	{
		if (Input.GetKey(KeyCode.UpArrow))
		{
			surfaceEffector2D.speed = boostSpeed;
		}	// if
		else
		{
			surfaceEffector2D.speed = baseSpeed;
		}	// else
	}   // RespondToBoost()

	/***
    *       RotatePlayer checks for keys that allow the user to make the snowboarder spin backwards or forwards.
    ***/
	void RotatePlayer()
	{
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			rb2d.AddTorque(torqueAmount);
		}   // if
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			rb2d.AddTorque(-torqueAmount);
		}   // else-if
		else
		{
			rb2d.AddTorque(0);
		}   // else
	}   // RotatePlayer()
}   // class PlayerController