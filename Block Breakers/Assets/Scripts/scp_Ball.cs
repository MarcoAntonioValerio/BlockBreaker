using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_Ball : MonoBehaviour
{
    // Config Parameters
    [SerializeField] scp_PaddleController paddle_1;

    // States
    Vector2 paddleToBallVector;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle_1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(paddle_1.transform.position.x, paddle_1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }
}
