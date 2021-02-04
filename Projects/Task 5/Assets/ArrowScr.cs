using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScr : MonoBehaviour

{
    
    public MainScr h;
    Vector3 originalScale;
    public float num = 0.0f;

    
    
    // Start is called before the first frame update
    void Start()
    {
        originalScale = transform.localScale ;  //Initial scale of arrows is saved
        transform.localScale = new Vector3(0,0,0);  //Initial scale is set to 0.
        num = Random.Range(0.0f, 1.0f); //num takes a random value
    }

    // Update is called once per frame
    void Update()
    {
        if(h.hotWaterOn)
        {
            transform.localScale =originalScale*((h.factor) + h.amplitude*((float)Mathf.Sin(h.w*(Time.time) + num)));   //Scale of arrows is oscillated when hot water is on 
        }
        else
        {
            transform.localScale = new Vector3(0,0,0);  //Scale is set to 0 when hot water is not on
        }    
    }
}
