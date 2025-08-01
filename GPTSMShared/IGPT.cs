using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPTSMShared
{
    public interface IGPT
    {
        public bool IsConfigured { get; set; }
        public void Initialize(GPTSettings _settings);
        public Task<string> Inference(string query);
    }
}
