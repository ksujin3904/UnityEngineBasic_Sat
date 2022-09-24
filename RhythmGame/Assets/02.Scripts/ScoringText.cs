using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //text를 갱신해야함

public class ScoringText : MonoBehaviour
{
    #region 싱글톤
    public static ScoringText Instance;

    private void Awake()
    {
        Instance = this;
        Score = 0;
    }
    #endregion

    private int _score;
    public int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _delta = (int)((_after - _before) / _scoringTime);  // 0.1초만에 점수 수치 업데이트
            _after = value;
            _score = value;
        }
    }

    [SerializeField] private TMP_Text _scoreText;
    private int _delta; // 변화량
    private int _before;
    private int _after;
    private float _scoringTime = 0.1f;

    private void Update()
    {
        if (_before < _after)
        {
            _before += (int)(_delta * Time.deltaTime);

            if (_before > _after)
                _before = _after;

            _scoreText.text = _before.ToString();
        }
    }
}
