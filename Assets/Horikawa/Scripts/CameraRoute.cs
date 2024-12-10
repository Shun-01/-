using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRoute : MonoBehaviour
{
    [HideInInspector]
    public GameObject mObject;
    [SerializeField]
    public float arrivalTime;//“ž’B‚·‚éŽžŠÔ

    void Start()
    {
        mObject = GetComponent<GameObject>();
    }
}
