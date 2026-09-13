using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(Rigidbody))]
public sealed class Cooler : MonoBehaviour, IInteractable
{
    [SerializeField] private XRGrabInteractable _interactable;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Install(Transform point)
    {
        Freeze();
        _rb.isKinematic = true;
        transform.SetPositionAndRotation(point.position, point.rotation);
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