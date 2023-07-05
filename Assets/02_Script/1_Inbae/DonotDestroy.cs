using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonotDestroy : MonoBehaviour
{
    private void Awake()
    {
        var obj = FindObjectsOfType<DonotDestroy>();

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
