using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheezeText : MonoBehaviour
{

    public TextMeshPro textMeshPro;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        textMeshPro = GetComponent<TextMeshPro>();
        textMeshPro.text = "+" + gameObject.GetComponentInParent<CheeseController>().moveCountRecoveryAmount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
