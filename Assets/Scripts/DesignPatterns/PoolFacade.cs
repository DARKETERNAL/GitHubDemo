using UnityEngine;

public class PoolFacade : MonoBehaviour
{
    public static PoolFacade Instance { get; private set; }

    public IPoolable RetrieveObject(System.Type type)
    {
        IPoolable result = null;

        if (type.Equals(typeof(PoolableGameObject)))
        {
            result = RetrieveCubeInstance();
        }
        else if (type.Equals(typeof(SimpleVFX)))
        {
            result = RetrieveVFXInstance();
        }

        return result;
    }

    public void RecycleObject(IPoolable obj)
    {
        if (obj is PoolableGameObject)
        {
            RecycleCube(obj as PoolableGameObject);
        }
        else if (obj is SimpleVFX)
        {
            RecycleVFX(obj as SimpleVFX);
        }
    }

    private PoolableGameObject RetrieveCubeInstance()
    {
        PoolableGameObject currentCube = CubePool.Instance.Retrieve();
        currentCube.transform.position = Vector3.zero;
        currentCube.transform.rotation = Quaternion.identity;

        return currentCube;
    }

    private void RecycleCube(PoolableGameObject target)
    {
        CubePool.Instance.Recycle(target);
    }

    private SimpleVFX RetrieveVFXInstance()
    {
        SimpleVFX currentVFX = VFXPool.Instance.Retrieve();
        currentVFX.transform.position = Vector3.zero;
        currentVFX.transform.rotation = Quaternion.identity;

        return currentVFX;
    }

    private void RecycleVFX(SimpleVFX vfx)
    {
        VFXPool.Instance.Recycle(vfx);
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}