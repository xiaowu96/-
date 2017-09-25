using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lighthouse_judge3 : MonoBehaviour
{
    int speed = 10;

    int seaLevel;

    public lighthouse_judge2 light_judges;


    // Use this for initialization
    void Start()
    {
        seaLevel = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider mCollider)//进入触发器。碰撞机
    {
        if (mCollider.gameObject.tag == "myBoat")
        {
            Debug.Log("11");
            if (light_judges.BoatIsSend == false)
            {
                light_judges.CreatBoat = true;
                light_judges.BoatIsSend = true;
            }

        }

    }
    void OnTriggerStay(Collider mCollider)//处于
    {
        if (mCollider.gameObject.tag == "myBoat")
        {
            Debug.Log("22");
            if (light_judges.BoatIsSend == false)
            {
                light_judges.CreatBoat = true;
                light_judges.BoatIsSend = true;
            }
        }

    }
    void OnTriggerExit(Collider mCollider)//退出
    {
        if (mCollider.CompareTag("myBoat"))
        {

            Debug.Log("33");
        }
    }
    

}
