using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class MouceTrapController : MonoBehaviour
{
    public Collider2D[] objectsInTarget;

    void OnDrawGizmos()
    {
        Gizmos.color = UnityEngine.Color.red;
        Gizmos.DrawWireSphere(transform.position, 2f);
    }

    private void Update()
    {
        objectsInTarget = Physics2D.OverlapCircleAll(transform.position, 2f);

        for (int i = 0; i < objectsInTarget.Length; i++)
        {
            if (objectsInTarget[i].CompareTag("Player")){
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(false);
            }
        }
    }
}
