using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Go2Stage : MonoBehaviour
{
    public void Go2InStage()
    {
        SceneManager.LoadScene("01_StageSelect");
    }
}
