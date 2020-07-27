namespace ControleSocial.Domain.Models.Staging
{
	public interface IFT_Staging<T> : IFT_Staging, IStaging<T>
	{
	}

	public interface IFT_Staging
	{
		long IdSeedHistory { get; set; }
		void Initialize(long idSeedHistory);
	}
}
