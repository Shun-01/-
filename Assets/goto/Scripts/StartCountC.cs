using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartCountC : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _countText;

    private GameObject[] _activeObjevts;

    [SerializeField]
    private AudioClip _acCountDown, _acStart;

    /// <summary>
    /// �J�E���g�_�E���l
    /// </summary>
    [SerializeField]
    private int timer = 3;

    /// <summary>
    /// �J�E���g����
    /// </summary>
    [SerializeField]
    private float _countDelta = 1.0f;

    [SerializeField]
    private AudioSource _audioS;

    [SerializeField]
    private GameObject _coupleM;

    
    public void StartCount(GameObject[] sets)
    {
        _activeObjevts = sets;
        StartCoroutine(CountDown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator CountDown()
    {
        while (timer > 0)
        {
            _audioS.PlayOneShot(_acCountDown);

           _countText.text=timer.ToString();
            yield return new WaitForSeconds(_countDelta);
            timer--;
        }
        StartGame();
        _audioS.PlayOneShot(_acStart);
        _audioS.Play();
        _countText.text = "FIRE!!";
        yield return new WaitForSeconds(_countDelta);
        _countText.gameObject.SetActive(false);
    }

    private void StartGame()
    {

        foreach(GameObject activeObj in _activeObjevts)
        {
            activeObj.SetActive(true);
        }
        _coupleM.GetComponent<GenerateManager>().GameStart();
    }
}
