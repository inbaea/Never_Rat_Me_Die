using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerController: MonoBehaviour
{
    private float timeToMove = 0.15f;

    public Vector2 size;

    private float xVelocity = 10.0f;
    private float yVelocity = 10.0f;

    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        xVelocity = 0f;
        yVelocity = 0f;
    }

    private void Awake()
    {
        target = transform.parent.gameObject;
        target = target.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float targetPosX = Mathf.SmoothStep(transform.position.x, target.transform.position.x, timeToMove);
        float targetPosY = Mathf.SmoothStep(transform.position.y, target.transform.position.y, timeToMove);
        //float targetPosX = Mathf.SmoothDamp(transform.position.x, target.transform.position.x, ref xVelocity, timeToMove);
        //float targetPosY = Mathf.SmoothDamp(transform.position.y, target.transform.position.y, ref yVelocity, timeToMove);

        transform.position = new Vector3(targetPosX, targetPosY, transform.position.z);
    }
}
