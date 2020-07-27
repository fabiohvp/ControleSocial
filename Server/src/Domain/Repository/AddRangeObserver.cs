using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Microsoft.EntityFrameworkCore
{
    public class AddRangeObserver : IObserver<AddRangeObserverResult>
    {
        private IDisposable Unsubscriber;

        private Action<AddRangeObserverResult> _OnNext;
        private Action<Exception> _OnError;
        private Action _OnCompleted;
        public string Metadata { get; set; }

        public AddRangeObserver(Action<AddRangeObserverResult> onNext = default, Action<Exception> onError = default, Action onCompleted = default, string metadata = default)
        {
            _OnNext = onNext;
            _OnError = onError;
            _OnCompleted = onCompleted;
            Metadata = metadata;
        }

        public virtual void Subscribe(IObservable<AddRangeObserverResult> provider)
        {
            Unsubscriber = provider.Subscribe(this);
        }

        public virtual void Unsubscribe()
        {
            Unsubscriber.Dispose();
        }

        public virtual void OnCompleted()
        {
            if (_OnCompleted == default)
            {
                Console.WriteLine("Completed");
            }
            else
            {
                _OnCompleted();
            }
        }

        public virtual void OnError(Exception error)
        {
            if (_OnError != default)
            {
                _OnError(error);
            }
        }

        public virtual void OnNext(AddRangeObserverResult value)
        {
            if (_OnNext == default)
            {
                Console.WriteLine($"{value.Date:dd/MM/yyyy HH:mm:ss}: {value.Type.Name} | inserted: {value.Inserted} | updated: {value.Updated} | from: {value.Start} | to: {value.End} | of: {value.Total}");
            }
            else
            {
                value.Metadata.Add(Metadata);
                _OnNext(value);
            }
        }
    }

    public class AddRangeObserverResult
    {
        [JsonIgnore]
        public Type Type { get; set; }
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public int End { get; set; }
        public int Inserted { get; set; }
        public int Updated { get; set; }
        public int Start { get; set; }
        public int Total { get; set; }
        public double Percent
        {
            get
            {
                if (End >= Total)
                {
                    return 100;
                }

                return End * 100 / Total;
            }
        }
        public HashSet<string> Metadata { get; set; } = new HashSet<string>();
    }
}
