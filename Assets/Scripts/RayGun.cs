using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
 
public class RayGun : MonoBehaviour
{
    public GameObject trig;
     XRRayInteractor laserLine;
 
    void Awake()
    {
        laserLine = trig.GetComponent<XRRayInteractor>();
        laserLine.enabled = false;
    }
 
    void Update()
    {
        
    }
 
    public void setRayOn(){
        laserLine.enabled = true;
    }

    public void setRayOff(){
        laserLine.enabled = false;
    }
}