using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreText : MonoBehaviour
{
    Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        scoreText.text = "SCORE:" + ScoreManager.Score.ToString("0000000");

    }
}
