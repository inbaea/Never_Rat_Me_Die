using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemyGuide : MonoBehaviour
{
    public GameObject movingEnemy;

    private float moveCooldown = 0.35f;

    private Vector3 origPos, targetPos;

    private int tileSize = 2;
    public Vector2 size = new Vector2(1, 1);

    public Collider2D[] objectsInTarget;

    public Vector3 direction = new Vector3(1, 0, 0); // start with right

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(movingEnemy.transform.position, transform.position) <= 0.02)
        {
            movingEnemy.transform.position = transform.position;
        }
    }

    private void Awake()
    {
        movingEnemy = transform.parent.transform.GetChild(0).gameObject;
        transform.position = movingEnemy.transform.position;
    }

    private IEnumerator Move()
    {

        while (true)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.W))
            {

                CheckObject();
                yield return new WaitForSeconds(moveCooldown);
            }

            yield return null;
        }
    }

    private void CheckObject()
    {
        origPos = transform.position;
        targetPos = origPos + (direction * tileSize);

        objectsInTarget = Physics2D.OverlapBoxAll(targetPos, size, 0f);

        if (objectsInTarget.Length != 0)
        {
            Debug.Log("From Moving Enemy Guide: " + objectsInTarget);
        }
        else
        {
            Debug.Log("From Moving Enemy Guide: NULL");
        }

        try
        {
            if (objectsInTarget.Length == 0)
            {
                // null space
                transform.position = targetPos;
            }
            else
            {
                for (int i = 0; i < objectsInTarget.Length; i++)
                {
                    if (objectsInTarget[i].tag == "Ground")
                    {
                        // no object in here
                        // then move

                        transform.position = targetPos;

                        return;
                    }

                    if (objectsInTarget[i].tag == "Wall")
                    {
                        // the object is Wall
                        if (direction.Equals(new Vector3(-1, 0, 0)))
                        {
                            direction = new Vector3(1, 0, 0);
                            transform.parent.GetChild(0).transform.rotation = transform.parent.GetChild(0).transform.rotation * new Quaternion(0, 1, 0, 0);
                        } else if (direction.Equals(new Vector3(1, 0, 0)))
                        {
                            direction = new Vector3(-1, 0, 0);
                            transform.parent.GetChild(0).transform.rotation = transform.parent.GetChild(0).transform.rotation * new Quaternion(0, 1, 0, 0);
                        }

                        return;
                    }

                }
            }
        }
        catch
        {
            transform.position = targetPos;
        }
    }
}
