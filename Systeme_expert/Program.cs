using System;
using System.Collections.Generic;

namespace Systeme_expert
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start the application!");

            Systeme<string> systeme;
            Hypotheses<string> hypotheses;

            if (args.Length != 2)
            {
                systeme = genereSysteme();
                hypotheses = generateHypotheses();
            }
            else
            {
                Console.WriteLine("Lecture des fichiers:\n" + args[0] + "\n" + args[1]);
                systeme = GenerateSystemeFromFile(args[0]);
                hypotheses = GenerateHypothesesFromFile(args[1]);
            }
            
            hypotheses.AddAbsentHypothesesFromSysteme(systeme);

            if (systeme != null && hypotheses != null)
            {
                Console.WriteLine("---------------------------\n" + 
                    "Before the algorithm :\n" +
                    systeme.ToString() + "\n" +
                    hypotheses.ToString());

                systeme.SolveWithHypotheses(hypotheses);

                Console.WriteLine("---------------------------\n" +
                    "After the algorithm :\n" +
                    systeme.ToString() + "\n" +
                    hypotheses.ToString());
            }

            Console.WriteLine("---------------------------\n" + 
                "End of the application!");
        }

        /// <summary>
        /// Generate a system with the example given in the exercice section of the README.
        /// </summary>
        /// 
        /// <returns>The system to solve</returns>
        static Systeme<string> genereSysteme()
        {
            // Prémisses des équations
            List<ElementEquation<string>> 
                premissesEquation1 = new List<ElementEquation<string>> 
                {
                    new ElementEquation<string>("A"),
                    new ElementEquation<string>("B")
                },
                premissesEquation2 = new List<ElementEquation<string>> 
                {
                    new ElementEquation<string>("C"),
                    new ElementEquation<string>("E"),
                    new ElementEquation<string>("D")
                },
                premissesEquation3 = new List<ElementEquation<string>> 
                {
                    new ElementEquation<string>("X"),
                    new ElementEquation<string>("D")
                };

            // Conclusion des équations
            Element<string> 
                conclusionEquation1 = new Element<string>("X"),
                conclusionEquation2 = new Element<string>("F"),
                conclusionEquation3 = new Element<string>("Z");

            // Equations
            Equation<string>
                equation1 = new Equation<string>(premissesEquation1, conclusionEquation1),
                equation2 = new Equation<string>(premissesEquation2, conclusionEquation2),
                equation3 = new Equation<string>(premissesEquation3, conclusionEquation3);

            // Systeme final
            return new Systeme<string>(new List<Equation<string>> { equation1, equation2, equation3 });
        }

        /// <summary>
        /// Generate hypotheses with the example given in the exercice section of the README.
        /// </summary>
        /// 
        /// <returns>Hypotheses which will be used to solve the system</returns>
        static Hypotheses<string> generateHypotheses()
        {
            return new Hypotheses<string>(
                new List<Element<string>> 
                    { 
                        new Element<string>("A"), 
                        new Element<string>("B"), 
                        new Element<string>("D") 
                    }
                );
        }

        /// <summary>
        /// Generate a systeme from a file.
        /// </summary>
        /// 
        /// <param name="systemeFilePath">The file to read's path.</param>
        /// 
        /// <returns>
        /// The created systeme object.
        /// Null if the file can not be read of if an error occured during the file reading.
        /// </returns>
        static Systeme<string> GenerateSystemeFromFile(string systemeFilePath)
        {
            try
            {
                string[] systemeFileLines = System.IO.File.ReadAllLines(systemeFilePath);

                Systeme<string> systeme = new Systeme<string>();

                foreach (string line in systemeFileLines)
                {
                    List<ElementEquation<string>> premissesEquations = new List<ElementEquation<string>>();

                    string currentWord = "";
                    int separatorPremissesAndConclusionIndex = 0;
                    ElementStateEnum stateFlag = ElementStateEnum.PresentWithoutNegation;

                    // Read premisses
                    for (int counter = 0; counter < line.Length && line[counter] != '='; counter++)
                    {
                        if (line[counter] == '+' || line[counter + 1] == '=')
                        {
                            premissesEquations.Add(new ElementEquation<string>(currentWord.TrimStart().TrimEnd(), stateFlag));
                            currentWord = "";
                            stateFlag = ElementStateEnum.PresentWithoutNegation;
                        }
                        else if (currentWord.TrimStart() == "" && line[counter] == '!')
                        {
                            stateFlag = ElementStateEnum.PresentWithNegation;
                        }
                        else
                        {
                            currentWord += line[counter];
                        }

                        if (counter < line.Length - 1 && line[counter + 1] == '=')
                            separatorPremissesAndConclusionIndex = counter + 1;
                    }

                    // Read conclusion
                    stateFlag = ElementStateEnum.PresentWithoutNegation;
                    string conclusion = "";
                    for(int counter = separatorPremissesAndConclusionIndex + 1; counter < line.Length; counter++)
                    {
                        if (currentWord.TrimStart() == "" && line[counter] == '!')
                            stateFlag = ElementStateEnum.PresentWithNegation;

                        conclusion += line[counter];
                    }

                    Element<string> conclusionEquation = new Element<string>(conclusion.TrimStart().TrimEnd(), stateFlag);

                    systeme.Equations.Add(
                        new Equation<string>(premissesEquations, conclusionEquation));
                }

                return systeme.Equations.Count != 0 ? systeme : null;

            }
            catch (Exception exception)
            {
                Console.WriteLine("Error during the system's file reading : " + exception.ToString());
                return null;
            }
        }

        /// <summary>
        /// Generate a hypotheses from a file.
        /// </summary>
        /// 
        /// <param name="hypothesesFilePath">The file to read's path.</param>
        /// 
        /// <returns>
        /// The created hypotheses object.
        /// Null if the file can not be read of if an error occured during the file reading.
        /// </returns>
        static Hypotheses<string> GenerateHypothesesFromFile(string hypothesesFilePath)
        {
            try
            {
                string[] hypothesesFileLines = System.IO.File.ReadAllLines(hypothesesFilePath);

                Hypotheses<string> hypotheses = new Hypotheses<string>();

                foreach (string line in hypothesesFileLines) {
                    string toAdd = line.TrimStart().TrimEnd();

                    if (toAdd[0] == '!')
                        hypotheses.ListeHypotheses.Add(
                            new Element<string>(toAdd.Substring(1), ElementStateEnum.PresentWithNegation));
                    else
                        hypotheses.ListeHypotheses.Add(
                            new Element<string>(toAdd, ElementStateEnum.PresentWithoutNegation));
                }

                return !hypotheses.IsEmpty() ? hypotheses : null;

            }
            catch (Exception exception)
            {
                Console.WriteLine("Error during the hypotheses's file reading : " + exception.ToString());
                return null;
            }
        }
    }
}
