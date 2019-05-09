using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_GameManager : MonoBehaviour
{
    //States
    [SerializeField] scp_SceneLoader loader;


    //Config Parameters
    public int blocksToWin;
    [Range(0.1f,10f)][SerializeField] float gameSpeed = 1f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        youWin();
        SpeedOfTheGame();
    }

    private void youWin()
    {
        if (blocksToWin == 0)
        {            
            loader.LoadNextScene();
        }
    }

    void SpeedOfTheGame()
    {
        Time.timeScale = gameSpeed;
    }
}
