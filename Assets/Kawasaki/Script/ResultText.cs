using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultText : MonoBehaviour
{
    public Sprite sprite_SS;// 変更する画像をインスペクターで入れます
    public Sprite sprite_S; // 変更する画像をインスペクターで入れます
    public Sprite sprite_A; // 変更する画像をインスペクターで入れます
    public Sprite sprite_B; // 変更する画像をインスペクターで入れます
    public Sprite sprite_C; // 変更する画像をインスペクターで入れます
    public Sprite sprite_F; // 変更する画像をインスペクターで入れます

    public SpriteRenderer sr; // 変更するオブジェクトのSpriteRenderer

    void Update()
    {
        if(ScoreManager.Score >= 400000)
        {
            sr.sprite = sprite_SS;             // ランクS
        }
        else if(400000 > ScoreManager.Score && ScoreManager.Score >= 350000)          // ランクS
        {
            sr.sprite = sprite_S;
        }
        else if(350000 > ScoreManager.Score && ScoreManager.Score >= 200000)    // ランクA
        {
            sr.sprite = sprite_A;
        }
        else if(200000 > ScoreManager.Score && ScoreManager.Score >= 100000)    // ランクB
        {
            sr.sprite = sprite_B;
        }
        else if(100000 > ScoreManager.Score&& ScoreManager.Score > 0)    // ランクC
        {
            sr.sprite = sprite_C;
        }
        else if (0 > ScoreManager.Score)        // ランクF
        {
            sr.sprite = sprite_F;
        }
    }
}
