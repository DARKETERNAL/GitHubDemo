public class InstantiateVFXState : IState
{
    public void Execute()
    {
        InstanceCreator.Instance.InstantiateVFX();
    }
}