using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Snake target;
    private float _offset;

    private void Awake()
    {
        _offset = transform.position.z - target.transform.position.z;
    }

    
    void Update()
    {
        Vector3 curPos = transform.position;
        curPos.z = target.transform.position.z + _offset;
        if (transform.position.z < curPos.z)
        {
            transform.position = curPos;
        }
        else return;
    }
}
