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
    {
        /// <summary>
        /// The label of the element.
        /// </summary>
        T Libelle { get; set; }

        /// <summary> (Constructor).
        ///  Initialize a new element with an defined element.
        /// </summary>
        /// 
        /// <param name="libelle">The label which will initialize the element.</param>
        public Element(T libelle) {
            Libelle = libelle;
        }

        /// <summary>
        /// An implementation of Equals for elements.
        /// Two elements are equals if their Libelle are equals. 
        /// </summary>
        /// 
        /// <param name="toCompare">The element to compare with the current element.</param>
        /// <returns>
        /// True if the both are equals
        /// False else
        /// </returns>
        public bool Equals(Element<T> toCompare)
        {
            return this.Libelle.Equals(toCompare.Libelle);
        }
    }
}
