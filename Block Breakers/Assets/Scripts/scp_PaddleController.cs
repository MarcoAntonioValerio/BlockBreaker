using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_PaddleController : MonoBehaviour
{
    //Configuration Parameters
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float leftBoudary = 1f;
    [SerializeField] float rightBoudary = 15f;
   

    
                                                                   
    // Update is called once per frame
    void Update()
    {
        MouseController();
    }

    void MouseController()
    {
        float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePosInUnits, leftBoudary, rightBoudary);
        transform.position = paddlePos;
    }
}
