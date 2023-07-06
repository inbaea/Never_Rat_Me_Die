using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InMenuDestroy : MonoBehaviour
{
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "00_Start" || SceneManager.GetActiveScene().name == "01_StageSelect")
        {
            Destroy(gameObject);
        }
    }
}
