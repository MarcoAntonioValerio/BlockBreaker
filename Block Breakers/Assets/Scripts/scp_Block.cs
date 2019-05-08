using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_Block : MonoBehaviour
{
    [SerializeField] scp_Ball ball;

    private void OnCollisionEnter2D(Collision2D collision)
    {        
        Destroy(gameObject);
        if (ball != null)
        {
            ball.AudioPlayer();
        }
        else return;
    }    
}
