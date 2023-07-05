using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int LeftMoveCount;

    private void Awake()
    {
        var obj = FindObjectsOfType<GameManager>();

        if (obj.Length == 1) {
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
  }
}
