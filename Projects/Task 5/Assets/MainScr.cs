using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScr : MonoBehaviour
{
    public bool hotWaterOn; 
    public bool coldWaterOn;   
    public Material hotWater;  
    public Material coldWater; 
    public float w = 1.0f;  
    public float factor = 1.0f; 
    public float amplitude = 0.3f; 
    void Start()
    {
        hotWaterOn = false; 
        coldWaterOn = false;    
    }

    
    void Update()
    {
        if ((Input.touchCount > 0) && (Input.touches[0].phase == TouchPhase.Began))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                if((hit.collider != null)&&(hit.collider.GetComponent<EmpScr1>() != null))  
                {
                   hotWaterOn = !(hotWaterOn);  
                }
                else if((hit.collider != null)&&(hit.collider.GetComponent<EmpScr2>() != null))  
                {
                        coldWaterOn = !(coldWaterOn);   
                }
            }
        }
        if(hotWaterOn == true)
        {
            hotWater.color=new Vector4(255.0f,0.0f,0.0f,255.0f)/255.0f; 
            
        }
        else if(hotWaterOn == false )
        {
            hotWater.color=new Vector4(255.0f,0.0f,0.0f,100.0f)/255.0f; 
            
        }
        if(coldWaterOn == true)
        {
            coldWater.color=new Vector4(0.0f,0.0f,255.0f,255.0f)/255.0f;   
            
        }
        else if(coldWaterOn == false)
        {
            coldWater.color=new Vector4(0.0f,0.0f,255.0f,100.0f)/255.0f;   
            
        }
    }
}