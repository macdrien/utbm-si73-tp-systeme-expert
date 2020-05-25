using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace Systeme_expert
{
    /// <summary>
    /// The hypotheses list
    /// </summary>
    /// 
    /// <typeparam name="T">
    /// The type of the elements of the list. 
    /// It must be the same as the type of the System's elements.
    /// </typeparam>
    class Hypotheses<T>
    {
        /// <summary>
        /// The hypotheses list
        /// </summary>
        public List<Element<T>> ListeHypotheses { get; set; }

        /// <summary> (Constructor).
        /// Initialize Hypotheses with a list of Element of type T
        /// </summary>
        /// 
        /// <param name="liste">The list to initialize</param>
        public Hypotheses(List<Element<T>> liste)
        {
            ListeHypotheses = liste;
        }

        /// <summary>
        /// Add a new Hypothese
        /// </summary>
        /// 
        /// <param name="hypothese">An Element of the type T</param>
        public void AddHypothese(Element<T> hypothese)
        {
            ListeHypotheses.Add(hypothese);
        }

        /// <summary>
        /// Add a new Hypothese
        /// </summary>
        /// 
        /// <param name="hypothese">An object of the type T</param>
        public void AddHypothese(T hypothese)
        {
            ListeHypotheses.Add(new Element<T>(hypothese));
        }

        public bool Contains(Element<T> toTest)
        {
            return ListeHypotheses.Contains(toTest);
        }

        public override string ToString()
        {
            string toReturn = "Hypotheses : { ";

            for (int counter = 0; counter < ListeHypotheses.Count; counter++)
            {
                toReturn += ListeHypotheses[counter].ToString();

                if (counter < ListeHypotheses.Count - 1)
                    toReturn += " , ";
            }

            toReturn += " }";
                
            return toReturn;
        }

        public bool Equals(Hypotheses<T> toTest)
        {
            if (this.ListeHypotheses.Count != toTest.ListeHypotheses.Count)
                return false;

            for (int counter = 0; counter < ListeHypotheses.Count; counter++)
                if (!ListeHypotheses[counter].Equals(toTest.ListeHypotheses[counter]))
                    return false;

            return true;
        }
    }
}
