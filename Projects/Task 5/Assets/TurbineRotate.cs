using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TurbineRotate : MonoBehaviour
{
    public MainScr h;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.localEulerAngles = new Vector3(0,0,0);    //Euler angle of turbine pivot is initialised
    }

    // Update is called once per frame
    void Update()
    {
        if(h.coldWaterOn && h.hotWaterOn)
        {
            transform.Rotate (100.0f*Time.deltaTime,0,0, Space.Self);   //Turbine is rotated when both hot and cold water are turned on
        }    
    }
}