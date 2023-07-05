using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InStageDestroy : MonoBehaviour
{
    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Stage2" || SceneManager.GetActiveScene().name == "Stage3")
        {
            Destroy(gameObject);
        }
  }
}
