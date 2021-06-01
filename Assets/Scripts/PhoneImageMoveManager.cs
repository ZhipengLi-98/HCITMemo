using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneImageMoveManager : MonoBehaviour
{
    public GameObject phone;

    private Vector3 posOffset;
    private Quaternion rotOffset;

    // Start is called before the first frame update
    void Start()
    {
        posOffset = this.transform.position - phone.transform.position;
        rotOffset = this.transform.rotation * Quaternion.Inverse(phone.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = phone.transform.position + posOffset;
        this.transform.rotation = phone.transform.rotation * rotOffset * Quaternion.Euler(0, 180, 0);
    }
}
