using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Reactive.Linq;

namespace S37.IS.Client.Tests
{
    [TestClass]
    public class FileReaderTests
    {
        [TestMethod]
        public void Will_read_from_a_specific_location()
        {
            var expected = @"d:\temp";
            var reader = new FileListener(expected);
            Assert.AreEqual(expected, reader.Location);
        }

        [TestMethod]
        public void Will_process_oldest_files_first()
        {
            var location = @"d:\temp\S37";
            if (Directory.Exists(location))
                Directory.Delete(location, true);
            Directory.CreateDirectory(location);

            var reader = new FileListener(location);
            var range = Enumerable.Range(0, 5);
            foreach (var item in range)
            {
                File.WriteAllText(Path.Combine(location, String.Format("{0}.txt", item)), item.ToString());
                Thread.Sleep(100);
            }

            reader.GetFilesAsObservable()
                .Take(1)
                .Subscribe(first => {
                    Assert.AreEqual("0.txt", first);
                });

            Directory.Delete(location, true);
        }

        [TestMethod]
        public void Will_process_existing_files_first()
        {
            var location = @"d:\temp\S37";
            if (Directory.Exists(location))
                Directory.Delete(location, true);
            Directory.CreateDirectory(location);

            var reader = new FileListener(location);
            var range = Enumerable.Range(0, 5);
            foreach (var item in range)
            {
                File.WriteAllText(Path.Combine(location, String.Format("{0}.txt", item)), item.ToString());
                Thread.Sleep(100);
            }

            var stream = reader.GetFilesAsObservable();

            var background = Task.Run(() => Enumerable.Range(6, 10).ForEach(item =>
            {
                File.WriteAllText(Path.Combine(location, String.Format("{0}.txt", item)), item.ToString());
                Thread.Sleep(100);
            }));

            stream.Skip(5).Take(1)
                .Subscribe(first => {
                    Assert.AreEqual("6.txt", first);
                });
            background.Wait();
            Directory.Delete(location, true);
        }
    }
}
