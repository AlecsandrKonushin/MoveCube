using UnityEngine;

/// <summary>
/// Обработчик столкновений Player с другими объектами.
/// </summary>
public class PlayerContacts : CharacterContacts
{
    private void Start()
    {
        character = GetComponent<Character>();
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
    }

    protected override void ContactWithCoockie()
    {
        Coockie coockie = collisionObject.GetComponent<Coockie>();

        character.SetNewPosition(coockie.transform.position, false);

        MainController.Instance.IsWinLevel = true;
        DeEnableMyColliders();
    }

    private void ContactWithChangeColor()
    {
        ColorObject colorObj = collisionObject.GetComponent<ColorObject>();

        if (colorObj.MyColor != character.MyColor)
        {
            (character as Player).SetNewColor(colorObj.MyColor);

            Destroy(colorObj.gameObject, .3f);
        }
    }

    private void ContactWithEnemy()
    {
        Enemy enemy = collisionObject.GetComponent<Enemy>();

        if (enemy.Type == TypeEnemy.Spike)
        {
            Player player = character as Player;
            player.SetNewPosition(enemy.transform.position, true);
            DeEnableMyColliders();

            if (character.GetDirectionMove == (enemy as SpikeEnemy).GetSpikeDirection)
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

    private void ContactWallPortal(Block wall)
    {
        //if (sideNow == wall.sideIn)
        //{
        //    DeEnableMyColliders();

        //    soundCon.PlaySound("portal");

        //    Vector3 exitPos = wall.ExitPortal.transform.position;

        //    if (wall.sideOut == "right")
        //    {
        //        myTransform.position = new Vector3(exitPos.x + 2, exitPos.y);
        //        SetDirectionPlayer("right");
        //    }
        //    else if (wall.sideOut == "left")
        //    {
        //        myTransform.position = new Vector3(exitPos.x - 2, exitPos.y);
        //        SetDirectionPlayer("left");
        //    }
        //    else if (wall.sideOut == "up")
        //    {
        //        myTransform.position = new Vector3(exitPos.x, exitPos.y + 2);
        //        SetDirectionPlayer("up");
        //    }
        //    else if (wall.sideOut == "down")
        //    {
        //        myTransform.position = new Vector3(exitPos.x, exitPos.y - 2);
        //        SetDirectionPlayer("down");
        //    }

        //    return;
        //}
    }
}
