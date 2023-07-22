using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateJump : State
{
    // Player가 땅에 닿아있으면서 상태가 Idle이거나 Move 일 때만 실행 가능
    public override bool canExecute =>_groundDetector.isDetected && 
                                      (machine.currentType == StateType.Idle ||
                                       machine.currentType == StateType.Move);

    private GroundDetector _groundDetector;

    public StateJump(StateMachine machine) : base(machine)
    {
        _groundDetector = machine.GetComponent<GroundDetector>();
    }

    public override StateType MoveNext()
    {
        StateType destination = StateType.Jump;

        switch (currentStep)
        {
            case IState<StateType>.Step.None:
                {
                    movement.isMovable = true;
                    movement.isDirectionChangeable = true;
                    rigidbody.bodyType = RigidbodyType2D.Dynamic;
                    animator.speed = 1.0f;
                    // rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0.0f); // 점프 결과 초기화
                    rigidbody.AddForce(Vector2.up * character.jumpForce, ForceMode2D.Impulse);
                    // force: 질량의 영향을 받음 / impulse: 질량의 영향을 받지 않음
                    animator.Play("Jump");
                    currentStep++;
                }
                break;
            case IState<StateType>.Step.Start:
                {
                    currentStep++;
                }
                break;
            case IState<StateType>.Step.Casting:
                {
                    currentStep++;
                }
                break;
            case IState<StateType>.Step.OnAction:
                {
                    if (_groundDetector.isDetected)
                        destination = movement.horizontal == 0.0f ? StateType.Idle : StateType.Move;
                    else if (rigidbody.velocity.y < 0)
                        destination = StateType.Fall;
                }
                break;
            case IState<StateType>.Step.Finish:
                break;
            default:
                break;
        }

        return destination;
    }
}
