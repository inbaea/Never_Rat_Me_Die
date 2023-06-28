using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text MoveCount;

    public PlayerGuideCorutine playerGuide;

    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        canvas = gameObject;
        MoveCount = gameObject.transform.Find("MoveCount").gameObject.GetComponent<Text>();
        playerGuide = GameObject.Find("PlayerGuide").gameObject.GetComponent<PlayerGuideCorutine>();
        MoveCount.text = playerGuide.moveCount.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        MoveCount.text = playerGuide.moveCount.ToString();

        if (playerGuide.isStageCleared)
        {
            canvas.transform.Find("StageClear").gameObject.SetActive(true);
        }

        if (playerGuide.moveCount <= 0)
        {
            canvas.transform.Find("FailedToClear").gameObject.SetActive(true);
        }
    }
}
