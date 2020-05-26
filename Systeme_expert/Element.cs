using System;
using System.Collections.Generic;
using System.Text;

namespace Systeme_expert
{
    /// <summary>
    /// An element used in the system resolution.
    /// It can be use as an hypothese or an equation's element.
    /// </summary>
    /// 
    /// <typeparam name="T">The type of the element.</typeparam>
    class Element<T>
        where T : IComparable
    {
        /// <summary>
        /// The label of the element.
        /// </summary>
        public T Libelle { get; set; }

        /// <summary>
        /// Flag to see if the element is in hypotheses.
        /// If yes then show if the element is true or false too.
        /// </summary>
        public ElementStateEnum State { get; set; }

        /// <summary> (Constructor).
        ///  Initialize a new element with an defined element.
        /// </summary>
        /// 
        /// <param name="libelle">The label which will initialize the element.</param>
        public Element(T libelle, ElementStateEnum stateFlag = ElementStateEnum.Absent) {
            Libelle = libelle;
            State = stateFlag;
        }

        /// <summary>
        /// An implementation of Equals for elements.
        /// Two elements are equals if their Libelle are equals and if they have the same State flag. 
        /// </summary>
        /// 
        /// <param name="toCompare">The element to compare with the current element.</param>
        /// <returns>
        /// True if the both have the same Libelle and the same State flag
        /// False else
        /// </returns>
        public bool Equals(Element<T> toCompare)
        {
            return this.Libelle.Equals(toCompare.Libelle) && 
                this.State == toCompare.State;
        }

        /// <summary>
        /// Compare the current instance with an other Element<T>.
        /// </summary>
        /// 
        /// <param name="toCompare">The second element to compare</param>
        /// 
        /// <returns>
        /// 1 if:
        ///     - CompareTo the current Element's Libelle and the toCompare's Libelle return a positive number.
        ///     - The both Libelle are equals and the current element's State is after the toCompare's state.
        /// 0 if the current element and toCompare are equals.
        /// -1 if:
        ///     - CompareTo the current Element's Libelle and the toCompare's Libelle return a negative number.
        ///     - The both Libelle are equals and the current element's State is before the toCompare's state.
        /// </returns>
        public int CompareTo(Element<T> toCompare)
        {
            if (this.Equals(toCompare))
                return 0;

            if (this.Libelle.Equals(toCompare.Libelle))
                // Organize elements with same Libelle by State order
                if (this.State < toCompare.State)
                    return -1;
                else
                    return 1;

            return this.Libelle.CompareTo(toCompare);
        }

        public override string ToString()
        {
            string toReturn = "";

            if (State == ElementStateEnum.PresentWithNegation)
                toReturn += "!";
            
            return toReturn + Libelle.ToString();
        }
    }
}
