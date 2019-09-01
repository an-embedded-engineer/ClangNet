using System;
using System.Collections.Generic;
using System.Text;

namespace ClangNet
{
    /// <summary>
    /// Abstract Messageable
    /// </summary>
    public abstract class AMessageable
    {
        /// <summary>
        /// Send Message
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="new_line">Append New Line Flag</param>
        protected void SendMessage(string message = "", bool new_line = true)
        {
            Messenger.Verb(message, new_line);
        }

        /// <summary>
        /// Send Information Message
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="new_line">Append New Line Flag</param>
        protected void SendInfoMessage(string message = "", bool new_line = true)
        {
            Messenger.Info(message, new_line);
        }

        /// <summary>
        /// Send Warning Message
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="new_line">Append New Line Flag</param>
        protected void SendWarnMessage(string message = "", bool new_line = true)
        {
            Messenger.Warn(message, new_line);
        }

        /// <summary>
        /// Send Error Message
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="new_line">Append New Line Flag</param>
        protected void SendErrorMessage(string message = "", bool new_line = true)
        {
            Messenger.Error(message, new_line);
        }
    }
}
