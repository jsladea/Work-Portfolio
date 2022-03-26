using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sampleApp.Common
{

    public static class FileTester
    {
        public static bool Exists(string filepath)
        {
            try
            {
                if (File.Exists(filepath))
                    return true;
            }
            catch (FileNotFoundException)
            {
                return false;
            }
            catch (IOException)
            {
                return true;
            }
            return false;
        }
    }

    public class FileLocker
    {

        private string filepath;
        private FileStream lockStream;

        public FileLocker(string file)
        {
            filepath = file;
        }

        public async Task LockRecordForEditing()
        {

            await Task.Run(() =>
            {
                while (FileInUse())
                {
                    //do nothing while the employee record is locked for editing by another user
                    Console.WriteLine("File is locked.");
                    Task.Delay(100);
                }
            });


            //lock the file for editing by this user
            lockStream = new FileStream(filepath, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.Delete);
        }

        public void UnlockForEditing()
        {
            lockStream.Dispose();
            lockStream = null;
            File.Delete(filepath);
        }

        private bool FileInUse()
        {
            try
            {
                if (File.Exists(filepath))
                    return true;
            }
            catch (FileNotFoundException)
            {
                return false;
            }
            catch (IOException)
            {
                return true;
            }
            return false;
        }


    }

    public class ConcurrentFileReader : StreamReader
    {
        
        public static async Task<ConcurrentFileReader> GetConcurrentFileReaderAsync(string filename)
        {
            Timeout timeout = new Timeout(2.5);
            ConcurrentFileReader fileReader = null;
            await Task.Run(async () =>
            {
                timeout.Start();
                while (fileReader == null && !timeout.IsExpired())
                {
                    try
                    {
                        fileReader = new ConcurrentFileReader(filename);
                        await Task.Delay(100);
                    }
                    catch(FileNotFoundException ex)
                    {
                        Console.WriteLine("File Not Found");
                        throw ex;
                    }
                    catch (IOException)
                    {
                        //the file is in use by another instance of the sampleApp application
                    }
                }
            });
            return fileReader;
        }

        private ConcurrentFileReader(string filename) : base(filename)
        {
        }
    }

    public class ConcurrentFileWriter : StreamWriter
    {
        public static async Task<ConcurrentFileWriter> GetConcurrentFileWriterAsync(string filename, bool append)
        {
            Timeout timeout = new Timeout(2.5);
            ConcurrentFileWriter fileWriter = null;
            await Task.Run(async () =>
            {
                timeout.Start();
                while (fileWriter == null && !timeout.IsExpired())
                {
                    try
                    {
                        fileWriter = new ConcurrentFileWriter(filename, append);
                        await Task.Delay(100);
                    }
                    catch (FileNotFoundException ex)
                    {
                        Console.WriteLine("File Not Found");
                        throw ex;
                    }
                    catch (IOException)
                    {
                        //the file is in use by another instance of the sampleApp application
                    }
                }
            });
            return fileWriter;
        }

        private ConcurrentFileWriter(string filename, bool append) : base(filename, append)
        {
        }
    }
}
