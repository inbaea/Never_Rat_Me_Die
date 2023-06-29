using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Move : MonoBehaviour
{
    public Transform tr;
    public string Block_name;
    public float moveSpeed;
    public int block_num = 25;
    public Rigidbody2D rb;
    public GameObject GameManager;
    public GameObject FlaskObject;

    public bool Lefted = false;
    public bool Righted = false;
    public bool Uped = false;
    public bool Downed = false;

    public bool canMove = true;
    public bool metStone = false;

    void Start()
    {
        tr = gameObject.transform;
        rb = gameObject.GetComponent<Rigidbody2D>();
        moveSpeed = 1250f;
        GameManager = GameObject.Find("GameManager");
    }

    void Update()
    {
        gameObject.GetComponent<Stage1StoneMove>().MeetStone();
        gameObject.GetComponent<Stage1EnemyMove>().MeetEnemy();
        if (GameManager.GetComponent<GameManager>().LeftMoveCount <= 0)
        {
            canMove = false;
            return;
        }
        
        if (!canMove) Deceleration();
        if (!canMove) CannotGo();

        if (canMove)
        {
            metStone = false;
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                if (block_num == 0 || block_num == 1 || block_num == 2 || block_num == 6 || block_num == 7 || block_num == 20)
                    return;
                MoveLeft();
                GameManager.GetComponent<GameManager>().LeftMoveCount--;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                if (block_num == 5 || block_num == 22 || block_num == 23 || block_num == 24 || block_num == 25)
                    return;
                MoveRight();
                GameManager.GetComponent<GameManager>().LeftMoveCount--;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                if (block_num == 2 || block_num == 7 || block_num == 9 || block_num == 11 || block_num == 13 || block_num == 15 || block_num == 17 || block_num == 20 || block_num == 22 || block_num == 25)
                    return;
                MoveUp();
                GameManager.GetComponent<GameManager>().LeftMoveCount--;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                if (block_num == 0 || block_num == 3 || block_num == 8 || block_num == 10 || block_num == 12 || block_num == 14 || block_num == 16 || block_num == 18 || block_num == 21 ||block_num == 23)
                    return;
                MoveDown();
                GameManager.GetComponent<GameManager>().LeftMoveCount--;
            }
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
        if (block_num > 20 || block_num == 9 || block_num == 8)
            block_num -= 5;
        else if (block_num == 3 || block_num == 4 || block_num == 5)
            block_num -= 3;
        else block_num -=4;
        Block_name = "Block" + block_num;
        GameObject MoveToThisBlock = GameObject.Find(Block_name);
        tr.SetParent(MoveToThisBlock.transform);
        MoveToThisBlock.transform.SetAsLastSibling();

        Vector3 getVel = new Vector3(-moveSpeed, 0, 0);
        rb.velocity = getVel;
    }

    public void MoveRight()
    {
        canMove = false;
        Righted = true;
        if (block_num == 3 || block_num == 4 || block_num == 16 || block_num == 17 || block_num == 18 ||block_num == 19 || block_num == 20 || block_num == 21)
            block_num += 5;
        else if (block_num == 0 || block_num == 1 || block_num == 2)
            block_num += 3;
        else block_num += 4;
        Block_name = "Block" + block_num;
        GameObject MoveToThisBlock = GameObject.Find(Block_name);
        tr.SetParent(MoveToThisBlock.transform);
        MoveToThisBlock.transform.SetAsLastSibling();

        Vector3 getVel = new Vector3(moveSpeed, 0, 0);
        rb.velocity = getVel;
    }

    public void MoveUp()
    {
        canMove = false;
        Uped = true;
        block_num++;
        Block_name = "Block" + block_num;
        GameObject MoveToThisBlock = GameObject.Find(Block_name);
        tr.SetParent(MoveToThisBlock.transform);
        MoveToThisBlock.transform.SetAsLastSibling();

        Vector3 getVel = new Vector3(0, moveSpeed, 0);
        rb.velocity = getVel;
    }

    public void MoveDown()
    {
        canMove = false;
        Downed = true;
        block_num--;
        Block_name = "Block" + block_num;
        GameObject MoveToThisBlock = GameObject.Find(Block_name);
        tr.SetParent(MoveToThisBlock.transform);
        MoveToThisBlock.transform.SetAsLastSibling();

        Vector3 getVel = new Vector3(0, -moveSpeed, 0);
        rb.velocity = getVel;
    }

    public void Deceleration()
    {
        if (metStone)
            return;
        if (Lefted)
        {
            if (gameObject.GetComponent<RectTransform>().anchoredPosition.x < 50)
            {
                Vector3 getVel = new Vector3(-moveSpeed/8, 0, 0);
                rb.velocity = getVel;
            }
        }

        if (Righted)
        {
            if (gameObject.GetComponent<RectTransform>().anchoredPosition.x > -50)
            {
                Vector3 getVel = new Vector3(moveSpeed/8, 0, 0);
                rb.velocity = getVel;
            }
        }

        if (Uped)
        {
            if (gameObject.GetComponent<RectTransform>().anchoredPosition.y > -50)
            {
                Vector3 getVel = new Vector3(0, moveSpeed/8, 0);
                rb.velocity = getVel;
            }
        }

        if (Downed)
        {
            if (gameObject.GetComponent<RectTransform>().anchoredPosition.y < 50)
            {
                Vector3 getVel = new Vector3(0, -moveSpeed/8, 0);
                rb.velocity = getVel;
            }
        }
    }

    public void CannotGo()
    {
        if (Lefted)
        {
            if(gameObject.GetComponent<RectTransform>().anchoredPosition.x < 80)
            {
                for (int i = 0; i < gameObject.transform.parent.transform.childCount; i++)
                {
                    if (gameObject.transform.parent.transform.GetChild(i).name == "Stone")
                    {
                        Lefted = false;
                        metStone = true;
                        MoveRight();
                    }
                    if (gameObject.transform.parent.transform.GetChild(i).name == "Flask")
                    {
                        FlaskObject = gameObject.transform.parent.transform.GetChild(i).gameObject;
                        gameObject.GetComponent<FlaskMove>().FlaskThrowMove();
                        Lefted = false;
                        MoveRight();
                    }
                }
            }
        }

        if (Righted)
        {
            if(gameObject.GetComponent<RectTransform>().anchoredPosition.x > -80)
            {
                for (int i = 0; i < gameObject.transform.parent.transform.childCount; i++)
                {
                    if (gameObject.transform.parent.transform.GetChild(i).name == "Stone")
                    {
                        Righted = false;
                        metStone = true;
                        MoveLeft();
                    }
                    if (gameObject.transform.parent.transform.GetChild(i).name == "Flask")
                    {   
                        FlaskObject = gameObject.transform.parent.transform.GetChild(i).gameObject;
                        gameObject.GetComponent<FlaskMove>().FlaskThrowMove();
                        Righted = false;
                        MoveLeft();
                    }
                }
            }
        }

        if (Uped)
        {
            if(gameObject.GetComponent<RectTransform>().anchoredPosition.y > -80)
            {
                for (int i = 0; i < gameObject.transform.parent.transform.childCount; i++)
                {
                    if (gameObject.transform.parent.transform.GetChild(i).name == "Stone")
                    {
                        Uped = false;
                        metStone = true;
                        MoveDown();
                    }
                    if (gameObject.transform.parent.transform.GetChild(i).name == "Flask")
                    {
                        FlaskObject = gameObject.transform.parent.transform.GetChild(i).gameObject;
                        gameObject.GetComponent<FlaskMove>().FlaskThrowMove();
                        Uped = false;
                        MoveDown();
                    }
                }
            }
        }

        if (Downed)
        {
            if(gameObject.GetComponent<RectTransform>().anchoredPosition.y < 80)
            {
                for (int i = 0; i < gameObject.transform.parent.transform.childCount; i++)
                {
                    if (gameObject.transform.parent.transform.GetChild(i).name == "Stone")
                    {
                        Downed = false;
                        metStone = true;
                        MoveUp();
                    }
                    if (gameObject.transform.parent.transform.GetChild(i).name == "Flask")
                    {
                        FlaskObject = gameObject.transform.parent.transform.GetChild(i).gameObject;
                        gameObject.GetComponent<FlaskMove>().FlaskThrowMove();
                        Downed = false;
                        MoveUp();
                    }
                }
            }
        }
    }
}