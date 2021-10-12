using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    void Start()
    {

    }
    public ulong giveScore()
    {
        return 10;
    }
    public void SetProperties(float posX, float posY)
    {
        transform.position = new Vector3(posX, posY);
    }
}
