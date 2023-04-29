public class InstantiateAndRecyclePoolableCommand : InstantiateAndRecycleAbstractCommand
{
    public InstantiateAndRecyclePoolableCommand(float _recycleTime) : base(_recycleTime)
    {
    }

    protected override IPoolable RetrieveIPoolable()
    {
        return PoolFacade.Instance.RetrieveObject(typeof(PoolableGameObject));
    }
}