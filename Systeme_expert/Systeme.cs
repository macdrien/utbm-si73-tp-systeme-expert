using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Systeme_expert
{
    /// <summary>
    /// An equation system to solve thanks to Hypotheses
    /// </summary>
    /// 
    /// <typeparam name="T">The type of the objects to analyse.</typeparam>
    class Systeme<T>
    {
        /// <summary>
        /// The system equation list.
        /// </summary>
        public List<Equation<T>> Equations { get; set; }

        /// <summary> (Constructor).
        /// Initialize a new System with an equation list
        /// </summary>
        /// 
        /// <param name="equations">The equation list which will initialize the system.</param>
        public Systeme(List<Equation<T>> equations)
        {
            this.Equations = equations;
        }

        public override string ToString()
        {
            string toReturn = "Systeme : {\n";

            for (int counter = 0; counter < Equations.Count; counter++)
                toReturn += "    " + Equations[counter].ToString() + "\n";

            toReturn += "}";

            return toReturn;
        }

        public Systeme<T> SolveWithHypotheses(Hypotheses<T> hypotheses)
        {
            Hypotheses<T> oldHypotheses;

            List<Element<T>> hypothesesList = hypotheses.ListeHypotheses.ToList();

            Console.WriteLine("Before the algorithm :\n" +
                ToString() + "\n" +
                hypotheses.ToString());

            do
            {
                oldHypotheses = new Hypotheses<T>(hypotheses.ListeHypotheses.ToList());

                foreach (Element<T> hypothese in hypothesesList)
                {
                    foreach (Equation<T> equation in Equations)
                    {
                        ElementEquation<T> premisse = equation.DoesPremissesContainsElement(hypothese);

                        if (premisse != null)
                            premisse.AlwaysTrue = true;

                        if (equation.IsPremissesEmpty() && !hypotheses.Contains(equation.Conclusion))
                            hypotheses.AddHypothese(equation.Conclusion);
                    }
                }

                Console.WriteLine("After an iteration of the algorithm :\n" +
                    ToString() + "\n" +
                    hypotheses.ToString());

                hypothesesList = hypotheses.ListeHypotheses.ToList();

            } while (!hypotheses.Equals(oldHypotheses));

            Console.WriteLine("After the algorithm :\n" +
                ToString() + "\n" +
                hypotheses.ToString());

            return this;
        }
    }
}
