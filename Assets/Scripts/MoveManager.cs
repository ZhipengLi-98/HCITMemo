using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveManager : MonoBehaviour
{
    public GameObject cam;
    public GameObject centereye;
    public GameObject textRecord;
    public GameObject textMilk;

    private float timeThreshold;

    // Start is called before the first frame update
    void Start()
    {
        textMilk.SetActive(false);
        timeThreshold = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeThreshold > 0)
        {
            timeThreshold -= Time.deltaTime;
        }
        OVRInput.Update();
        float x = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x;
        float y = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y;
        cam.transform.position += (x / 10) * (centereye.transform.right);
        cam.transform.position += (y / 10) * (centereye.transform.forward);
        if (timeThreshold < 0 && !textMilk.activeSelf && OVRInput.Get(OVRInput.Button.One))
        {
            cam.transform.position = new Vector3(-115, 5, 2);
            if (!textRecord.activeSelf)
            {
                textMilk.SetActive(true);
            }
            timeThreshold = 0.5f;
        }
        if (timeThreshold < 0 && !textRecord.activeSelf && textMilk.activeSelf && OVRInput.Get(OVRInput.Button.One))
        {
            cam.transform.position = new Vector3(-1.361f, 0.89f, -29.4f);
            timeThreshold = 0.5f;
        }
        if (cam.transform.position.x < -100)
        {
            textRecord.transform.position = cam.transform.position + 10.0f * centereye.transform.forward;
            textRecord.transform.rotation = Quaternion.LookRotation(centereye.transform.forward, centereye.transform.up);
            if (timeThreshold < 0 && OVRInput.Get(OVRInput.Button.Two))
            {
                textRecord.SetActive(false);
                timeThreshold = 0.5f;
            }
        }
        
    }
}
