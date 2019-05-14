// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Quantum.Arithmetic {
    open Microsoft.Quantum.Intrinsic;
    open Microsoft.Quantum.Diagnostics;

    /// # Summary
    /// Integer division of integer `xs` by integer `ys`. `xs` will hold the
    /// remainder `xs - floor(xs/ys) * ys` and `result` will hold
    /// `floor(xs/ys)`.
    ///
    /// # Input
    /// ## xs
    /// n-bit dividend (LittleEndian), will be replaced by the remainder.
    /// ## ys
    /// n-bit divisor (LittleEndian)
    /// ## result
    /// n-bit result (LittleEndian), must be in state $\ket{0}$ initially
    /// and will be replaced by the result of the integer division.
    ///
    /// # Remarks
    /// Uses a standard shift-and-subtract approach to implement the division.
    /// The controlled version is specialized such the subtraction does not
    /// require additional controls.
    operation IntegerDivision (xs: LittleEndian, ys: LittleEndian,
                               result: LittleEndian) : Unit {
        body (...) {
            (Controlled IntegerDivision) (new Qubit[0], (xs, ys, result));
        }
        controlled (controls, ...) {
            let n = Length(result!);

            EqualityFactI(n, Length(ys!), "Integer division requires
                           equally-sized registers ys and result.");
            EqualityFactI(n, Length(xs!), "Integer division
                            requires an n-bit dividend registers.");
            AssertAllZero(result!);

            let xpadded = LittleEndian(xs! + result!);

			for (i in (n-1)..(-1)..0) {
                let xtrunc = LittleEndian(xpadded![i..i+n-1]);
                (Controlled IntegerGreaterThan) (controls,
                                                 (ys, xtrunc, result![i]));
                // if ys > xtrunc, we don't subtract:
                (Controlled X) (controls, result![i]);
                (Controlled Adjoint IntegerAddition) ([result![i]],
                                                      (ys, xtrunc));
            }
        }
        adjoint auto;
        adjoint controlled auto;
    }
}