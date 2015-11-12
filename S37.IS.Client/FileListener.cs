using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reactive.Linq;
using System.Reactive.Disposables;

namespace S37.IS.Client
{
    public class FileListener : IDisposable
    {
        public string Location { get; private set; }

        FileSystemWatcher _watcher;
        FileSystemEventHandler _fileSystemEvent;

        public FileListener(string location)
        {
            // todo: validate location
            Location = location;
            _watcher = new FileSystemWatcher(location);
            _watcher.Filter = @"*.*";
            _watcher.NotifyFilter = NotifyFilters.LastWrite;
            _watcher.EnableRaisingEvents = true;
        }

        private IObservable<string> Listen()
        {
            return Observable.Create<string>(observer => {
                _fileSystemEvent = (sender, args) => observer.OnNext(args.FullPath);
                _watcher.Changed += _fileSystemEvent;
                return Disposable.Empty;
            });
        }

        private IEnumerable<string> GetFiles()
        {
            // todo: add exception handling around this
            var directoryInfo = new DirectoryInfo(Location);
            return directoryInfo.EnumerateFiles()
                .OrderBy(f => f.CreationTime)
                .Select(f => f.Name);
        }

        public IObservable<string> GetFilesAsObservable()
        {
            return Observable.Create<string>(observer => {
                GetFiles().ForEach(observer.OnNext);
                observer.OnCompleted();
                return Disposable.Empty;
            })
            .Concat(Listen());
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _watcher.Changed -= _fileSystemEvent;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~FileReader() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
