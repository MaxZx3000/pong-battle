using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class PaddleCharacters
{
    // SOLID Principle
    protected Sprite paddleImage;
    protected int force;
    protected int movementSpeed;
    protected ulong additionalScore;
    public PaddleCharacters() { }
    public int Force { get => force; }
    public int MovementSpeed { get => movementSpeed; }
    public ulong AdditionalScore { get => additionalScore; }
    public Sprite PaddleImage { get => paddleImage; set => paddleImage = value;}
    public void movePaddle(string inputMoveKey, Transform transform, float maxPosition)
    {
        float newX = Input.GetAxis(inputMoveKey) * Time.deltaTime * movementSpeed;
        Vector3 newValue = new Vector3(Mathf.Abs(transform.position.x + newX), 0);
        if (newValue.x < maxPosition)
        {
            transform.Translate(new Vector3(newX, 0));
        }
    }
    
}
public class BluePaddle : PaddleCharacters
{
    public BluePaddle() {
        paddleImage = Resources.Load<Sprite>("BluePaddle");
        additionalScore = 20;
        movementSpeed = 12;
        force = 20;
    }
}
public class GreenPaddle : PaddleCharacters
{
    public GreenPaddle() {
        paddleImage = Resources.Load<Sprite>("GreenPaddle");
        additionalScore = 30;
        movementSpeed = 10;
        force = 30;
    }
}
public class PinkPaddle : PaddleCharacters
{
    public PinkPaddle() {
        paddleImage = Resources.Load<Sprite>("PinkPaddle");
        additionalScore = 40;
        movementSpeed = 8;
        force = 40;
    }
}

