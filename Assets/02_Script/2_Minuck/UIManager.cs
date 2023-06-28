using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text MoveCount;

    public PlayerGuideCorutine playerGuide;

    // Start is called before the first frame update
    void Start()
    {
        MoveCount.text = playerGuide.moveCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        MoveCount.text = playerGuide.moveCount.ToString();
    }
}
