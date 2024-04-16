using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hubbard.Utils
{
    public static class Helpers
    {
        static readonly Dictionary<float, WaitForSeconds> WaitForSecondsDict = new(100, new FloatComparer());
        
        public static WaitForSeconds GetWaitForSeconds(float seconds) {
            if (seconds < 1f / Application.targetFrameRate) return null;

            if (WaitForSecondsDict.TryGetValue(seconds, out var forSeconds)) return forSeconds;

            var waitForSeconds = new WaitForSeconds(seconds);
            WaitForSecondsDict[seconds] = waitForSeconds;
            return waitForSeconds;
        }
        
        class FloatComparer : IEqualityComparer<float> {
            public bool Equals(float x, float y) => Mathf.Abs(x - y) <= Mathf.Epsilon;
            public int GetHashCode(float obj) => obj.GetHashCode();
        }
    }
}
