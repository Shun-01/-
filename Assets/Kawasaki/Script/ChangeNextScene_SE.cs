using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeNextScene_SE : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

    public string m_nextScene;

    private void Update()
    {
        // マウスを左クリックで音楽を鳴らす(2重で鳴らせないように条件を追加)
        if (Input.GetMouseButtonDown(0) && !audioSource.isPlaying)
        {
            StartCoroutine(Cor());
        }
    }

    // SEを鳴らし、鳴り終わったことを通知するコルーチン
    IEnumerator Cor()
    {
        // SEを鳴らす
        audioSource.PlayOneShot(audioClip);

        // 鳴り始めたことを表示
        Debug.Log("開始");

        // 終了まで待機
        yield return new WaitWhile(() => audioSource.isPlaying);

        // 終了したことを表示
        Debug.Log("終了");

        // SEが鳴り終わったら次のシーンへ遷移する
        SceneManager.LoadScene(m_nextScene);
    }
}