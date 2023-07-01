using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Character
{
    private PlayerInput _input;
    /// <summary> => �ؿ� �����ؼ� �ʿ� ����
    /// public void OnJump()
    /// {
    ///     stateMachine.ChangeState(StateType.Jump);
    /// }
    /// </summary>

    protected override void Awake()
    {
        // input�� ������ �� �ۿ� �ν� ���� -> Ű�� ���� �� / �� ���� �ν��ϱ� ���� �۾�
        base.Awake();
        _input = GetComponent<PlayerInput>();

        InputAction jumpAction = _input.currentActionMap.FindAction("Jump");
        jumpAction.performed += ctx => stateMachine.ChangeState(StateType.Jump);



        InputAction crouchAction = _input.currentActionMap.FindAction("Crouch");
        // ����
        // crouch �׼ǿ� ���ؼ� ��ư�� ������ �� ���� ����
        crouchAction.performed += ctx => stateMachine.ChangeState(StateType.Crouch);
        // crouch �׼ǿ� ���ؼ� ��ư�� ���� �� ���� ����
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
