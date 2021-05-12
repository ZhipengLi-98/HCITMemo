using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserManager : MonoBehaviour
{
    public LineRenderer laserLineRenderer;
    public float laserWidth = 0.01f;
    public OVRInput.Controller controllerType;
    public float dist;
    private Vector3 startPoint;
    public GameObject centerEye;
    public GameObject textFridge1;
    public GameObject textFridge2;
    public GameObject textFridge3;

    // Start is called before the first frame update
    void Start()
    {
        laserLineRenderer.positionCount = 2;
        laserLineRenderer.SetPosition(0, Vector3.zero);
        laserLineRenderer.SetPosition(1, Vector3.zero);
        laserLineRenderer.startWidth = laserWidth;
        laserLineRenderer.endWidth = laserWidth;
        dist = 10.0f;
        startPoint = new Vector3(0, 1.5f, 0);
        textFridge1.SetActive(false);
        textFridge2.SetActive(false);
        textFridge3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetActiveController() == controllerType)
        {
            startPoint = centerEye.transform.position;
            laserLineRenderer.SetPosition(0, startPoint + OVRInput.GetLocalControllerPosition(controllerType));
            laserLineRenderer.SetPosition(1, startPoint + OVRInput.GetLocalControllerPosition(controllerType) + dist * (OVRInput.GetLocalControllerRotation(controllerType) * Vector3.forward));

            RaycastHit hit;
            if (Physics.Raycast(startPoint + OVRInput.GetLocalControllerPosition(controllerType), startPoint + OVRInput.GetLocalControllerPosition(controllerType) + dist * (OVRInput.GetLocalControllerRotation(controllerType) * Vector3.forward), out hit, 15f))
            {
                if (hit.collider != null)
                {
                    if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
                    {
                        if (hit.transform.gameObject.name.Equals("PFB_Fridge"))
                        {
                            Debug.Log(hit.transform.gameObject.name);
                            textFridge1.SetActive(true);
                            textFridge2.SetActive(true);
                            textFridge3.SetActive(true);
                        }
                    }
                }
            }
        }
    }
}
