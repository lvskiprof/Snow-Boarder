using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField]
    float delayTime = 1f;
    [SerializeField]
    ParticleSystem finishEffect;

    /***
    *       Start is called before the first frame update
    ***
    void Start()
    {
        Disabled
    }   // Start()

    /***
    *       Update is called once per frame
    ***
    void Update()
    {
        Disabled
    }   // Update()

    /***
    *       OnTriggerEnter2D is used to detect when we cross the finish line.
    ***/
    private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.CompareTag("Player"))
        {
            Debug.Log("You finished!");
            finishEffect.Play();
            gameObject.GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", delayTime);
        }   // if
        else
        {
            Debug.Log("Contact with " + collision.tag);
        }   // else
    }   // OnTriggerEnter2D(Collider2D collision)

    /***
    *       ReloadScene is used to restart the level, but called after a delay.
    ***/
    private void ReloadScene()
	{
        SceneManager.LoadScene(0);
    }   // ReloadScene()
}   // class FinishLine