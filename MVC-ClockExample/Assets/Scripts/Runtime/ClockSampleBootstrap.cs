using UnityEngine;

namespace Runtime
{
    public class ClockSampleBootstrap : MonoBehaviour
    {
        void Start()
        {
            Debug.Log("clock initialized");
            Clock clock = new Clock();
            clock.Initialize();
        }
    
    }
}
