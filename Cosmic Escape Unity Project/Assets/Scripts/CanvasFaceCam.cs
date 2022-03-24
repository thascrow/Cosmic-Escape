using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFaceCam : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private Canvas canvas;

    private void Start()
    {
        cam = Camera.main;
        canvas.worldCamera = cam;
    }

    private void LateUpdate()
    {
        transform.LookAt(transform.position + cam.transform.forward);
    }
}
