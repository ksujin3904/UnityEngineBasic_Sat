using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateBase : IState // 인터페이스 구현(마우스로)  * 객체화 할 일이 없으므로 abstract 사용 *
{
    protected StateMachine Machine;
    protected Animator Animator;
    protected StateMachine.StateType MachineType;
    public StateBase(StateMachine.StateType machineType, StateMachine machine)
    {
        MachineType = machineType;
        Machine = machine;
        Animator = Machine.GetComponent<Animator>();
    }

    public IState.Commands Current { get; protected set; }

    public abstract bool IsExecuteOK { get; }

    public abstract void Execute();

    public abstract void FixedUpdate();

    public abstract void ForceStop();

    public abstract void MoveNext();

    public abstract StateMachine.StateType Update();
}