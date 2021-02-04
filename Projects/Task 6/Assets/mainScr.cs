using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using UnityEngine;


public class mainScr : MonoBehaviour
{

    public float Ix, Iy, Iz;
    public float wx, wy = 1.0f, wz;
    public float dwx, dwy, dwz;
    public float factor;

    Rigidbody rb;

    public bool tennisRacquetOn;
    public bool pointMassesOn;
    public bool screwOn;
    public bool rotating = true;

    public Transform tennisRacquet;
    public Transform pointMasses;
    public Transform screw;

    Vector3 tennisRacquetInitScale;
    Vector3 pointMassesInitScale;
    Vector3 screwInitScale;
    Vector3 Handpicked = new Vector3(0.2f,0.4f, 1);
    Vector3 TransInit;

    public Material button1;
    public Material button2;
    public Material button3;
    public Material button4;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = new Vector3(wx, wy, wz);
        tennisRacquetInitScale = tennisRacquet.localScale;
        pointMassesInitScale = pointMasses.localScale;
        screwInitScale = screw.localScale;
        pointMasses.localScale = new Vector3(0, 0, 0);
        screw.localScale = new Vector3(0, 0, 0);
        tennisRacquetOn = true;
        pointMassesOn = false;
        screwOn = false;
        rotating = true;
        TransInit = transform.position;
        factor = 1.5f;
        button1.color = new Vector4(255.0f, 255.0f, 255.0f, 255.0f) / 255.0f;
        button2.color = new Vector4(255.0f, 255.0f, 136.0f, 255.0f) / 255.0f;
        button3.color = new Vector4(255.0f, 255.0f, 136.0f, 255.0f) / 255.0f;
        button4.color = new Vector4(255.0f, 255.0f, 255.0f, 255.0f) / 255.0f;
    }


    void Update()
    {
        transform.position = TransInit;
        if ((Input.touchCount > 0) && (Input.touches[0].phase == TouchPhase.Began))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if ((hit.collider != null) && (hit.collider.GetComponent<EmpScr>() != null))
                {
                    tennisRacquetOn = true;
                    pointMassesOn = false;
                    screwOn = false;


                }
                else if ((hit.collider != null) && (hit.collider.GetComponent<EmpScr2>() != null))
                {
                    pointMassesOn = true;
                    screwOn = false;
                    tennisRacquetOn = false;

                }
                else if ((hit.collider != null) && (hit.collider.GetComponent<EmpScr3>() != null))
                {
                    pointMassesOn = false;
                    screwOn = true;
                    tennisRacquetOn = false;

                }
            }
        }
        if (tennisRacquetOn == true)
        {
            Ix = Handpicked.x;
            Iy = Handpicked.y;
            Iz = Handpicked.z;
            tennisRacquet.localScale = tennisRacquetInitScale;
            pointMasses.localScale = new Vector3(0, 0, 0);
            screw.localScale = new Vector3(0.00001f, 0.00001f, 0.00001f);
            button1.color = new Vector4(255.0f, 255.0f, 255.0f, 255.0f) / 255.0f;
            button2.color = new Vector4(255.0f, 255.0f, 255.0f, 136.0f) / 255.0f;
            button3.color = new Vector4(255.0f, 255.0f, 255.0f, 136.0f) / 255.0f;
        }
        else if (pointMassesOn == true)
        {
            Ix = Handpicked.x;
            Iy = Handpicked.y;
            Iz = Handpicked.z;
            tennisRacquet.localScale = new Vector3(0, 0, 0);
            pointMasses.localScale = pointMassesInitScale;
            screw.localScale = new Vector3(0.00001f, 0.00001f, 0.00001f);
            button1.color = new Vector4(255.0f, 255.0f, 255.0f, 136.0f) / 255.0f;
            button2.color = new Vector4(255.0f, 255.0f, 255.0f, 255.0f) / 255.0f;
            button3.color = new Vector4(255.0f, 255.0f, 255.0f, 136.0f) / 255.0f;
        }
        else if (screwOn == true)
        {
            tennisRacquet.localScale = new Vector3(0, 0, 0);
            pointMasses.localScale = new Vector3(0, 0, 0);

            //screw.localScale = screwInitScale;
            Ix = ((screw.localScale.y) * (screw.localScale.y) + (screw.localScale.z) * (screw.localScale.z));
            Iy = ((screw.localScale.z) * (screw.localScale.z) + (screw.localScale.x) * (screw.localScale.x));
            Iz = ((screw.localScale.x) * (screw.localScale.x) + (screw.localScale.y) * (screw.localScale.y));

            button1.color = new Vector4(255.0f, 255.0f, 255.0f, 136.0f) / 255.0f;
            button2.color = new Vector4(255.0f, 255.0f, 255.0f, 136.0f) / 255.0f;
            button3.color = new Vector4(255.0f, 255.0f, 255.0f, 255.0f) / 255.0f;
        }

        wx = rb.angularVelocity.x;
        wy = rb.angularVelocity.y;
        wz = rb.angularVelocity.z;
        dwx = ((Iy - Iz) / Ix) * wy * wz * Time.deltaTime;
        dwy = ((Iz - Ix) / Iy) * wz * wx * Time.deltaTime;
        dwz = ((Ix - Iy) / Iz) * wx * wy * Time.deltaTime;
        rb.angularVelocity += new Vector3(dwx, dwy, dwz);
        if ((Input.touchCount > 0) && (Input.touches[0].phase == TouchPhase.Began))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if ((hit.collider != null) && (hit.collider.GetComponent<EmpScr4>() != null))
                {
                    if ((rotating == true))
                    {
                        rb.angularVelocity = new Vector3(0, 0, 0);
                        rotating = false;
                        button4.color = new Vector4(255.0f, 255.0f, 255.0f, 255.0f) / 255.0f;

                    }
                    else
                    {
                        rb.angularVelocity = new Vector3(2, 500, 0);
                        rotating = true;
                        transform.rotation = Quaternion.identity;
                        button4.color = new Vector4(255.0f, 255.0f, 255.0f, 255.0f) / 255.0f;
                    }
                }
            }
        }
    }
    public void adjustx (float newx)
    {
        screw.localScale = new Vector3(factor * newx, screw.localScale.y, screw.localScale.z);
    }
    public void adjusty(float newy)
    {
        screw.localScale = new Vector3(screw.localScale.x, factor * newy, screw.localScale.z);
    }
    public void adjustz(float newz)
    {
        screw.localScale = new Vector3(screw.localScale.x, screw.localScale.y, factor * newz);
    }

}
