using UniRx;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public sealed class CoolerSlot : MonoBehaviour, IInteractable
{
    [SerializeField] private XRSocketInteractor _socket;

    private readonly ReactiveProperty<Cooler> _inserted = new(null);

    public IReadOnlyReactiveProperty<Cooler> Inserted => _inserted;

    private void Awake()
    {
        _socket.selectEntered.AddListener(OnSelected);
        _socket.selectExited.AddListener(OnDeselected);
    }

    private void OnSelected(SelectEnterEventArgs args)
    {
        var cooler = args.interactableObject.transform.GetComponentInParent<Cooler>();
        cooler.Install(_socket.attachTransform);
        _inserted.Value = cooler;
    }

    private void OnDeselected(SelectExitEventArgs args)
    {
        _inserted.Value = null;
    }

    public void Freeze()
    {
        _socket.enabled = false;
    }

    public void Unfreeze()
    {
        _socket.enabled = true;
    }
}