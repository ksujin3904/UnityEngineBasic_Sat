using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderDetector : MonoBehaviour
{
    public bool isGoUpPossible
    {
        get
        {
            Collider2D col =
                Physics2D.OverlapCircle((Vector2)transform.position + Vector2.up * _upLadderDetectOffsetY,
                                        _detectRadius,
                                        _ladderMask);
            // col이 null이 아니면
            upLadder = col ? col.GetComponent<Ladder>() : null;
            return upLadder;
        }
    }

    public bool isGoDownPossible
    {
        get
        {
            Collider2D col =
                Physics2D.OverlapCircle((Vector2)transform.position + Vector2.down * _downLadderDetectOffsetY,
                                        _detectRadius,
                                        _ladderMask);
            // col이 null이 아니면
            downLadder = col ? col.GetComponent<Ladder>() : null;
            return downLadder;
        }
    }


    public Ladder upLadder;
    public Ladder downLadder;
    [SerializeField] private float _upLadderDetectOffsetY;
    [SerializeField] private float _downLadderDetectOffsetY;
    [SerializeField] private float _detectRadius; // 감지기
    [SerializeField] private LayerMask _ladderMask; // 사다리 감지 마스크

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position + Vector3.up * _upLadderDetectOffsetY, _detectRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + Vector3.down * _downLadderDetectOffsetY, _detectRadius);
    }


}
