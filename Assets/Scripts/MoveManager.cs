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

    // Start is called before the first frame update
    void Start()
    {
        textMilk.SetActive(false);
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
            cam.transform.position = new Vector3(-115, 5, 2);
            if (!textRecord.activeSelf)
            {
                textMilk.SetActive(true);
            }
        }
        if (cam.transform.position.x < -100)
        {
            textRecord.transform.position = cam.transform.position + 10.0f * centereye.transform.forward;
            textRecord.transform.rotation = Quaternion.LookRotation(centereye.transform.forward, centereye.transform.up);
            if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
            {
                textRecord.SetActive(false);
            }
        }
    }
}
