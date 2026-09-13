using UniRx;
using UnityEngine;

public abstract class ScenarioTask : MonoBehaviour
{
    public string HintText { get; protected set; }

    protected readonly CompositeDisposable _disposables = new CompositeDisposable();

    public abstract void Activate();

    public void Deactivate()
    {
        OnDeactivate();
        _disposables.Clear();
    }

    protected void Complete() => SignalBus.Publish(new TaskCompletedSignal(this));

    protected virtual void OnDeactivate()
    {

    }
}