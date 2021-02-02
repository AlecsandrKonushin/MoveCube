using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerContacts))]
public class Player : Character
{
    [SerializeField] private Sprite[] mySprites;

    [SerializeField]private Enemy enemyCollision;
    public Enemy SetEnemyCollision { set => enemyCollision = value; }

    [SerializeField] private float timeSpikeDamage = 1f;

    protected override void EndMove()
    {
        base.EndMove();

        MainController.Instance.PlayerEndMove();
    }

    public void SetNewColor(AllColor color)
    {
        MyColor = color;

        if (MyColor == AllColor.green)
            spriteRen.sprite = mySprites[0];
        else if (MyColor == AllColor.yellow)
            spriteRen.sprite = mySprites[1];
        else if (MyColor == AllColor.blue)
            spriteRen.sprite = mySprites[2];
        else if (MyColor == AllColor.red)
            spriteRen.sprite = mySprites[3];
    }

    public void PushEnemy()
    {
        AfterMove -= PushEnemy;

        enemyCollision.SetNewPosition(directionMove);
    }

    public void PlayAnimation(PlayerAnim anim)
    {
        animator.SetTrigger(anim.ToString());
    }

    public void Damage()
    {
        AfterMove -= Damage;

        PlayAnimation(PlayerAnim.SpikeDamage);
        Invoke(nameof(Death), timeSpikeDamage);
    }

    protected override void Death()
    {
        MainController.Instance.PlayerDeath();
    }

    public void ChangeColor(AllColor color)
    {
        spriteRen.sprite = mySprites[(int)color];
    }
}

public enum PlayerAnim
{
    SpikeDamage
}
