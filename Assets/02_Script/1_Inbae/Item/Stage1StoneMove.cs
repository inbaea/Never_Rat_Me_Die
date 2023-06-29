using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1StoneMove : MonoBehaviour
{
    public GameObject MoveScript;
    public GameObject StoneObject;
    
    void Start()
    {
        MoveScript = GameObject.Find("Player");
    }

    public void MeetStone()
    {
        if (gameObject.transform.parent.transform.childCount > 1)
        {
            for (int i = 0; i < gameObject.transform.parent.transform.childCount; i++)
            {
                if (gameObject.transform.parent.transform.GetChild(i).name == "Stone")
                {
                    StoneObject = gameObject.transform.parent.transform.GetChild(i).gameObject;
                    CanStoneMove();
                }
            }
        }
    }

    public void CanStoneMove()
    {
        if (MoveScript.GetComponent<Stage1Move>().Lefted)
        {
            if (MoveScript.GetComponent<Stage1Move>().block_num == 0 || MoveScript.GetComponent<Stage1Move>().block_num == 1 || MoveScript.GetComponent<Stage1Move>().block_num == 2 || MoveScript.GetComponent<Stage1Move>().block_num == 6 || MoveScript.GetComponent<Stage1Move>().block_num == 7 || MoveScript.GetComponent<Stage1Move>().block_num == 20)
                return;
            
            int newblock_num;
            if (MoveScript.GetComponent<Stage1Move>().block_num == 3 || MoveScript.GetComponent<Stage1Move>().block_num == 4 || MoveScript.GetComponent<Stage1Move>().block_num == 5)
                newblock_num = MoveScript.GetComponent<Stage1Move>().block_num - 3;
            else newblock_num = MoveScript.GetComponent<Stage1Move>().block_num - 4;
            string MoveStoneHere_num = "Block" + newblock_num;
            GameObject MoveStoneHere = GameObject.Find(MoveStoneHere_num);

            for (int i = 0; i < MoveStoneHere.transform.childCount; i++)
            {
                if (MoveStoneHere.transform.GetChild(i).name == "Stone")
                {
                    return;
                }
                if (MoveStoneHere.transform.GetChild(i).name == "Escape")
                {
                    return;
                }
            }
            StoneObject.transform.SetParent(MoveStoneHere.transform);
            StoneObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0);
        }

        if (MoveScript.GetComponent<Stage1Move>().Righted)
        {
            if (MoveScript.GetComponent<Stage1Move>().block_num == 5 || MoveScript.GetComponent<Stage1Move>().block_num == 21 || MoveScript.GetComponent<Stage1Move>().block_num == 22 || MoveScript.GetComponent<Stage1Move>().block_num == 23)
                return;

            int newblock_num;
            if (MoveScript.GetComponent<Stage1Move>().block_num == 3 || MoveScript.GetComponent<Stage1Move>().block_num == 4 || MoveScript.GetComponent<Stage1Move>().block_num == 16 || MoveScript.GetComponent<Stage1Move>().block_num == 17 || MoveScript.GetComponent<Stage1Move>().block_num == 18 || MoveScript.GetComponent<Stage1Move>().block_num == 19 || MoveScript.GetComponent<Stage1Move>().block_num == 20)
                newblock_num = MoveScript.GetComponent<Stage1Move>().block_num + 5;
            else newblock_num = MoveScript.GetComponent<Stage1Move>().block_num + 4;
            string MoveStoneHere_num = "Block" + newblock_num;
            GameObject MoveStoneHere = GameObject.Find(MoveStoneHere_num);
            for (int i = 0; i < MoveStoneHere.transform.childCount; i++)
            {
                if (MoveStoneHere.transform.GetChild(i).name == "Stone")
                {
                    return;
                }
                if (MoveStoneHere.transform.GetChild(i).name == "Escape")
                {
                    return;
                }
            }
            StoneObject.transform.SetParent(MoveStoneHere.transform);
            StoneObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0);
        }

        if (MoveScript.GetComponent<Stage1Move>().Uped)
        {
            if (MoveScript.GetComponent<Stage1Move>().block_num == 4 || MoveScript.GetComponent<Stage1Move>().block_num == 5 || MoveScript.GetComponent<Stage1Move>().block_num == 6)
            {
                int newblock_num = MoveScript.GetComponent<Stage1Move>().block_num + 1;
                string MoveStoneHere_num = "Block" + newblock_num;
                GameObject MoveStoneHere = GameObject.Find(MoveStoneHere_num);
                for (int i = 0; i < MoveStoneHere.transform.childCount; i++)
                {
                    if (MoveStoneHere.transform.GetChild(i).name == "Stone")
                    {
                        return;
                    }
                    if (MoveStoneHere.transform.GetChild(i).name == "Escape")
                    {
                        return;
                    }
                }
                StoneObject.transform.SetParent(MoveStoneHere.transform);
                StoneObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0);
            }
            else return;
        }
    }
}