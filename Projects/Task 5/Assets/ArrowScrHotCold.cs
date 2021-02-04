using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ArrowScrHotCold : MonoBehaviour
{
    public MainScr h;    //An object for MainScr is created
    Vector3 originalScale;  //Vector for storing original scale of arrows
    
    
    // Start is called before the first frame update
    void Start()
    {
        originalScale = transform.localScale ;  //Initial scale of arrows is saved
        transform.localScale = new Vector3(0,0,0);  //Initial scale is set to 0.
    }

    // Update is called once per frame
    void Update()
    {
        if(h.coldWaterOn && h.hotWaterOn)
        {
            transform.localScale =originalScale*((h.factor) + h.amplitude*((float)Math.Sin(h.w*(Time.time))));  //Scale of arrows is oscillated when hot and cold water are on
        }
        else
        {
            transform.localScale = new Vector3(0,0,0);  //Scale is set to 0 when either hot or cold water is turned off
        }    
    }
}