using Microsoft.Extensions.CommandLineUtils;
using NEOBlockContentsViewer.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace neo_block_contents
{
    class Program
    {
        private static string _defaultEndpoint = "http://localhost:10332";

        static void Main(string[] args)
        {
            // Set up the app
            var app = new CommandLineApplication();
            app.Name = "dotnet NEOBlockContentsViewer.dll";
            app.HelpOption("-?|-h|--help");

            CommandArgument block = app.Argument(
                "block", 
                "The block height to retrieve", 
                false);

            CommandArgument endpoint = app.Argument(
                "endpoint",
                "The rpc endpoint to use",
                false);

            CommandOption raw = app.Option(
                "--raw",
                "Retrieve the raw bytes",
                CommandOptionType.NoValue);

            app.OnExecute(() =>
            {
                if(block.Value == null)
                {
                    Console.WriteLine("No block height specified.  -h for help");
                    return 0;
                }

                int blockHeight = 0;
                if(!int.TryParse(block.Value, out blockHeight))
                {
                    Console.WriteLine("Invalid block height specified.");
                    return 0;
                }

                GetBlock(endpoint.Value, blockHeight, raw.HasValue());
                return 0;
            });
            app.Execute(args);
        }

        private static void GetBlock(string endpoint, int height, bool raw)
        {
            if (String.IsNullOrEmpty(endpoint))
                endpoint = _defaultEndpoint;

            NeoCliHelper cli = new NeoCliHelper(endpoint);
            var blockContent = cli.GetRawBlock(height, !raw);

            Console.WriteLine("Retrieve block at " + height + (raw ? " -raw" : String.Empty));
            string blockOutput = String.Empty;
            if (raw)
            {
                blockOutput = BitConverter.ToString((byte[])blockContent).Replace("-", "");
            }
            else
            {
                blockOutput = JToken.Parse(blockContent.ToString()).ToString(Formatting.Indented);           
            }

            Console.WriteLine(blockOutput);
        }
    }
}
