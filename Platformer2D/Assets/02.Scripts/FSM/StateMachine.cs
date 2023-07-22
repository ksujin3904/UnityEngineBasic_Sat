using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public StateType currentType;
    public IState<StateType> current;
    private Dictionary<StateType, IState<StateType>> states;
    // �ڵ� ��ɾ� �浹 ����
    private bool _isDirty;

    public void InitStates(Dictionary<StateType, IState<StateType>> states)
    {
        this.states = states;
        current = states[currentType];
    }

    public bool ChangeState(StateType newType)
    {
        // �̹� ���°� �������̶��
        if (_isDirty)
            return false;
        // ���ο� ���°� ������ ���� 
        if (currentType == newType)
            return false;
        // -> ���� ���θ� Ȯ���� �� ����
        if (states[newType].canExecute == false)
            return false;

        current.Reset();
        current = states[newType];
        currentType = newType;
        // ���°� ���ŵǴ� ���
        _isDirty= true;
        return true;
    }

    private void Update()
    {
        ChangeState(current.MoveNext());
        _isDirty = false;

    }
}
