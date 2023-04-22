public class CubePool : PoolBase<PoolableGameObject>
{
    protected override void AddNewInstanceToPool()
    {
        PoolableGameObject newInstance = CubeFactory.Instance.DeliverNewProduct();
        Recycle(newInstance);
    }
}