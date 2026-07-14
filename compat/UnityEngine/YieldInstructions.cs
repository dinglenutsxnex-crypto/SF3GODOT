using System;
using System.Collections;
using Godot;

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
        private float _endTime;
        public WaitForSeconds(float seconds) { _endTime = (float)Godot.Time.GetTicksMsec() / 1000f + seconds; }
        public bool keepWaiting => (float)Godot.Time.GetTicksMsec() / 1000f < _endTime;
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
        private Func<bool> _predicate;
        public WaitUntil(Func<bool> predicate) { _predicate = predicate; }
        public override bool keepWaiting
        {
            get
            {
                try { return !_predicate(); }
                catch { return false; }
            }
        }
    }
    public class WaitWhile : CustomYieldInstruction
    {
        private Func<bool> _predicate;
        public WaitWhile(Func<bool> predicate) { _predicate = predicate; }
        public override bool keepWaiting
        {
            get
            {
                try { return _predicate(); }
                catch { return false; }
            }
        }
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
