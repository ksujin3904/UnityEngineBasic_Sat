using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum StateType
    {
        Idle,
        Move,
        Jump,
        Fall,
        Attack,
        Crouch,
        EOF
    }

    public StateType Current; // ���� ����
    private Dictionary<StateType, StateBase> _states = new Dictionary<StateType, StateBase>();
    private StateBase _CurrentState;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        // �ݺ����� -> �ڵ�ȭ �ʿ� (Reflection Ȱ��) , Addstate() �Լ� ����
        // _states.Add(StateType.Idle, new StateIdle());
        // _states.Add(StateType.Move, new StateMove());
        // _states.Add(StateType.Jump, new StateJump());
        // _states.Add(StateType.Fall, new StateFall());
        // _states.Add(StateType.Attack, new StateAttack());

        for (StateType stateType = StateType.Idle; stateType < StateType.EOF; stateType++) //enum ��ȸ
        {
            AddState(stateType);
        }
        _CurrentState = _states[StateType.Idle];
        Current = StateType.Idle;
    }

    // Reflection1 - Add�� ���� �Լ� �߰�
    private void AddState(StateType stateType)
    {
        // ��ųʸ��� �̹� ���°� ��ϵ� ���� (Ű ���� �ߺ��� �Ұ��ϹǷ�)
        if (_states.ContainsKey(stateType))
            return;

        // ���ڿ��� ���� (using System)
        string stateName = Convert.ToString(stateType);
        string typeName = "State" + stateName;
        Debug.Log($"[StateMachine]: Adding state...{stateName}");

        Type type = Type.GetType(typeName);

        if (type != null)
        {

            ConstructorInfo constructor = type.GetConstructor(new Type[]
            {
                typeof(StateType),
                typeof(StateMachine)
            });

            StateBase state
                = constructor.Invoke(new object[2]
                    {
                        stateType,
                        this
                    }) as StateBase; //Invoke: ȣ�� *StateBase�� �� ��ȯ

            _states.Add(stateType, state);
            Debug.Log($"[StateMachine]: {stateName} state is successfully added");
        }
    }



    private void Update()
    {
        ChangeState(_CurrentState.Update());

        if (Input.GetKeyDown(KeyCode.LeftAlt)) 
            ChangeState(StateType.Jump);
    }

    private void ChangeState(StateType newStateType)
    {

        // ���°� �ٲ��� �ʾ�����
        if (Current == newStateType)
            return;

        // �ٲٷ��� ���°� ���� �������� ������
        if (_states[newStateType].IsExecuteOK == false)
            return;

        
        _CurrentState.ForceStop(); // ���� ���� �ߴ�
        _CurrentState = _states[newStateType]; // ���� ����
        _CurrentState.Execute(); // ���� �� ���� ���� 
        Current = newStateType;
    }

}
