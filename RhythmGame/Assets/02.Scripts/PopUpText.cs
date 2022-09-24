using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpText : MonoBehaviour
{
    private TMP_Text _text;
    private Vector3 _popUpPos; //팝업할 위치
    [SerializeField]private Vector3 _dir = Vector3.up; // 위로 움직임
    [SerializeField]private float _moveSpeed = 0.5f; //움직이는 속도
    [SerializeField]private float _fadeSpeed = 0.5f; //몇초만에 사라지는지

    public void PopUp()
    {
        gameObject.SetActive(false);
        gameObject.SetActive(true);
    }

    public void PopUp(string text)
    {
        gameObject.SetActive(false);
        _text.text = text;
        gameObject.SetActive(true);
    }

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
        _popUpPos = transform.position;
    }

    private void OnEnable() //활성화될때마다 호출
    {
        transform.position = _popUpPos; // 처음 위치로 가서
        _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, 1.0f);
    }

    private void FixedUpdate()
    {
        transform.Translate(_dir * _moveSpeed * Time.fixedDeltaTime);
        float a = (_text.color.a - _fadeSpeed * Time.fixedDeltaTime);

        if (a <= 0.01f)
        {
            gameObject.SetActive(false); //game object 비활성화
        }
        else
        {
            _text.color = new Color(_text.color.r,
                        _text.color.g,
                        _text.color.b,
                        a);
        }


        
    }
}
