using System;
using System.Collections.Generic;
using System.Linq;
using ClangNet.Samples;

namespace ClangNet.CUI
{
    /// <summary>
    /// Program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main Function
        /// </summary>
        /// <param name="args">Arguments</param>
        public static void Main(string[] args)
        {
            var impl = new ProgramImpl();

            impl.Execute();
        }

        /// <summary>
        /// Program Implementation
        /// </summary>
        internal class ProgramImpl : AMessageable
        {
            /// <summary>
            /// Execute
            /// </summary>
            public void Execute()
            {
                using (var logger = this.CreateLogger())
                {
                    this.InitializeMessenger(logger);

                    try
                    {
                        var (target_src, command_line_args) = this.CreateParameters();

                        CursorVisitor.Execute(target_src, command_line_args);

                        this.SendMessage();

                        InclusionVisitor.Execute(target_src, command_line_args);
                    }
                    catch(Exception ex)
                    {
                        this.SendErrorMessage(ex.Message);
                        this.SendErrorMessage(ex.StackTrace);
                    }
                }
            }

            /// <summary>
            /// Create Parameters(Source Path &amp; Command Line Arguments)
            /// </summary>
            /// <returns>Parameters</returns>
            private (string, string[]) CreateParameters()
            {
                var target_dir = $@"./Code";
                var target_src = $@"{target_dir}/src/test.cpp";
                var target_includes = new List<string> { $@"{target_dir}/inc" };
                var other_args = new List<string> { };
                var cl_args = target_includes.Select(inc => $"-I{inc}").Concat(other_args);
                var command_line_args = cl_args.ToArray();

                return (target_src, command_line_args);
            }

            /// <summary>
            /// Create Logger
            /// </summary>
            /// <returns>Logger Interface</returns>
            private ILogger CreateLogger()
            {
                var logger = new LogManager();

                logger.Add(new ConsoleLogger());
                logger.Add(new FileLogger("Log.txt"));

                return logger;
            }

            /// <summary>
            /// Initialize Messenger
            /// </summary>
            /// <param name="logger">Logger Interface</param>
            private void InitializeMessenger(ILogger logger)
            {
                Messenger.OnVerbMessageReceived += (message, new_line) =>
                {
                    logger.Verb(message, new_line);
                };

                Messenger.OnInfoMessageReceived += (message, new_line) =>
                {
                    logger.Info(message, new_line);
                };

                Messenger.OnWarnMessageReceived += (message, new_line) =>
                {
                    logger.Warn(message, new_line);
                };

                Messenger.OnErrorMessageReceived += (message, new_line) =>
                {
                    logger.Error(message, new_line);
                };
            }
        }
    }
}
