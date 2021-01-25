using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private TypeEnemy type;
    public TypeEnemy Type { get => type; }

    protected override void EndMove()
    {
        base.EndMove();
    }
}

public enum TypeEnemy
{
    Spike
}
