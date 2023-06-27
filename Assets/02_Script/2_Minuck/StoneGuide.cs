using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class StoneGuide : MonoBehaviour
{
    public GameObject stone;

    public bool isMoving;
    public bool isGetPushed;

    private Vector3 origPos, targetPos;

    public LayerMask Ground;
    public LayerMask Stone;

    private float tileSize = 2f;
    public Vector2 size = new Vector2(1,1);

    public float moveSpeed = 10f;
    public float velocity = 0f;

    void Start()
    {
        stone = Physics2D.OverlapBox(transform.position, size, 0f, Stone).gameObject;
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

        if (Physics2D.OverlapBox(targetPos, size, 0f, Ground) != null || Physics2D.OverlapBox(targetPos, size, 0f) == null)
        {
            // no object in here
            // then move
            Debug.Log("Empty Space, Move Stone");

            transform.position = targetPos;

            return;
        }
        else
        {
            // object blocks stone
            // can't move
            Debug.Log("Not Empty Space, Can't Move Stone");
        }

    }
}
