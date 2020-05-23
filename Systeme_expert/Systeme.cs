using System;
using System.Collections.Generic;
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
        List<Equation<T>> Equations { get; set; }

        /// <summary> (Constructor).
        /// Initialize a new System with an equation list
        /// </summary>
        /// 
        /// <param name="equations">The equation list which will initialize the system.</param>
        public Systeme(List<Equation<T>> equations)
        {
            this.Equations = equations;
        }
    }
}
