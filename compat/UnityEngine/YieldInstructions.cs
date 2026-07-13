using System;
using System.Collections;

namespace UnityEngine
{
    public class AsyncOperation
    {
        public bool isDone { get; set; }
        public float progress { get; set; }
        public int priority { get; set; }
        public bool allowSceneActivation { get; set; }
    }

    public class YieldInstruction { }
    public class Coroutine : YieldInstruction
    {
        public IEnumerator routine;
        public Coroutine() { }
        public Coroutine(IEnumerator routine) { this.routine = routine; }
    }
    public class WaitForSeconds : YieldInstruction
    {
        public WaitForSeconds(float seconds) { }
    }
    public class WaitForEndOfFrame : YieldInstruction { }
    public class WaitForFixedUpdate : YieldInstruction { }
    public class WaitForSecondsRealtime : CustomYieldInstruction
    {
        public WaitForSecondsRealtime(float time) { }
        public override bool keepWaiting => false;
    }
    public class WaitForUpdate : YieldInstruction { }
    public class WaitUntil : CustomYieldInstruction
    {
        public WaitUntil(Func<bool> predicate) { }
        public override bool keepWaiting => false;
    }
    public class WaitWhile : CustomYieldInstruction
    {
        public WaitWhile(Func<bool> predicate) { }
        public override bool keepWaiting => false;
    }
    public abstract class CustomYieldInstruction : IEnumerator
    {
        public abstract bool keepWaiting { get; }
        public object Current => null;
        public bool MoveNext() => keepWaiting;
        public void Reset() { }
    }

    public struct RenderBuffer { }

    public static class PlayableDirectorExtensions
    {
    }
}
