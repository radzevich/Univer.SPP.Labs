using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace _2
{
    class FileManager
    {
        private bool _copyAll = false;

        private enum UserAnswer
        {
            Yes = 'y',
            No = 'n',
            YesToAll = 'a',
        }

        public void CopyFile(object pathToCopy)
        {
            var copyIfExists = _copyAll;

            var fileToCopyInfo = new FileInfo((string)pathToCopy);
            if (fileToCopyInfo.Exists && !copyIfExists)
            {
                Console.WriteLine("File is already exists! Would you like to replace it?");
                Console.WriteLine("Yes - {0}, No - {1}, Yes to all = {2}", 
                    UserAnswer.Yes, 
                    UserAnswer.No, 
                    UserAnswer.YesToAll
                );

                string userAnswer = Console.ReadLine();
                switch (userAnswer)
                {
                    case "y":
                        copyIfExists = true;
                        break;
                    case "a":
                        _copyAll = true;
                        break;
                    case "n":
                        break;
                    default:
                        return;
                }
            }
            fileToCopyInfo.CopyTo((string)pathToCopy, copyIfExists);
        }

        public int CopyFilesAsync(List<string> filesToCopy, string targetCatalog)
        {
            var copiedFilesCounter = new MultiThreadCounter();
            var worksCompletedCounter = new MultiThreadCounter(filesToCopy.Count);

            foreach (var file in filesToCopy)
            {
                try
                {
                    var fileToCopyPath = Path.Combine(file, targetCatalog);
                    var fileWasCopied = ThreadPool.QueueUserWorkItem(CopyFile, fileToCopyPath);
                    if (fileWasCopied)
                    {
                        copiedFilesCounter.Inc();
                    }
                }
                finally
                {
                    worksCompletedCounter.Dec();
                }
            }
            
            return copiedFilesCounter.Value;
        }
    }
}
