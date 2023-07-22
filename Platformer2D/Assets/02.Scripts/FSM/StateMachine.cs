using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public StateType currentType;
    public IState<StateType> current;
    private Dictionary<StateType, IState<StateType>> states;
    // 코드 명령어 충돌 감지
    private bool _isDirty;

    public void InitStates(Dictionary<StateType, IState<StateType>> states)
    {
        this.states = states;
        current = states[currentType];
    }

    public bool ChangeState(StateType newType)
    {
        // 이미 상태가 변경중이라면
        if (_isDirty)
            return false;
        // 새로운 상태가 들어오면 변경 
        if (currentType == newType)
            return false;
        // -> 가능 여부를 확인한 후 변경
        if (states[newType].canExecute == false)
            return false;

        current.Reset();
        current = states[newType];
        currentType = newType;
        // 상태가 갱신되는 경우
        _isDirty= true;
        return true;
    }

    private void Update()
    {
        ChangeState(current.MoveNext());
        _isDirty = false;

    }
}
