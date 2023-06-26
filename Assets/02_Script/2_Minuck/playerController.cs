using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;

    private bool isMoving;

    private Vector3 origPos, targetPos;
    private float timeToMove = 0.2f;

    public LayerMask Wall;
    public LayerMask Goal;
    public LayerMask Stone;

    private float tileSize = 2f;
    public Vector2 size;

    public int moveCount = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (!isMoving)
        {
            if (horizontalInput == -1)
            {
                StartCoroutine(TryToMove(Vector3.left));

            }

            if (horizontalInput == 1)
            {
                StartCoroutine(TryToMove(Vector3.right));
            }

            if (verticalInput == -1)
            {
                StartCoroutine(TryToMove(Vector3.down));
            }

            if (verticalInput == 1)
            {
                StartCoroutine(TryToMove(Vector3.up));
            }
        }

    }

    private IEnumerator TryToMove(Vector3 direction)
    {
        isMoving = true;

        if (moveCount <= 0)
        {
            // failed to stage clear

            yield return null;
        }

        origPos = transform.position;
        targetPos = origPos + (direction * tileSize);

        if (Physics2D.OverlapBox(targetPos, size, 0f) == null)
        {
            // no object in here
            // then move
            Debug.Log("Empty Space");

            float elapsedTime = 0;

            while (elapsedTime < timeToMove)
            {
                transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = targetPos;

        }
        else
        {
            Debug.Log("Not Empty Space");
            CheckObject(direction);

            yield return null;
        }

        isMoving = false;

        moveCount--;

        yield return null;
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

    private IEnumerator CheckObject(Vector3 direction)
    {
        // funtion for object checking
        // 

        origPos = transform.position;
        targetPos = origPos + (direction * tileSize);

        if (Physics2D.OverlapBox(targetPos, size, 0f, Stone) != null)
        {
            // the object is Stone
            Debug.Log("Stone");

            TryToPush(direction);

            yield return null;
        }

        if (Physics2D.OverlapBox(targetPos, size, 0f, Wall) != null)
        {
            // the object is Wall
            Debug.Log("Wall");

            yield return null;
        }

        if (Physics2D.OverlapBox(transform.position, size, 0f, Goal) != null)
        {
            // the object is Goal
            // Stage Clear
            Debug.Log("GOAL!");

            yield return null;
        }

        yield return null;
    }


}
