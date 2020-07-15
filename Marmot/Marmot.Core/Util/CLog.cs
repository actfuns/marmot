using NLog;
using System;

namespace Marmot.Core.Util
{
    /// <summary>
    /// CLog
    /// </summary>
    public class CLog
    {
        /// <summary>
        /// logger
        /// </summary>
        private static readonly Logger _logger = LogManager.GetLogger("marmot");

        /// <summary>
        /// Trace
        /// </summary>
        /// <param name="message"></param>
        public static void Trace(string message)
        {
            try
            {
                _logger.Trace(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        /// <summary>
        /// Trace
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public static void Trace(string message, params object[] args)
        {
            try
            {
                _logger.Trace(message, args);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        /// <summary>
        /// Trace
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        public static void Trace(Exception exception, string message)
        {
            try
            {
                _logger.Trace(exception, message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        /// <summary>
        /// Trace
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public static void Trace(Exception exception, string message, params object[] args)
        {
            try
            {
                _logger.Trace(exception, message, args);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        /// <summary>
        /// Debug
        /// </summary>
        /// <param name="message"></param>
        public static void Debug(string message)
        {
            try
            {
                _logger.Debug(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        /// <summary>
        /// Debug
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public static void Debug(string message, params object[] args)
        {
            try
            {
                _logger.Debug(message, args);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        /// <summary>
        /// Debug
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        public static void Debug(Exception exception, string message)
        {
            try
            {
                _logger.Debug(exception, message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        /// <summary>
        /// Debug
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public static void Debug(Exception exception, string message, params object[] args)
        {
            try
            {
                _logger.Debug(exception, message, args);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        /// <summary>
        /// Info
        /// </summary>
        /// <param name="message"></param>
        public static void Info(string message)
        {
            try
            {
                _logger.Info(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        /// <summary>
        /// Info
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public static void Info(string message, params object[] args)
        {
            try
            {
                _logger.Info(message, args);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        /// <summary>
        /// Info
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        public static void Info(Exception exception, string message)
        {
            try
            {
                _logger.Info(exception, message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        /// <summary>
        /// Info
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public static void Info(Exception exception, string message, params object[] args)
        {
            try
            {
                _logger.Info(exception, message, args);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        /// <summary>
        /// Warn
        /// </summary>
        /// <param name="message"></param>
        public static void Warn(string message)
        {
            try
            {
                _logger.Warn(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        /// <summary>
        /// Warn
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public static void Warn(string message, params object[] args)
        {
            try
            {
                _logger.Warn(message, args);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        /// <summary>
        /// Warn
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        public static void Warn(Exception exception, string message)
        {
            try
            {
                _logger.Warn(exception, message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        /// <summary>
        /// Warn
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public static void Warn(Exception exception, string message, params object[] args)
        {
            try
            {
                _logger.Warn(exception, message, args);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        public static void Error(string message)
        {
            try
            {
                _logger.Error(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        /// <summary>
        /// Error
        /// </summary>
        /// <param name="message"></param>
        public static void Error(Exception exception)
        {
            try
            {
                _logger.Error(exception);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        /// <summary>
        /// Error
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public static void Error(string message, params object[] args)
        {
            try
            {
                _logger.Error(message, args);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        /// <summary>
        /// Error
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        public static void Error(Exception exception, string message)
        {
            try
            {
                _logger.Error(exception, message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        /// <summary>
        /// Error
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public static void Error(Exception exception, string message, params object[] args)
        {
            try
            {
                _logger.Error(exception, message, args);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        /// <summary>
        /// Fatal
        /// </summary>
        /// <param name="message"></param>
        public static void Fatal(string message)
        {
            try
            {
                _logger.Fatal(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        /// <summary>
        /// Fatal
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public static void Fatal(string message, params object[] args)
        {
            try
            {
                _logger.Fatal(message, args);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        /// <summary>
        /// Fatal
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        public static void Fatal(Exception exception, string message)
        {
            try
            {
                _logger.Fatal(exception, message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        /// <summary>
        /// Fatal
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public static void Fatal(Exception exception, string message, params object[] args)
        {
            try
            {
                _logger.Fatal(exception, message, args);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
        }
    }
}
