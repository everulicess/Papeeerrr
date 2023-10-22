using UnityEngine;
using System;

public abstract class State<EState> where EState : Enum
{
    public State(EState key)
    {
        stateKey = key;
    }
    public EState stateKey { get; private set; }
    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void UpdateState();
    public abstract EState GetNextState();
    public virtual void OnTriggerEnter(Collider other) { }
    public virtual void OnTriggerStay(Collider other) { }
    public virtual void OnTriggerExit(Collider other) { }



    //protected StateController sc;
    //public virtual void OnStateEnter(/*StateController stateController*/)
    //{
    //    //sc = stateController;
    //    OnEnter();
    //}
    //protected virtual void OnEnter()
    //{

    //}
    //public virtual void OnStateUpdate()
    //{
    //    OnUpdate();
    //}
    //protected virtual void OnUpdate()
    //{

    //}
    //public virtual void OnStateExit()
    //{
    //    OnExit();
    //}
    //protected virtual void OnExit()
    //{

    //}
}
