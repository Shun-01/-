using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeNextScene : MonoBehaviour
{
    public string m_nextScene;

    private bool isable = false;

    private void Start()
    {
        StartCoroutine(able());
    }

    private void Update()
    {
        // マウスを左クリックすると次のシーンへ遷移する
        if (Input.GetMouseButtonDown(0)&&isable)
        {
            SceneManager.LoadScene(m_nextScene);
        }
    }

    private IEnumerator able()
    {
        yield return new WaitForSeconds(1.5f);
        isable = true;

    }
}