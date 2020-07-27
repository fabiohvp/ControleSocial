using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControleSocial.WebSockets
{
	public abstract class WebSocketHandler
	{
		public WebSocketConnectionManager ConnectionManager { get; set; }

		public WebSocketHandler(WebSocketConnectionManager socketManager)
		{
			ConnectionManager = socketManager;
		}

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
		public virtual async Task OnConnected(WebSocket socket)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
		{
			ConnectionManager.AddSocket(socket);
		}

		public virtual async Task OnDisconnected(WebSocket socket)
		{
			var id = ConnectionManager.GetSocketId(socket);
			await ConnectionManager.RemoveSocket(id);
		}

		public async Task SendAsync(WebSocket socket, string message)
		{
			if (socket.State == WebSocketState.Open)
			{
				var bytes = Encoding.UTF8.GetBytes(message);
				var buffer = new ArraySegment<byte>(bytes, 0, bytes.Length);
				await socket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
			}
		}

		public async Task SendAsync(string socketId, string message)
		{
			var socket = ConnectionManager.GetSocketById(socketId);
			await SendAsync(socket, message);
		}

		public async Task SendToAllAsync(string message)
		{
			foreach (var socket in ConnectionManager.GetAllSockets())
			{
				if (socket.Value.State == WebSocketState.Open)
				{
					await SendAsync(socket.Value, message);
				}
			}
		}

		public abstract Task ReceiveAsync(WebSocket socket, WebSocketReceiveResult result, byte[] buffer);
	}
}
