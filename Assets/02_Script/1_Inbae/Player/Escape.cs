using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour
{
    Transform tr;
    public GameObject ClearLogo;
    public GameObject PlayerScript;
    public bool canEscape = true;

    void Start()
    {
        tr = gameObject.transform;
        PlayerScript = GameObject.Find("Player");
    }

    void Update()
    {
        for (int i = 0; i < tr.childCount; i++)
        {
            if (tr.GetChild(i).name == "Stone")
            {
                canEscape = false;
            }
        }
        if (tr.childCount > 1 && canEscape)
        {
            PlayerScript.GetComponent<Move>().canMove = false;
            ClearLogo.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0);
        }
    }
}
