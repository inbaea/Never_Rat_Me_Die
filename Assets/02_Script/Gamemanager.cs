using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int LeftMoveCount;
    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LeftMoveCount = 999;
    }
}
