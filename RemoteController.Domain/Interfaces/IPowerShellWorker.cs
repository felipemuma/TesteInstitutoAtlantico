using System.Collections.Generic;

namespace RemoteController.Domain.Interfaces
{
    public interface IPowerShellWorker
    {
        List<string> OutputResult { get; set; }
        
        void ReadInput(string command);

        void ReadOutput();
    }
}
