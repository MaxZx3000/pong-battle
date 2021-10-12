using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittableBlockScript : MonoBehaviour
{
    void Update()
    {
        transform.Translate(new Vector3(0, -2f * Time.deltaTime));
        if (transform.position.y < -5.5f)
        {
            Destroy(this.gameObject);
        }
    }
    public ulong destroyPoint()
    {
        return 30;        
    }
}
