using UnityEngine;

public class InstanceCreator : MonoBehaviour, IObserver
{
    public static InstanceCreator Instance { get; private set; }

    [SerializeField]
    private float recycleTime = 3F;

    private ICommand instantiatePoolableCommand;
    private ICommand instantiateVFXCommand;

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

    public void InstantiateVFX()
    {
        if (instantiateVFXCommand == null)
        {
            instantiateVFXCommand = new InstantiateAndRecycleVFXCommand(recycleTime);
        }

        StartCoroutine(instantiateVFXCommand.Execute());
    }

    public void InstantiatePoolableGOs()
    {
        if (instantiatePoolableCommand == null)
        {
            instantiatePoolableCommand = new InstantiateAndRecyclePoolableCommand(recycleTime);
        }

        StartCoroutine(instantiatePoolableCommand.Execute());
    }

    public void Notify()
    {
        InstantiatePoolableGOs();
    }
}