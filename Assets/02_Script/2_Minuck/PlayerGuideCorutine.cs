using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PlayerGuideCorutine : MonoBehaviour
{

    private float moveCooldown = 0.35f;

    private Vector3 origPos, targetPos;

    private AudioSource moveSound;

    public LayerMask Wall;
    public LayerMask Goal;
    public LayerMask MoveableObject;
    public LayerMask Ground;
    public LayerMask Item;

    private float tileSize = 2f;
    public Vector2 size = new Vector2(1,1);

    public int moveCount = 99;

    public bool isStageCleared = false;
    public bool isFailed = false;

    // Start is called before the first frame update
    void Start()
    {
        moveSound = GetComponent<AudioSource>();

        StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update()
    {
        if (moveCount <= 0)
        {
            Debug.Log("Failed to Clear Stage");
        }
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
        moveCount--;

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

            isStageCleared = true;

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
