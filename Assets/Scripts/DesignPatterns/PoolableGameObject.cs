using UnityEngine;

public class PoolableGameObject : MonoBehaviour, IPoolable
{
    public void PrepareForRecycle(Transform parent)
    {
        gameObject.SetActive(false);
        transform.parent = parent;
        transform.position = parent.position;
        transform.rotation = Quaternion.identity;
    }

    public void PrepareForRetrieve()
    {
        transform.parent = null;
        gameObject.SetActive(true);
    }
}