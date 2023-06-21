using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : MonoBehaviour
{
    GameObject gamemanager;

    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
    }

    public void AddMoveCount()
    {
        gamemanager.GetComponent<GameManager>().LeftMoveCount += 5;
    }
}
