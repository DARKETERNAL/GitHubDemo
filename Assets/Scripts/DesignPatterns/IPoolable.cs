using UnityEngine;

public interface IPoolable
{
    void PrepareForRetrieve();

    void PrepareForRecycle(Transform parent);
}