using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    private float realsensX;
    public float sensY;
    private float realsensY;

    public Transform orientation;
    float xRotation;
    float yRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        realsensX = sensX * 20;
        realsensY = sensY * 20;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * realsensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * realsensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //rotation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0f);
    }
}
