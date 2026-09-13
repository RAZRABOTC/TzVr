using System;
using UniRx;
using UnityEngine;

public sealed class ToolTask : ScenarioTask
{
    [SerializeField] private ToolActivationButton _button;
    [SerializeField] private ToolWorkZone _workZone;
    [SerializeField] private float _holdSeconds = 2f;

    private void Awake()
    {
        HintText = "Возьмите инструмент и удерживайте кнопку в рабочей зоне 2 секунды";
    }

    public override void Activate()
    {
        _workZone.ContainsTool
            .CombineLatest(_button.IsPressed, (inZone, pressed) => inZone && pressed)
            .Where(active => active)
            .SelectMany(_ => Observable.Timer(TimeSpan.FromSeconds(_holdSeconds)))
            .Where(_ => _workZone.ContainsTool.Value && _button.IsPressed.Value)
            .Subscribe(_ => Complete())
            .AddTo(_disposables);
    }
}