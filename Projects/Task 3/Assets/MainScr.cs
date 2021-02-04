using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScr : MonoBehaviour
{
    public Transform waterLevel;    
    public Transform AlkaliLevel;  
    public Transform brineLevel;   
    public Transform LWire1Elec;    
    public Transform LWire2Elec;  
    public Transform RWire1Elec;    
    public Transform RWire2Elec;   
    public Transform bubblesystem1; 
    public Transform bubblesystem2; 
    public Transform ChlorineGas;   
    public Transform HydrogenGas;  
    Vector3 waterinitscale; 
    Vector3 brineinitscale; 
    Vector3 alkaliinitscale;    
    Vector3 Chlorineinitscale;  
    Vector3 Hydrogeninitscale;  
    Vector3 bubblesystem1initscale; 
    Vector3 bubblesystem2initscale; 
    Vector3 lelec1initscale;   
    Vector3 lelec2initscale;  
    Vector3 relec1initscale;   
    Vector3 relec2initscale;   
    public float scalespeed=80; 
    public float scalespeedwater=1; 

        void Start()
    {
        Chlorineinitscale = ChlorineGas.localScale; 
        Hydrogeninitscale = HydrogenGas.localScale; 
        bubblesystem1initscale = bubblesystem1.localScale;  
        bubblesystem2initscale = bubblesystem2.localScale;  
        lelec1initscale = LWire1Elec.localScale;    
        lelec2initscale = LWire2Elec.localScale;    
        relec1initscale = RWire1Elec.localScale;    
        relec2initscale = RWire2Elec.localScale;    
        LWire1Elec.localScale = new Vector3 (0,0,0);    
        LWire2Elec.localScale = new Vector3 (0,0,0);    
        RWire1Elec.localScale = new Vector3 (0,0,0);    
        RWire2Elec.localScale = new Vector3 (0,0,0);    
        bubblesystem1.localScale = new Vector3 (0,0,0); 
        bubblesystem2.localScale = new Vector3 (0,0,0); 
        ChlorineGas.localScale = new Vector3 (0,0,0);   
        HydrogenGas.localScale = new Vector3 (0,0,0);   
        waterinitscale = waterLevel.localScale; 
        alkaliinitscale = AlkaliLevel.localScale;   
        brineinitscale = brineLevel.localScale; 
       


    }

    // Update is called once per frame
    void Update()
    {
        
        if ((Input.touchCount > 0) && (Input.touches[0].phase == TouchPhase.Began))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                if((hit.collider != null)&&(hit.collider.GetComponent<EmptScr>() != null))  
                {
                    LWire1Elec.localScale = new Vector3 (0,0,0);    
                    LWire2Elec.localScale = new Vector3 (0,0,0);    
                    RWire1Elec.localScale = new Vector3 (0,0,0);    
                    RWire2Elec.localScale = new Vector3 (0,0,0);    
                    bubblesystem1.localScale = new Vector3 (0,0,0); 
                    bubblesystem2.localScale = new Vector3 (0,0,0); 
                    ChlorineGas.localScale = new Vector3 (0,0,0);   
                    HydrogenGas.localScale = new Vector3 (0,0,0);   
                    waterLevel.localScale = waterinitscale; 
                    AlkaliLevel.localScale = alkaliinitscale;   
                    brineLevel.localScale = brineinitscale; 
                }
            }

        }
        
        else if ((Input.touchCount > 0) && (Input.touches[0].phase == TouchPhase.Stationary))
        {
            if(brineLevel.localScale.z > 18)
            {
                LWire1Elec.localScale =  lelec1initscale;  
                LWire2Elec.localScale =  lelec2initscale;       
                RWire1Elec.localScale =  relec1initscale;   
                RWire2Elec.localScale =  relec2initscale;   
                bubblesystem1.localScale =  bubblesystem1initscale  ;       
                bubblesystem2.localScale =  bubblesystem2initscale;        
                ChlorineGas.localScale =  Chlorineinitscale  ;       
                HydrogenGas.localScale =  Hydrogeninitscale ;       
                brineLevel.localScale -= new Vector3(0, 0,scalespeed*(Time.deltaTime)); 
                AlkaliLevel.localScale += new Vector3(0,0,scalespeed*(Time.deltaTime)); 
                waterLevel.localScale -= new Vector3(0,0,scalespeedwater*(Time.deltaTime)); 
            }
        }
        else
        {
            

            LWire1Elec.localScale = new Vector3 (0,0,0);    
            LWire2Elec.localScale = new Vector3 (0,0,0);    
            RWire1Elec.localScale = new Vector3 (0,0,0);         
            RWire2Elec.localScale = new Vector3 (0,0,0);    
            bubblesystem1.localScale = new Vector3 (0,0,0); 
            bubblesystem2.localScale = new Vector3 (0,0,0); 
            ChlorineGas.localScale = new Vector3 (0,0,0);   
            HydrogenGas.localScale = new Vector3 (0,0,0);   
        }
    }
}
