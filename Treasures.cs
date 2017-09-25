using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasures : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "myBoat")
        {
            GetGoodsType();
            Destroy(gameObject);
        }

    }

    void GetGoodsType()
    {
        int temp;
        temp = UnityEngine.Random.Range(0, 20);

        if (temp < 16)
        {
            Debug.Log("You get some gold");
        }
        else if (temp < 18)
        {
            Debug.Log("You get a tool");
        }
        else if (temp < 19)
        {
            Debug.Log("You get a weapon");
        }
        else
        {
            Debug.Log("You get a collection");
        }
    }
}
