using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public StateType currentType;
    public IState<StateType> current;
    private Dictionary<StateType, IState<StateType>> states;

    public void InitStates(Dictionary<StateType, IState<StateType>> states)
    {
        this.states = states;
        current = states[currentType];
    }

    public bool ChangeState(StateType newType)
    {
        // 새로운 상태가 들어오면 변경 
        if (currentType == newType)
            return false;
        // -> 가능 여부를 확인한 후 변경
        if (states[newType].canExecute == false)
            return false;

        current.Reset();
        current = states[newType];
        currentType = newType;
        return true;
    }

    private void Update()
    {
        ChangeState(current.MoveNext());
    }
}
