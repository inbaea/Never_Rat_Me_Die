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

    public void GoStage1()
    {
        SceneManager.LoadScene("HelltakerStage1");
    }

    public void GoStage2()
    {
        SceneManager.LoadScene("Stage2");
    }

    public void GoStage3()
    {
        SceneManager.LoadScene("Stage3");
    }

    public void GoStage4()
    {
        SceneManager.LoadScene("HelltakerStage1");
    }
}
