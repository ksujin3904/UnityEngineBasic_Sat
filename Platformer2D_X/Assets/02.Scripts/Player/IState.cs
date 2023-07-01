// 인터페이스: 접근가능하도록 추상화 => public
public interface IState
{
    
    enum Commands
    {
        Idle,
        Prepare,
        Casting,
        OnAction,
        Finish
    }
    Commands Current { get; }
    bool IsExecuteOK { get; }

    void Execute();
    void ForceStop();
    StateMachine.StateType Update();
    void FixedUpdate();
    void MoveNext();

}
