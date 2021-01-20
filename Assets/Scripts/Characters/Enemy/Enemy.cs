using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private TypeEnemy type;
    public TypeEnemy Type { get => type; }

    protected override void EndMove()
    {
        if (fall)
        {
            return;
        }
        else
        {
            canMove = false;
        }
    }
}

public enum TypeEnemy
{
    Spike
}
