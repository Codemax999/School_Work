using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace CodyMaxwell_CE07
{
    class Program
    {
        //output location
        static string outputFolder = @"..\..\Output";

        static void Main(string[] args)
        {
            //give user choice of reading in all of DataFile 1, 2, or 3
            //convert data to JSON
            //data files have values of each field
            //DataFieldsLayou file contains name of each field stored in a variable
            //data fields are able to read in from at least one of the DataFile files and stored in variable
            //Formatted JSON need to be written out to a new file

            //program instance
            Program pro = new Program();

            Console.WriteLine("Please select a file to process by entering the number of the item.");
            Console.WriteLine("\r\n1) DataFile1\r\n2) DataFile2\r\n3) DataFile3\r\n4) exit");

            String userSelection = Console.ReadLine();

            switch (userSelection)
            {
                case "1":

                    StreamReader myReaderData = new StreamReader("DataFile1.txt");
                    pro.Jsonify(myReaderData);
                    break;

                case "2":

                    StreamReader myReaderDataFile2 = new StreamReader("DataFile2.txt");
                    pro.Jsonify(myReaderDataFile2);
                    break;

                case "3":

                    StreamReader myReaderDataFile3 = new StreamReader("DataFile3.txt");
                    pro.Jsonify(myReaderDataFile3);
                    break;

                case "4":
                    return;

                default:
                    Console.WriteLine("Number Not Found, Please try again...");
                    break;
            }
        }

        private void Jsonify (StreamReader _dataFile)
        {
            //make output directory
            Directory.CreateDirectory(outputFolder);

            //write out to file reference
            StreamWriter outStream = new StreamWriter(outputFolder + @"\FileData.txt");

            //reader of data field
            StreamReader myReaderIndex = new StreamReader("DataFieldsLayout.txt");

            //string variables
            string dataFileLine = "";
            string dataFieldLine = "";

            //counter for going through main data file lines
            int counter = 0;

            //create dictionary

            //loop for reader
            while (counter < 102)
            {
                //skip initial line
                if (counter >= 1)
                {
                    //create dictionary 
                    Dictionary<string, string> newData = new Dictionary<string, string>();

                    //read file
                    dataFileLine = _dataFile.ReadLine();

                    //split line by pipes
                    string[] splitDataFile = dataFileLine.Split('|');

                    //loop through array of seperated sections
                    for (int i = 0; i < splitDataFile.Length; i++)
                    {
                        //add index key from DataFields Layout to each section of line
                        dataFieldLine = myReaderIndex.ReadLine();

                        //add dictionary to out JSON
                        if (i < 148)
                        {
                            //Add to dictionary
                            newData.Add(dataFieldLine, splitDataFile[i]);
                        }

                        //if final field of data go back to top of data field
                        if (i == 148)
                        {
                            myReaderIndex.DiscardBufferedData();
                            myReaderIndex.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
                        }
                    }

                    //format as json
                    string json = JsonConvert.SerializeObject(newData, Formatting.Indented);

                    //write out to file
                    outStream.WriteLine(json);
                }
                //go to next line
                counter++;
            }

            //close reader
            _dataFile.Close();
            Console.WriteLine("success");
        }
    }
}
