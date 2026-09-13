using UniRx;
using UnityEngine;

public sealed class ToolWorkZone : MonoBehaviour
{
    [SerializeField] private string _toolTag = "Tool";

    private readonly BoolReactiveProperty _containsTool = new BoolReactiveProperty(false);
    public IReadOnlyReactiveProperty<bool> ContainsTool => _containsTool;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(_toolTag)) return;
        _containsTool.Value = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag(_toolTag)) return;
        _containsTool.Value = false;
    }
}