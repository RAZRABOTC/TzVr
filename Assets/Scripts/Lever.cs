using UniRx;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public sealed class Lever : MonoBehaviour, IInteractable
{
    public BoolReactiveProperty IsOn { get; } = new BoolReactiveProperty(false);
    [SerializeField] private XRGrabInteractable _interactable;
    [SerializeField] private HingeJoint _hingeJoint;
    [SerializeField] private float _offAngleThreshold = 10f;
    [SerializeField] private float _onAngleThreshold = 160f;

    private void Awake()
    {
        _interactable.selectExited.AddListener(OnLeverMoved);
    }

    private void OnLeverMoved(SelectExitEventArgs args)
    {
        Debug.Log(IsOn.Value);
        IsOn.Value = _hingeJoint.angle > _onAngleThreshold || (_hingeJoint.angle >= _offAngleThreshold && IsOn.Value);
        Debug.Log(IsOn.Value);
    }

    public void Freeze()
    {
        _interactable.enabled = false;
    }

    public void Unfreeze()
    {
        _interactable.enabled = true;
    }
}
