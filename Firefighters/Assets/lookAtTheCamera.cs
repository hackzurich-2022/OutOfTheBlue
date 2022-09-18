using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtTheCamera : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject mainCamera;
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(mainCamera.transform);
    }
}
