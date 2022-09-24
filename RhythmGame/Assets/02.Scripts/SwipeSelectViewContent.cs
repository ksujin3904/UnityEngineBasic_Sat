using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeSelectViewContent : MonoBehaviour
{
    private RectTransform[] _items;
    private RectTransform _rectTransform;
    private Rect _frameRect; // 사각형 정보 포함

    private float _itemLength;
    private float _spacedLength;
    private int _curentIndex;

    private void Awake()

        
    {
        int childCount = transform.childCount;
        _rectTransform = GetComponent<RectTransform>();
        _spacedLength = GetComponent<HorizontalLayoutGroup>().spacing +
                        (_rectTransform.rect.width + _itemLength * childCount/ childCount);
        _frameRect = transform.parent.GetComponent<RectTransform>().rect;

        _items = new RectTransform[childCount];
        for (int i = 0; i < childCount; i++)
        {
            _items[i] = transform.parent.GetComponent<RectTransform>();
        }
        _itemLength = -_items[0].rect.width;
    }

    public void MoveLeft()
    {
        if (_curentIndex > 0)
            _curentIndex--;
    }

    public void Move(int index)
    {
        Vector3 moveVec = new Vector3((-_itemLength + _spacedLength) * index,transform.localPosition.y,transform.localPosition.z);
        _rectTransform.localPosition = moveVec;

    }

}
