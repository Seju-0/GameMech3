using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [Header("References")]

    public Rigidbody rb;
    public Transform head;
    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * 2f);
    }
    void FixedUpdate()
    {
        Vector3 newVelocity = Vector3.up * rb.velocity.y;
        rb.velocity = transform.TransformDirection(newVelocity);
    }
    private void LateUpdate()
    {
        //Vertical Rotation
        Vector3 e = head.eulerAngles;
        e.x -= Input.GetAxis("Mouse Y") * 2f;
        e.x = RestrictAngle(e.x, -85f, 85f);
        head.eulerAngles = e;
    }
    public static float RestrictAngle(float angle, float angleMin, float angleMax)
    {
        if (angle > 180)
            angle -= 360;
        else if (angle < -180)
            angle += 360;

        if (angle > angleMax)
            angle = angleMax;
        if (angle < angleMin)
            angle = angleMin;

        return angle;
    }
}

