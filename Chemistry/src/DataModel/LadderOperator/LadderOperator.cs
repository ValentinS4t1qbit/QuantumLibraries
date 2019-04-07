﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.Quantum.Chemistry.LadderOperators
{
    /// <summary>
    /// Enum for raising or lowering operator.
    /// </summary>
    public enum LadderType
    {
        u = 0, d = 1, identity
    }

    /// <summary>
    /// Data strcture for raising and lowering operators.
    /// </summary>
    public struct LadderOperator
    {
        /// <summary>
        /// LadderType specifying raising or lowering operator.
        /// </summary>
        public LadderType type;

        /// <summary>
        /// System index operator acts on.
        /// </summary>
        public int index;
        

        /// <summary>
        /// Constructor for ladder operator.
        /// </summary>
        /// <param name="setType">Set raising or lowering operator.</param>
        /// <param name="setIndex">Set system index.</param>
        public LadderOperator(LadderType setType, int setIndex)
        {
            type = setType;
            index = setIndex;
        }

        /// <summary>
        /// Constructor for ladder operator.
        /// </summary>
        /// <param name="set">Tuple where first item sets the operator type,
        /// and the second item indexes the system.</param>
        public LadderOperator((LadderType, int) set) : this(set.Item1, set.Item2) { }

        #region Equality Testing
        public override bool Equals(object obj)
        {
            return (obj is LadderOperator x) ? Equals(x) : false;
        }

        public bool Equals(LadderOperator x)
        {
            return (type == x.type) && (index == x.index);
        }

        public override int GetHashCode()
        {
            return index * Enum.GetNames(typeof(LadderType)).Length + (int) type;
        }

        public static bool operator ==(LadderOperator x, LadderOperator y)
        {
            return x.Equals(y);
        }

        public static bool operator !=(LadderOperator x, LadderOperator y)
        {
            return !(x.Equals(y));
        }
        #endregion

        /// <summary>
        /// Returns a human-readable description this object.
        /// </summary>
        public override string ToString() {
            string op = type.ToString();
            return $"{index}{op}";
        }
    }
    

}


