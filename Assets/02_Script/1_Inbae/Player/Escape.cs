using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour
{
    Transform tr;
    public GameObject ClearLogo;

    void Start()
    {
        tr = gameObject.transform;
    }

    void Update()
    {
        if (tr.childCount > 1)
            ClearLogo.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0);
    }
}
