using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_Block : MonoBehaviour
{
    public bool hasCollidedWithBrick = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hasCollidedWithBrick = true;
        Destroy(gameObject);
    }    
}
