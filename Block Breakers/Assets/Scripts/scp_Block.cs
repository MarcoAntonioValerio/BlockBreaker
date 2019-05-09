using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_Block : MonoBehaviour
{
    [SerializeField] scp_Ball ball;
    [SerializeField] scp_GameManager gameManager;

    private void Awake()
    {
        gameManager.blocksToWin++;
    }
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
