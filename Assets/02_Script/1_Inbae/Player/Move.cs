using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Transform tr;
    string Block_name;
    int block_num = 0;
    Rigidbody2D rb;

    bool Lefted = false;
    bool Righted = false;
    bool Uped = false;
    bool Downed = false;

    bool canMove = true;

    void Start()
    {
        tr = gameObject.transform;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && canMove)
        {
            if (block_num == 0 || block_num == 7 || block_num == 14 || block_num == 20 || block_num == 26)
                return;
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && canMove)
        {
            if (block_num == 6 || block_num == 13 || block_num == 19 || block_num == 25 || block_num == 31)
                return;
            MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && canMove)
        {
            if (block_num > 25 || block_num == 7)
                return;
            MoveUp();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && canMove)
        {
            if (block_num < 7)
                return;
            MoveDown();
        }

        if (gameObject.GetComponent<RectTransform>().anchoredPosition.x < 0 && Lefted)
        {
            rb.velocity = new Vector3(0, 0, 0);
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0);
            Lefted = false;
            canMove = true;
        }
        if (gameObject.GetComponent<RectTransform>().anchoredPosition.x > 0 && Righted)
        {
            rb.velocity = new Vector3(0, 0, 0);
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0);
            Righted = false;
            canMove = true;
        }
        if (gameObject.GetComponent<RectTransform>().anchoredPosition.y > 0 && Uped)
        {
            rb.velocity = new Vector3(0, 0, 0);
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0);
            Uped = false;
            canMove = true;
        }
        if (gameObject.GetComponent<RectTransform>().anchoredPosition.y < 0 && Downed)
        {
            rb.velocity = new Vector3(0, 0, 0);
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0);
            Downed = false;
            canMove = true;
        }
    }

    public void MoveLeft()
    {
        canMove = false;
        Lefted = true;
        block_num--;
        Block_name = "Block" + block_num;
        GameObject MoveToThisBlock = GameObject.Find(Block_name);
        Vector3 MoveToThis = MoveToThisBlock.GetComponent<RectTransform>().anchoredPosition;
        tr.SetParent(MoveToThisBlock.transform);
        MoveToThisBlock.transform.SetAsLastSibling();

        Vector3 getVel = new Vector3(-100f, 0, 0);
        rb.velocity = getVel;
    }

    public void MoveRight()
    {
        canMove = false;
        Righted = true;
        block_num++;
        Block_name = "Block" + block_num;
        GameObject MoveToThisBlock = GameObject.Find(Block_name);
        tr.SetParent(MoveToThisBlock.transform);
        MoveToThisBlock.transform.SetAsLastSibling();

        Vector3 getVel = new Vector3(100f, 0, 0);
        rb.velocity = getVel;
    }

    public void MoveUp()
    {
        canMove = false;
        Uped = true;
        if (block_num < 7)
            block_num += 7;
        else
            block_num += 6;
        Block_name = "Block" + block_num;
        GameObject MoveToThisBlock = GameObject.Find(Block_name);
        tr.SetParent(MoveToThisBlock.transform);
        MoveToThisBlock.transform.SetAsLastSibling();

        Vector3 getVel = new Vector3(0, 100f, 0);
        rb.velocity = getVel;
    }

    public void MoveDown()
    {
        canMove = false;
        Downed = true;
        if (block_num > 13)
            block_num -= 6;
        else
            block_num -= 7;
        Block_name = "Block" + block_num;
        GameObject MoveToThisBlock = GameObject.Find(Block_name);
        tr.SetParent(MoveToThisBlock.transform);
        MoveToThisBlock.transform.SetAsLastSibling();

        Vector3 getVel = new Vector3(0, -100f, 0);
        rb.velocity = getVel;
    }
}
