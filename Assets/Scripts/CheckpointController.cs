using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 spawnPoint;
    public static CheckpointController instance;
    CheckPoint[] checkpoints;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        spawnPoint = PlayerController.instance.gameObject.transform.position;
        checkpoints = FindObjectsOfType<CheckPoint>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DeactiveCheckpoints()
    {
        for(int i = 0; i < checkpoints.Length; i++)
        {
            checkpoints[i].ResetCheckpoint();
        }
    }
    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;
    }
}
