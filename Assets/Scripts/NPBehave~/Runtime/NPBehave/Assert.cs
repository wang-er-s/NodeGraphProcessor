using ET;

namespace NPBehave
{
    public class Debug
    {
        public static void Assert(bool result, string errorMessage = "")
        {
            if (!result)
            {
                UnityEngine.Debug.LogError($"NPBehave Assert Fail!!!: {errorMessage}");
            }
        }
    }
}