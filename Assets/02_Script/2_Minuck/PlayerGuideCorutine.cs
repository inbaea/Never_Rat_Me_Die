using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PlayerGuideCorutine : MonoBehaviour
{
    public GameObject player;

    private readonly float moveCooldown = 0.35f;

    private Vector3 origPos, targetPos;

    private AudioSource moveSound;

    private readonly int tileSize = 2;
    public Vector2 size = new(1,1);

    public int moveCount = 99;
    public int adrenalineCount = 0;

    public bool isStageCleared = false;
    public bool isFailed = false;

    public Collider2D[] objectsInTarget;

    public Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        moveSound = GetComponent<AudioSource>();

        StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update()
    {
        if (moveCount < 0)
        {
            Debug.Log("Failed to Clear Stage");
        }
    }

    private void Awake()
    {
        player = transform.parent.transform.GetChild(0).gameObject;
        transform.position = player.transform.position;
    }

    void Push(Vector3 direction, GameObject target)
    {
        if (target != null)
        {
            switch (target.tag)
            {
                case "StoneGuide":
                    {
                        StoneGuide stoneGuide = target.GetComponent<StoneGuide>();

                        if (stoneGuide.isGetPushed == false)
                        {
                            stoneGuide.Move(direction);
                        }

                        break;
                    }

                case "WoodBoxGuide":
                    {
                        WoodBoxGuide woodBoxGuide = target.GetComponent<WoodBoxGuide>();

                        if (woodBoxGuide.isGetPushed == false)
                        {
                            woodBoxGuide.Move(direction);
                        }

                        break;
                    }

                case "AcidFlaskGuide":
                    {
                        AcidFlaskGuide acidFlaskGuide = target.GetComponent<AcidFlaskGuide>();

                        if (acidFlaskGuide.isGetPushed == false)
                        {
                            acidFlaskGuide.Move(direction);
                        }

                        break;
                    }

                default:
                    break;
            }
        }
        else
        {
            Debug.LogError("MoveableObject Guide Not Founded");
        }

    }

    public void GetPushed(Vector3 direction)
    {
        origPos = transform.position;
        targetPos = origPos + (direction * tileSize);

        transform.position = targetPos;
    }

    private IEnumerator Move()
    {

        while (true)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {

                CheckObject(new Vector3(-1, 0, 0));
                yield return new WaitForSeconds(moveCooldown);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                CheckObject(new Vector3(1, 0, 0));
                yield return new WaitForSeconds(moveCooldown);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                CheckObject(new Vector3(0, -1, 0));
                yield return new WaitForSeconds(moveCooldown);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                CheckObject(new Vector3(0, 1, 0));
                yield return new WaitForSeconds(moveCooldown);
            }

            yield return null;
        }
    }

    private void CheckObject(Vector3 direction)
    {
        this.direction = direction;

        moveCount--;

        origPos = transform.position;
        targetPos = origPos + (direction * tileSize);

        objectsInTarget = Physics2D.OverlapBoxAll(targetPos, size, 0f);

        if (objectsInTarget.Length != 0)
        {
            for (int i = 0; i < objectsInTarget.Length; i++)
            {
                Debug.Log("From Player Guide: " + objectsInTarget[i].tag);
            }
                
        }
        else
        {
            Debug.Log("From Player Guide: NULL");
        }
        
        try
        {
            if (objectsInTarget.Length == 0)
            {
                // null space
                transform.position = targetPos;

                moveSound.Play();
            }
            else
            {
                for (int i = 0; i < objectsInTarget.Length; i++)
                {
                    switch (objectsInTarget[i].tag)
                    {
                        case "Ground":
                            // no object in here
                            // then move

                            transform.position = targetPos;

                            moveSound.Play();

                            break;

                        case "StoneGuide":
                        case "WoodBoxGuide":
                            {
                                // the object is MoveableObject

                                GameObject tempObj = objectsInTarget[i].gameObject;

                                if (adrenalineCount > 0)
                                {
                                    Destroy(tempObj.transform.parent.gameObject);
                                    adrenalineCount--;
                                    transform.position = targetPos;
                                }
                                else
                                {
                                    Push(direction, tempObj);
                                }

                                tempObj = null;

                                break;
                            }

                        case "Wall":
                            // the object is Wall

                            break;

                        case "Goal":
                            // the object is Goal
                            // Stage Clear

                            transform.position = targetPos;

                            isStageCleared = true;

                            break;

                        case "Item":
                            // the object is Item

                            transform.position = targetPos;

                            break;

                        case "AcidFlaskGuide":
                            {
                                GameObject tempObj = objectsInTarget[i].gameObject;

                                Push(direction, tempObj);

                                tempObj = null;

                                break;
                            }

                        case "BombWall":

                            transform.position = targetPos;

                            break;
                    }
                }
            }
        }
        catch
        {
            transform.position = targetPos;

            moveSound.Play();
        }
    }
}
