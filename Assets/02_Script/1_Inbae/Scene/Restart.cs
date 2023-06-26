using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public GameObject GameManager;
    
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
    }

    public void OnClickRestart()
    {
        GameManager.GetComponent<GameManager>().LeftMoveCount = 25;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
