using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_GameManager : MonoBehaviour
{
    //States
    [SerializeField] scp_SceneLoader loader;


    //Config Parameters
    public int blocksToWin = 20;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        youWin();
    }

    private void youWin()
    {
        if (blocksToWin == 0)
        {
            loader.LoadNextScene();
        }
    }
}
