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

    }

}
