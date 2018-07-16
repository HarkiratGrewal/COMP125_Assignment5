using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            #region creating objects
            Flower Sepals = new Flower();
            Flower Petals = new Flower();
            string Species = Flower._Species;//local variable for the 
            #endregion

            #region Part1
            const char Delim = ',';
            string recordIn = ""; // Initiate with a value first. ALWAYS ALWAYS INITIATE STRINGS WITH A VALUE. Don't assign it null.
            string[] fields = new string[8]; // We assign it as an 8 size string array. The data never goes above or below this. Please never do this when the array size WILL change.
            int serialNumber;
            FileStream infile = new FileStream(@"C:\College\COMP 123\Assignments\Assignment 5\iris.csv", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(infile);
            Console.WriteLine("S.No. Speals.Length Sepals.Width Petals.Length Petals.Width Species"); // Moves it here instead. Cleaner output
            #endregion

            #region Part 2
            const string FileName = "iris.ser";
            FileStream outFile = new FileStream(FileName, FileMode.Create, FileAccess.ReadWrite);
            StreamWriter writer = new StreamWriter(outFile);
            BinaryFormatter bformatter = new BinaryFormatter();
            string writers = "";
            #endregion

            #region Part1
            while (recordIn != null)
            {
                fields = recordIn.Split(Delim);
                if (fields == null) // If it is an empty, skip execution of the while
                {
                    continue; // Don't continue to the tryc block. We are done.
                }//if condition for skipping
                recordIn = reader.ReadLine();
                try
                {
                    serialNumber = Convert.ToInt32(fields[0]);
                    Sepals.Length = Convert.ToDouble(fields[1]);
                    Sepals.Width = Convert.ToDouble(fields[2]);
                    Petals.Length = Convert.ToDouble(fields[3]);
                    Petals.Width = Convert.ToDouble(fields[4]);
                    Species = fields[5];
                    Console.WriteLine($"{serialNumber,3}{Sepals.Length,16}{Sepals.Width,13}{Petals.Length,14}{Sepals.Width,13}{Species,13}");
                    #endregion

                    #region Part2
                    try
                    {
                        writers = Convert.ToString(serialNumber);
                        writer.Write(writers);//writing to file
                        writers = Convert.ToString(serialNumber);
                        writer.Write(writers);//writing to file
                        writers = Convert.ToString(Sepals.Length);
                        writer.Write(writers);//writing to file
                        writers = Convert.ToString(Sepals.Width);
                        writer.Write(writers);//writing to file
                        writers = Convert.ToString(Petals.Length);
                        writer.Write(writers);//writing to file
                        writers = Convert.ToString(Petals.Width);
                        writer.Write(writers);//writing to file
                        writers = (Species);
                        writer.WriteLine(writers);//writing to file
                        bformatter.Serialize(outFile, writers);//binary convertor
                    }//try
                    catch (ObjectDisposedException)
                    {
                        writer.Dispose();
                    }//catch
                    writer.Close();
                    outFile.Close();
                    #endregion

                    #region Part1
                }//try
                catch (FormatException)
                {
                    serialNumber = 0;
                    Sepals.Length = 0;
                    Sepals.Width = 0;
                    Petals.Length = 0;
                    Petals.Width = 0;
                    Console.WriteLine("String variables, oops...");//change the error, i prefer it to be clear
                }//catch
            }//while loop reading file
            reader.Close();
            infile.Close();
            #endregion

            #region Part3
            string fileContent = "";
            const char DelimSer = ';';
            string[] field;//does not contain all data, size is always 1
            FileStream newFile = new FileStream(@"C:\College\COMP 123\Assignments\Assignment 5\ConsoleApp1\ConsoleApp1\bin\Debug\iris.ser", FileMode.Open, FileAccess.Read);
            StreamReader newfile = new StreamReader(newFile);
            while (fileContent != null)
            {
                field = fileContent.Split(DelimSer);
                fileContent = newfile.ReadLine();
                Console.WriteLine(field[0]);
            }//while loop reading file
            #endregion

            #region Part3 (Method 2)
            //const char Deliminator = ';';
            //string recordInDeserialize = "";
            //string[] fileDeserialize;
            //FileStream newFileDeserialize = new FileStream(@"C:\College\COMP 123\Assignments\Assignment 5\ConsoleApp1\ConsoleApp1\bin\Debug\iris.ser", FileMode.Open, FileAccess.Read);
            //StreamReader newfileDeserialize = new StreamReader(newFileDeserialize);
            //while(recordInDeserialize != null)
            //{
            //    fileDeserialize = recordInDeserialize.Split(Deliminator);
            //    if (fileDeserialize == null)
            //    {
            //        continue;
            //    }//if statement
            //    try
            //    {
            //        recordInDeserialize = newfileDeserialize.ReadLine();
            //        string content = Convert.ToString(fileDeserialize[0]);
            //        Console.WriteLine(content);
            //    }//try
            //    catch
            //    {
            //
            //    }//catch
            //}//while loop Deserialize
            #endregion

            #region Part4
            string fileContent2 = "";
            const char Deliminator = ';';
            string[] fileds;
            FileStream inFile2 = new FileStream(@"C:\College\COMP 123\Assignments\Assignment 5\ConsoleApp1\ConsoleApp1\bin\Debug\iris.ser", FileMode.Open, FileAccess.Read);
            StreamWriter outFile2 = new StreamWriter(inFile2);

            #endregion

        }//Main
    }//class Program

    [Serializable]
    #region Flower class
    class Flower
    {
        private double _Length;//change all these to array to store?
        private double _Width;
        //public static string _Species;
        public double Length
        {
            get
            {
                return _Length;
            }
            set
            {
                _Length = value;
            }
        }//Length
        public double Width
        {
            get
            {
                return _Width;
            }
            set
            {
                _Width = value;
            }
        }//Width
    }//class Flower
    #endregion

}//namespace ConsoleApp
