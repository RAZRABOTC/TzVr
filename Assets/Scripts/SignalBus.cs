using System;
using UniRx;

public static class SignalBus
{
    private static readonly Subject<ISignal> _subject = new Subject<ISignal>();

    public static void Publish<T>(T signal) where T : ISignal => _subject.OnNext(signal);

    public static IObservable<T> Receive<T>() where T : ISignal => _subject.OfType<ISignal, T>();
}

public interface ISignal { }

public readonly struct TaskCompletedSignal : ISignal
{
    public readonly ScenarioTask Task;
    public TaskCompletedSignal(ScenarioTask task) => Task = task;
}