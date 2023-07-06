using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class StoneController : MonoBehaviour
{
    private readonly float timeToMove = 0.15f;

    public float xVelocity = 8.0f;
    public float yVelocity = 8.0f;

    public GameObject target;

    public Vector2 size = new(1,1);

    private void Awake()
    {
        xVelocity = 0f;
        yVelocity = 0f;

        target = transform.parent.gameObject;
        target = target.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        float targetPosX = Mathf.SmoothDamp(transform.position.x, target.transform.position.x, ref xVelocity, timeToMove);
        float targetPosY = Mathf.SmoothDamp(transform.position.y, target.transform.position.y, ref yVelocity, timeToMove);

        transform.position = new Vector3(targetPosX, targetPosY, transform.position.z);
    }
}
