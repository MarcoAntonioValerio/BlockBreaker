using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class scp_Ball : MonoBehaviour
{
    // Config Parameters
    [SerializeField] scp_PaddleController paddle_1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;

    // States
    Vector2 paddleToBallVector;
    bool gameHasStarted = false;
    private AudioSource audioSource;
    

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameHasStarted)
        {
            AudioPlayer();         
        }
    }

    private void AudioPlayer()
    {
        //Get the AudioSource
        audioSource = GetComponent<AudioSource>();
        //Change the pitch of the sound on a Random Range between 0.1/1
        audioSource.pitch = (UnityEngine.Random.Range(0.1f, 1f));
        //Play the sounds
        audioSource.Play();
    }


}
