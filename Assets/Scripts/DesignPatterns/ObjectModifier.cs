using UnityEngine;

public class ObjectModifier : MonoBehaviour, IDecorator
{
    [SerializeField]
    private GameObject basePrefab;

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

    public GameObject ExecuteWithGameObject()
    {
        if (UseCount > 0)
        {
            useCount -= 1;
        }
        
        return Instantiate(basePrefab, Vector3.zero, Quaternion.identity);
    }
}