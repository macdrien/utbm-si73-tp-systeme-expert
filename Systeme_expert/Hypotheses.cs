using System;
using System.Collections.Generic;
using System.Dynamic;
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
        List<Element<T>> ListeHypotheses { get; set; }

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
    }
}
