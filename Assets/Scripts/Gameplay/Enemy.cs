using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class Enemy
{
    protected Sprite enemySprites;
    protected float speedMovement;
    protected ulong scoreGiven;
    protected GameObject weapon;
    public Sprite EnemySprites { get => enemySprites; }
    public float SpeedMovement { get => speedMovement; set => speedMovement = value; }
    public ulong ScoreGiven { get => scoreGiven; }
    public Enemy() { weapon = Resources.Load("HittableBlock") as GameObject; }
    public void MoveEnemy(Vector3 currentPosition, Vector3 maxPosition, Transform transform)
    {
        if (Mathf.Abs(currentPosition.x + speedMovement * Time.deltaTime) >= Mathf.Abs(maxPosition.x)) speedMovement *= -1;
        transform.Translate(new Vector3(speedMovement * Time.deltaTime, 0));
    }
    public void Shoot(Vector3 currentPosition)
    {
        GameObject.Instantiate(weapon, currentPosition, Quaternion.identity, null);
    }
    public void MoveOppositeDirection()
    {
        speedMovement *= -1;
    }
    public Enemy ChangeEnemy(Enemy enemy, SpriteRenderer spriteRenderer, int direction)
    {
        ;
        float absoluteSpeedMovement = Mathf.Abs(enemy.SpeedMovement);
        if (direction >= 0) enemy.SpeedMovement = absoluteSpeedMovement;
        else enemy.SpeedMovement = absoluteSpeedMovement - (2 * absoluteSpeedMovement);
        spriteRenderer.sprite = enemy.EnemySprites;
        return enemy;
    }
}
class EnemyWhite : Enemy
{
    public EnemyWhite()
    {
        enemySprites = Resources.Load<Sprite>("EnemyWhite");
        scoreGiven = 30;
        speedMovement = 7;
    }

}
class EnemyRed : Enemy
{
    public EnemyRed()
    {
        enemySprites = Resources.Load<Sprite>("EnemyRed");
        scoreGiven = 40;
        speedMovement = 5;
    }
}