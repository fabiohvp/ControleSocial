namespace ControleSocial.Models
{
	public class Upload
	{
		public string Blob { get; set; }
		public byte[] Contents
		{
			get
			{
				return new System.Text.UTF8Encoding().GetBytes(Blob);
			}
		}
		public string Name { get; set; }
	}
}
