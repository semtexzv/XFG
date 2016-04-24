using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFG
{
    public enum LogType
    {
        //Should reflect android Log levels
        Assert=7,
        Fatal=Assert,
        Error=6,
        Warn=5,
        Info=4,
        Debug =3,
        Verbose=2,
    }
    public static class Logger
    {
        public delegate void OnLogDelegate(string message, LogType type);
        public static OnLogDelegate OnMessage;

        /// <summary>
        /// Log a message using specified log type
        /// </summary>
        /// <param name="type">Log type</param>
        /// <param name="format">Message, can contain tokens that should by replace by args</param>
        /// <param name="args">args, passed along with message to String.Format</param>
        public static void Log(LogType type, string format, params object[] args)
        {
            if (OnMessage != null)
                OnMessage(String.Format(format, args), type);
        }
        /// <summary>
         /// Log a message using specified log type
         /// </summary>
         /// <param name="type">Log type</param>
         /// <param name="format">Message, can contain tokens that should by replace by args</param>
         /// <param name="args">args, passed along with message to String.Format</param>
        public static void Log(LogType type, string format)
        {
            if (OnMessage != null)
                OnMessage(format, type);
        }
        /// <summary>
        /// Logs a message using lowest priority setting.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public static void Verbose(string format, params object[] args)
        {
            Log(LogType.Verbose, format, args);
        }
        /// <summary>
        /// Logs a message using debug priority setting.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public static void Debug(string format, params object[] args)
        {
            Log(LogType.Debug, format, args);
        }
        /// <summary>
        /// Logs a message using standard priority setting.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public static void Log(string format,params object[] args)
        {
            Log(LogType.Info, format, args);
        }
        /// <summary>
        /// Logs a message using warning priority setting.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public static void Warning(string format, params object[] args)
        {
            Log(LogType.Warn, format, args);
        }
        /// <summary>
        /// Logs a message using high priority setting.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public static void Error(string format, params object[] args)
        {
            Log(LogType.Error, format, args);
        }
        /// <summary>
        /// Logs a message using highest priority setting.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public static void Fatal(string format, params object[] args)
        {
            Log(LogType.Fatal, format, args);
        }
    }
}
