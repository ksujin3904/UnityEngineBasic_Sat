using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateLadderUp : State {

    // StateLadderUp ��������
    public override bool canExecute => (machine.currentType == StateType.Idle ||
                                        machine.currentType == StateType.Move ||
                                        machine.currentType == StateType.Jump ||
                                        machine.currentType == StateType.Fall) &&
                                        _ladderDetector.isGoUpPossible;

    private LadderDetector _ladderDetector;
    private GroundDetector _groundDetector;

    // ������ �ִ� ��ٸ� ������ ���� �������
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
                    // ������ �ִ� ��ٸ� ����
                    _ladder = _ladderDetector.upLadder;
                    // �Ŵ޷��ִ� ���� �̵��Ұ�, ���� ���� �Ұ�
                    movement.isMovable = false;
                    movement.isDirectionChangeable= false;
                    // �ӵ� = 0���� ���� + �߷°� ��ݿ� �������� �ʵ��� �߰� ���� => Unity �������� ��� X
                    rigidbody.velocity = Vector2.zero;
                    // bodyType�� Dynamic(Unity���� �⺻����)���� Kinematic(����� ���� ��������)
                    rigidbody.bodyType = RigidbodyType2D.Kinematic;
                    // �Ŵ޸� ����(Ű �Է��� ���� ���)������ �ִϸ��̼� ���� ����
                    animator.speed= 0;
                    animator.Play("Ladder");
                    // ��ٸ��� Ÿ�� ���� ��ġ ����
                    // 1) ���� ���� ������� ���  2) ���� ���� ������� ���� ���
                     
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
                // ��ٸ� Ż�� ��ġ ����
                    // ���� ���� ���� ���
                    if (_groundDetector.isDetected)
                    {
                        destination = movement.horizontal == 0.0f ? StateType.Idle : StateType.Move;
                    }
                    // �Ʒ��� Ż���ϴ� ���
                    else if(transform.position.y < _ladder.downEndPos.y)
                    {
                        destination = StateType.Idle;
                    }
                    // ���� Ż���ϴ� ���
                    else if(transform.position.y > _ladder.upEndPos.y)
                    {
                        transform.position = _ladder.topPos;
                        destination = movement.horizontal == 0.0f ? StateType.Idle : StateType.Move;
                    }
                    // �Ŵ޷��ִ� ���(�� �Ʒ��� �̵�����)
                    else
                    {
                        float vertical = Input.GetAxis("Vertical");
                        animator.speed = MathF.Abs(vertical);
                        // kinematic�� ������̱� ������ rigidbody ���� �Լ� ��� �Ұ�
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
