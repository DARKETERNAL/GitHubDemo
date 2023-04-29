public class InstantiateAndRecycleVFXCommand : InstantiateAndRecycleAbstractCommand
{
    public InstantiateAndRecycleVFXCommand(float _recycleTime) : base(_recycleTime)
    {
    }

    protected override IPoolable RetrieveIPoolable()
    {
        IPoolable currentVFX = PoolFacade.Instance.RetrieveObject(typeof(SimpleVFX));
        (currentVFX as SimpleVFX).StartVFX();
        return currentVFX;
    }
}