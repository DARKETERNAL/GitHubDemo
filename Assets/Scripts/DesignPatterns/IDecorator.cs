using UnityEngine;

public interface IDecorator
{
    int UseCount { get; }

    void Execute();

    void Destroy();

    PoolableGameObject ExecuteWithGameObject();
}