using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

public sealed class ToolActivationButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private readonly BoolReactiveProperty _isPressed = new (false);
    public IReadOnlyReactiveProperty<bool> IsPressed => _isPressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        _isPressed.Value = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isPressed.Value = false;
    }
}