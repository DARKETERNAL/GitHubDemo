public class FiniteStateMachine
{
    public enum EStateType
    {
        InstantiateGO,
        InstantiateVFX
    }

    private IState currentState;
    private IState instantiateGOState;
    private IState instantiateVFXState;

    public FiniteStateMachine()
    {
        Init();
    }

    public void ExecuteState()
    {
        currentState?.Execute();
    }

    private void SwitchToState(EStateType state)
    {
        switch (state)
        {
            case EStateType.InstantiateGO:
                currentState = instantiateGOState;
                break;

            case EStateType.InstantiateVFX:
                currentState = instantiateVFXState;
                break;

            default:
                currentState = instantiateGOState;
                break;
        }
    }

    private void Init()
    {
        instantiateGOState = new InstantiateGOState();
        instantiateVFXState = new InstantiateVFXState();

        GameInput.Instance.onChangeFSMState += SwitchToState;

        currentState = instantiateGOState;
    }
}