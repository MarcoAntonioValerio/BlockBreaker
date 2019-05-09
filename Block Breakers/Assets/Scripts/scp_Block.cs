using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_Block : MonoBehaviour
{
    [SerializeField] scp_Ball ball;
    [SerializeField] scp_GameManager gameManager;

    //On awake, blocksToWin is incremented by one on each block.
    private void Awake()
    {
        gameManager.blocksToWin++;
    }

    //Audio starts on collision, the GameObject is destroyed, 1 is subtracted from blocksToWin.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        //Check if script is on, if not return
        if (ball != null)
        {
            ball.AudioPlayer();
        }
        else return;

        //Destroy the brick on collision
        Destroy(gameObject);
        gameManager.blocksToWin--;        
    }    
}
