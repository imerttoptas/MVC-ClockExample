using System;
using System.Threading.Tasks;
using RMC.Core.Architectures.Mini.Context;
using RMC.Core.Architectures.Mini.Service;
using UnityEngine;
using UnityEngine.Events;

namespace Runtime.Service
{
    public class LoadedUnityEvent : UnityEvent{}
    
    public class ClockService : BaseService
    {
        //Events
        public readonly LoadedUnityEvent OnLoaded = new LoadedUnityEvent();
        
        //Fields
        public int TimeDelay => _timeDelay;
        
        //Properties
        private int _timeDelay;
        
        public override void Initialize(IContext context)
        {
            if (!IsInitialized)
            {
                base.Initialize(context);
                _timeDelay = 0;
            }
        }

        public void Load()
        {
            RequireIsInitialized();

            LoadAsync();
        }

        private async void LoadAsync()
        {
            RequireIsInitialized();
            
            TextAsset textAsset = Resources.Load<TextAsset>("Texts/TimeDelay");

            await Task.Delay(500);
            
            if (textAsset == null)
            {
                Debug.LogError("Error: LoadAsync failed.");
            }
            else
            {
                _timeDelay = Int32.Parse(textAsset.ToString());
                OnLoaded.Invoke();
            }
        }
    }
}
