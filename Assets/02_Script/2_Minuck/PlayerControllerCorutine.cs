using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PlayerControllerCorutine : MonoBehaviour
{

    private float moveCooldown = 0.25f;

    private Vector3 origPos, targetPos;

    public LayerMask Wall;
    public LayerMask Goal;
    public LayerMask Stone;
    public LayerMask Ground;

    private float tileSize = 2f;
    public Vector2 size = new Vector2(1,1);

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update()
    {
        
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
            Debug.LogError("StoneGuide Guide Not Founded");
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
        origPos = transform.position;
        targetPos = origPos + (direction * tileSize);

        if (Physics2D.OverlapBox(targetPos, size, 0f, Ground) != null || Physics2D.OverlapBox(targetPos, size, 0f) == null)
        {
            // no object in here
            // then move
            Debug.Log("Empty Space");

            while(true)
            {
                transform.position = transform.position + (direction * 0.1f);

                if (transform.position == targetPos)
                {
                    break;
                }
            }

            return;
        }

        if (Physics2D.OverlapBox(targetPos, size, 0f, Stone) != null)
        {
            // the object is StoneGuide
            Debug.Log("StoneGuide");

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
