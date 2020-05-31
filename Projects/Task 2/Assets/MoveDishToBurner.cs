using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDishToBurner : MonoBehaviour
{
    public Transform newcoordinates;    //Transform of the position of the china dish on the wire gauze
    public Transform oldcoordinates;    //Transform of the position of the china dish when not on the wire gauze
    public Transform bowl;  //Transform of the china dish
    public Transform Fire;  //Transform of the Burner flame
    bool isBurning=false;   //Boolean variable keeping track of whether the burner flame is on or off
    public Material powder; //Variable storing material of copper powder
    bool bowlPos = false;   //Boolean variable keeping track of whether the china dish is on the wire gauze or not
    public float t=0.0f;    //Variable used in context of time in the program
    public float speed = 0.5f;  //Variable specifying the speed of change of copper powder color
    void Start()
    {
        powder.color=new Vector4(144.0f,7.0f,7.0f,255.0f)/255.0f;   //Color of Copper powder is  initialised using rgba values
    }
    void Update()
    {
        
        if ((Input.touchCount > 0) && (Input.touches[0].phase == TouchPhase.Began))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if(Physics.Raycast(ray,out hit))
            {
                if((hit.collider != null)&&(hit.collider.GetComponent<EmptScr>() != null))  //Returns true when an object with the component "EmptScr" Script attached with it is touched by the user
                {
                    hit.collider.GetComponent<Transform>().position = newcoordinates.position;  //Position of the china dish is changed to the position on the wire gauze
                    bowlPos=true;   //Specifies that china dish is on the wire gauze
                }
                else if((hit.collider != null)&&(hit.collider.GetComponent<EmptScrReturns>() != null))  //Returns true when an object with the component "EmptScrReturns" Script attached with it is touched by the user
                {
                    if(isBurning)
                    {
                        Fire.localScale = Vector3.zero; //If the flame is on then its scale is set to zero practically turning it off
                        isBurning=false;    //Specifies that the flame is now off
                    }
                    else
                    {
                        Fire.localScale = new Vector3(1,1,1);   //If the flame is off then its scale is set to the specified scale practically turning it on
                        isBurning=true; //Specifies that the flame is now on
                    }
                }
                else if((hit.collider != null)&&(hit.collider.GetComponent<EmptScrThree>() != null))    ////Returns true when an object with the component "EmptScrThree" Script attached with it is touched by the user
                {
                    bowl.position = oldcoordinates.position;    //Chinadish is brought back to it's original position
                    t=0.0f; //t is reset to it's original value
                    isBurning=false;    //Burner flame is turned off
                    powder.color=new Vector4(144.0f,7.0f,7.0f,255.0f)/255.0f;   //Color of copper powder is changed to it's original color 
                }
            }
        }
        
        if(t>1)
        {
            bowl.position = oldcoordinates.position;    //Bowl is removed from wire gauze after the color has been changed to black

        }
        if((isBurning)&&(bowlPos))
        {
            t+=speed*(Time.deltaTime);  //t is incremented if Burnerflame is on and the china dish is on the wire gauze
            powder.color =  Color.Lerp(new Vector4(144.0f,7.0f,7.0f,255.0f)/255.0f, Color.black, t);    //Color of copper powder is changed continuously
        } 
    }
}