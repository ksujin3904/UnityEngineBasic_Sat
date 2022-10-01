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

    public StateType Current; // 현재 상태
    private Dictionary<StateType, StateBase> _states = new Dictionary<StateType, StateBase>();
    private StateBase _CurrentState;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        // 반복적임 -> 자동화 필요 (Reflection 활용) , Addstate() 함수 참조
        // _states.Add(StateType.Idle, new StateIdle());
        // _states.Add(StateType.Move, new StateMove());
        // _states.Add(StateType.Jump, new StateJump());
        // _states.Add(StateType.Fall, new StateFall());
        // _states.Add(StateType.Attack, new StateAttack());

        for (StateType stateType = StateType.Idle; stateType < StateType.EOF; stateType++) //enum 순회
        {
            AddState(stateType);
        }
        _CurrentState = _states[StateType.Idle];
        Current = StateType.Idle;
    }

    // Reflection1 - Add에 관한 함수 추가
    private void AddState(StateType stateType)
    {
        // 딕셔너리에 이미 상태가 등록된 상태 (키 값은 중복이 불가하므로)
        if (_states.ContainsKey(stateType))
            return;

        // 문자열로 변경 (using System)
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
                    }) as StateBase; //Invoke: 호출 *StateBase로 형 변환

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

        // 상태가 바뀌지 않았으면
        if (Current == newStateType)
            return;

        // 바꾸려는 상태가 실행 가능하지 않으면
        if (_states[newStateType].IsExecuteOK == false)
            return;

        
        _CurrentState.ForceStop(); // 기존 상태 중단
        _CurrentState = _states[newStateType]; // 상태 갱신
        _CurrentState.Execute(); // 갱신 된 상태 실행 
        Current = newStateType;
    }

}
