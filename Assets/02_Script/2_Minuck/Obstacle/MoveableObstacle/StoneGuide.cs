using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StoneGuide : MonoBehaviour
{
    public GameObject stone;

    public bool isMoving;
    public bool isGetPushed;

    private Vector3 origPos, targetPos;

    public LayerMask Ground;

    private float tileSize = 2f;
    public Vector2 size = new Vector2(1,1);

    public Collider2D objectInTarget;

    private void Awake()
    {
        stone = transform.parent.transform.GetChild(0).gameObject;
        transform.position = stone.transform.position;

        isMoving = false;
        isGetPushed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(stone.transform.position, transform.position) <= 0.02)
        {
            stone.transform.position = transform.position;
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

        objectInTarget = Physics2D.OverlapBox(targetPos, size, 0f);

        if (objectInTarget != null)
        {
            Debug.Log("From Stone Guide: " + Physics2D.OverlapBox(targetPos, size, 0f));
        }
        else
        {
            Debug.Log("From Stone Guide: NULL");
        }

        try
        {
            if (objectInTarget.tag == "Ground")
            {
                transform.position = targetPos;
            }
            else
            {

            }
        }
        catch
        {
            transform.position = targetPos;
        }


        /*
        if (Physics2D.OverlapBox(targetPos, size, 0f, Ground) != null || Physics2D.OverlapBox(targetPos, size, 0f) == null)
        {
            // no object in here
            // then move
            Debug.Log("Empty Space, Move MoveableObject");

            transform.position = targetPos;   

            return;
        }
        else
        {
            // object blocks stone
            // can't move
            Debug.Log("Not Empty Space, Can't Move MoveableObject");
        }
        */
    }
}
