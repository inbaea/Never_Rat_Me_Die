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

    private readonly float tileSize = 2f;
    public Vector2 size = new(1,1);

    public Collider2D[] objectsInTarget;

    public AudioSource audioSource;

    private void Awake()
    {
        stone = transform.parent.transform.GetChild(0).gameObject;
        transform.position = stone.transform.position;

        audioSource = GetComponent<AudioSource>();

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
            Debug.Log("From Stone Guide: NULL");
        }

        try
        {
            if (objectsInTarget.Length == 0)
            {
                //null space
                transform.position = targetPos;
                audioSource.Play();
            }
            else
            {
                for (int i = 0; i < objectsInTarget.Length; i++)
                {
                    switch (objectsInTarget[i].tag)
                    {
                        case "Ground":
                            transform.position = targetPos;
                            audioSource.Play();
                            break;

                        case "AcidFloor":
                            transform.position = targetPos;
                            audioSource.Play();
                            break;

                        default:
                            break;
                    }
                }
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
