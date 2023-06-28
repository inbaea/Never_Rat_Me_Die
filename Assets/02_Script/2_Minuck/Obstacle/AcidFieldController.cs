using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidFieldController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log(other.gameObject.tag);

        if (other.transform.tag == "Stone" || other.transform.tag == "WoodBox")
        {
            other.transform.parent.gameObject.SetActive(false);
            
        }

        if (other.transform.tag == "Player")
        {
            Debug.Log(other.gameObject.tag);
            other.transform.parent.gameObject.transform.Find("PlayerGuide").gameObject.GetComponent<PlayerGuideCorutine>().moveCount = 0;
        }
    }
}
