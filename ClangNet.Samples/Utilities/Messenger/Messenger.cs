using System;
using System.Collections.Generic;
using System.Text;

namespace ClangNet
{
    /// <summary>
    /// Message Received Event Handler
    /// </summary>
    /// <param name="message">Message</param>
    /// <param name="new_line">Append New Line Flag</param>
    public delegate void MessageReceivedEventHandler(string message, bool new_line);

    /// <summary>
    /// Messenger
    /// </summary>
    public static class Messenger
    {
        /// <summary>
        /// Verbatim Message Received Event
        /// </summary>
        public static MessageReceivedEventHandler OnVerbMessageReceived { get; set; }

        /// <summary>
        /// Information Message Received Event
        /// </summary>
        public static MessageReceivedEventHandler OnInfoMessageReceived { get; set; }

        /// <summary>
        /// Warning Message Received Event
        /// </summary>
        public static MessageReceivedEventHandler OnWarnMessageReceived { get; set; }

        /// <summary>
        /// Error Message Received Event
        /// </summary>
        public static MessageReceivedEventHandler OnErrorMessageReceived { get; set; }

        /// <summary>
        /// Send Verbatim Message
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="new_line">Append New Line Flag</param>
        public static void Verb(string message, bool new_line)
        {
            Messenger.OnVerbMessageReceived?.Invoke(message, new_line);
        }

        /// <summary>
        /// Send Information Message
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="new_line">Append New Line Flag</param>
        public static void Info(string message, bool new_line)
        {
            Messenger.OnInfoMessageReceived?.Invoke(message, new_line);
        }

        /// <summary>
        /// Send Warning Message
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="new_line">Append New Line Flag</param>
        public static void Warn(string message, bool new_line)
        {
            Messenger.OnWarnMessageReceived?.Invoke(message, new_line);
        }

        /// <summary>
        /// Send Error Message
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="new_line">Append New Line Flag</param>
        public static void Error(string message, bool new_line)
        {
            Messenger.OnErrorMessageReceived?.Invoke(message, new_line);
        }
    }
}
