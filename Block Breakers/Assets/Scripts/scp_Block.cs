using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_Block : MonoBehaviour
{
    //Configuration parameters
    [SerializeField] int maxHits;
    [SerializeField] GameObject sparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    //Cache Reference
    [SerializeField] scp_Ball ball;
    [SerializeField] scp_GameManager gameManager;
    [SerializeField] scp_Level level;

    //States
    [SerializeField] int timesHit;  //Only serialized for debug.
    private int firstDamage = 1;
    private int secondDamage = 2;
    private int[] damageCounter;

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
            HandleHit();

        }

    }

    private void HandleHit()
    {
        //Adds one to times hit
        timesHit++;

        if (timesHit >= maxHits)
        {
            DestroyTheBlock();
        }
        else
        {
            showNextHitSprites();
        }
    }

    private void showNextHitSprites()
    {
        
        switch (timesHit)
        {
            case 1:
                GetComponent<SpriteRenderer>().sprite = hitSprites[0];
                break;

            case 2:
                GetComponent<SpriteRenderer>().sprite = hitSprites[1];
                break;

            default:
                Debug.Log("Default case triggered");
                break;
        }

    }

    private void DestroyTheBlock()
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
        Destroy(sparkle, 1f);
    }
}
