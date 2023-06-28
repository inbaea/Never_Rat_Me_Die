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
    public LayerMask MoveableObject;
    public LayerMask Ground;
    public LayerMask Item;

    private float tileSize = 2f;
    public Vector2 size;

    public int moveCount = 99;

    void Start()
    {
        moveSound = GetComponent<AudioSource>();

        transform.position = player.transform.position;

        isMoving = false;
    }

    private void Awake()
    {
        player = transform.parent.transform.GetChild(0).gameObject;
        transform.position = player.transform.position;
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



        CheckObject(direction);

        moveCount--;

    }

    void OnDrawGizmos()
    {
        Gizmos.color = UnityEngine.Color.red;
        Gizmos.DrawWireCube(targetPos, size);
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }

    void Push(Vector3 direction, GameObject target)
    {
        
        if (target != null)
        {
            StoneGuide stoneGuide = target.GetComponent<StoneGuide>();
            WoodBoxGuide woodBoxGuide = target.GetComponent<WoodBoxGuide>();

            if (stoneGuide != null)
            {
                if (stoneGuide.isGetPushed == false)
                {
                    stoneGuide.Move(direction);
                    target = null;
                }
            }

            if (woodBoxGuide != null)
            {
                if (woodBoxGuide.isGetPushed == false)
                {
                    woodBoxGuide.Move(direction);
                    target = null;
                }
            }

        }
        else
        {
            Debug.LogError("MoveableObject Guide Not Founded");
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

            moveSound.Play();

            return;
        }

        if (Physics2D.OverlapBox(targetPos, size, 0f, MoveableObject) != null)
        {
            // the object is MoveableObject
            Debug.Log("MoveableObject");

            GameObject tempStoneObj = Physics2D.OverlapBox(targetPos, size, 0f, MoveableObject).gameObject;

            Push(direction, tempStoneObj);

            tempStoneObj = null;

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

        if (Physics2D.OverlapBox(targetPos, size, 0f, Item) != null)
        {
            // the object is Item
            // Stage Clear
            Debug.Log("Item Looted");

            transform.position = targetPos;

            return;
        }
    }
}
