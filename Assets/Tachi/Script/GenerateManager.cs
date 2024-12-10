using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateManager : MonoBehaviour {
    public GameObject Couple;
    public GameObject Bocchi;
    public GameObject SpawnPos;
    GameObject[] CoupleList = new GameObject[10];
    GameObject[] BocchiList = new GameObject[10];
    int PhaseNum = 0;
    // Start is called before the first frame update
    private void Awake() {
        for (int j = 0; j < CoupleList.Length; j++) {
            CoupleList[j] = Instantiate(Couple) as GameObject;
            CoupleList[j].name = Couple.name;
            CoupleList[j].SetActive(false);
        }
        for (int j = 0; j < BocchiList.Length; j++) {
            BocchiList[j] = Instantiate(Bocchi) as GameObject;
            BocchiList[j].name = Bocchi.name;
            BocchiList[j].SetActive(false);
        }
    }

    public void GameStart() {
        StartCoroutine("generate");
        StartCoroutine("PhaseChanger");
    }

    IEnumerator generate() {
        while (true) {
            if(PhaseNum == 0) {
                spawn(SpawnPos, CoupleList);
                spawn(SpawnPos, CoupleList);
                spawn(SpawnPos, BocchiList);
            }else if(PhaseNum == 1) {
                for(int i= 0; i < 10; i++) {
                    spawn(SpawnPos, CoupleList);
                }
            }
            
            yield return new WaitForSeconds(2);
            SetInactive();
        }
    }

    IEnumerator PhaseChanger() {
        yield return new WaitForSeconds(50);
        PhaseNum = 1;
    }

    void spawn(GameObject/*[]*/ SpawnPoint, GameObject[] Target) {
        Vector2 BottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        Vector2 TopRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        for (int k = 0; k < SpawnPoint.transform.childCount + 1; k++) {
            if (k == SpawnPoint.transform.childCount) {
                return;
            }
            if (SpawnPoint.transform.GetChild(k).gameObject.activeSelf == true) {
                if (SpawnPoint.transform.GetChild(k).gameObject.transform.position.x > BottomLeft.x && SpawnPoint.transform.GetChild(k).gameObject.transform.position.x < TopRight.x) {
                    if (SpawnPoint.transform.GetChild(k).gameObject.transform.position.y > BottomLeft.y && SpawnPoint.transform.GetChild(k).gameObject.transform.position.y < TopRight.y) {
                        break;
                    }
                }
            }
        }
        int i = Random.Range(0, SpawnPoint.transform.childCount);
        //Debug.Log(SpawnList[i].name);
        while (true) {
            if(SpawnPoint.transform.GetChild(i).gameObject.activeSelf == false) {
                i = Random.Range(0, SpawnPoint.transform.childCount);
                continue;
            }

            if (SpawnPoint.transform.GetChild(i).gameObject.transform.position.x < BottomLeft.x || SpawnPoint.transform.GetChild(i).gameObject.transform.position.x > TopRight.x) {
                i = Random.Range(0, SpawnPoint.transform.childCount);
                continue;
            }

            if (SpawnPoint.transform.GetChild(i).gameObject.transform.position.y < BottomLeft.y || SpawnPoint.transform.GetChild(i).gameObject.transform.position.y > TopRight.y) {
                i = Random.Range(0, SpawnPoint.transform.childCount);
                continue;
            }
            break;
        }
        /*
        PosScript _PosScript = GameObject.Find(SpawnPoint.transform.GetChild(i).gameObject.name).GetComponent<PosScript>();
        while ((SpawnPoint.transform.GetChild(i).gameObject.activeSelf == false)/* || _PosScript.Visible == false) {
            i = Random.Range(0, SpawnPoint.transform.childCount);
        }
        */
        SpawnPoint.transform.GetChild(i).gameObject.SetActive(false);
        for (int j = 0; j < Target.Length; j++) {
            if (Target[j].activeSelf == false) {
                Target[j].transform.position = SpawnPoint.transform.GetChild(i).gameObject.transform.position;
                Target[j].SetActive(true);
                break;
            } else if (j == Target.Length - 1) {
                Target[0].transform.position = SpawnPoint.transform.GetChild(i).gameObject.transform.position;
                Target[0].SetActive(true);
                break;
            }
        }
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void SetInactive() {
        for (int j = 0; j < CoupleList.Length; j++) {
            CoupleList[j].SetActive(false);
        }
        for (int j = 0; j < BocchiList.Length; j++) {
            BocchiList[j].SetActive(false);
        }
        for (int j = 0; j < SpawnPos.transform.childCount; j++) {
            SpawnPos.transform.GetChild(j).gameObject.SetActive(true);
        }
    }
}
