using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    GameObject[] currentGoods;
    public GameObject goods;
    int maxGoodsNum;

    EnemyBoat[] currentEnemyBoat;
    public EnemyBoat enemyBoat;

    GameObject[] currentSafePoint;
    public GameObject safePoint;

    // Use this for initialization
    void Start()
    {
        maxGoodsNum = 4;
        currentGoods = new GameObject[maxGoodsNum];

        currentSafePoint = new GameObject[2];
        SafePointInit();

        currentEnemyBoat = new EnemyBoat[4];
        EnemyBoatInit();
    }

    // Update is called once per frame
    void Update()
    {
        TreasuresUpdate();

    }

    void TreasuresUpdate()
    {
        for (int i = 0; i < currentGoods.Length; i++)
        {
            if (currentGoods[i] == null)
            {
                float tx = 0.0f;
                float tz = 0.0f;
                while (-30.0f < tx && tx < 30.0f)
                {
                    tx = UnityEngine.Random.Range(-100, 100);
                }
                while (-30.0f < tz && tz < 30.0f)
                {
                    tz = UnityEngine.Random.Range(-100, 100);
                }

                currentGoods[i] = (GameObject)Instantiate(goods, new Vector3(tx, 0, tz), goods.transform.rotation);

            }
        }
    }

    void SafePointInit()
    {
        currentSafePoint[0] = (GameObject)Instantiate(safePoint, new Vector3(0, 0, 0), safePoint.transform.rotation);

        for (int i = 0; i < currentSafePoint.Length; i++)
        {
            if (currentSafePoint[i] == null)
            {
                float tx = 0.0f;
                float tz = 0.0f;
                while (-80.0f < tx && tx < 80.0f)
                {
                    tx = UnityEngine.Random.Range(-100, 100);
                }
                while (-80.0f < tz && tz < 80.0f)
                {
                    tz = UnityEngine.Random.Range(-100, 100);
                }

                currentSafePoint[i] = (GameObject)Instantiate(safePoint, new Vector3(tx, 0, tz), safePoint.transform.rotation);

            }
        }
    }

    void EnemyBoatInit()
    {
        for (int i = 0; i < currentEnemyBoat.Length; i++)
        {
            if (currentEnemyBoat[i] == null)
            {
                float tx = 0.0f;
                float tz = 0.0f;
                int j = 0;
                while (j < currentSafePoint.Length)
                {

                    while (-30.0f < tx && tx < 30.0f)
                    {
                        tx = UnityEngine.Random.Range(-100, 100);
                    }
                    while (-30.0f < tz && tz < 30.0f)
                    {
                        tz = UnityEngine.Random.Range(-100, 100);
                    }
                    for (j = 0; j < currentSafePoint.Length; j++)
                    {
                        if (Vector3.Distance(new Vector3(tx, 0, tz), currentSafePoint[j].transform.position) < 30)
                        {
                            tx = tz = 0;
                            j = 0;
                            break;
                        }
                    }
                }

                currentEnemyBoat[i] = Instantiate(Resources.Load<EnemyBoat>("Enemyboat"));
                //currentEnemyBoat[i] = (Rigidbody)Instantiate(enemyBoat, new Vector3(tx, 0, tz), enemyBoat.transform.rotation);
                //EnemyBoat enemyBoatVar = currentEnemyBoat[i].GetComponent<EnemyBoat>();
                //enemyBoatVar.Init(new Vector3(tx, 0, tz), 1);
                currentEnemyBoat[i].Init(new Vector3(tx, 0, tz), 1);
            }
        }
    }
}
