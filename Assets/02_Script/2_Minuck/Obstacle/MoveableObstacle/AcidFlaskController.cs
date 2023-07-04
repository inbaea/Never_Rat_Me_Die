using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidFlaskController : MonoBehaviour
{
    private readonly float timeToMove = 0.25f;

    public float xVelocity = 5.0f;
    public float yVelocity = 5.0f;

    public GameObject target;
    public GameObject destroyTarget;

    public GameObject AcidFloor;

    public Vector2 size = new(1, 1);

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        destroyTarget = other.gameObject;

        switch (other.gameObject.tag)
        {
            case "Stone":
            case "StoneGuide":
                Destroy(other.transform.parent.gameObject);
                Destroy(transform.parent.gameObject);
                break;

            case "Wall":
                {
                    Vector2 spawnpos = new((int)transform.position.x, (int)transform.position.y);
                    Instantiate(AcidFloor, spawnpos, transform.rotation);
                    Destroy(transform.parent.gameObject);
                    break;
                }
        }
    }

    public void Break()
    {
        Instantiate(AcidFloor, transform.position, transform.rotation);
        Destroy(this.transform.parent.gameObject);
    }
}
