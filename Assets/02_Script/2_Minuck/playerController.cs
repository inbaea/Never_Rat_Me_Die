using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class playerController : MonoBehaviour
{
    public Rigidbody2D rb;

    public float horizontalInput;
    public float verticalInput;

    private bool isMoving;

    private Vector3 origPos, targetPos;
    private float timeToMove = 0.2f;

    public LayerMask Wall;
    public LayerMask Goal;
    public LayerMask Stone;
    public LayerMask Ground;

    private float tileSize = 2f;
    public Vector2 size;

    public int moveCount = 99;
    public float moveSpeed = 10f;
    public float velocity = 0f;

    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (!isMoving)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                TryToMove(Vector3.left);

            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                TryToMove(Vector3.right);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                TryToMove(Vector3.down);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                TryToMove(Vector3.up);
            }
        }

    }


    private void TryToMove(Vector3 direction)
    {
        isMoving = true;

        if (moveCount <= 0)
        {
            // failed to stage clear

            return;
        }

        origPos = transform.position;
        targetPos = origPos + (direction * tileSize);

        CheckObject(direction);

        isMoving = false;

        moveCount--;

    }

    void OnDrawGizmos()
    {
        Gizmos.color = UnityEngine.Color.red;
        Gizmos.DrawWireCube(targetPos, size);
    }

    void TryToPush(Vector3 direction)
    {
        
    }

    private void Move(Vector3 direction)
    {
        
    }

    private void CheckObject(Vector3 direction)
    {
        // funtion for object checking
        // 

        origPos = transform.position;
        targetPos = origPos + (direction * tileSize);

        if (Physics2D.OverlapBox(targetPos, size, 0f, Ground) != null)
        {
            // no object in here
            // then move
            Debug.Log("Empty Space");

            GameObject tempObj = Physics2D.OverlapBox(targetPos, size, 0f, Ground).gameObject;


            Debug.Log(tempObj);
            Debug.Log(tempObj.transform.position);

            float newPositionX = Mathf.SmoothDamp(transform.position.x, tempObj.transform.position.x, ref velocity, timeToMove);

            float newPositionY = Mathf.SmoothDamp(transform.position.y, tempObj.transform.position.y, ref velocity, timeToMove);

            transform.position = new Vector3(newPositionX, newPositionY, transform.position.z);

            //transform.position = Vector3.Lerp(origPos, targetPos, Time.deltaTime);

            return;
        }

        if (Physics2D.OverlapBox(targetPos, size, 0f, Stone) != null)
        {
            // the object is Stone
            Debug.Log("Stone");

            TryToPush(direction);

            return;
        }

        if (Physics2D.OverlapBox(targetPos, size, 0f, Wall) != null)
        {
            // the object is Wall
            Debug.Log("Wall");

            return;
        }

        if (Physics2D.OverlapBox(transform.position, size, 0f, Goal) != null)
        {
            // the object is Goal
            // Stage Clear
            Debug.Log("GOAL!");

            return;
        }
    }


}
