using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scp_UiManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreTextBox;
    [SerializeField] scp_GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        ScoreBox();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreBox(); 
    }

    void ScoreBox()
    {        
        scoreTextBox.text = "Score: " + gameManager.totalScore.ToString();
    }
}
