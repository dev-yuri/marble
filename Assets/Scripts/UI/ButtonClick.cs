using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] Image _image;
    [SerializeField] Sprite _default, _pressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        _image.sprite = _pressed;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _image.sprite = _default;
    }
}
