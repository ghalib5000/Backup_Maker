using BasicLogger;
using CliFx;
using CliFx.Attributes;
using JsonMaker;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Backup_Maker
{
    public static class Program
    {
            public static async Task<int> Main() =>
                await new CliApplicationBuilder()
                    .AddCommandsFromThisAssembly()
                    .Build()
                    .RunAsync();



    }
}

