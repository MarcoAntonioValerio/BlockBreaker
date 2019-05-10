﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_Block : MonoBehaviour
{
    //Configuration parameters
    [SerializeField] int maxHits;
    [SerializeField] GameObject sparklesVFX;

    //Cache Reference
    [SerializeField] scp_Ball ball;
    [SerializeField] scp_GameManager gameManager;
    [SerializeField] scp_Level level;

    //States
    [SerializeField] int timesHit;  //Only serialized for debug.


    public int destroyedBlockPoints = 86;

    //On awake, blocksToWin is incremented by one on each block.
    private void Awake()
    {
        AddBlockToTotalIfBreakable();
        gameManager = FindObjectOfType<scp_GameManager>();
    }

    private void Update()
    {
        
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        //Check if script is on, if yes play the Audio, if not return.
        if (ball != null)
        {
            ball.AudioPlayer();
        }
        else return;

        if (tag == "Breakable")
        {
            //Destroy the brick on collision
            Destroy(gameObject);

            //Vfx Sparkles starts
            TriggerSparksVFX();

            //Subtract one brick
            level.blocksToWin--;

            //Add the points of the destroyed brick
            gameManager.totalScore += destroyedBlockPoints;
        }
        
    }

    public void AddBlockToTotalIfBreakable()
    {
        if (tag == "Breakable")
        {
            if (gameManager != null)
            {
                level.blocksToWin++;
            }
        }        
    }

    private void TriggerSparksVFX()
    {
        GameObject sparkle = Instantiate(sparklesVFX, transform.position, transform.rotation);
    }
}
