﻿using UnityEngine;

/// <summary>
/// Обработчик столкновений Player с другими объектами.
/// </summary>
public class PlayerContacts : CharacterContacts
{
    private Player player;

    protected override void Start()
    {
        base.Start();

        player = character as Player;    
    }

    /// <summary>
    /// Столкновение с объектом.
    /// Объект определяется по тегу.
    /// </summary>
    /// <param name="collision"></param>
    public override void CollisionWithObjeсt(GameObject collision)
    {
        base.CollisionWithObjeсt(collision);

        if (collision.transform.tag == "coockie")
            ContactWithCoockie();
        else if (collision.transform.tag == "colorChange")
            ContactWithChangeColor();
        else if (collision.transform.tag == "enemy")
            ContactWithEnemy();
        else if (collision.transform.tag == "bottle")
            ContactWithBottle();
    }

    protected override void ContactWithCoockie()
    {
        character.SetNewPosition(collisionObject.transform.position, false);

        MainController.Instance.IsWinLevel = true;
        DeEnableMyColliders();
    }

    private void ContactWithChangeColor()
    {
        ColorObject colorObj = collisionObject.GetComponent<ColorObject>();

        if (colorObj.MyColor != character.MyColor)
        {
            player.SetNewColor(colorObj.MyColor);

            Destroy(colorObj.gameObject, .3f);
        }
    }

    private void ContactWithEnemy()
    {
        Enemy enemy = collisionObject.GetComponent<Enemy>();

        if (enemy.Type == TypeEnemy.Spike)
        {
            player.SetNewPosition(enemy.transform.position, true);
            DeEnableMyColliders();

            if (character.GetDirectionMove == (enemy as SpikeEnemy).GetDangerDirectionMove)
            {
                player.AfterMove += player.Damage;
            }
            else
            {
                player.SetEnemyCollision = enemy;
                player.AfterMove += player.PushEnemy;
            }
        }
    }

    private void ContactWithBottle()
    {
        Bottle bottle = collisionObject.GetComponent<Bottle>();

        player.ChangeColor(bottle);
    }
}
