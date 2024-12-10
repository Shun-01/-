using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultText : MonoBehaviour
{
    public Sprite sprite_SS;// �ύX����摜���C���X�y�N�^�[�œ���܂�
    public Sprite sprite_S; // �ύX����摜���C���X�y�N�^�[�œ���܂�
    public Sprite sprite_A; // �ύX����摜���C���X�y�N�^�[�œ���܂�
    public Sprite sprite_B; // �ύX����摜���C���X�y�N�^�[�œ���܂�
    public Sprite sprite_C; // �ύX����摜���C���X�y�N�^�[�œ���܂�
    public Sprite sprite_F; // �ύX����摜���C���X�y�N�^�[�œ���܂�

    public SpriteRenderer sr; // �ύX����I�u�W�F�N�g��SpriteRenderer

    void Update()
    {
        if(ScoreManager.Score >= 400000)
        {
            sr.sprite = sprite_SS;             // �����NS
        }
        else if(400000 > ScoreManager.Score && ScoreManager.Score >= 350000)          // �����NS
        {
            sr.sprite = sprite_S;
        }
        else if(350000 > ScoreManager.Score && ScoreManager.Score >= 200000)    // �����NA
        {
            sr.sprite = sprite_A;
        }
        else if(200000 > ScoreManager.Score && ScoreManager.Score >= 100000)    // �����NB
        {
            sr.sprite = sprite_B;
        }
        else if(100000 > ScoreManager.Score&& ScoreManager.Score > 0)    // �����NC
        {
            sr.sprite = sprite_C;
        }
        else if (0 > ScoreManager.Score)        // �����NF
        {
            sr.sprite = sprite_F;
        }
    }
}
