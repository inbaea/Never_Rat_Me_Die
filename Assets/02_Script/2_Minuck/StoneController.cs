using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class StoneController : MonoBehaviour
{
    private float timeToMove = 0.25f;

    public float xVelocity = 5.0f;
    public float yVelocity = 5.0f;

    public GameObject target;

    public LayerMask stoneGuide;

    public Vector2 size = new Vector2(1,1);

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        xVelocity = 0f;
        yVelocity = 0f;
        target = Physics2D.OverlapBox(transform.position, size, 0f, stoneGuide).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        float targetPosX = Mathf.SmoothDamp(transform.position.x, target.transform.position.x, ref xVelocity, timeToMove);
        float targetPosY = Mathf.SmoothDamp(transform.position.y, target.transform.position.y, ref yVelocity, timeToMove);

        transform.position = new Vector3(targetPosX, targetPosY, transform.position.z);
    }
}
