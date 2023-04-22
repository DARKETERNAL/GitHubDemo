using UnityEngine;

public class VFXPool : PoolBase<SimpleVFX>
{
    [SerializeField]
    private GameObject basePrefab;

    private IDecorator decorator;

    protected override void AddNewInstanceToPool()
    {
        SimpleVFX newInstance = Instantiate(basePrefab, transform.position, Quaternion.identity).GetComponent<SimpleVFX>();
        Recycle(newInstance);
    }

    protected override void ProcessTargetToRecycle(SimpleVFX target)
    {
        target.StopVFX();
        target.gameObject.transform.position = transform.position;
        target.gameObject.transform.parent = transform;
    }

    protected override void ProcessTargetToRetrieve(SimpleVFX target)
    {
        target.gameObject.transform.parent = null;

        if (decorator == null)
        {
            decorator = GetComponent<IDecorator>();
        }

        if (decorator != null)
        {
            decorator.Execute();
        }
    }
}