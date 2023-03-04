using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBase : MonoBehaviour
{
    [SerializeField] protected Transform spawnPrefab;
    [SerializeField] protected float spawnPosOffsetX;
    [SerializeField] protected float spawnRate;
    [SerializeField] protected float waitForSecToSpawn;

    // 3 �e�it sapwnoffset var ilki 1 ikinci 1.5 ve sonunucsu 2 firewalla g�re ayarama yap
    protected void Start()
    {
        InvokeRepeating("Spawn", waitForSecToSpawn, spawnRate);
    }
    

    protected virtual void Spawn()
    {
        float spawnPosx = Random.Range(CameraScr.Instance.cameraLeftCornerX.x + spawnPosOffsetX, CameraScr.Instance.cameraRightCornerX.x - spawnPosOffsetX);
        Vector3 spawnPos = new Vector3(spawnPosx, transform.position.y, 0f);
        Instantiate(spawnPrefab, spawnPos, Quaternion.identity);
    }


    [ContextMenu("StartSpawning")]
    protected virtual void StartSpawning()
    {
        InvokeRepeating("Spawn", waitForSecToSpawn, spawnRate);
    }

    [ContextMenu("StopSpawning")]
    protected virtual void StopSpawning()
    {
        CancelInvoke("Spawn");
    }

}
