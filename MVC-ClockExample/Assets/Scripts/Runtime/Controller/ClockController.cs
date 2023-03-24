using System.Threading.Tasks;
using RMC.Core.Architectures.Mini.Context;
using RMC.Core.Architectures.Mini.Controller;
using Runtime.Controller.Commands;
using Runtime.Model;
using Runtime.Service;
using Runtime.View;
using UnityEngine;

namespace Runtime.Controller
{
    public class ClockController : BaseController<ClockModel,ClockView,ClockService>
    {
        
        public ClockController(ClockModel model, ClockView view , ClockService service) : base(model, view , service)
        {   
            
        }

        public override void Initialize(IContext context)
        {
            base.Initialize(context);
            
            _model.Time.OnValueChanged.AddListener(Model_OnTimerChanged);
            _service.OnLoaded.AddListener(Service_OnLoaded);
            _service.Load();
        }
        
        //Methods
        
        private void StartTicking()
        {
            RequireIsInitialized();
            
            ClockHelper.StartTicking(async() =>
            {
                float time = Mathf.Round(Time.time);
                if (time > 0)
                {
                    _model.Time.Value = time;
                }
                
                await Task.Delay(_model.TimeDelay.Value);
            });
        }


        //Event Handlers
        private void Model_OnTimerChanged(float previousValue, float currentValue)
        {
            RequireIsInitialized();
            
            Context.CommandManager.InvokeCommand(new TimeChangedCommand(previousValue,currentValue));
        }
        
        private void Service_OnLoaded()
        {
            RequireIsInitialized();
            
            _model.TimeDelay.Value = _service.TimeDelay;
            
            StartTicking();
        }

       
    }
}
