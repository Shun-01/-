using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
public class Result : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreText,_rankText,_awordText;

    [SerializeField]
    private int Spuls, S, A, B;
    
    [SerializeField]
    private string awSpuls,awS,awA,awB,awC;

    [SerializeField]
    private AudioClip _audioClip,exp;

    [SerializeField]
    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetSeries());



    }

    private IEnumerator SetSeries()
    {
        SetScore();
        yield return new WaitForSeconds(1f);
        SetRank();
        yield return new WaitForSeconds(1f);
        SetAword();
    }

    private void SetScore()
    {
        _audioSource.PlayOneShot(_audioClip);
        _scoreText.gameObject.SetActive(true);
        _scoreText.text = "Score:" + ScoreManager.Score.ToString();
    }

    private void SetRank()
    {
        _audioSource.PlayOneShot(_audioClip);
        _rankText.gameObject.SetActive(true);
        string rank = "";
        if (ScoreManager.Score >= Spuls) rank = "S+";
        else if (ScoreManager.Score >= S) rank = "S";
        else if (ScoreManager.Score >= A) rank = "A";
        else if (ScoreManager.Score >= B) rank = "B";
        else rank = "C";
        _rankText.text = "Rank:" + rank;
    }

    private void SetAword()
    {
        _audioSource.PlayOneShot(exp);
        _awordText.gameObject.SetActive(true);

        if (ScoreManager.Score >= Spuls) _awordText.text = awSpuls;
        else if (ScoreManager.Score >= S) _awordText.text = awS;
        else if (ScoreManager.Score >= A) _awordText.text = awA;
        else if (ScoreManager.Score >= B) _awordText.text = awB;
        else _awordText.text = awC;
    }
}
