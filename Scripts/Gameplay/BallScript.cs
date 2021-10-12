using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private int turboY = 250;
    private int turboX = 300;
    private Vector3 initialPosition;
    private Rigidbody2D rigidbody2D;
    private PlayersScript currentPlayerScript;
    [SerializeField] private AudioSource audioSource;
    public PlayersScript CurrentPlayerScript { get => currentPlayerScript; set => currentPlayerScript = value; }
    public void firstPush()
    {
        rigidbody2D.velocity = Vector3.zero;
        transform.position = initialPosition;
        rigidbody2D.AddForce(new Vector2(0, -turboY));
    }
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        initialPosition = new Vector3(0, -1.8f);
    }
    private void giveBallForce(float x1, float y1, float x2, float y2, float additionalForceX, float additionalForceY)
    {
        float differenceX = x1 - x2;
        float differenceY = y1 - y2;
        rigidbody2D.velocity = Vector2.zero;
        rigidbody2D.AddForce(new Vector2(differenceX, Mathf.Sign(differenceY)).normalized * new Vector2(turboX + additionalForceX, turboY + additionalForceY));
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        AudioClip audioClip = collision.gameObject.GetComponent<AudioSource>().clip;
        audioSource.clip = audioClip;
        if (audioClip != null) audioSource.Play();
        string collisionName = collision.transform.name;
        if (collisionName.Contains("HittableBlock"))
        {
            currentPlayerScript.increaseScore(collision.gameObject.GetComponent<HittableBlockScript>().destroyPoint() + currentPlayerScript.PaddleCharacter.AdditionalScore);
            giveBallForce(transform.position.x, transform.position.y, collision.transform.position.x, collision.transform.position.y, 50, 50);
            Destroy(collision.gameObject);
        }
        else if (collisionName.Contains("Enemy"))
        {
            currentPlayerScript.increaseScore(collision.gameObject.GetComponentInParent<EnemyScript>().CurrentEnemy.ScoreGiven + currentPlayerScript.PaddleCharacter.AdditionalScore);
            collision.gameObject.GetComponentInParent<EnemyScript>().CurrentEnemy.MoveOppositeDirection();
            giveBallForce(transform.position.x, transform.position.y, collision.transform.position.x, collision.transform.position.y, 50, 50);
        }
        else if (collisionName.Contains("BlockingLine"))
        {
            giveBallForce(transform.position.x, transform.position.y, collision.transform.position.x, collision.transform.position.y, 50, 50);
        }
        else if (collisionName.Contains("Paddle"))
        {
            currentPlayerScript = collision.gameObject.GetComponent<PlayersScript>();
            giveBallForce(transform.position.x, transform.position.y, collision.transform.position.x, collision.transform.position.y, currentPlayerScript.PaddleCharacter.Force, currentPlayerScript.PaddleCharacter.Force);
        }
        else if (collisionName.Contains("CircleReflector"))
        {
            currentPlayerScript.increaseScore(collision.gameObject.GetComponent<Bouncer>().giveScore() + currentPlayerScript.PaddleCharacter.AdditionalScore);
            giveBallForce(transform.position.x, transform.position.y, collision.transform.position.x, collision.transform.position.y, 125, 125);
        }
    }
    void Update()
    {
        if (Mathf.Abs(transform.position.x) > 9f)
        {
            float sign = Mathf.Sign(transform.position.x);
            transform.position = new Vector3(-(sign) * 8.5f, transform.position.y, 0);
        }
        else if (transform.position.y < -5.5f)
        {
            AudioClip audio = Resources.Load<AudioClip>("SoundEffects/Pain");
            audioSource.clip = audio;
            audioSource.Play();
        }
    }
}
