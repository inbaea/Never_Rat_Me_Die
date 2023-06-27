using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGuide : MonoBehaviour
{
    public GameObject player;

    private AudioSource moveSound;

    public bool isMoving;

    private Vector3 origPos, targetPos;

    public LayerMask Wall;
    public LayerMask Goal;
    public LayerMask Stone;
    public LayerMask Ground;

    private float tileSize = 2f;
    public Vector2 size;

    public int moveCount = 99;
    public float moveSpeed = 10f;
    public float velocity = 0f;

    void Start()
    {
        moveSound = GetComponent<AudioSource>();

        transform.position = player.transform.position;

        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (!isMoving)
        {

            if (Input.GetKeyDown(KeyCode.A))
            {
                Move(Vector3.left);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                Move(Vector3.right);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                Move(Vector3.down);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                Move(Vector3.up);
            }
        }

        if (Vector2.Distance(player.transform.position , transform.position) <= 0.02)
        {
            player.transform.position = transform.position;
            isMoving = false;
        }

    }


    private void Move(Vector3 direction)
    {

        isMoving = true;

        if (moveCount <= 0)
        {
            // failed to stage clear

            return;
        }

        moveSound.Play();

        CheckObject(direction);

        moveCount--;

    }

    void OnDrawGizmos()
    {
        Gizmos.color = UnityEngine.Color.red;
        Gizmos.DrawWireCube(targetPos, size);
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }

    void Push(Vector3 direction)
    {
        GameObject tempStoneObj = GameObject.FindWithTag("StoneGuide");

        if (tempStoneObj != null)
        {
            StoneGuide stoneGuide = tempStoneObj.GetComponent<StoneGuide>();

            if (stoneGuide.isGetPushed == false)
            {
                stoneGuide.Move(direction);
            }
        }
        else
        {
            Debug.LogError("Stone Guide Not Founded");
        }

    }

    private void CheckObject(Vector3 direction)
    {
        // funtion for object checking
        // 

        origPos = transform.position;
        targetPos = origPos + (direction * tileSize);

        if (Physics2D.OverlapBox(targetPos, size, 0f, Ground) != null || Physics2D.OverlapBox(targetPos, size, 0f) == null)
        {
            // no object in here
            // then move
            Debug.Log("Empty Space");

            transform.position = targetPos;

            return;
        }

        if (Physics2D.OverlapBox(targetPos, size, 0f, Stone) != null)
        {
            // the object is Stone
            Debug.Log("Stone");

            Push(direction);

            return;
        }

        if (Physics2D.OverlapBox(targetPos, size, 0f, Wall) != null)
        {
            // the object is Wall
            Debug.Log("Wall");

            return;
        }

        if (Physics2D.OverlapBox(targetPos, size, 0f, Goal) != null)
        {
            // the object is Goal
            // Stage Clear
            Debug.Log("GOAL!");

            transform.position = targetPos;

            return;
        }
    }
}
