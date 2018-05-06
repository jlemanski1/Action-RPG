using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;
    public Vector3 offset;

    public float pitch = 2f;

    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15f;
    private float currentZoom = 10f;

    public float yawSpeed = 100f;
    private float currentYaw = 0f;
    

	void Update()
    {
        //Zoom In/Out: ScrollWheel
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        //Turn Camera: A | D
        currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }

	void LateUpdate ()
    {
        //Move with & aim at target(player)
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);

        //Rotate with target
        transform.RotateAround(target.position, Vector3.up, currentYaw);
	}
}
