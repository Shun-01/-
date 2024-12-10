using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TimeManager : MonoBehaviour
{
    [SerializeField]
    float timeLimit;
    [SerializeField]
    string resultSceneName;
    float m_timer;
    public float getNowTime() { return m_timer; }
    public float getTimeLimit() { return timeLimit; }
    Text timeText;
    public bool isStop;
    // Start is called before the first frame update
    void Start()
    {
        timeText = GetComponent<Text>();
        m_timer = timeLimit;
        timeText.text = m_timer.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        if (isStop) return;

        timeText.text = m_timer.ToString("F2");
        m_timer -= Time.deltaTime;
        if (m_timer <= 0)
        {
            m_timer = 0;
            TimeOver();
        }
        
    }

    void AddTime(float mNum)
    {
        m_timer += mNum;
        if(m_timer <=0)m_timer = 0;
        timeText.text = m_timer.ToString();
    }

    void TimeOver()
    {
        SceneManager.LoadScene(resultSceneName);
    }
}
