using DG.Tweening;

namespace GourmetsRealm.LastStationDemo.Utils
{
    public static class DoTweenExtensions
    {
        public static void KillActiveTween(this Tween tween)
        {
            if (tween.IsActive())
            {
                tween.Kill();
            }
        }
    }
}