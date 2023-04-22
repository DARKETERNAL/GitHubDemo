using UnityEngine;

public class VFXPool : PoolBase<SimpleVFX>
{
    [SerializeField]
    private GameObject basePrefab;

    protected override void AddNewInstanceToPool()
    {
        SimpleVFX newInstance = Instantiate(basePrefab, transform.position, Quaternion.identity).GetComponent<SimpleVFX>();
        Recycle(newInstance);
    }
}