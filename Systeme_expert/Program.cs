using System;
using System.Collections.Generic;
using System.Linq;

namespace Systeme_expert
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start the application!");

            Systeme<string> systeme = genereSysteme();
            Hypotheses<string> hypotheses = generateHypotheses(),
                oldHypotheses;

            List<Element<string>> hypothesesList = hypotheses.ListeHypotheses.ToList();

            Console.WriteLine("Before the algorithm :\n" +
                systeme.ToString() + "\n" +
                hypotheses.ToString());

            do
            {
                oldHypotheses = new Hypotheses<string>(hypotheses.ListeHypotheses.ToList());

                foreach (Element<string> hypothese in hypothesesList)
                {
                    foreach (Equation<string> equation in systeme.Equations)
                    {
                        ElementEquation<string> premisse = equation.DoesPremissesContainsElement(hypothese);

                        if (premisse != null)
                            premisse.AlwaysTrue = true;

                        if (equation.IsPremissesEmpty() && !hypotheses.Contains(equation.Conclusion))
                            hypotheses.AddHypothese(equation.Conclusion);
                    }
                }

                Console.WriteLine("After an iteration of the algorithm :\n" +
                    systeme.ToString() + "\n" +
                    hypotheses.ToString());

                hypothesesList = hypotheses.ListeHypotheses.ToList();

            } while (!hypotheses.Equals(oldHypotheses));

            Console.WriteLine("After the algorithm :\n" +
                systeme.ToString() + "\n" +
                hypotheses.ToString());

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
    }
}
