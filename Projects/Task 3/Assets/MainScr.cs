using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScr : MonoBehaviour
{
    public Transform waterLevel;    // Transform of the water level in the main chamber
    public Transform AlkaliLevel;   // Transform of alkali level in the NaoH chamber
    public Transform brineLevel;    // Transform of brine level in the brine chamber
    public Transform LWire1Elec;    // Transform of Upper part of left wire connecting the battery and cathode
    public Transform LWire2Elec;    // Transform of lower part of left wire connecting the battery and cathode
    public Transform RWire1Elec;    // Transform of Upper part of right wire connecting the battery and cathode 
    public Transform RWire2Elec;    // Transform of lower part of right wire connecting the battery and cathode 
    public Transform bubblesystem1; // Transform of bubbles on the left cathode
    public Transform bubblesystem2; // Transform of bubbles on the right cathode
    public Transform ChlorineGas;   // Transform of chlorine gas 
    public Transform HydrogenGas;   // Transform of hydrogen gas
    Vector3 waterinitscale; // Variable for storing initial water level
    Vector3 brineinitscale; // Variable for storing initial brine level
    Vector3 alkaliinitscale;    // Variable for storing initial alkali level
    Vector3 Chlorineinitscale;  // Variable for storing initial chlorine gas state
    Vector3 Hydrogeninitscale;  // Variable for storing initial hydrogen gas state
    Vector3 bubblesystem1initscale; // Variable for storing initial left bubble system state
    Vector3 bubblesystem2initscale; // Variable for storing initial right bubble system state
    Vector3 lelec1initscale;    // Variable for storing initial upper left wire electricity state
    Vector3 lelec2initscale;    // Variable for storing initial lower left wire electricity state
    Vector3 relec1initscale;    // Variable for storing initial upper right wire electricity state
    Vector3 relec2initscale;    // Variable for storing initial lower right wire electricity state
    public float scalespeed=80; // Variable for storing speed of alkali level decrease
    public float scalespeedwater=1; //Variable for storing speed of water level decrease

        void Start()
    {
        Chlorineinitscale = ChlorineGas.localScale; //Initial state of chlorine gas is stored
        Hydrogeninitscale = HydrogenGas.localScale; //Initial state of hydrogen gas is stored
        bubblesystem1initscale = bubblesystem1.localScale;  //Initial state of bubbles on left cathode is stored
        bubblesystem2initscale = bubblesystem2.localScale;  //Initial state of bubbles on right cathode is stored
        lelec1initscale = LWire1Elec.localScale;    //Initial state of upper left wire electricity is stored
        lelec2initscale = LWire2Elec.localScale;    //Initial state of lower left wire electricity is stored
        relec1initscale = RWire1Elec.localScale;    //Initial state of upper right wire electricity is stored
        relec2initscale = RWire2Elec.localScale;    //Initial state of lower right wire electricity is stored
        LWire1Elec.localScale = new Vector3 (0,0,0);    //Upper left wire electricity is scaled to 0
        LWire2Elec.localScale = new Vector3 (0,0,0);    //Lower left wire electricity is scaled to 0
        RWire1Elec.localScale = new Vector3 (0,0,0);    //Upper right wire electricity is scaled to 0
        RWire2Elec.localScale = new Vector3 (0,0,0);    //Lower right wire electricity is scaled to 0
        bubblesystem1.localScale = new Vector3 (0,0,0); //Bubbles on left electrode are scaled to 0
        bubblesystem2.localScale = new Vector3 (0,0,0); //Bubbles on right electrode are scaled to 0
        ChlorineGas.localScale = new Vector3 (0,0,0);   //Chlorine gas is scaled to 0
        HydrogenGas.localScale = new Vector3 (0,0,0);   //Hydrogen gas is scaled to 0
        waterinitscale = waterLevel.localScale; //Initial water level is stored
        alkaliinitscale = AlkaliLevel.localScale;   //Initial alkali level is stored
        brineinitscale = brineLevel.localScale; //Initial brine level is stored
       


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
                    LWire1Elec.localScale = new Vector3 (0,0,0);    //Upper left wire electricity is scaled to 0
                    LWire2Elec.localScale = new Vector3 (0,0,0);    //Lower left wire electricity is scaled to 0
                    RWire1Elec.localScale = new Vector3 (0,0,0);    //Upper right wire electricity is scaled to 0
                    RWire2Elec.localScale = new Vector3 (0,0,0);    //Lower right wire electricity is scaled to 0
                    bubblesystem1.localScale = new Vector3 (0,0,0); //Bubbles on left electrode are scaled to 0
                    bubblesystem2.localScale = new Vector3 (0,0,0); //Bubbles on right electrode are scaled to 0
                    ChlorineGas.localScale = new Vector3 (0,0,0);   //Chlorine gas is scaled to 0
                    HydrogenGas.localScale = new Vector3 (0,0,0);   //Hydrogen gas is scaled to 0
                    waterLevel.localScale = waterinitscale; //Water level is set to initial value
                    AlkaliLevel.localScale = alkaliinitscale;   //Alkali level is set to initial value
                    brineLevel.localScale = brineinitscale; //Brine level is set to initial value
                }
            }

        }
        
        else if ((Input.touchCount > 0) && (Input.touches[0].phase == TouchPhase.Stationary))
        {
            if(brineLevel.localScale.z > 18)
            {
                LWire1Elec.localScale =  lelec1initscale;   //Upper left wire electricity is switched on
                LWire2Elec.localScale =  lelec2initscale;   //Lower left wire electricity is switched on     
                RWire1Elec.localScale =  relec1initscale;   //Upper right wire electricity is switched on
                RWire2Elec.localScale =  relec2initscale;   //Lower right wire electricity is switched on
                bubblesystem1.localScale =  bubblesystem1initscale  ;   //Bubbles on left electrode appear    
                bubblesystem2.localScale =  bubblesystem2initscale; //Bubbles on right electrode appear       
                ChlorineGas.localScale =  Chlorineinitscale  ;  //Chlorine gas appears     
                HydrogenGas.localScale =  Hydrogeninitscale ;   //Hyrdrogen gas appears    
                brineLevel.localScale -= new Vector3(0, 0,scalespeed*(Time.deltaTime)); //Brine level is updated with time
                AlkaliLevel.localScale += new Vector3(0,0,scalespeed*(Time.deltaTime)); //Alkali level is updated with time
                waterLevel.localScale -= new Vector3(0,0,scalespeedwater*(Time.deltaTime)); //Water level is updated with time
            }
        }
        else
        {
            

            LWire1Elec.localScale = new Vector3 (0,0,0);    //Upper left wire electricity is scaled to 0
            LWire2Elec.localScale = new Vector3 (0,0,0);    //Lower left wire electricity is scaled to 0
            RWire1Elec.localScale = new Vector3 (0,0,0);    //Upper right wire electricity is scaled to     
            RWire2Elec.localScale = new Vector3 (0,0,0);    //Lower right wire electricity is scaled to 
            bubblesystem1.localScale = new Vector3 (0,0,0); //Bubbles on left electrode are scaled to 0
            bubblesystem2.localScale = new Vector3 (0,0,0); //Bubbles on right electrode are scaled to 0
            ChlorineGas.localScale = new Vector3 (0,0,0);   //Chlorine gas is scaled to 0
            HydrogenGas.localScale = new Vector3 (0,0,0);   //Hydrogen gas is scaled to 0
        }
    }
}
