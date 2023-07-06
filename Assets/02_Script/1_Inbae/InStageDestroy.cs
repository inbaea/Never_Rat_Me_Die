using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InStageDestroy : MonoBehaviour
{
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Stage1" || SceneManager.GetActiveScene().name == "Stage2" || SceneManager.GetActiveScene().name == "Stage3"
            || SceneManager.GetActiveScene().name == "Stage4" || SceneManager.GetActiveScene().name == "Stage5")
        {
            Destroy(gameObject);
        }
    }
}
