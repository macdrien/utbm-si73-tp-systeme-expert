using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Systeme_expert
{
    /// <summary>
    /// An element only for Equations.
    /// </summary>
    /// 
    /// <typeparam name="T">The type of the element</typeparam>
    class ElementEquation<T> : Element<T>
    {
        /// <summary>
        /// Flag to see if the element is always true.
        /// </summary>
        public bool AlwaysTrue { get; set; }

        /// <summary> (Constructor).
        /// Initialize a new ElementEquation with given properties.
        /// </summary>
        /// 
        /// <param name="libelle">The label which will intialize the ElementEqualtion</param>
        /// <param name="alwaysTrue">The alwaysTrue flag which will intialize the ElementEqualtion</param>
        public ElementEquation(T libelle, bool alwaysTrue = false) : base(libelle)
        {
            this.AlwaysTrue = alwaysTrue;
        }
    }
}
