using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using log4net;
using Newtonsoft.Json.Linq;

namespace UploadfilesToGoogleStorage
{
    class ExecutionTimeLogger : IDisposable
    {
        private readonly ILog log = LogManager.GetLogger("ExecutionTimes");
        private readonly string methodName;
        private readonly Stopwatch stopwatch;

        public ExecutionTimeLogger([CallerMemberName] string methodName = "")
        {
            this.methodName = methodName;
            stopwatch = Stopwatch.StartNew();
           // its value is used to calculate the elapsed time when the Dispose method is called.
        }

        public void Dispose()
        {
            log.Debug(methodName + "() took " + stopwatch.ElapsedMilliseconds + " ms.");
            GC.SuppressFinalize(this);
        }
    }
}
