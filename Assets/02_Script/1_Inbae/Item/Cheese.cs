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

    void Update()
    {
        for (int i = 0; i < gameObject.transform.parent.transform.childCount; i++)
                {
                    if (gameObject.transform.parent.transform.GetChild(i).name == "Player")
                    {
                        gameObject.SetActive(false);
                        gamemanager.GetComponent<GameManager>().LeftMoveCount += 5;
                    }
                }
    }
}
