using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField]
    float delayTime = 1f;
    [SerializeField]
    ParticleSystem crashEffect;
    [SerializeField]
    AudioClip crashSFX;
    AudioSource boarderSound;
    bool hasCrashed = false;

    /***
    *       Start is called before the first frame update
    ***/
    void Start()
    {
        boarderSound = gameObject.GetComponent<AudioSource>();
    }   // Start()

    /***
    *       Update is called once per frame
    ***
    void Update()
    {
        Disabled
    }   // Update()

    /***
    *       OnTriggerEnter2D is used to detect when the players head hits the snow.
    ***/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            Debug.Log("Ouch, hit my head!");
            if (!hasCrashed)
            {   // Only execute this code once, but if we bounce it could run again, so prevent that
                hasCrashed = true;
                FindObjectOfType<PlayerController>().DisableControls(); // Display user controls if we crash
                crashEffect.Play();
                gameObject.GetComponent<AudioSource>().PlayOneShot(crashSFX);
                Invoke("ReloadScene", delayTime);
            }   // if
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
}   // class CrashDetector