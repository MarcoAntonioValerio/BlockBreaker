using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scp_SceneLoader : MonoBehaviour {
    [SerializeField] scp_GameManager gameManager;

	public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        gameManager = FindObjectOfType<scp_GameManager>();
        gameManager.ResetGameScore();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
