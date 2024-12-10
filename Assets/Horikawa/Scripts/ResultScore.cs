using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResultScore : MonoBehaviour
{
    [SerializeField]
    int debug_AddScoreNum;
    [SerializeField]
    Text scoreNumText;
    [SerializeField]
    Text scoreRankText;
    [SerializeField]
    int rankBorderS;
    [SerializeField]
    int rankBorderA;
    [SerializeField]
    int rankBorderB;
    [SerializeField]
    int rankBorderC;
    // Start is called before the first frame update
    void Start()
    {
        ScoreManager.Score += debug_AddScoreNum;
        if (scoreNumText == null)
        {
            scoreNumText = GetComponent<Text>();
        }
        if (scoreNumText == null)
        {
            scoreRankText = GetComponent<Text>();
        }

        scoreNumText.text = ScoreManager.Score.ToString();
        scoreRankText.text = getRank();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    string getRank()
    {
        int mScore = ScoreManager.Score;
        if (mScore >= rankBorderS)
        {
            return "S";
        }
        else if(mScore >= rankBorderA)
        {
            return "A";
        }
        else if (mScore >= rankBorderB)
        {
            return "B";
        }
        else if (mScore >= rankBorderC)
        {
            return "C";
        }
        else return "null";
    }
}
