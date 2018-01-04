using CommandLine;
using COTS.GameServer.Lua;
using System;
using System.Threading.Tasks;

namespace COTS.GameServer {

    public sealed class Program {

        private static void Main(string[] args) {
            var parser = Parser.Default;
            var parseAttempt = parser.ParseArguments<CommandLineArguments>(args: args);

            if (parseAttempt is Parsed<CommandLineArguments> successfullyParsed) {
                RunWithSucessfullyParsedCommandLineArguments(successfullyParsed.Value);
            } else if (parseAttempt is NotParsed<CommandLineArguments> failedAttempt) {
                ReportCommandLineParsingError(failedAttempt);
            } else {
                throw new InvalidOperationException("Fo reals? This line should never be reached.");
            }

            Console.ReadLine();
        }

        private static void RunWithSucessfullyParsedCommandLineArguments(CommandLineArguments commandLineArguments) {
            Task.WaitAny(LuaManager.Initialize());

            var clientConnectionManager = commandLineArguments.GetClientConnectionManager();
            Task.Run(() => clientConnectionManager.StartListening());
        }

        private static void ReportCommandLineParsingError(NotParsed<CommandLineArguments> failedAttempt) {
            throw new NotImplementedException();
        }
    }
}