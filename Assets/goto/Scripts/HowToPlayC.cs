using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayC : MonoBehaviour
{
    [SerializeField]
    GameObject _hotoplay;

    [SerializeField]
    private GameObject[] _activeObjevts;

    // Start is called before the first frame update
    void Start()
    {
        ScoreManager.Score = 0;
        foreach (GameObject activeObj in _activeObjevts)
        {
            activeObj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _hotoplay.SetActive(true);
            _hotoplay.GetComponent<StartCountC>().StartCount(_activeObjevts);
            Destroy(gameObject);
        }
    }
}
