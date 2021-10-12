using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayersScript : MonoBehaviour
{
    private MenuPlayer menuPlayer;
    private PaddleCharacters paddleCharacter;
    private Text textScore;
    private Text textLives;
    private Vector3 initialPosition;
    private float maxPositionX = 7.55f;
    private string inputMoveKey;
    private ulong currentScore;
    private int lives = 3;
    public PaddleCharacters PaddleCharacter{ get => paddleCharacter; set => paddleCharacter = value; }
    private BallScript ballScript;
    public BallScript BallScript { get => ballScript; set => ballScript = value;  }
    public Text TextScore { set => textScore = value; }
    public Text TextLives { set => textLives = value; }
    public string InputMoveKey { get => inputMoveKey; set => inputMoveKey = value; }
    public ulong CurrentScore { get => currentScore; }
    public MenuPlayer MenuPlayer { set => menuPlayer = value; }

    void Start()
    {
        initialPosition = transform.position;
        ballScript.firstPush();
        textScore.text = currentScore + "";
        textLives.text = "Lives: " + lives;
    }
    public void increaseScore(ulong value)
    {
        currentScore += value;
        textScore.text = currentScore + "";
    }
    private void ResetPosition()
    {
        lives -= 1;
        if (lives > 0)
        {
            ballScript.firstPush();
            transform.position = initialPosition;
            textLives.text = "Lives: " + lives;
        }
        else
        {
            menuPlayer.gameOver();
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (ballScript.gameObject.transform.position.y < -5.5f)
        {
            ResetPosition();
        }
        paddleCharacter.movePaddle(inputMoveKey, transform, maxPositionX);
    }
}
