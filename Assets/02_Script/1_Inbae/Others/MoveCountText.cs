using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCountText : MonoBehaviour
{
    public GameObject GameManager;
    public Text movecountText;
    
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
    }

    void Update()
    {
        movecountText.text = GameManager.GetComponent<GameManager>().LeftMoveCount.ToString();
    }
}
