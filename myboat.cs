using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myboat : MonoBehaviour
{
    int level;
    int durable;
    int speed;
    int bagNum;
    float maxAngle;

    Vector3 lastSafePoint;
    public GameObject tolastSafePoint;//指向上一个安全点的指示物体
    // Use this for initialization
    void Start()
    {
        level = 1;
        durable = level * 10;
        speed = level + 2;
        bagNum = 2 * (level - 1) + 10;

        //lastSafePoint = new Vector3(0, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, lastSafePoint) >= 8)
        {
            tolastSafePoint.transform.LookAt(lastSafePoint);
            tolastSafePoint.transform.position = this.transform.position;
            tolastSafePoint.transform.Translate(0, 0, 1.5f);
            tolastSafePoint.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            tolastSafePoint.GetComponent<Renderer>().enabled = false;
        }

        this.transform.Translate(0, 0, Time.deltaTime * speed);

    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "enemy")
        {
            Debug.Log("get a good");
        }

        

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "safePoint")
        {
            lastSafePoint = other.transform.position;
            Debug.Log("in safePoint");
        }
    }

}
