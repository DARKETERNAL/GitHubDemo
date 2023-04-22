using UnityEngine;

public class ObjectModifier : MonoBehaviour, IDecorator
{
    [SerializeField]
    private PoolableGameObject basePrefab;

    [SerializeField]
    private int useCount = 5;

    public int UseCount => useCount;

    public void Destroy()
    {
        Destroy(this);
    }

    public void Execute()
    {
    }

    public PoolableGameObject ExecuteWithGameObject()
    {
        if (UseCount > 0)
        {
            useCount -= 1;
        }
        
        return Instantiate<PoolableGameObject>(basePrefab, Vector3.zero, Quaternion.identity);
    }
}