using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum States
    {
        Idle,
        Move,
        Attack,
        Jump,
        Fall,

    }

    public enum JumpStates
    {
        Idle,
        prepare,
        Casting,
        OnAction,
        Finish
    }
    public enum FallStates
    {
        Idle,
        prepare,
        Casting,
        OnAction,
        Finish
    }

    public enum AttackStates
    {
        Idle,
        prepare,
        Casting,
        OnAction,
        Finish
    }

    States _state;
    JumpStates _jumpState;
    FallStates _fallState;
    AttackStates _attackState;

    private void Update()
    {

        switch (_state)
        {
            case States.Idle:
                break;
            case States.Move:
                break;
            case States.Attack:

                switch (_attackState)
                {
                    case AttackStates.Idle:
                        break;
                    case AttackStates.prepare:
                        break;
                    case AttackStates.Casting:
                        break;
                    case AttackStates.OnAction:
                        break;
                    case AttackStates.Finish:
                        break;
                    default:
                        break;
                }
                break;
            case States.Jump:

                switch (_jumpState)
                {
                    case JumpStates.Idle:
                        break;
                    case JumpStates.prepare:
                        break;
                    case JumpStates.Casting:
                        break;
                    case JumpStates.OnAction:
                        break;
                    case JumpStates.Finish:
                        break;
                    default:
                        break;
                }
                break;
            case States.Fall:

                switch (_fallState)
                {
                    case FallStates.Idle:
                        break;
                    case FallStates.prepare:
                        break;
                    case FallStates.Casting:
                        break;
                    case FallStates.OnAction:
                        break;
                    case FallStates.Finish:
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
    }
}
