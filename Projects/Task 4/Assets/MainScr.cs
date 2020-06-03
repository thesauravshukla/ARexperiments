using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScr : MonoBehaviour
{
    public Material flame;  //Transform of the burner flame material
    public Material sooty;  //Transform of the soot material
    public float t = 0.0f;  //Variable related to lerping of flame color
    public Transform soot;  //Transform of flame soot
    public Color lerpedColor;   //Variable for final lerped color of the flame
    public ParticleSystem particleSystem;   //Variable for the soot particle system
    public float v = 25.0f; //Variable for lerping speed of soot
    
    void Start()
    {
        flame.SetColor("_TintColor", new Vector4(61.0f,41.0f,9.0f, 255.0f)/255.0f); //Flame color is initialised
    }
    void Update()
    {
        var main = particleSystem.main; //Particle system is referenced
        main.startColor = new Color(0.0f, 0.0f, 0.0f, (1-t)/v); //Initial soot color
        lerpedColor = Color.Lerp(new Vector4(61.0f,41.0f,9.0f, 355.0f)/355.0f, new Vector4(8.0f,26.0f,238.0f, 255.0f)/255.0f, t);   //Flame color is lerped
        flame.SetColor("_TintColor", lerpedColor);  //Tint Color of flame is set to lerped color
        sooty.SetColor("_TintColor", new Vector4(9.0f,123.0f,255.0f, 255.0f * t)/255.0f);   //Soot tint color is set
    }
    public void getval(float val)
    {
        
        t = val;    //Value returned by the slider is accessed
    }
    
}
