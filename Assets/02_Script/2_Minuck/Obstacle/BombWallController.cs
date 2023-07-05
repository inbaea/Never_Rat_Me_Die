using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombWallController : MonoBehaviour
{
    public GameObject target;

    public Vector3 direction;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            target = other.transform.parent.GetChild(1).gameObject;

            direction = target.GetComponent<PlayerGuideCorutine>().direction;


            if (direction.Equals(new Vector3(-1, 0, 0)))
            {
                direction = new Vector3(1, 0, 0);
            }
            else if (direction.Equals(new Vector3(1, 0, 0)))
            {
                direction = new Vector3(-1, 0, 0);
            }
            else if (direction.Equals(new Vector3(0, 1, 0)))
            {
                direction = new Vector3(0, -1, 0);
            }
            else if (direction.Equals(new Vector3(0, -1, 0)))
            {
                direction = new Vector3(0, 1, 0);
            }

            other.transform.parent.GetChild(1).GetComponent<PlayerGuideCorutine>().GetPushed(direction);

            target.GetComponent<PlayerGuideCorutine>().moveCount -= 5;

            Destroy(gameObject);
        }
    }
}
