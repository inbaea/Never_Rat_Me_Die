using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class ItemController : MonoBehaviour
{

    public PlayerGuide playerGuide;
    public PlayerController playerController;

    private void Awake()
    {
        playerGuide = GameObject.Find("PlayerGuide").GetComponent<PlayerGuide>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.ApplyEffect();

            Destroy(this.gameObject);
        }
    }

    protected abstract void ApplyEffect();
}
