using UnityEngine;

namespace InputComponent
{
    public class VersionController : MonoBehaviour
    {
        private void Start()
        {
            switch (Application.platform)
            {
                case RuntimePlatform.Android:
                    gameObject.AddComponent<AndroidInput>();
                    break;
                case RuntimePlatform.WindowsPlayer:
                    gameObject.AddComponent<WinInput>();
                    break;
            }
        }
    }
}