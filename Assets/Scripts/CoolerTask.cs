using UniRx;
using UnityEngine;

public sealed class CoolerTask : ScenarioTask
{
    [SerializeField] private CoolerSlot _slot;
    [SerializeField] private HintUI _hintUI;

    private void Awake() => HintText = "Установите сменную деталь в крепление";

    public override void Activate()
    {
        _slot.Unfreeze();

        _slot.Inserted
            .Where(item => item != null)
            .Subscribe(OnInserted)
            .AddTo(_disposables);
    }

    private void OnInserted(Cooler item)
    {
        if (_slot.Inserted == null)
        {
            _hintUI.Show("Неверное крепление");
            return;
        }

        Complete();
    }

    protected override void OnDeactivate()
    {

        _slot.Freeze();
    }
}