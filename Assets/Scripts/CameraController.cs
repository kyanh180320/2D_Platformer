using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public Transform farBackground;
    public Transform middleBackground;
    private Vector3 startPos;
    private float lastXPos;
    void Start()
    {
        startPos = farBackground.position;
        lastXPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
        float amountX = transform.position.x - lastXPos;
        farBackground.position += new Vector3(amountX, 0, 0);
        middleBackground.position += new Vector3(0.5f * amountX, 0, 0);
        lastXPos = transform.position.x;

        //Different Way
        //transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
        //farBackground.position = new Vector3(target.position.x, transform.position.y,0);
        //middleBackground.position = new Vector3(target.position.x * 0.5f, transform.position.y, 0);
       
    }
}
