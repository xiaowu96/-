using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lighthouse_judge2 : MonoBehaviour
{
    int speed = 10;

    int seaLevel;

    EnemyBoat1[] currentEnemyBoat1;
    public EnemyBoat1 enemyBoat1;
    int boatMaxNum;
    public bool BoatIsSend;
    public bool CreatBoat;
    public int nowBoatNum;

    int readyTime;

    // Use this for initialization
    void Start()
    {
        boatMaxNum = 3;
        currentEnemyBoat1 = new EnemyBoat1[boatMaxNum];
        seaLevel = 1;
        BoatIsSend = false;
        CreatBoat = false;
        readyTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (readyTime != 0)
        {
            readyTime--;
        }
        if (CreatBoat == true && readyTime == 0)
        {
            for (int i = 0; i < currentEnemyBoat1.Length; i++)
            {
                if (!currentEnemyBoat1[i])
                {
                    Debug.Log("creat");

                    currentEnemyBoat1[i] = (EnemyBoat1)Instantiate(enemyBoat1, transform.position, enemyBoat1.transform.rotation);
                    currentEnemyBoat1[i].Init(transform.position, 1);
                    readyTime = 20;
                    break;
                }

            }
        }

        Debug.Log(currentEnemyBoat1.Length);
        nowBoatNum = 0;
        for (int i = 0; i < currentEnemyBoat1.Length; i++)
        {
            if (currentEnemyBoat1[i])
            {
                nowBoatNum++;
                Debug.Log(nowBoatNum);
            }
        }

        if (CreatBoat == true && nowBoatNum == boatMaxNum)
        {
            CreatBoat = false;
        }

        if (nowBoatNum == 0)
        {
            BoatIsSend = false;
        }
    }
    void OnTriggerEnter(Collider mCollider)//进入触发器。碰撞机
    {
        if (mCollider.gameObject.tag == "myBoat")
        {
            Debug.Log("11");
            if (BoatIsSend == false)
            {
                CreatBoat = true;
                BoatIsSend = true;
            }

        }

    }
    void OnTriggerStay(Collider mCollider)//处于
    {
        if (mCollider.gameObject.tag == "myBoat")
        {
            Debug.Log("22");
            if (BoatIsSend == false)
            {
                CreatBoat = true;
                BoatIsSend = true;
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
