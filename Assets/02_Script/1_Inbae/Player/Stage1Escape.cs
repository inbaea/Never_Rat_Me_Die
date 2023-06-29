using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Escape : MonoBehaviour
{
    Transform tr;
    public GameObject ClearLogo;
    public GameObject PlayerScript;

    void Start()
    {
        tr = gameObject.transform;
        PlayerScript = GameObject.Find("Player");
    }

    void Update()
    {
        if (tr.childCount > 1)
        {
            PlayerScript.GetComponent<Stage1Move>().canMove = false;
            ClearLogo.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0);
        }
    }
}
