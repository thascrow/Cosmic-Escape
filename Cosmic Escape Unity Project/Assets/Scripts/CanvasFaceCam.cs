using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFaceCam : MonoBehaviour
{
    [SerializeField] private Transform cam;

    private void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
