using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidFloorController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log(other.gameObject.tag);

        if (other.CompareTag("Stone") || other.CompareTag("WoodBox"))
        {
            other.transform.parent.gameObject.SetActive(false);

            this.gameObject.SetActive(false);     
        }

        else if (other.CompareTag("Player"))
        {
            Debug.Log(other.gameObject.tag);
            other.transform.parent.gameObject.transform.Find("PlayerGuide").gameObject.GetComponent<PlayerGuideCorutine>().moveCount = 0;
        }
    }
}
