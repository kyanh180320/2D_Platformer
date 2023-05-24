using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public Transform farBackground;
    public Transform middleBackground;
    public float minHeight;
    public float maxHeight;
    private Vector2 lastPos;

    void Start()
    {
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);

        Vector2 amoutToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);

        farBackground.position += new Vector3(amoutToMove.x, amoutToMove.y, 0);
        middleBackground.position += new Vector3(amoutToMove.x, amoutToMove.y, 0) * 0.5f;

        lastPos = transform.position;


        //Different Way Background Parralax horizontal
        //transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
        //farBackground.position = new Vector3(target.position.x, transform.position.y,0);
        //middleBackground.position = new Vector3(target.position.x * 0.5f, transform.position.y, 0);

    }
}
