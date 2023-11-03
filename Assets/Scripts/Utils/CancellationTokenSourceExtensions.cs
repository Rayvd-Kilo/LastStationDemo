using System.Threading;

namespace GourmetsRealm.LastStationDemo.Utils
{
    public static class CancellationTokenSourceExtensions
    {
        public static void CancelToken(this CancellationTokenSource cts)
        {
            cts?.Cancel();
            cts?.Dispose();
        }
    }
}