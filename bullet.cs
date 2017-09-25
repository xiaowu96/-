using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour
{
    int temptime = 0;
    public int damageValue;
    // Use this for initialization
    void Start()
    {

    }

    public void Init(int v)
    {
        damageValue = v;
    }

    // Update is called once per frame
    void Update()
    {
        temptime++;
        if (temptime >= 200)
        {
            Destroy(gameObject);
        }
    }
}
