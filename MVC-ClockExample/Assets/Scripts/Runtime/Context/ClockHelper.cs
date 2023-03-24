using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public static class ClockHelper
{
    public static async void StartTicking(Func<Task> fun)
    {
        
        // ConfigureAwait must be true to get unity main thread context
        var tcs = new TaskCompletionSource<bool>();
        await Task.Run(() => { tcs.SetResult(true);});
        
        tcs.Task.ConfigureAwait(true).GetAwaiter().OnCompleted(async() =>
        {
            if (Application.isPlaying)
            {
                //Call
                await fun.Invoke();
                    
                //Repeat
                StartTicking(fun);
            }
        });
    }

}
