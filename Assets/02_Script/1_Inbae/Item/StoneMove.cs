using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMove : MonoBehaviour
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
                if (gameObject.transform.parent.transform.GetChild(i).name == "MoveableObject")
                {
                    StoneObject = gameObject.transform.parent.transform.GetChild(i).gameObject;
                    CanStoneMove();
                }
            }
        }
    }

    public void CanStoneMove()
    {
        if (MoveScript.GetComponent<Move>().Lefted)
        {
            if (MoveScript.GetComponent<Move>().block_num == 0 || MoveScript.GetComponent<Move>().block_num == 7 || MoveScript.GetComponent<Move>().block_num == 14 || MoveScript.GetComponent<Move>().block_num == 20 || MoveScript.GetComponent<Move>().block_num == 26)
                return;
            int newblock_num = MoveScript.GetComponent<Move>().block_num -1;
            string MoveStoneHere_num = "Block" + newblock_num;
            GameObject MoveStoneHere = GameObject.Find(MoveStoneHere_num);
            for (int i = 0; i < MoveStoneHere.transform.childCount; i++)
            {
                if (MoveStoneHere.transform.GetChild(i).name == "MoveableObject")
                {
                    return;
                }
            }
            StoneObject.transform.SetParent(MoveStoneHere.transform);
            StoneObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0);
        }

        if (MoveScript.GetComponent<Move>().Righted)
        {
            if (MoveScript.GetComponent<Move>().block_num == 6 || MoveScript.GetComponent<Move>().block_num == 13 || MoveScript.GetComponent<Move>().block_num == 19 || MoveScript.GetComponent<Move>().block_num == 25 || MoveScript.GetComponent<Move>().block_num == 31)
                return;
            int newblock_num = MoveScript.GetComponent<Move>().block_num + 1;
            string MoveStoneHere_num = "Block" + newblock_num;
            GameObject MoveStoneHere = GameObject.Find(MoveStoneHere_num);
            for (int i = 0; i < MoveStoneHere.transform.childCount; i++)
            {
                if (MoveStoneHere.transform.GetChild(i).name == "MoveableObject")
                {
                    return;
                }
            }
            StoneObject.transform.SetParent(MoveStoneHere.transform);
            StoneObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0);
        }

        if (MoveScript.GetComponent<Move>().Uped)
        {
            if (MoveScript.GetComponent<Move>().block_num >= 26 || MoveScript.GetComponent<Move>().block_num == 7)
                return;
            int newblock_num;
            if (MoveScript.GetComponent<Move>().block_num < 7)
                newblock_num = MoveScript.GetComponent<Move>().block_num + 7;
            else
                newblock_num = MoveScript.GetComponent<Move>().block_num + 6;
            string MoveStoneHere_num = "Block" + newblock_num;
            GameObject MoveStoneHere = GameObject.Find(MoveStoneHere_num);
            for (int i = 0; i < MoveStoneHere.transform.childCount; i++)
            {
                if (MoveStoneHere.transform.GetChild(i).name == "MoveableObject")
                {
                    return;
                }
            }
            StoneObject.transform.SetParent(MoveStoneHere.transform);
            StoneObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0);
        }

        if (MoveScript.GetComponent<Move>().Downed)
        {
            if (MoveScript.GetComponent<Move>().block_num <= 6)
                return;
            int newblock_num;
            if (MoveScript.GetComponent<Move>().block_num > 13)
                newblock_num = MoveScript.GetComponent<Move>().block_num - 6;
            else
                newblock_num = MoveScript.GetComponent<Move>().block_num - 7;
            string MoveStoneHere_num = "Block" + newblock_num;
            GameObject MoveStoneHere = GameObject.Find(MoveStoneHere_num);
            for (int i = 0; i < MoveStoneHere.transform.childCount; i++)
            {
                if (MoveStoneHere.transform.GetChild(i).name == "MoveableObject")
                {
                    return;
                }
            }
            StoneObject.transform.SetParent(MoveStoneHere.transform);
            StoneObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0);
        }
    }
}