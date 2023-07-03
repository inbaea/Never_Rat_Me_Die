using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class WoodBoxGuide : MonoBehaviour
{
    public GameObject WoodBox;

    public bool isMoving;
    public bool isGetPushed;

    private Vector3 origPos, targetPos;

    public LayerMask Ground;

    private float tileSize = 2f;
    public Vector2 size = new Vector2(1, 1);

    public Collider2D objectInTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        WoodBox = transform.parent.transform.GetChild(0).gameObject;
        transform.position = WoodBox.transform.position;

        isMoving = false;
        isGetPushed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(WoodBox.transform.position, transform.position) <= 0.02)
        {
            WoodBox.transform.position = transform.position;
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

        Debug.Log("From Wood Box Guide: " + Physics2D.OverlapBox(targetPos, size, 0f));

        objectInTarget = Physics2D.OverlapBox(targetPos, size, 0f);

        try
        {
            if (objectInTarget.tag == "Ground")
            {
                Debug.Log("Ground Space, Move MoveableObject");

                transform.position = targetPos;
            }
            else
            {
                Debug.Log("Not Empty Space, Can't Move MoveableObject");

                WoodBox.GetComponent<WoodBoxController>().Break();

                Destroy(gameObject);
            }
        }
        catch (NullReferenceException e)
        {
            Debug.Log("Null Space, Move MoveableObject");

            transform.position = targetPos;
        }

        /*
        if (Physics2D.OverlapBox(targetPos, size, 0f, Ground) != null || Physics2D.OverlapBox(targetPos, size, 0f) == null)
        {
            // no object in here
            // then move
            Debug.Log("Empty Space, Move WoodBoxGuide");

            transform.position = targetPos;

            return;
        }
        else
        {
            // object blocks WoodBoxGuide
            // Woodbox Breaks
            Debug.Log("Not Empty Space, Wood box Breaks");

            WoodBox.GetComponent<WoodBoxController>().Break();

            Destroy(gameObject);

            return;
        }
        */

    }

}
