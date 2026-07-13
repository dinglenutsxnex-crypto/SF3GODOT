using System;

namespace UnityEngine.Networking
{
    public class DownloadHandlerScript : DownloadHandler
    {
        public DownloadHandlerScript() { }
        public DownloadHandlerScript(byte[] preallocatedBuffer) { }
        protected virtual bool ReceiveData(byte[] data, int dataLength) => true;
        protected virtual void ReceiveContentLengthHeader(ulong contentLength) { }
        protected virtual byte[] GetData() => null;
        protected virtual void ReceiveContentLength(int contentLength) { }
        protected virtual void CompleteContent() { }
        protected virtual float GetProgress() => 0f;
    }
}
