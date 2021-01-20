using UnityEngine;

/// <summary>
/// Обработчик столкновений Player с другими объектами.
/// </summary>
public class PlayerContacts : CharacterContacts
{
    private Player player;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    /// <summary>
    /// Столкновение с объектом.
    /// Объект определяется по тегу.
    /// </summary>
    /// <param name="collision"></param>
    public override void CollisionWithObjeсt(GameObject collision)
    {
        collisionObject = collision;

        if (collision.transform.tag == "block")
            ContactWithBlock();
        else if (collision.transform.tag == "wall")
            ContactWithWall();
        else if (collision.transform.tag == "coockie")
            ContactWithCoockie();
        else if (collision.transform.tag == "colorChange")
            ContactWithChangeColor();
        else if (collision.transform.tag == "portal")
            ContactWithPortal();
        else if (collision.transform.tag == "enemy")
            ContactWithEnemy();
    }

    private void ContactWithBlock()
    {
        Block block = collisionObject.GetComponent<Block>();

        if (player.MyColor != block.MyColor)
        {
            player.SetNewPosition(block.transform.position);
            DeEnableMyColliders();
        }
    }

    private void ContactWithCoockie()
    {
        Coockie coockie = collisionObject.GetComponent<Coockie>();

        player.SetNewPosition(coockie.transform.position, false);

        MainController.Instance.IsWinLevel = true;
        DeEnableMyColliders();
    }

    private void ContactWithChangeColor()
    {
        ColorObject colorObj = collisionObject.GetComponent<ColorObject>();

        if (colorObj.MyColor != player.MyColor)
        {
            player.SetNewColor(colorObj.MyColor);

            Destroy(colorObj.gameObject, .3f);
        }
    }

    private void ContactWithPortal()
    {

    }

    private void ContactWithWall()
    {
        DeEnableMyColliders();

        player.SetPositionBeforeWall(collisionObject.transform.position);
    }

    private void ContactWithEnemy()
    {
        Enemy enemy = collisionObject.GetComponent<Enemy>();

        if (enemy.Type == TypeEnemy.Spike)
        {
            player.SetNewPosition(enemy.transform.position, true);
            DeEnableMyColliders();

            if (player.GetDirectionMove == (enemy as SpikeEnemy).GetSpikeDirection)
            {                
                player.SpikeDamage = true;
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
