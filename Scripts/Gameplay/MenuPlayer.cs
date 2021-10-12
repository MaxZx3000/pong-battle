using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuPlayer : MonoBehaviour
{
    [SerializeField]private GameObject panelMenu;
    [SerializeField]private GameObject panelPlayerStatsUI;
    [SerializeField]private GameObject panelGameOver;
    [SerializeField]private GameObject backgroundMusicObject;
    private GameObject newBlockingLine;
    private GameObject newBlockingLineTwo;
    private GameObject ball;
    private GameObject paddle;
    private GameObject enemyObject;
    private GameObject circleRelfector;
    private GameObject circleRelfector2;
    private AbstractMenuClass abstractMenuClass;
    private ComponentStats[] component;
    private PlayersScript player;
    [SerializeField] private Text textScore;
    private int currentIndexPlayer1;
    void Start()
    {
        panelPlayerStatsUI.SetActive(false);
        panelGameOver.SetActive(false);
        component = new ComponentStats[1];
        component[0] = new ComponentStats(GameObject.Find("ImagePlayer1").GetComponent<Image>(), GameObject.Find("MovementSpeedPlayer1").GetComponent<Text>(), GameObject.Find("ForcePlayer1").GetComponent<Text>());
        abstractMenuClass = new OnePlayerMenu(GameObject.Find("Player 1"));
        abstractMenuClass.ShowMenus();
        abstractMenuClass.displayCharacterInformation(0, 0, component);
    }
    private void ProcessAudio(AudioClip audio)
    {
        GetComponent<AudioSource>().clip = audio;
        GetComponent<AudioSource>().Play();
    }
    private void SetEnemies()
    {
        newBlockingLine = Instantiate(Resources.Load("BlockingLine") as GameObject, null);
        newBlockingLine.AddComponent<BlockingPaddle>().SetProperties(new Vector3(-10.2f, 1), new Vector3(10.2f,1), 8f);
        newBlockingLineTwo = Instantiate(Resources.Load("BlockingLine") as GameObject, null);
        newBlockingLineTwo.AddComponent<BlockingPaddle>().SetProperties(new Vector3(10.2f, -1), new Vector3(-10.2f, -1), -8f);
        enemyObject = Instantiate(Resources.Load("EnemyPlatform") as GameObject, null);
        enemyObject.AddComponent<EnemyScript>().SetProperties(new Vector3(0, 1.5f), new Vector3(7.4f, 1.5f));
        circleRelfector = Instantiate(Resources.Load("CircleReflector") as GameObject, null);
        circleRelfector.GetComponent<Bouncer>().SetProperties(-6.3f, 0);
        circleRelfector2 = Instantiate(Resources.Load("CircleReflector") as GameObject, null);
        circleRelfector2.GetComponent<Bouncer>().SetProperties(6.3f, 0);
    }
    private void SetPlayer1()
    {
        ball = Instantiate(Resources.Load("Ball") as GameObject);
        paddle = Instantiate(Resources.Load("Paddle") as GameObject, null);
        paddle.AddComponent<PlayersScript>().BallScript = ball.GetComponent<BallScript>();
        paddle.GetComponent<PlayersScript>().TextScore = GameObject.Find("Player1Score").GetComponent<Text>();
        paddle.GetComponent<PlayersScript>().TextLives = GameObject.Find("Player1Lives").GetComponent<Text>();
        paddle.GetComponent<PlayersScript>().InputMoveKey = "Horizontal";
        paddle.GetComponent<PlayersScript>().PaddleCharacter = abstractMenuClass.executeInformation(currentIndexPlayer1);
        paddle.GetComponent<PlayersScript>().MenuPlayer = this;
        player = paddle.GetComponent<PlayersScript>();
        paddle.GetComponent<SpriteRenderer>().sprite = paddle.GetComponent<PlayersScript>().PaddleCharacter.PaddleImage;
        ball.GetComponent<BallScript>().CurrentPlayerScript = paddle.GetComponent<PlayersScript>();
    }
    public void nextItem(AudioSource audioSource)
    {
        ProcessAudio(audioSource.clip);
        if (currentIndexPlayer1 + 1 < abstractMenuClass.PaddleCharacters.Length) currentIndexPlayer1 += 1;
        else currentIndexPlayer1 = 0;
        abstractMenuClass.displayCharacterInformation(0, currentIndexPlayer1, component);
    }
    public void previousItem(AudioSource audioSource)
    {
        ProcessAudio(audioSource.clip);
        if (currentIndexPlayer1 > 0) currentIndexPlayer1 -= 1;
        else currentIndexPlayer1 = abstractMenuClass.PaddleCharacters.Length - 1;
        abstractMenuClass.displayCharacterInformation(0, currentIndexPlayer1, component);
    }
    public void StartGame(AudioSource audioSource)
    {
        backgroundMusicObject.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Audio/GalacticFunk");
        backgroundMusicObject.GetComponent<AudioSource>().Play();
        ProcessAudio(audioSource.clip);
        panelPlayerStatsUI.SetActive(true);
        SetPlayer1();
        SetEnemies();
        panelMenu.SetActive(false);
    }
    public void gameOver()
    {
        backgroundMusicObject.GetComponent<AudioSource>().clip = null;
        panelGameOver.SetActive(true);
        textScore.text = "Your score is: " + player.CurrentScore;
        Destroy(newBlockingLine);
        Destroy(newBlockingLineTwo);
        Destroy(enemyObject);
        Destroy(ball);
        Destroy(paddle);
        Destroy(circleRelfector);
        Destroy(circleRelfector2);
        panelPlayerStatsUI.SetActive(false);
    }
    public void restartGame(AudioSource audio)
    {
        ProcessAudio(audio.clip);
        SceneManager.LoadScene("MainGameOnePlayer");
    }
    public void returnToMenu(AudioSource audio)
    {
        ProcessAudio(audio.clip);
        SceneManager.LoadScene("Menu");
    }
}
