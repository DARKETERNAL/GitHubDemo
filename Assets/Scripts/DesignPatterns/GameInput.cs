using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    public delegate void OnChangeFSMState(FiniteStateMachine.EStateType state);

    public event OnChangeFSMState onChangeFSMState;

    public List<IObserver> observers;

    private FiniteStateMachine fsm;

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

        Instance.observers = new List<IObserver>();
        fsm = new FiniteStateMachine();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fsm.ExecuteState();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            onChangeFSMState?.Invoke(FiniteStateMachine.EStateType.InstantiateGO);
            print("Changed to Instantiate GO");
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            onChangeFSMState?.Invoke(FiniteStateMachine.EStateType.InstantiateVFX);
            print("Changed to Instantiate VFX");
        }
    }

    public void SubscribeObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void UnsubscribeObserver(IObserver observer) => observers.Remove(observer);

    public void NotifyObservers()
    {
        foreach (IObserver observer in observers)
        {
            observer.Notify();
        }
    }
}