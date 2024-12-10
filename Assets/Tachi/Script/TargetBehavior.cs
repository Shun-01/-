using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavior : MonoBehaviour {
    //int Score;
    public GameObject CoupleEffect;
    public GameObject BocchiEffect;
    //GameObject[] CoupleEffectList = new GameObject[5];
    //GameObject[] BocchiEffectList = new GameObject[3];
    int num = 1;

    // Start is called before the first frame update
    private void Awake() {
        /*
        for (int i = 0; i < CoupleEffectList.Length; i++) {
            CoupleEffectList[i] = Instantiate(CoupleEffect);
            CoupleEffectList[i].name = CoupleEffect.name;
            CoupleEffectList[i].SetActive(false);
        }
        for (int i = 0; i < BocchiEffectList.Length; i++) {
            BocchiEffectList[i] = Instantiate(BocchiEffect);
            BocchiEffectList[i].name = BocchiEffect.name;
            BocchiEffectList[i].SetActive(false);
        }
        */
    }

    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void CalScore() {
        //Debug.Log("aaaa");
        if (this.gameObject.name == "christmas_hitori_bocchi") {
            ScoreManager.Score -= 3000;
            GameObject obj = Instantiate(BocchiEffect,transform.position,transform.rotation);
            obj.name = BocchiEffect.name;
            /*
            for(int i = 0; i < BocchiEffectList.Length; i++) {
                if (BocchiEffectList[i].activeSelf == false) {
                    BocchiEffectList[i].transform.position = this.gameObject.transform.position;
                    BocchiEffectList[i].SetActive(true);
                    break;
                }else if (i == BocchiEffectList.Length - 1) {
                    BocchiEffectList[0].transform.position = this.gameObject.transform.position;
                    BocchiEffectList[0].SetActive(true);
                    break;
                }
            }
            */
            this.gameObject.SetActive(false);
        } else if (this.gameObject.name == "date_couple") {
            ScoreManager.Score += 5000;
            GameObject obj = Instantiate(CoupleEffect,transform.position, transform.rotation);
            obj.name = CoupleEffect.name;
            /*
            for (int i = 0; i < CoupleEffectList.Length; i++) {
                if (CoupleEffectList[i].activeSelf == false) {
                    CoupleEffectList[i].transform.position = this.gameObject.transform.position;
                    CoupleEffectList[i].SetActive(true);
                    break;
                } else if (i == CoupleEffectList.Length - 1) {
                    CoupleEffectList[0].transform.position = this.gameObject.transform.position;
                    CoupleEffectList[0].SetActive(true);
                    break;
                }
            }
            */
            this.gameObject.SetActive(false);
        }
    }
}
