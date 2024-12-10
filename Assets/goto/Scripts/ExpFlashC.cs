using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpFlashC : MonoBehaviour
{
    protected Vector3 _goal;

    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected void FixedUpdate()
    {
        time += Time.deltaTime;
        if (time >= 0.2)
        {
            time = 0;
            transform.eulerAngles += Vector3.forward * 45;
        }

        transform.position+= GetSneaking(transform.position, _goal, 10);

    }

    public void SetGoal(Vector3 goal)
    {
        _goal = goal;
        
        Destroy(gameObject,Random.Range(0.6f,1.0f));
    }

    protected static Vector3 GetSneaking(Vector3 ownPos, Vector3 targetPos, float speed)
    {
        Vector3 sneaking = Vector3.zero;
        if (speed == 0.0f)
        {
            return sneaking;
        }
        sneaking.x = (targetPos.x - ownPos.x) / speed;
        sneaking.y = (targetPos.y - ownPos.y) / speed;
        return sneaking;
    }


}
