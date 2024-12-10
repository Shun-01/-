using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRoute : MonoBehaviour
{
    [HideInInspector]
    public GameObject mObject;
    [SerializeField]
    public float arrivalTime;//到達する時間

    void Start()
    {
        mObject = GetComponent<GameObject>();
    }
}
