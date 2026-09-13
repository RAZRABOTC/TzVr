using System;
using UniRx;
using UnityEngine;

public class Scenario : MonoBehaviour
{
    [SerializeField] private ScenarioTask[] tasks;
    [SerializeField] private HintUI hintUI;

    private readonly CompositeDisposable _disposables = new CompositeDisposable();
    private int _index = -1;

    public void StartScenario()
    {
        _disposables.Clear();

        foreach (var task in tasks)
        {
            task.Deactivate();
        }

        SignalBus.Receive<TaskCompletedSignal>()
            .Subscribe(signal => OnTaskCompleted(signal.Task))
            .AddTo(_disposables);

        _index = -1;
        Next();
    }

    private void OnTaskCompleted(ScenarioTask task)
    {
        Debug.Log("TASK OMOPE;ELERED");
        if (_index < 0 || _index >= tasks.Length) return;
        if (tasks[_index] != task) return;

        task.Deactivate();
        Next();
    }

    private void Next()
    {
        Debug.Log("TASK NEXT NEXT ");
        _index++;

        if (_index >= tasks.Length)
        {
            hintUI.Show("Готово");
            return;
        }

        var task = tasks[_index];
        hintUI.Show(task.HintText);
        task.Activate();
    }

    private void OnDestroy() => _disposables.Dispose();
}