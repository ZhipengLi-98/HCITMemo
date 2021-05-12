using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManager : MonoBehaviour
{
    public GameObject cam;
    public GameObject centereye;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();
        float x = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x;
        float y = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y;
        cam.transform.position += (x / 10) * (centereye.transform.right);
        cam.transform.position += (y / 10) * (centereye.transform.forward);
        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))
        {
            cam.transform.position = new Vector3(-221, 7, 2);
        }
    }
}
