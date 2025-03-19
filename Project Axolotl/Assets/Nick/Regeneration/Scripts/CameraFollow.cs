using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// IMPORTANT - This script goes on the camera

public class CameraFollow : MonoBehaviour
{

    #region Variables

    private Vector3 offSet = new Vector3(0f, 0f, -10f);
    private Vector3 velocitySpeed = Vector3.zero; // speed of camera

    public float smoothTime = 0.25f; // the smoothing time for the camera

    [SerializeField] private Transform target; // what the camera follows

    #endregion

    private void Update()
    {
        Vector3 targetPosition = target.position + offSet; // location the camera should go

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocitySpeed, smoothTime); // move camera to target on a smooth damp
    }
}
