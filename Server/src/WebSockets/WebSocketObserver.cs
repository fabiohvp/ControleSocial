using Newtonsoft.Json;
using System;

namespace ControleSocial.WebSockets
{
	public class WebSocketObserver : WebSocketObserver<object>
	{
		public WebSocketObserver(string socketId, WebSocketWorkflowHandler session)
				: base(socketId, session)
		{
		}
	}

	public class WebSocketObserver<T> : IObserver<T>
	{
		protected IDisposable Unsubscriber;
		public readonly string SocketId;
		public readonly WebSocketWorkflowHandler Session;

		public WebSocketObserver(string socketId, WebSocketWorkflowHandler session)
		{
			SocketId = socketId;
			Session = session;
		}

		public virtual void Subscribe(IObservable<T> provider)
		{
			Unsubscriber = provider.Subscribe(this);
		}

		public virtual void Unsubscribe()
		{
			Unsubscriber.Dispose();
		}

		public virtual void OnCompleted()
		{
			//Console.WriteLine("Completed.");
		}

		public virtual void OnError(Exception error)
		{
			_ = Session.SendAsync(SocketId, JsonConvert.SerializeObject(error, Formatting.Indented, Startup.JsonSerializerSettings));
		}

		public virtual void OnNext(T value)
		{
			_ = Session.SendAsync(SocketId, JsonConvert.SerializeObject(value, Startup.JsonSerializerSettings));
		}
	}
}
