using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDishToBurner : MonoBehaviour
{
    public Transform newcoordinates; 
    public Transform oldcoordinates;  
    public Transform bowl;  
    public Transform Fire;  
    bool isBurning=false;  
    public Material powder; 
    bool bowlPos = false;   
    public float t=0.0f;    
    public float speed = 0.5f;  
    void Start()
    {
        powder.color=new Vector4(144.0f,7.0f,7.0f,255.0f)/255.0f;  
    }
    void Update()
    {
        
        if ((Input.touchCount > 0) && (Input.touches[0].phase == TouchPhase.Began))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if(Physics.Raycast(ray,out hit))
            {
                if((hit.collider != null)&&(hit.collider.GetComponent<EmptScr>() != null))  z
                {
                    hit.collider.GetComponent<Transform>().position = newcoordinates.position;  
                    bowlPos=true;  
                }
                else if((hit.collider != null)&&(hit.collider.GetComponent<EmptScrReturns>() != null))  
                {
                    if(isBurning)
                    {
                        Fire.localScale = Vector3.zero; 
                        isBurning=false;   
                    }
                    else
                    {
                        Fire.localScale = new Vector3(1,1,1);   
                        isBurning=true; 
                    }
                }
                else if((hit.collider != null)&&(hit.collider.GetComponent<EmptScrThree>() != null))   
                {
                    bowl.position = oldcoordinates.position;    
                    t=0.0f; 
                    isBurning=false;   
                    powder.color=new Vector4(144.0f,7.0f,7.0f,255.0f)/255.0f;    
                }
            }
        }
        
        if(t>1)
        {
            bowl.position = oldcoordinates.position;    

        }
        if((isBurning)&&(bowlPos))
        {
            t+=speed*(Time.deltaTime); 
            powder.color =  Color.Lerp(new Vector4(144.0f,7.0f,7.0f,255.0f)/255.0f, Color.black, t);    
        } 
    }
}