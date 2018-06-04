using System;
using System.Runtime.Serialization;

namespace ConsoleApp1
{
	[Serializable]
	internal class ReservedException : Exception
	{
		public ReservedException() : base()
		{
		}

		public ReservedException(string message) : base(message)
		{
		}

		public ReservedException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected ReservedException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
	
	[Serializable]
	internal class NaNException : Exception
	{
		public NaNException() : base()
		{
		}

		public NaNException(string message) : base(message)
		{
		}

		public NaNException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected NaNException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}