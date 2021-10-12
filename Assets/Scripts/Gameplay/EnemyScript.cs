using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Enemy[] enemy;
    private Enemy currentEnemy;
    private Vector3 maxPosition;
    private int currentIndex = 0;
    private Timer timeChangeForm;
    private Timer timeShoot;
    private SpriteRenderer enemySpriteRenderer;
    public Enemy CurrentEnemy { get => currentEnemy; }
    public void SetProperties(Vector3 currentPosition, Vector3 maxPosition)
    {
        transform.position = currentPosition;
        this.maxPosition = maxPosition;
    }
    // Start is called before the first frame update
    void Start()
    {
        enemy = new Enemy[2] { new EnemyWhite(), new EnemyRed()};
        currentEnemy = enemy[currentIndex];
        enemySpriteRenderer = transform.Find("Enemy").GetComponent<SpriteRenderer>();
        currentEnemy = currentEnemy.ChangeEnemy(enemy[currentIndex], enemySpriteRenderer, (int)Mathf.Sign(currentEnemy.SpeedMovement));
        timeChangeForm = new Timer();
        timeChangeForm.initializeCurrentTime(3);
        timeShoot = new Timer();
        timeShoot.initializeCurrentTime(2);
    }

    // Update is called once per frame
    void Update()
    {
        currentEnemy.MoveEnemy(transform.position, maxPosition, transform);
        if (timeChangeForm.determineIfFinished() == true)
        {
            if (currentIndex < enemy.Length - 1) currentIndex += 1;
            else currentIndex = 0;
            currentEnemy = currentEnemy.ChangeEnemy(enemy[currentIndex], enemySpriteRenderer, (int)Mathf.Sign(currentEnemy.SpeedMovement));
            timeChangeForm.initializeCurrentTime(3);
        }
        if (timeShoot.determineIfFinished() == true)
        {
            currentEnemy.Shoot(transform.position);
            timeShoot.initializeCurrentTime(2);
        }
    }
}
