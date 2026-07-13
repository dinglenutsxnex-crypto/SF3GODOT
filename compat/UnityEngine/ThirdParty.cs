using System;

namespace JetBrains.Annotations
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public sealed class CanBeNullAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public sealed class NotNullAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public sealed class StringFormatMethodAttribute : Attribute
    {
        public string FormatParameterName { get; }
        public StringFormatMethodAttribute(string formatParameterName) { FormatParameterName = formatParameterName; }
    }

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public sealed class UsedImplicitlyAttribute : Attribute
    {
        public UsedImplicitlyAttribute() { }
        public UsedImplicitlyAttribute(ImplicitUseKindFlags flags) { }
        public UsedImplicitlyAttribute(ImplicitUseTargetFlags targetFlags) { }
        public UsedImplicitlyAttribute(ImplicitUseKindFlags flags, ImplicitUseTargetFlags targetFlags) { }
    }

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public sealed class InstantHandleAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public sealed class PureAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public sealed class MustUseReturnValueAttribute : Attribute
    {
        public string Justification { get; }
        public MustUseReturnValueAttribute() { }
        public MustUseReturnValueAttribute(string justification) { Justification = justification; }
    }

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public sealed class NoEnumerationAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public sealed class ContractAnnotationAttribute : Attribute
    {
        public string Contract { get; }
        public bool ForceFullStates { get; }
        public ContractAnnotationAttribute(string contract) { Contract = contract; }
        public ContractAnnotationAttribute(string contract, bool forceFullStates) { Contract = contract; ForceFullStates = forceFullStates; }
    }

    [Flags]
    public enum ImplicitUseKindFlags
    {
        Default = 0,
        Access = 1,
        Assign = 2,
        Instantiation = 4,
        MethodAccess = 8,
        MethodCall = 16,
        Type = 32,
    }

    [Flags]
    public enum ImplicitUseTargetFlags
    {
        Default = 0,
        Itself = 1,
        Members = 2,
        WithMembers = 4,
        WithInheritors = 8,
        WithMembersExtensions = 16,
        GenericParameters = 32,
        WithMembersParameters = 64,
    }
}

namespace UniRx
{
    public interface IObservable<T>
    {
        IDisposable Subscribe(IObserver<T> observer);
    }

    public interface IObserver<T>
    {
        void OnNext(T value);
        void OnError(Exception error);
        void OnCompleted();
    }

    // Uses System.IDisposable

    public static class Observable
    {
        public static IObservable<T> Return<T>(T value) => null;
        public static IObservable<T> Empty<T>() => null;
        public static IObservable<T> Never<T>() => null;
        public static IObservable<long> Interval(TimeSpan period) => null;
        public static IObservable<long> Timer(TimeSpan dueTime) => null;
        public static IObservable<long> Timer(TimeSpan dueTime, TimeSpan period) => null;
        public static IObservable<T> FromEvent<T>(Action<Action<T>> addHandler, Action<Action<T>> removeHandler) => null;
        public static IObservable<Unit> FromEvent(Action addHandler, Action removeHandler) => null;
        public static IObservable<long> EveryUpdate() => null;
    }

    public static class ObservableExtensions
    {
        public static IDisposable Subscribe<T>(this IObservable<T> source, Action<T> onNext) => null;
        public static IDisposable Subscribe<T>(this IObservable<T> source, Action<T> onNext, Action<Exception> onError) => null;
        public static IDisposable Subscribe<T>(this IObservable<T> source, Action<T> onNext, Action onCompleted) => null;
        public static IDisposable Subscribe<T>(this IObservable<T> source, Action<T> onNext, Action<Exception> onError, Action onCompleted) => null;
    }

    public class CompositeDisposable : IDisposable
    {
        public void Add(IDisposable item) { }
        public void Remove(IDisposable item) { }
        public void Clear() { }
        public void Dispose() { }
    }

    public class Subject<T> : IObservable<T>, IObserver<T>, IDisposable
    {
        public void OnNext(T value) { }
        public void OnError(Exception error) { }
        public void OnCompleted() { }
        public IDisposable Subscribe(IObserver<T> observer) => null;
        public void Dispose() { }
    }

    public struct Unit
    {
        public static readonly Unit Default = default;
    }

    public class ReactiveProperty<T> : IObservable<T>, IDisposable
    {
        public T Value { get; set; }
        public ReactiveProperty() { }
        public ReactiveProperty(T initialValue) { }
        public IDisposable Subscribe(IObserver<T> observer) => null;
        public void Dispose() { }
    }

    public class ReactiveCollection<T> : System.Collections.Generic.IList<T>, IDisposable
    {
        public T this[int index] { get => default; set { } }
        public int Count => 0;
        public bool IsReadOnly => false;
        public void Add(T item) { }
        public void Clear() { }
        public bool Contains(T item) => false;
        public void CopyTo(T[] array, int arrayIndex) { }
        public System.Collections.Generic.IEnumerator<T> GetEnumerator() => null;
        public int IndexOf(T item) => -1;
        public void Insert(int index, T item) { }
        public bool Remove(T item) => false;
        public void RemoveAt(int index) { }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => null;
        public void Dispose() { }
    }

    public static class UniRxScheduler
    {
        public static IScheduler MainThread => null;
        public static IScheduler MainThreadFixedUpdate => null;
        public static IScheduler MainThreadLateUpdate => null;
        public static IScheduler ThreadPool => null;
        public static IScheduler Immediate => null;
    }

    public interface IScheduler
    {
        IDisposable Schedule(Action action);
        IDisposable Schedule(Action action, TimeSpan dueTime);
    }
}

namespace Nekki
{
    public class HTTPRequest : Godot.HttpRequest
    {
    }
}
