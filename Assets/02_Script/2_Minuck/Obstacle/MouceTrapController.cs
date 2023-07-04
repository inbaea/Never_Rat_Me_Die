using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class MouceTrapController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDrawGizmos()
    {
        Gizmos.color = UnityEngine.Color.red;
        Gizmos.DrawWireSphere(transform.position, 4f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}
