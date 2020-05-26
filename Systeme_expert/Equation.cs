using System;
using System.Collections.Generic;

namespace Systeme_expert
{
    /// <summary>
    /// An equation.
    /// </summary>
    /// 
    /// <typeparam name="T">The type of the elements of the equation.</typeparam>
    class Equation<T>
        where T : IComparable
    {
        /// <summary>
        /// The elements on the left of the equation.
        /// </summary>
        public List<ElementEquation<T>> Premisses { get; set; }

        /// <summary>
        /// The result of the equation.
        /// If all Premisses are true then Conclusion is true.
        /// </summary>
        public Element<T> Conclusion { get; set; }

        /// <summary>
        /// Initialize a new Equation with premisses and a conclusion
        /// </summary>
        /// 
        /// <param name="premisses">The list of premisses</param>
        /// <param name="conclusion">The conclusion of the equation</param>
        public Equation(List<ElementEquation<T>> premisses, Element<T> conclusion)
        {
            this.Premisses = premisses;
            this.Conclusion = conclusion;
        }

        /// <summary>
        /// Test if the premisse list is empty.
        /// A list of premisses is empty if all premisses are always true.
        /// </summary>
        /// 
        /// <returns>
        /// True if all the premisses of the list are always true.
        /// False if at least one premisses is not always true.
        /// </returns>
        public bool ArePremissesTrue()
        {
            foreach (ElementEquation<T> premisse in Premisses)
                if (!premisse.AlwaysTrue)
                    return false;

            return true;
        }

        /// <summary>
        /// Test if premisses contains an element
        /// </summary>
        /// 
        /// <param name="toTest">The element to search</param>
        /// 
        /// <returns>
        /// The found element if toTest exists in Premisses.
        /// Null else.
        /// </returns>
        public ElementEquation<T> DoesPremissesContainsElement(Element<T> toTest)
        {
            foreach(ElementEquation<T> premisse in Premisses)
                if (premisse.Equals(toTest))
                    return premisse;

            return null;
        }

        public override string ToString()
        {
            string toReturn = "";
            
            for (int counter = 0; counter < Premisses.Count; counter++)
            {
                if (Premisses[counter].State == ElementStateEnum.PresentWithNegation)
                    toReturn += "!";

                toReturn += Premisses[counter].Libelle.ToString();

                toReturn += " ";

                if (counter < Premisses.Count - 1)
                    toReturn += "+ ";
            }

            toReturn += "=> " + Conclusion.ToString();

            return toReturn;
        }
    }
}
