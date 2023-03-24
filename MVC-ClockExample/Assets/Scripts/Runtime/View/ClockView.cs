using System;
using RMC.Core.Architectures.Mini.Context;
using RMC.Core.Architectures.Mini.View;
using Runtime.Controller.Commands;
using UnityEngine;

namespace Runtime.View
{
    public class ClockView : IView 
    {
        //Properties
        public bool IsInitialized => _isInitialized;
        public IContext Context => _context;

        //  Fields 
        private bool _isInitialized = false;
        private IContext _context;
        
        public void Initialize(IContext context)
        {
            if (!IsInitialized)
            {
                _isInitialized = true;
                _context = context;

                context.CommandManager.AddCommandListener<TimeChangedCommand>(OnTimeChangedCommand);
            }
        }

        public void RequireIsInitialized()
        {
            if (!_isInitialized)
            {
                throw new Exception("MustBeInitialized");
            }
        }

        private void OnTimeChangedCommand(TimeChangedCommand timeChangedCommand)
        {
            RequireIsInitialized();

            Debug.Log($"Elapsed Time: {timeChangedCommand.CurrentValue} seconds");
        }
        
        
        
    }
}
