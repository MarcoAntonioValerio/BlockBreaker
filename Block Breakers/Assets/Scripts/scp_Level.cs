using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_Level : MonoBehaviour
{
    [SerializeField] scp_SceneLoader loader;
    [SerializeField] scp_GameManager gameManager;

    public int blocksToWin;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<scp_GameManager>();
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
            gameManager.gameSpeed = 1f;

        }
    }
}
