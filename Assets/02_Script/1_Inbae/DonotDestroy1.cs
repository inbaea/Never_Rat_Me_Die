using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonotDestroy1 : MonoBehaviour
{
    private void Awake()
    {
        var obj = FindObjectsOfType<DonotDestroy1>();

        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
  }
}
