using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

    public float currxRot;
    public float curryRot;
    public float sensitivity = 5f;

    float xRot;
    float yRot;
    float xVel;
    float yVel;
    float smoothtime = .05f;

    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Turn();
    }

    void Turn()
    {
        xRot -= Input.GetAxisRaw("Mouse Y") * sensitivity;
        yRot += Input.GetAxisRaw("Mouse X") * sensitivity;

        currxRot = Mathf.SmoothDamp(currxRot, xRot, ref xVel, smoothtime);
        curryRot = Mathf.SmoothDamp(curryRot, yRot, ref yVel, smoothtime);

        currxRot =  Mathf.Clamp(currxRot, -60, 60);

        transform.rotation = Quaternion.Euler(currxRot, curryRot, 0);
    }
}
