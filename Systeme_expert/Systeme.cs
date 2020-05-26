using System;
using System.Collections.Generic;
using System.Linq;

namespace Systeme_expert
{
    /// <summary>
    /// An equation system to solve thanks to Hypotheses
    /// </summary>
    /// 
    /// <typeparam name="T">The type of the objects to analyse.</typeparam>
    class Systeme<T>
        where T : IComparable
    {
        /// <summary>
        /// The system equation list.
        /// </summary>
        public List<Equation<T>> Equations { get; set; }

        /// <summary> (Constructor).
        /// Initialize a new System with an empty equation list
        /// </summary>
        public Systeme() 
        {
            Equations = new List<Equation<T>>();
        }

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

        /// <summary> (Constructor).
        /// Solve the current system with the given hypotheses.
        /// </summary>
        /// 
        /// <param name="hypotheses">Hypotheses used to solve the system.</param>
        ///
        /// <returns>The system after the algorithm.</returns>
        public Systeme<T> SolveWithHypotheses(Hypotheses<T> hypotheses)
        {
            Hypotheses<T> oldHypotheses;

            List<Element<T>> hypothesesList = hypotheses.ListeHypotheses.ToList();

            do
            {
                oldHypotheses = new Hypotheses<T>(hypotheses.ListeHypotheses.ToList());

                foreach (Element<T> hypothese in hypothesesList)
                {
                    if (hypothese.State != ElementStateEnum.Absent)
                        foreach (Equation<T> equation in Equations)
                        {
                            ElementEquation<T> premisse = equation.DoesPremissesContainsElement(hypothese);

                            if (premisse != null)
                                premisse.AlwaysTrue = true;

                            if (equation.ArePremissesTrue() && !hypotheses.Contains(equation.Conclusion))
                                hypotheses.AddHypothese(equation.Conclusion);
                        }
                }

                hypothesesList = hypotheses.ListeHypotheses.ToList();

            } while (!hypotheses.Equals(oldHypotheses));

            return this;
        }
    }
}
