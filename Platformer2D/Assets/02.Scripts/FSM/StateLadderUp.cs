using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateLadderUp : State {

    // StateLadderUp 실행조건
    public override bool canExecute => (machine.currentType == StateType.Idle ||
                                        machine.currentType == StateType.Move ||
                                        machine.currentType == StateType.Jump ||
                                        machine.currentType == StateType.Fall) &&
                                        _ladderDetector.isGoUpPossible;

    private LadderDetector _ladderDetector;
    private GroundDetector _groundDetector;

    // 오르고 있는 사다리 정보를 가진 멤버변수
    private Ladder _ladder;
    public StateLadderUp(StateMachine machine) : base(machine)
    {
        _ladderDetector = machine.GetComponent<LadderDetector>();
        _groundDetector = machine.GetComponent<GroundDetector>();

    }

    public override StateType MoveNext()
    {
        StateType destination = StateType.LadderUp;

        switch (currentStep)
        {
            case IState<StateType>.Step.None:
                {
                    // 오르고 있는 사다리 정보
                    _ladder = _ladderDetector.upLadder;
                    // 매달려있는 동안 이동불가, 상태 변경 불가
                    movement.isMovable = false;
                    movement.isDirectionChangeable= false;
                    // 속도 = 0으로 설정 + 중력과 충격에 내려가지 않도록 추가 설정 => Unity 물리엔진 사용 X
                    rigidbody.velocity = Vector2.zero;
                    // bodyType을 Dynamic(Unity제공 기본엔진)에서 Kinematic(사용자 설정 물리엔진)
                    rigidbody.bodyType = RigidbodyType2D.Kinematic;
                    // 매달린 상태(키 입력이 없는 경우)에서는 애니메이션 실행 정지
                    animator.speed= 0;
                    animator.Play("Ladder");
                    // 사다리를 타는 시작 위치 설정
                    // 1) 발이 땅에 닿아있을 경우  2) 발이 땅에 닿아있지 않은 경우
                     
                    if(_groundDetector.isDetected)
                    {
                        transform.position = _ladder.upStartPos;
                    }
                    else
                    {
                        transform.position = new Vector2(_ladder.transform.position.x, transform.position.y);
                    }

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
                // 사다리 탈출 위치 설정
                    // 발이 땅에 닿은 경우
                    if (_groundDetector.isDetected)
                    {
                        destination = movement.horizontal == 0.0f ? StateType.Idle : StateType.Move;
                    }
                    // 아래로 탈출하는 경우
                    else if(transform.position.y < _ladder.downEndPos.y)
                    {
                        destination = StateType.Idle;
                    }
                    // 위로 탈출하는 경우
                    else if(transform.position.y > _ladder.upEndPos.y)
                    {
                        transform.position = _ladder.topPos;
                        destination = movement.horizontal == 0.0f ? StateType.Idle : StateType.Move;
                    }
                    // 매달려있는 경우(위 아래로 이동가능)
                    else
                    {
                        float vertical = Input.GetAxis("Vertical");
                        animator.speed = MathF.Abs(vertical);
                        // kinematic을 사용중이기 떄문에 rigidbody 제공 함수 사용 불가
                        transform.position += Vector3.up * vertical * character.ladderSpeed * Time.deltaTime;
                    }
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
