using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaskMove : MonoBehaviour
{
    public GameObject MoveScript;
    public GameObject FlaskObject;
    public GameObject TargetObject;
    public float moveSpeed = 750f;
    public int block_num = 0;

    public bool throwing = false;
    public bool throwingL = false;
    public bool throwingR = false;
    public bool throwingU = false;
    public bool throwingD = false;

    void Start()
    {
        MoveScript = GameObject.Find("Player");
    }

    void Update()
    {
        if (throwing)
        {
            if (throwingL)
            {
                if (FlaskObject.GetComponent<RectTransform>().anchoredPosition.x < 0)
                {
                    FlaskObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                    FlaskObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0);
                    throwing = false;
                    throwingL = false;
                }
            }
            if (throwingR)
            {
                if (FlaskObject.GetComponent<RectTransform>().anchoredPosition.x > 0)
                {
                    FlaskObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                    FlaskObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0);
                    throwing = false;
                    throwingR = false;
                }
            }
            if (throwingU)
            {
                if (FlaskObject.GetComponent<RectTransform>().anchoredPosition.y > 0)
                {
                    FlaskObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                    FlaskObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0);
                    throwing = false;
                    throwingU = false;
                }
            }
            if (throwingD)
            {
                if (FlaskObject.GetComponent<RectTransform>().anchoredPosition.y < 0)
                {
                    FlaskObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                    FlaskObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0);
                    throwing = false;
                    throwingD = false;
                }
            }
        }
    }

    public void FlaskThrowMove()
    {
        FlaskObject = gameObject.GetComponent<Move>().FlaskObject;
        block_num = gameObject.GetComponent<Move>().block_num;

        if (MoveScript.GetComponent<Move>().Lefted)
        {
            for (int j = 0; j < 20; j++)
            {
                block_num--;
                string MoveNext_num = "Block" + block_num;
                GameObject MoveNext = GameObject.Find(MoveNext_num);

                if (MoveNext.transform.childCount > 0)
                {
                    block_num++;
                    MoveNext_num = "Block" + block_num;
                    TargetObject = GameObject.Find(MoveNext_num);
                    FlaskObject.transform.SetParent(TargetObject.transform);
                    break;
                }
                if (block_num == 0 || block_num == 7 || block_num == 14 || block_num == 20 || block_num == 26)
                {
                    MoveNext_num = "Block" + block_num;
                    TargetObject = GameObject.Find(MoveNext_num);
                    FlaskObject.transform.SetParent(TargetObject.transform);
                    break;
                }
            }

            Vector3 getVel = new Vector3(-moveSpeed, 0, 0);
            FlaskObject.GetComponent<Rigidbody2D>().velocity = getVel;
            throwing = true;
            throwingL = true;
        }

        if (MoveScript.GetComponent<Move>().Righted)
        {
            for (int j = 0; j < 20; j++)
            {
                block_num++;
                string MoveNext_num = "Block" + block_num;
                GameObject MoveNext = GameObject.Find(MoveNext_num);

                if (MoveNext.transform.childCount > 0)
                {
                    block_num--;
                    MoveNext_num = "Block" + block_num;
                    TargetObject = GameObject.Find(MoveNext_num);
                    FlaskObject.transform.SetParent(TargetObject.transform);
                    break;
                }
                if (block_num == 6 || block_num == 13 || block_num == 19 || block_num == 25 || block_num == 31)
                {
                    MoveNext_num = "Block" + block_num;
                    TargetObject = GameObject.Find(MoveNext_num);
                    FlaskObject.transform.SetParent(TargetObject.transform);
                    break;
                }
            }

            Vector3 getVel = new Vector3(moveSpeed, 0, 0);
            FlaskObject.GetComponent<Rigidbody2D>().velocity = getVel;
            throwing = true;
            throwingR = true;
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
            string MoveNext_num = "Block" + newblock_num;
            GameObject MoveNext = GameObject.Find(MoveNext_num);
            for (int i = 0; i < MoveNext.transform.childCount; i++)
            {
                if (MoveNext.transform.GetChild(i).name == "MoveableObject")
                {
                    return;
                }
                if (MoveNext.transform.GetChild(i).name == "Escape")
                {
                    return;
                }
            }
            FlaskObject.transform.SetParent(MoveNext.transform);
            FlaskObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0);
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
            string MoveNext_num = "Block" + newblock_num;
            GameObject MoveNext = GameObject.Find(MoveNext_num);
            for (int i = 0; i < MoveNext.transform.childCount; i++)
            {
                if (MoveNext.transform.GetChild(i).name == "MoveableObject")
                {
                    return;
                }
                if (MoveNext.transform.GetChild(i).name == "Escape")
                {
                    return;
                }
            }
            FlaskObject.transform.SetParent(MoveNext.transform);
            FlaskObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0);
        }
    }
}
