using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateID_1     //状态
{
    NullState,
    Chaseing,
    Shooting
}

public class EnemyBoat1 : MonoBehaviour
{
    int seaLevel;
    int durable;
    int speed;
    int damageValue;
    GameObject player;
    Vector3 homePoint;

    public bullet b;

    int shootTimeInterval;
    StateID_1 currentState;

    // Use this for initialization
    void Start()
    {
        //seaLevel = 3;
        //durable = seaLevel * 10;
        //speed = seaLevel + 1;
        //shootTimeInterval = 20;
        //homePoint = new Vector3(10, 0, 10);
        //damageValue = 1;

        //player = GameObject.FindGameObjectWithTag("myBoat");

        //InitState();

    }

    public void Init(Vector3 p, int level)
    {
        seaLevel = level;
        durable = seaLevel * 10;
        speed = seaLevel + 3;
        shootTimeInterval = 20;
        homePoint = p;
        damageValue = seaLevel;

        player = GameObject.FindGameObjectWithTag("myBoat");

        
        InitState();
    }

    void InitState()
    {
        currentState = StateID_1.Chaseing;
    }


    void FixedUpdate()
    {
        

        switch (currentState)
        {
            case StateID_1.Shooting:
                this.currentState = ShootingStateUpdate();
                break;
            case StateID_1.Chaseing:
                this.currentState = ChaseingStateUpdate();
                break;
        }
    }

    StateID_1 ShootingStateUpdate()
    {
        transform.LookAt(player.transform.position);
        shootTimeInterval--;
        if (shootTimeInterval == 0)
        {
            shootTimeInterval = 80;
            bullet obj = (bullet)Instantiate(b, transform.position, b.transform.rotation);
            obj.Init(damageValue);
            obj.GetComponent<Rigidbody>().AddForce(this.transform.forward * 600);
        }

        if (Vector3.Distance(player.transform.position, transform.position) > 7 && shootTimeInterval == 1)
        {

            return StateID_1.Chaseing;
        }
        return StateID_1.Shooting;
    }



    StateID_1 ChaseingStateUpdate()
    {
        transform.LookAt(player.transform.position);

        transform.Translate(0, 0, Time.deltaTime * speed);


        if (Vector3.Distance(player.transform.position, transform.position) < 6)
        {
            return StateID_1.Shooting;
        }

        if (Vector3.Distance(player.transform.position, transform.position) >= 15)
        {
            Destroy(gameObject);
            //Debug.Log("lose");
            return StateID_1.NullState;

        }
        if (Vector3.Distance(player.transform.position, homePoint) >= speed * 20)
        {
            Destroy(gameObject);
            Debug.Log("lose");
            return StateID_1.NullState;

        }
        return StateID_1.Chaseing;
    }

}
