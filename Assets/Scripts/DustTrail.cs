using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField]
    ParticleSystem dustParticles;

    /***
    *        Start is called before the first frame update
    ***
     void Start()
     {

     }   // Start()

     /***
     *       Update is called once per frame
     ***
     void Update()
     {

     }   // Update()

     /***
     *       OnTriggerEnter2D is used to detect when we touch the ground.
     ***/
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Kicking up some snow!");
            dustParticles.Play();
        }   // if
        else
            Debug.Log("Collided with " + other.gameObject.tag);
    }   // OnTriggerEnter2D(Collider2D other)

    /***
    *       OnTriggerExit2D is used to detect when we stop touching the ground.
    ***/
    void OnTriggerExit2D(Collider2D other)
	{
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Catching some air!");
            dustParticles.Stop();
        }   // if
        else
            Debug.Log("Collided with " + other.gameObject.tag);
    }   // OnTriggerExit2D(Collider2D other)
}   // class DustTrail