using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotating : MonoBehaviour
{

    [SerializeField] GameObject Board;
    [SerializeField] GameObject Cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cam.transform.LookAt(Board.transform.position);

        transform.Rotate(new Vector3(0, 0.2f, 0), Space.Self);
    }
}
