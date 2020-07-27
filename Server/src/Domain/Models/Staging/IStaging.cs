using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ControleSocial.Domain.Models.Staging
{
	public interface IStaging<T>
	{
		string CodigoComparacao { get; }
		IEnumerable<T> Save(IEnumerable<T> rows, IObserver<AddRangeObserverResult> observer = default);
	}
}
