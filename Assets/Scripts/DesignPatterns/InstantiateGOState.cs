public class InstantiateGOState : IState
{
    public void Execute()
    {
        InstanceCreator.Instance.InstantiatePoolableGOs();
    }
}