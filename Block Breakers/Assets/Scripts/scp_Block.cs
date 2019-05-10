using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_Block : MonoBehaviour
{
    [SerializeField] scp_Ball ball;
    [SerializeField] scp_GameManager gameManager;
    [SerializeField] scp_Level level;

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
}
