using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace ControleSocial.WebSockets
{
	public class WebSocketWorkflowHandler : WebSocketHandler
	{
		public static ConcurrentDictionary<string, WebSocketObserver> Observers = new ConcurrentDictionary<string, WebSocketObserver>();

		public WebSocketWorkflowHandler(WebSocketConnectionManager socketManager)
				: base(socketManager)
		{
		}

		public override async Task ReceiveAsync(WebSocket socket, WebSocketReceiveResult result, byte[] buffer)
		{
			var str = System.Text.Encoding.UTF8.GetString(buffer, 0, result.Count); // base64 string
			var message = JsonConvert.DeserializeObject<Message>(str, Startup.JsonSerializerSettings);

			if (message.Type == "handshake")
			{
				var socketId = ConnectionManager.GetSocketId(socket);
				Observers.TryAdd(message.Value.ToString(), new WebSocketObserver(socketId, this));
			}
		}

		public override Task OnDisconnected(WebSocket socket)
		{
			var socketId = ConnectionManager.GetSocketId(socket);
			var observers = Observers.Where(o => o.Value.SocketId == socketId);

			foreach (var observer in observers)
			{
				var _observer = default(WebSocketObserver);
				Observers.TryRemove(observer.Key, out _observer);
			}

			return base.OnDisconnected(socket);
		}

		public class Message
		{
			public string Type { get; set; }
			public object Value { get; set; }
		}
	}
}
