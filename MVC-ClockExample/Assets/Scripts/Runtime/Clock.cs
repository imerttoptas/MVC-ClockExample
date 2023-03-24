using RMC.Core.Architectures.Mini;
using RMC.Core.Architectures.Mini.Context;
using Runtime.Model;
using Runtime.Controller;
using Runtime.View;
using Runtime.Service;

namespace Runtime
{
    public class Clock : MiniMvcs<Context,ClockModel,ClockView,ClockController,ClockService>
    {
        public override void Initialize()
        {
            if (!_isInitialized)
            {
                _isInitialized = true;

                _context = new Context();
                _model = new ClockModel();
                _view = new ClockView();
                _service = new ClockService();
                _controller = new ClockController(_model, _view, _service);
                
                
                _model.Initialize(_context);
                _view.Initialize(_context);
                _service.Initialize(_context);
                _controller.Initialize(_context);
            }
        }
    }
}
