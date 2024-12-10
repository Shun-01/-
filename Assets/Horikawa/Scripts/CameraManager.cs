using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CameraManager : MonoBehaviour
{
    [SerializeField]
    TimeManager timeManager;
    [SerializeField]
    List<CameraRoute> cameraRoots;
    int nowTargetNum = 0;
    float nowTime;
    Vector3 originPos;
    float originTime;
    Vector3 targetPos;
    float targetTime;
    //[SerializeField]
    //Text debugText;
    // Start is called before the first frame update
    void Start()
    {
        originPos  = transform.position;
        originTime = timeManager.getTimeLimit();
    }

    // Update is called once per frame
    void Update()
    {
        if(cameraRoots != null)//�G���[���
        {

            nowTime = timeManager.getNowTime();
            //���ɓ��B�\���CameraRoot������
            for (int i=nowTargetNum;i<cameraRoots.Count;i++)
            {
                if (nowTime >= cameraRoots[i].arrivalTime)
                {
                    nowTargetNum = i;
                    targetPos = cameraRoots[i].transform.position;
                    targetTime = cameraRoots[i].arrivalTime;
                    break;
                }
                else
                {
                    originPos = cameraRoots[i].transform.position;
                    originTime = cameraRoots[i].arrivalTime;
                }
            }

            //�o���n�_����ڕW�n�_�܂ł�Lerp
            transform.position = (Vector3.Lerp(originPos,targetPos, (originTime - nowTime) / (timeManager.getTimeLimit() - cameraRoots[nowTargetNum].arrivalTime - (timeManager.getTimeLimit() - originTime))));
            //debugText.text = cameraRoots.Count.ToString();
        }
    }
}
