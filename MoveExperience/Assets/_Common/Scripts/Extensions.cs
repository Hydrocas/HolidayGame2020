///-----------------------------------------------------------------
/// Author : Hugo TEYSSIER
/// Date : 30/05/2020 21:02
///-----------------------------------------------------------------

using UnityEngine;

namespace UnityEngine
{
	public static class Extensions {

        private const string LOG_TAG = "[{0}] ";

        public static void Log(this object @object, object message)
        {
            Debug.Log(Format(@object, message));
        }

        public static void LogWarning(this object @object, object message)
        {
            Debug.LogWarning(Format(@object, message));
        }

        public static void LogError(this object @object, object message)
        {
            Debug.LogError(Format(@object, message));
        }

        private static string Format(object @object, object message)
        {
            return string.Concat(string.Format(LOG_TAG, @object.GetType().Name), message);
        }
    }
}