using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FramePin : MonoBehaviour
{
    public void Awake()
    {
        Application.targetFrameRate = 60;
    }
}
