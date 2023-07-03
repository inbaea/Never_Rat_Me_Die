using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidFlaskGuide : MonoBehaviour
{
    public GameObject acidFlask;

    public bool isMoving;
    public bool isGetPushed;

    private Vector3 origPos, targetPos;

    public LayerMask Ground;

    private float tileSize = 2f;
    public Vector2 size = new Vector2(1, 1);

    public Collider2D[] objectsInTarget;

    private void Awake()
    {
        acidFlask = transform.parent.transform.GetChild(0).gameObject;
        transform.position = acidFlask.transform.position;

        isMoving = false;
        isGetPushed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(acidFlask.transform.position, transform.position) <= 0.02)
        {
            acidFlask.transform.position = transform.position;
            isMoving = false;
            isGetPushed = false;
        }

    }


    public void Move(Vector3 direction)
    {

        isMoving = true;
        isGetPushed = true;

        CheckObject(direction);

    }

    void OnDrawGizmos()
    {
        Gizmos.color = UnityEngine.Color.red;
        Gizmos.DrawWireCube(targetPos, size);
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }

    private void CheckObject(Vector3 direction)
    {
        // funtion for object checking
        // 

        origPos = transform.position;
        targetPos = origPos + (direction * tileSize);

        int loopStopper = 0;

        bool keepGoing = true;

        while (keepGoing)
        {
            if (loopStopper >= 10)
            {
                Debug.Log("infinity loop detected");
                break;
            }

            loopStopper++;

            objectsInTarget = Physics2D.OverlapBoxAll(targetPos, size, 0f);

            if (objectsInTarget.Length != 0)
            {
                Debug.Log("From Stone Guide: " + Physics2D.OverlapBox(targetPos, size, 0f));
            }
            else
            {
                Debug.Log("From Stone Guide: NULL");
            }

            if (objectsInTarget.Length == 0)
            {
                // null space

                transform.position = targetPos;
                targetPos = targetPos + (direction * tileSize);
            }
            else
            {
                for (int i = 0; i < objectsInTarget.Length; i++)
                {
                    if (objectsInTarget[i].tag == "Ground")
                    {
                        // ground = moveable

                        transform.position = targetPos;
                        targetPos = targetPos + (direction * tileSize);
                    } else if (objectsInTarget[i].tag == "Stone" || objectsInTarget[i].tag == "StoneGuide")
                    {
                        transform.position = targetPos;
                        keepGoing = false;
                        break;
                    } else if (objectsInTarget[i].tag == "Wall")
                    {

                        keepGoing = false;
                        break;
                    }
                    else
                    {
                        Debug.Log("From Acid Flask Guide: not empty space");
                        keepGoing = false;
                        break;
                    }

                }
            }
        }
    }
 }
