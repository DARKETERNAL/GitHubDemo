public abstract class InstantiateAndRecycleAbstractCommand : ICommand
{
    private float recycleTime;

    public InstantiateAndRecycleAbstractCommand(float _recycleTime)
    {
        recycleTime = _recycleTime;
    }

    public System.Collections.IEnumerator Execute()
    {
        yield return RecyclePoolable(RetrieveIPoolable());
    }

    protected abstract IPoolable RetrieveIPoolable();

    private System.Collections.IEnumerator RecyclePoolable(IPoolable obj)
    {
        yield return new UnityEngine.WaitForSeconds(recycleTime);
        PoolFacade.Instance.RecycleObject(obj);
    }
}