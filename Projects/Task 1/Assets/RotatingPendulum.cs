using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RotatingPendulum : MonoBehaviour
{
    public float w=1.0f;    //Angular Velocity of the rotating pendulum
    public float a=45.0f;   //Initial amplitude of the pendulum
    float returnanswer(float g) //Returns 0 when Left most pendulum should not be rotating else returns Sin of the euler angle
    {
        while(Math.Abs(g)>(float)(2*Math.PI))
        {
            g-=((Math.Sign(g))*(float)(2*Math.PI));
        }

        if((g > 0)&&(g < Math.PI))
        return ((float)(Math.Sin(-1*g)));

        else
        return 0.0f ;
    }
    float returnanswer2(float g)    //Returns 0 when Right most pendulum should not be rotating else returns Sin of the euler angle
    {
        while(Math.Abs(g)>(float)(2*Math.PI))
        {
            g-=((Math.Sign(g))*(float)(2*Math.PI));
        }

        if((g > 0)&&(g < Math.PI))
        return 0.0f;

        else
        return ((float)(Math.Sin(g))) ;
    }
    public Transform L; //Transform of left most pendulum
    public Transform R; //Transform of right most pendulum
    

    // Start is called before the first frame update
    void Start()
    {
        L.eulerAngles = new Vector3(0,0,-45);   //Inital amplitude of the Left most Pendulum 
    }

    // Update is called once per frame
    void Update()
    {
        L.localEulerAngles = new Vector3(0, 0, (a*returnanswer(Time.time*w)));   //Value of the euler angle of left most pendulum is updated
        R.localEulerAngles = new Vector3(0, 0, -(a*returnanswer2(Time.time*w))); //Value of the euler angle of right most pendulum is updated
    }
}