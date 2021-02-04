using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScr : MonoBehaviour
{
    public Material flame; 
    public Material sooty; 
    public float t = 0.0f;  
    public Transform soot;  
    public Color lerpedColor;   
    public ParticleSystem particleSystem;   
    public float v = 25.0f; 
    
    void Start()
    {
        flame.SetColor("_TintColor", new Vector4(61.0f,41.0f,9.0f, 255.0f)/255.0f); 
    }
    void Update()
    {
        var main = particleSystem.main;
        main.startColor = new Color(0.0f, 0.0f, 0.0f, (1-t)/v); 
        lerpedColor = Color.Lerp(new Vector4(61.0f,41.0f,9.0f, 355.0f)/355.0f, new Vector4(8.0f,26.0f,238.0f, 255.0f)/255.0f, t);   
        flame.SetColor("_TintColor", lerpedColor);  
        sooty.SetColor("_TintColor", new Vector4(9.0f,123.0f,255.0f, 255.0f * t)/255.0f);   
    }
    public void getval(float val)
    {
        
        t = val;    
    }
    
}
