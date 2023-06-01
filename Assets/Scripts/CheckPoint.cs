using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // Start is called before the first frame update\
    public Sprite cpOn, cpOff;
    SpriteRenderer theSR;
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CheckpointController.instance.DeactiveCheckpoints();
            CheckpointController.instance.SetSpawnPoint(transform.position);
            theSR.sprite = cpOn;
        }
    }
    public void ResetCheckpoint()
    {
        theSR.sprite = cpOff;
    }
}
