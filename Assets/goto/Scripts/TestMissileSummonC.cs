using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMissileSummonC : MonoBehaviour
{
    /// <summary>
    /// ミサイルオブジェクト
    /// </summary>
    [SerializeField]
    private MissileC _prfbMissile;

    [SerializeField]
    private Vector3 _posCannon;

    [SerializeField]
    private Transform _firstPosGo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _posCannon = _firstPosGo.position;
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(_prfbMissile, _posCannon, Quaternion.Euler(0, 0, 0))
                .SetTarget(GetMousePosition(), _posCannon);
        }
    }

    private Vector3 GetMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10;
        Vector3 target = Camera.main.ScreenToWorldPoint(mousePosition);
        return target;
    }
}
