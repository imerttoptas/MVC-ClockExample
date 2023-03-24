using RMC.Core.Architectures.Mini.Controller.Commands;

namespace Runtime.Controller.Commands
{
    public class TimeChangedCommand : ValueChangedCommand<float>
    {
        public TimeChangedCommand(float previousValue, float currentValue) : base(previousValue,currentValue)
        {
            
        }
    }
}
