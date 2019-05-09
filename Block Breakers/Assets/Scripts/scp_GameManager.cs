﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_GameManager : MonoBehaviour
{
    //Tiago is here
    //States
    [SerializeField] scp_SceneLoader loader;
    

    //Config Parameters
    public int blocksToWin;
    public int totalScore = 0;
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
        Debug.Log(totalScore);
    }

    private void youWin()
    {
        if (blocksToWin == 0)
        {            
            loader.LoadNextScene();
            gameSpeed = 1f;
        }
    }

    void SpeedOfTheGame()
    {
        Time.timeScale = gameSpeed;
    }
}
