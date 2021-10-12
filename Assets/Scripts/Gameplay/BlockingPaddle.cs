using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockingPaddle : MonoBehaviour
{
    private Vector3 respawnPosition;
    private Vector3 endPosition;
    private float movementSpeed;
    public void SetProperties(Vector3 respawnPosition, Vector3 endPosition, float movementSpeed)
    {
        this.respawnPosition = respawnPosition;
        this.endPosition = endPosition;
        this.movementSpeed = movementSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = respawnPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.x) >= Mathf.Abs(endPosition.x))
        {
            transform.position = respawnPosition;
        }
        transform.Translate(new Vector3(Time.deltaTime * movementSpeed, 0, 0));
    }
}
