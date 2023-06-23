using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Go2Home : MonoBehaviour
{
    public void Go2InHome()
    {
        SceneManager.LoadScene("00_Start");
    }
}
