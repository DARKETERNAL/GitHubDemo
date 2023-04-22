using System.Collections.Generic;
using UnityEngine;

public abstract class PoolBase<T> : MonoBehaviour
{
    private static PoolBase<T> instance;

    [SerializeField]
    private int size = 15;

    protected List<T> instances = new List<T>();

    public static PoolBase<T> Instance { get => instance; protected set => instance = value; }

    public virtual T Retrieve()
    {
        if (instances.Count < 1)
        {
            AddNewInstanceToPool();
        }

        T target = instances[0];
        instances.Remove(target);
        ProcessTargetToRetrieve(target);

        return target;
    }

    public virtual void Recycle(T target)
    {
        ProcessTargetToRecycle(target);
        instances.Add(target);
    }

    protected abstract void ProcessTargetToRecycle(T target);

    protected abstract void ProcessTargetToRetrieve(T target);

    protected abstract void AddNewInstanceToPool();

    protected void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    protected void Start()
    {
        for (int i = 0; i < size; i++)
        {
            AddNewInstanceToPool();
        }
    }
}