using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRoute : MonoBehaviour
{
    [HideInInspector]
    public GameObject mObject;
    [SerializeField]
    public float arrivalTime;//���B���鎞��

    void Start()
    {
        mObject = GetComponent<GameObject>();
    }
}
