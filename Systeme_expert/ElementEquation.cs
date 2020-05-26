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
        where T : IComparable
    {
        /// <summary>
        /// Flag to see if the element is always true.
        /// 
        /// If the Not flag is false then ElementEquation is true when it is given by an hypothese.
        /// If the Not flag is true then ElementEquation is true when it is not given by an hypothese.
        /// </summary>
        public bool AlwaysTrue { get; set; }

        /// <summary> (Constructor).
        /// Initialize a new ElementEquation with given properties.
        /// </summary>
        /// 
        /// <param name="libelle">The label which will intialize the ElementEqualtion</param>
        /// <param name="stateFlag">
        /// The state flag which will initialize the ElementEquation.
        /// PresentWithoutNegation as default.
        /// </param>
        /// <param name="alwaysTrue">
        /// The alwaysTrue flag which will intialize the ElementEquation.
        /// False as default.
        /// </param>
        public ElementEquation(T libelle, ElementStateEnum stateFlag = ElementStateEnum.PresentWithoutNegation, bool alwaysTrue = false) : base(libelle, stateFlag)
        {
            this.AlwaysTrue = alwaysTrue;
        }
    }
}
