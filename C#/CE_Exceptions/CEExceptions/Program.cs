using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;

namespace CEExceptions
{
    class Program
    {
        //This program follows a set of procedural steps and has the potential to throw a lot of exceptions
        static void Main(string[] args)
        {
            //Initialize the variables that will be used in this application
            WebClient apiConnection = new WebClient();
            Person thePerson = new Person();
            String userInput = "";
            String apiEndPoint = @"https://www.govtrack.us/api/v2/person?limit=10";
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(APIdata));
            APIdata data = new APIdata();

            //Display introduction
            Console.WriteLine("The purpose of this application is to enter information about a person. Let's begin.");

            //Ask the user for their name
            Console.WriteLine("What is the person's full name? (first middle last)");
            userInput = Console.ReadLine();

            //separate the first, middle, and last names out of the user input and store them in the Person object
            try
            {
                String[] names = userInput.Split(' ');
                thePerson.FirstName = names[0];
                thePerson.MiddleName = names[1];
                thePerson.LastName = names[2];
            }
            catch(ArgumentNullException e)
            {
                //if user was not set
                Console.WriteLine("\r\nERROR Lines: 32 - 35\r\nYou will only see this if there was no way to set the person.");
            }
            catch (IndexOutOfRangeException e)
            {
                //indexOutOfRangException: out of bounds of array
                //could have been number
                //could be empty
                //could be for entering characters with less than 3 spaces
                Console.WriteLine("\r\nERROR Line: 27\r\nThe error could be caused by:\r\nEmpty Input\r\nString with less than 3 spaces\r\nOr a number");
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred:  '{0}' ", e);
                return;
            }

            //ask the user for their age
            Console.WriteLine("What is the person's age?");
            userInput = Console.ReadLine();
            
            //convert the age to an int and store it in the Person object
            try
            {
                thePerson.Age = Convert.ToInt32(userInput);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("null");
            }
            catch (FormatException e)
            {
                //Format Exception
                //could be for leaving blank
                //could be non int
                Console.WriteLine("\r\nERROR Line: 58\r\nError Could have been from leaving blank\r\nOr a non int was added.");
            }
            catch(OverflowException e)
            {
                //number too large or small
                Console.WriteLine("\r\nERROR Line 58\r\nThe number was too large or small for int.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }

            //Ask the user to provide some miscellaneous traits and add them to the Person object
            Console.WriteLine("Provide some traits of your choice.");
            Console.WriteLine("How many traits will you add? (Maximum of 5)");
            userInput = Console.ReadLine();
            try
            {
                int numTraits = Convert.ToInt32(userInput);
                if(numTraits > 5)
                {
                    numTraits = 5;
                }

                //ask for as many traits as the user specified and add them to the Person object
                for (int i = 0; i < numTraits; i++)
                {
                    Console.WriteLine("What is the name of this trait?");
                    string traitName = Console.ReadLine();

                    Console.WriteLine("What is the value of this trait?");
                    string traitValue = Console.ReadLine();
                    
                    thePerson.AddTrait(traitName, traitValue);
                }
            }
            catch(FormatException e)
            {
                //could be blank
                //could have entered something that could not convert to int
                Console.WriteLine("\r\nERROR Line 90\r\nError could be blank input\r\nOr could not convert to int.");
            }
            catch(OverflowException e)
            {
                //too large or small for int
                Console.WriteLine("\r\nERROR Line 90\r\nNumber entered was too large or small for int.");
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return;
            }

            //display the Person object that the user created
            try
            {
                Console.WriteLine("This is the data you have entered:");
                Console.WriteLine(thePerson);
            }
            catch(FormatException e)
            {
                //invalid date time
                Console.WriteLine("\r\nERROR Lines: 32-35\r\nUnable to convert to Date Time input and to convert Character values to strings.");
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return;
            }

            //inform the user that we will now be downloading some additional Person objects
            Console.WriteLine("We will now download some additional people from an online API.");

            //read in some objects from an API; you may not recognize how this code works, but researching what exceptions it may throw is still the same
            try
            {
                Stream apiStream = apiConnection.OpenRead(apiEndPoint);

                data = (APIdata)ser.ReadObject(apiStream);

                apiStream.Close();
            }
            catch(HttpListenerException e)
            {
                //error closing
                Console.WriteLine("Should not see this error, you do there was an issue with the api request.");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return;
            }

            //let the user select which of these people that they want to see all of the information about.
            while (true)
            {
                try
                {
                    Console.WriteLine("Which of these people would you like to see full details on? (Enter e to exit)");
                    for (int i = 0; i < data.People.Count; i++)
                    {
                        Console.WriteLine(String.Format("{0}.{1} {2}\n", i, data.People[i].FirstName, data.People[i].LastName));
                    }
                    userInput = Console.ReadLine();
                    if (userInput.ToLower().Equals("e"))
                    {
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(data.People[Convert.ToInt32(userInput)]);
                    }
                }
                catch(FormatException e)
                {
                    //could have been empty
                    Console.WriteLine("\r\nERROR Line 178\r\nError could be blank input\r\nOr could not convert to int.");
                }
                catch(ArgumentOutOfRangeException e)
                {
                    //could have been a number that was not given
                    Console.WriteLine("\r\nERROR Line 178\r\nError from listing a number that was not available.");
                }
                catch(OverflowException e)
                {
                    //value to small or large
                    Console.WriteLine("\r\nERROR Line 178\r\nError was from entering number that was too large or small for int.");
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                    return;
                }
            }
            //end of program
        }
    }
}
