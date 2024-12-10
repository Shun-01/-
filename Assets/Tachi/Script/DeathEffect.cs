using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEffect : MonoBehaviour
{
    [SerializeField]
    private AudioClip BocchiSE, CoupleSE;
    // Start is called before the first frame update
    void Start() {
        StartCoroutine("hogehoge");
        if (this.gameObject.name == "pose_sugoi_okoru_man") {
            GameObject.Find("AudioManager").GetComponent<AudioSource>().PlayOneShot(BocchiSE);
        } else if (this.gameObject.name == "shitsuren_man") {
            GameObject.Find("AudioManager").GetComponent<AudioSource>().PlayOneShot(CoupleSE);
        }
    }

    // Update is called once per frame
    void Update() {
        this.gameObject.transform.Rotate(0.0f, 0.0f, 0.07f);
    }

    IEnumerator hogehoge() {
        yield return new WaitForSeconds(1.0f);
        //this.gameObject.SetActive(false);
        Destroy(this.gameObject);
    }
}
