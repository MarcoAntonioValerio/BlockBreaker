using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_GameManager : MonoBehaviour
{
    
    //States
    //[SerializeField] scp_SceneLoader loader;
    //[SerializeField] scp_Block block;

    //Config Parameters    
    public int totalScore;    
    [Range(0.1f,10f)]public float gameSpeed = 1f;



    private void Awake()
    {
        DoNotDestroyTheGameManager();        
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
        SpeedOfTheGame();
        Debug.Log(totalScore);
    }

    

    void SpeedOfTheGame()
    {
        Time.timeScale = gameSpeed;
    }

    void DoNotDestroyTheGameManager()
    {
        int managerObjectsCount = FindObjectsOfType<scp_GameManager>().Length;
        if (managerObjectsCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {

            DontDestroyOnLoad(gameObject);
        }        
    }

    public void ResetGameScore()
    {
        totalScore = 0;
    }
}
