using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileC : MonoBehaviour
{
    /// <summary>
    /// �^�[�Q�b�g�ʒu
    /// </summary>
    private Vector3 _posTarget;

    /// <summary>
    /// ���ˈʒu
    /// </summary>
    private Vector3 _posOwnFirst;

    /// <summary>
    /// ���e�܂ł̎���
    /// </summary>
    [SerializeField]
    private float _countMissileFirst;

    /// <summary>
    /// ���Z�l
    /// </summary>
    private Vector3 _posDelta;

    /// <summary>
    /// ���e�܂ł̎c�莞��
    /// </summary>
    private float _countMissile;

    /// <summary>
    /// �����T�C�Y
    /// </summary>
    private Vector3 _scaOwn;

    /// <summary>
    /// �������Ȃ�X�s�[�h
    /// </summary>
    private Vector3 _scaDelta;

    /// <summary>
    /// �����͈�
    /// </summary>
    [SerializeField]
    private float _radiusExp;

    /// <summary>
    /// �������o
    /// </summary>
    [SerializeField]
    private GameObject _prfbExp,_prfbDust;

    /// <summary>
    /// ��
    /// </summary>
    [SerializeField]
    private GameObject _prfbSmog;

    /// <summary>
    /// �I�[�f�B�I
    /// </summary>
    [SerializeField]
    private AudioMC _auSource;

    [SerializeField]
    private AudioClip _clipExp,_shot;

    /// <summary>
    /// ���ˈʒu�ƒ��e�ʒu�̓���
    /// �i�������F���e�ʒu�A�������F���ˈʒu�j
    /// </summary>
    /// <param name="target"></param>
    /// <param name="first"></param>
    public void SetTarget(Vector3 target,Vector3 first)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        _posOwnFirst = first;
        _posTarget = target;
    }

    private void Start()
    {
        _posOwnFirst = transform.position;
        _posDelta = (_posTarget - _posOwnFirst) / _countMissileFirst;
        _scaOwn=transform.localScale;
        _scaDelta = _scaOwn / _countMissileFirst;
        _countMissile = _countMissileFirst;
        //transform.eulerAngles = new Vector3(0, 0, GetAngle(_posOwnFirst, _posTarget));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.position += _posDelta;
        transform.localScale -= _scaDelta;

        if (Random.Range(0, 2) == 0)
        {
            SummonSmog(_prfbSmog, 1,1.0f).GetComponent<SmogC>().SetSize((_countMissile / _countMissileFirst)*0.7f);
            GetComponent<SpriteRenderer>().color= Color.white;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.yellow;
        }


        _countMissile--;
        if (_countMissile <= 0)
        {
            GameObject.Find("AudioManager").GetComponent<AudioSource>().PlayOneShot(_clipExp);
            //Debug.Log("Dooooooon!");
            DoExp();
        }
    }


    /// <summary>
    /// �~�`�o���T��
    /// </summary>
    /// <param name="smog"></param>
    /// <param name="areaRad"></param>
    /// <returns></returns>
    private GameObject SummonSmog(GameObject smog,int areaRad,float deleteTime)
    {
        float radRandom = Random.Range(0, 360);
        float areaRamdom = Random.Range(0, areaRad);

        Vector3 posExp = transform.position
            + new Vector3(Mathf.Sin(radRandom * Mathf.Deg2Rad), Mathf.Cos(radRandom * Mathf.Deg2Rad), 0) * areaRamdom;

        GameObject Object = Instantiate(smog, posExp, Quaternion.Euler(0, 0, radRandom));
        Destroy(Object, deleteTime);
        return Object;
    }

    /// <summary>
    /// ���������A�[������
    /// </summary>
    private void DoExp()
    {
        for (int i = 0; i <= 10 + (_radiusExp *30); i++)
        {
            float radRandom = Random.Range(0, 360);
            float areaRamdom = Random.Range(0.0f, _radiusExp * 2);

            Vector3 posExp = transform.position
                + new Vector3(Mathf.Sin(radRandom * Mathf.Deg2Rad), Mathf.Cos(radRandom * Mathf.Deg2Rad), 0) * areaRamdom;

            Instantiate(_prfbExp, transform.position, Quaternion.Euler(0, 0, radRandom)).GetComponent<ExpFlashC>().SetGoal(posExp);
            //Instantiate(_prfbDust, transform.position, Quaternion.Euler(0, 0, radRandom)).GetComponent<ExpFlashC>().SetGoal(posExp);
        }

        RaycastHit2D[] ExpHits = Physics2D.CircleCastAll(transform.position, _radiusExp,Vector2.zero);
        foreach(RaycastHit2D hit in ExpHits)
        {
            if (hit.collider)
            {
                if (hit.collider.gameObject.tag == "Target")
                {
                    hit.collider.gameObject.GetComponent<TargetBehavior>().CalScore();
                }
                
            }
        }

        Destroy(gameObject);
    }

    private float GetAngle(Vector3 ownPos, Vector3 targetPos)
    {
        Vector2 direction = targetPos - ownPos;
        return Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }

}
