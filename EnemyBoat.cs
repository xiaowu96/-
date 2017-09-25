using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateID     //状态
{
    NullState,
    Chaseing,
    BackHome,
    Walking
}

public class EnemyBoat : MonoBehaviour
{
    int seaLevel;
    int durable;
    int speed;
    Vector3 homePoint;
    GameObject player;

    //巡逻状态需要的属性
    int walkingStep;
    Vector3 Dir_left;
    Vector3 Dir_right;
    Vector3 Dir_ahead;
    Vector3 Dir_back;
    Vector3 targetDir;
    bool walking = false;

     public StateID currentState;

    // Use this for initialization
    void Start()
    {


    }

    public void Init(Vector3 p, int l)
    {
        seaLevel = l;
        durable = seaLevel * 10;
        speed = seaLevel + 1;
        homePoint = p;
        transform.position = homePoint;
    
        player = GameObject.FindGameObjectWithTag("myBoat");

        InitState();
    }

    void InitState()
    {
        walkingStep = 0;
        Dir_left = new Vector3(0, -90, 0);
        Dir_right = new Vector3(0, 90, 0);
        Dir_ahead = new Vector3(0, 0, 0);
        Dir_back = new Vector3(0, 180, 0);

        currentState = StateID.Walking;
    }


    void FixedUpdate()
    {
        switch (currentState)
        {
            case StateID.Walking:
                this.currentState = WalkingStateUpdate();
                break;
            case StateID.Chaseing:
                this.currentState = ChaseingStateUpdate();
                break;
            case StateID.BackHome:
                this.currentState = BackHomeStateUpdate();
                break;
        }
    }

    StateID WalkingStateUpdate()
    {
        int temp;
        if (!walking)
        {
            temp = UnityEngine.Random.Range(0, 4);
            Vector3 preDir = new Vector3(0, 0, 1);

            switch (temp)
            {
                case 0:
                    preDir = Dir_left;
                    break;
                case 1:
                    preDir = Dir_ahead;
                    break;
                case 2:
                    preDir = Dir_right;
                    break;
                case 3:
                    preDir = Dir_back;
                    break;
            }
            transform.Rotate(preDir);
            walking = true;

        }
        else
        {
            if (Mathf.Abs(transform.position.x - homePoint.x) > speed * 10 || Mathf.Abs(transform.position.z - homePoint.z) > speed * 10)
            {
                transform.Rotate(Dir_back);
                walkingStep = 148;
            }
            transform.Translate(0, 0, Time.deltaTime * speed);
            walkingStep += 1;
            if (walkingStep == 150)
            {
                walkingStep = 0;
                walking = false;
            }

        }

        if (Vector3.Distance(player.transform.position, transform.position) < 10)
        {
            //Debug.Log("see boat");
            return StateID.Chaseing;
        }
        return StateID.Walking;
    }



    StateID ChaseingStateUpdate()
    {
        transform.LookAt(player.transform.position);

        if (Vector3.Distance(player.transform.position, transform.position) < 2)
        {
            Debug.Log("Game over!");
        }
        else
        {
            transform.Translate(0, 0, Time.deltaTime * speed);
        }

        if (Vector3.Distance(player.transform.position, transform.position) >= 15)
        {

            return StateID.BackHome;


        }
        return StateID.Chaseing;
    }

    StateID BackHomeStateUpdate()
    {
        transform.LookAt(homePoint);
        transform.Translate(0, 0, Time.deltaTime * speed);

        if (Vector3.Distance(homePoint, transform.position) < 2)
        {
            transform.forward = new Vector3(0, 0, 1);
            return StateID.Walking;
        }
        return StateID.BackHome;
    }
}
