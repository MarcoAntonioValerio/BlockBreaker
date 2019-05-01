using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scp_LooseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        SceneManager.LoadScene("scn_03_GameOver", LoadSceneMode.Single);
    }
}
