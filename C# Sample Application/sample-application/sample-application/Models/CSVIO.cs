using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApp.Common;

namespace sampleApp.Models.CSVIO
{

    public class CSVFileOperator
    {
        private string filename;

        public CSVFileOperator(string filename)
        {
            this.filename = filename;
        }

        /// <summary>
        /// Deletes first occurrence of rows in the csv file whose first cell is contained in the valuesToRemove list
        /// 
        /// </summary>
        /// <param name="valuesToRemove">list of starting values of the rows to remove</param>
        /// <returns></returns>
        public async Task DeleteRows(List<string> valuesToRemove)
        {

            string tempFileName = GetTempFileName();
            using (CSVFileReader reader = await CSVFileReader.GetReaderAsync(filename))
            {
                using (CSVFileWriter writer = new CSVFileWriter(tempFileName, false))
                {
                    await Task.Run(async () =>
                    {
                        string readLine;
                        while ((readLine = await reader.ReadRowAsync()) != null)
                        {
                            Console.WriteLine("\n" + readLine);
                            if (!DeleteLine(readLine.Substring(0, readLine.IndexOf(",")), valuesToRemove))
                            { //if the line shouldn't be deleted, then write it to the file copy
                                await writer.WriteRowAsync(readLine);
                            }
                        }
                    });
                }
            }
            //delete and replace file
            File.Delete(filename);
            File.Move(tempFileName, filename);
            
        }

        private bool DeleteLine(string value, List<string> valuesToRemove)
        {
            if (valuesToRemove.Count > 0)//if there are still values to remove
                foreach (string valueToRemove in valuesToRemove)
                    if (value.Equals(valueToRemove))
                    {
                        valuesToRemove.Remove(value);
                        return true; //the line should be deleted from the file
                    }

            return false;
        }

        private string GetTempFileName()
        {
            int dotIndex = filename.LastIndexOf(".");
            return filename.Substring(0, dotIndex) + "temp" + this.GetHashCode() + filename.Substring(dotIndex);
        }
    }

    public class CSVFileReader : StreamReader
    {

        /// <summary>
        /// Obtains a CSVFileReader for a specified file and avoids concurrent editing of shared files by waiting until the file is no longer under modification
        /// </summary>
        /// <param name="filename">file to read</param>
        /// <returns>a CSVFileReader object for the specified file</returns>
        public static async Task<CSVFileReader> GetReaderAsync(string filename)
        {
            Timeout timeout = new Timeout(2.5);
            CSVFileReader reader = null;
            await Task.Run(async () =>
            {
                timeout.Start();
                while(reader == null && !timeout.IsExpired())
                {   
                    try
                    {
                        reader = new CSVFileReader(filename);
                    }
                    catch (System.IO.FileNotFoundException ex) //the file doesn't exist throw exception to be handled in implementation
                    {
                        throw ex;
                    }
                    catch (System.IO.IOException) //the file is currently in use by another instance of the sampleApp program
                    {
                        Console.WriteLine(filename + " is currently in use by another user. The system will wait to open the file.");
                        await Task.Delay(100); //used to avoid unnecessary performance loss
                    }
                }
            });

            return reader;
        } 


        private bool validFile;

        public CSVFileReader(Stream stream) : base(stream)
        {
        }

        public CSVFileReader(string filename) : base(filename)
        {
            validFile = File.Exists(filename);
        }

        public async Task<string[]> ReadRowArrayAsync()
        {

            string line = await ReadLineAsync(); //read line from file
            
            if (string.IsNullOrEmpty(line))
                return null;

            string[] row = line.Split(',');
            EscapeCommas(row); //allows for the display of commas
            return row;
        }

        private void EscapeCommas(string[] row)
        {
            for(int i = 0; i < row.Length; i++)
            {
                row[i] = row[i].Replace(EscapeCharacters.Comma, ",");
            }
        }

        public async Task<string> ReadRowAsync()
        {
            string line = await ReadLineAsync();

            if (string.IsNullOrEmpty(line))
                return null;

            return line;
        }
    }

    public class CSVFileWriter : StreamWriter
    {

        /// <summary>
        /// Obtains a CSVFileWriter for a specified file and avoids concurrent editing of shared files by waiting until the file is no longer under modification
        /// </summary>
        /// <param name="filename">file to read</param>
        /// <returns>a CSVFileWriter object for the specified file</returns>
        public async static Task<CSVFileWriter> GetWriterAsync(string filename, bool append)
        {
            Timeout timeout = new Timeout(2.5);
            CSVFileWriter writer = null;

            await Task.Run(async () =>
            {
                timeout.Start();
                while(writer == null && !timeout.IsExpired())
                {
                    try
                    {
                        writer = new CSVFileWriter(filename, append);
                    }
                    catch (System.IO.IOException) //the file is currently in use by another instance of the sampleApp program
                    {
                        Console.WriteLine(filename + " is currently in use by another user. The system will wait to open the file.");
                        await Task.Delay(100); //used to avoid unnecessary performance loss
                    }
                }
            });

            return writer;
        }

        public StringBuilder LineBuilder { get; private set; } = new StringBuilder();

        public CSVFileWriter(string filename, bool append): base(filename, append)
        {
        }

        public CSVFileWriter(string filename) : base(filename)
        {
        }

        public CSVFileWriter(Stream stream): base(stream)
        {
        }

        public async Task WriteRowAsync()
        {
            await WriteLineAsync(LineBuilder.ToString());
            LineBuilder.Clear();
        }

        public async Task WriteRowAsync(string line)
        {
            await WriteLineAsync(line);
        }

    }

    public class EscapeCharacters
    {
        public static string Comma => "&Comma";
    }
}
