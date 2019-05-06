using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scp_LooseCollider : MonoBehaviour
{
    [SerializeField] scp_SceneLoader sceneLoaderObject;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        sceneLoaderObject.LoadNextScene();
    }
}
