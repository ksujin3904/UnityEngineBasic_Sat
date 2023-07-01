using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Character
{
    private PlayerInput _input;
    /// <summary> => 밑에 정의해서 필요 없음
    /// public void OnJump()
    /// {
    ///     stateMachine.ChangeState(StateType.Jump);
    /// }
    /// </summary>

    protected override void Awake()
    {
        // input은 누르는 것 밖에 인식 못함 -> 키를 누를 때 / 뗄 때를 인식하기 위해 작업
        base.Awake();
        _input = GetComponent<PlayerInput>();

        InputAction jumpAction = _input.currentActionMap.FindAction("Jump");
        jumpAction.performed += ctx => stateMachine.ChangeState(StateType.Jump);



        InputAction crouchAction = _input.currentActionMap.FindAction("Crouch");
        // 구독
        // crouch 액션에 대해서 버튼을 눌렸을 때 상태 정의
        crouchAction.performed += ctx => stateMachine.ChangeState(StateType.Crouch);
        // crouch 액션에 대해서 버튼을 뗏을 때 상태 정의
        crouchAction.canceled += ctx => stateMachine.ChangeState(StateType.StandUp); 
    }

    private void Start()
    {
        stateMachine.InitStates(new Dictionary<StateType, IState<StateType>>()
        {
            { StateType.Idle, new StateIdle(stateMachine) },
            { StateType.Move, new StateMove(stateMachine) },
            { StateType.Jump, new StateJump(stateMachine) },
            { StateType.Fall, new StateFall(stateMachine) },
            { StateType.Land, new StateLand(stateMachine) },
            { StateType.Crouch, new StateCrouch(stateMachine) },
            { StateType.StandUp, new StateStandUp(stateMachine) },
        });
    }
}
