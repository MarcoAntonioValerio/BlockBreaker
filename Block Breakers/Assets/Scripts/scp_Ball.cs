using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class scp_Ball : MonoBehaviour
{
    // Config Parameters
    [SerializeField] scp_PaddleController paddle_1;
    

    [SerializeField] AudioClip[] ballArray;

    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    

    // States
    private Vector2 paddleToBallVector;
    private bool gameHasStarted = false;
    private AudioSource audioSource;
    private TrailRenderer trail;

    
    

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle_1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameHasStarted)
        {
            BallStartingPosition();
            LaunchOnMouseClick();
        }
        trailMethod();
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {            
            gameHasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);            
        }
    }

    private void BallStartingPosition()
    {
        Vector2 paddlePos = new Vector2(paddle_1.transform.position.x, paddle_1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }
    
    
    public void AudioPlayer()
    {
        Debug.Log("AudioPlayer() is firing.");
        //Get the AudioSource
        audioSource = GetComponent<AudioSource>();

        //Switch between clips randomly
        AudioClip clip = ballArray[UnityEngine.Random.Range(0, ballArray.Length)];

        //Change the pitch of the sound on a Random Range between 0.1/1
        audioSource.pitch = (UnityEngine.Random.Range(0.1f, 1f));

        //Play the sounds
        audioSource.PlayOneShot(clip);
    }

    void trailMethod()
    {
        trail = GetComponent<TrailRenderer>();
        if (trail != null)
        {
            if (!gameHasStarted)
            {
                trail.enabled = false;
            }
            else if (gameHasStarted)
            {
                trail.enabled = true;
            }
        }
        
    }

}
