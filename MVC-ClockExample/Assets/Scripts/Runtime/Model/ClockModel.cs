using RMC.Core.Architectures.Mini.Context;
using RMC.Core.Architectures.Mini.Model;

namespace Runtime.Model
{
    /// <summary>
    /// Data store for all Runtime Data
    /// </summary>
    public class ClockModel : BaseModel
    {
        //Properties
        public Observable<int> TimeDelay => _timeDelay;
        public Observable<float> Time => _time;

        //Fields
        private readonly Observable<int> _timeDelay = new Observable<int>();
        private readonly Observable<float> _time = new Observable<float>();
        
        public override void Initialize(IContext context)
        {
            if (!IsInitialized)
            {
                base.Initialize(context);
                _time.Value = 0;
                _timeDelay.Value = 0;
            }
        }
    }
}
