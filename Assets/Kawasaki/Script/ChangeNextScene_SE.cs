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
        // �}�E�X�����N���b�N�ŉ��y��炷(2�d�Ŗ点�Ȃ��悤�ɏ�����ǉ�)
        if (Input.GetMouseButtonDown(0) && !audioSource.isPlaying)
        {
            StartCoroutine(Cor());
        }
    }

    // SE��炵�A��I��������Ƃ�ʒm����R���[�`��
    IEnumerator Cor()
    {
        // SE��炷
        audioSource.PlayOneShot(audioClip);

        // ��n�߂����Ƃ�\��
        Debug.Log("�J�n");

        // �I���܂őҋ@
        yield return new WaitWhile(() => audioSource.isPlaying);

        // �I���������Ƃ�\��
        Debug.Log("�I��");

        // SE����I������玟�̃V�[���֑J�ڂ���
        SceneManager.LoadScene(m_nextScene);
    }
}