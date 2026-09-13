using UniRx;
using UnityEngine;

public class LeverTask : ScenarioTask
{
    [SerializeField] private Lever lever;

    private void Awake() => HintText = "Отключите установку рубильником";

    protected override void OnDeactivate()
    {
        lever.Freeze();
    }

    public override void Activate()
    {
        lever.Unfreeze();

        lever.IsOn
            .Where(on => on)
            .Subscribe(_ => Complete())
            .AddTo(_disposables);
    }
}