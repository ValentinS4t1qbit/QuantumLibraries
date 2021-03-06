// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Quantum.Chemistry;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;

using Xunit;

namespace SystemTests
{
    using static FermionTermType.Common;
    using FermionTerm = FermionTerm;
    using FermionTermType = FermionTermType;
    public class SystemTestFromGeneralHamiltonian
    {

        [Fact]
        public void PPTermFromGeneralHamiltonianTest()
        {
            var generalHamiltonian = new FermionHamiltonian(nOrbitals: 1, nElectrons: 1);
            generalHamiltonian.AddFermionTerm(PPTermType, new Int64[] { 0, 0 }, 1.0);
            var jwEvolutionSetData = JordanWignerEncoding.Create(generalHamiltonian);
            var identityCoefficient = jwEvolutionSetData.energyOffset;
            var termData = jwEvolutionSetData.Terms;
            using (var qsim = new QuantumSimulator())
            {
                PPTermFromGeneralHamiltonianTestOp.Run(qsim, identityCoefficient, termData).Wait();
            }
        }

        [Fact]
        public void PQTermABFromGeneralHamiltonianTest()
        {
            var generalHamiltonian = new FermionHamiltonian(nOrbitals: 1, nElectrons: 1);
            generalHamiltonian.AddFermionTerm(PQTermType, new Int64[] { 0, 1 }, 2.0);
            var jwEvolutionSetData = JordanWignerEncoding.Create(generalHamiltonian);
            var termData = jwEvolutionSetData.Terms;
            using (var qsim = new QuantumSimulator())
            {
                PQTermABFromGeneralHamiltonianTestOp.Run(qsim, termData).Wait();
            }
        }

        [Fact]
        public void PQTermACFromGeneralHamiltonianTest()
        {
            var generalHamiltonian = new FermionHamiltonian(nOrbitals: 3, nElectrons: 1);
            generalHamiltonian.AddFermionTerm(PQTermType, new Int64[] { 0, 2 }, 2.0);
            var jwEvolutionSetData = JordanWignerEncoding.Create(generalHamiltonian);

            var termData = jwEvolutionSetData.Terms;
            using (var qsim = new QuantumSimulator())
            {
                PQTermACFromGeneralHamiltonianTestOp.Run(qsim, termData).Wait();
            }
            
        }

        [Fact]
        public void PQQPTermFromGeneralHamiltonianTest()
        {
            var generalHamiltonian = new FermionHamiltonian(nOrbitals: 3, nElectrons: 1);
            generalHamiltonian.AddFermionTerm(PQQPTermType, new Int64[] { 0, 1, 1, 0}, 1.0);
            var jwEvolutionSetData = JordanWignerEncoding.Create(generalHamiltonian);
            var identityCoefficient = jwEvolutionSetData.energyOffset;
            var termData = jwEvolutionSetData.Terms;
            using (var qsim = new QuantumSimulator())
            {
                PQQPTermFromGeneralHamiltonianTestOp.Run(qsim, identityCoefficient, termData).Wait();
            }
        }

        [Fact]
        public void PQQRTermFromGeneralHamiltonianTest()
        {
            var generalHamiltonian = new FermionHamiltonian(nOrbitals: 2, nElectrons: 1);
            generalHamiltonian.AddFermionTerm(PQQRTermType, new Int64[] { 0, 1, 2, 0 }, 1.0);
            var jwEvolutionSetData = JordanWignerEncoding.Create(generalHamiltonian);
            var termData = jwEvolutionSetData.Terms;
            using (var qsim = new QuantumSimulator())
            {
                PQQRTermFromGeneralHamiltonianTestOp.Run(qsim, termData).Wait();
            }
        }

        [Fact]
        public void PQRSTermFromGeneralHamiltonianTest()
        {
            var generalHamiltonian = new FermionHamiltonian(nOrbitals: 2, nElectrons: 1);
            generalHamiltonian.AddFermionTerm(PQRSTermType, new Int64[] { 0, 1, 3, 2 }, 2.0);
            var jwEvolutionSetData = JordanWignerEncoding.Create(generalHamiltonian);
            var termData = jwEvolutionSetData.Terms;
            using (var qsim = new QuantumSimulator())
            {
                PQRSTermFromGeneralHamiltonianTestOp.Run(qsim, termData).Wait();
            }
        }
    }

    public class SystemTestFromLiquidOrbital
    {

        [Fact]
        public void PPTermFromLiquidOrbitalTest()
        {
            string orbitals =  "0,0=1.0" ;
            var generalHamiltonian = LoadData.LoadFromLiquid(orbitals);
            generalHamiltonian.NElectrons = 1L;
            var jwEvolutionSetData = JordanWignerEncoding.Create(generalHamiltonian);
            var identityCoefficient = jwEvolutionSetData.energyOffset;
            var termData = jwEvolutionSetData.Terms;
            using (var qsim = new QuantumSimulator())
            {
                PPTermFromLiquidOrbitalTestOp.Run(qsim, identityCoefficient, termData).Wait();
            }
        }

        [Fact]
        public void PQTermABFromLiquidOrbitalTest()
        {
            string orbitals =  "0,1=1.0" ;
            var generalHamiltonian = LoadData.LoadFromLiquid(orbitals);
            generalHamiltonian.NElectrons = 1L;
            var jwEvolutionSetData = JordanWignerEncoding.Create(generalHamiltonian);
            var termData = jwEvolutionSetData.Terms;
            using (var qsim = new QuantumSimulator())
            {
                PQTermABFromLiquidOrbitalTestOp.Run(qsim, termData).Wait();
            }
        }

        [Fact]
        public void PQTermACFromLiquidOrbitalTest()
        {
            string orbitals =  "0,2=1.0" ;
            var generalHamiltonian = LoadData.LoadFromLiquid(orbitals);
            generalHamiltonian.NElectrons = 1L;
            var jwEvolutionSetData = JordanWignerEncoding.Create(generalHamiltonian);
            var identityCoefficient = jwEvolutionSetData.energyOffset;
            var termData = jwEvolutionSetData.Terms;
            using (var qsim = new QuantumSimulator())
            {
                PQTermACFromLiquidOrbitalTestOp.Run(qsim, termData).Wait();
            }
        }

        [Fact]
        public void PQQPTermFromLiquidOrbitalTest()
        {
            string orbitals =  "0,1,1,0=1.0" ;
            var generalHamiltonian = LoadData.LoadFromLiquid(orbitals);
            generalHamiltonian.NElectrons = 1L;
            var jwEvolutionSetData = JordanWignerEncoding.Create(generalHamiltonian);
            var identityCoefficient = jwEvolutionSetData.energyOffset;
            var termData = jwEvolutionSetData.Terms;
            using (var qsim = new QuantumSimulator())
            {
                PQQPTermFromLiquidOrbitalTestOp.Run(qsim, identityCoefficient, termData).Wait();
            }
        }

        [Fact]
        public void PQQRTermFromLiquidOrbitalTest()
        {
            string orbitals =  "0,0,1,0=1.0" ;
            var generalHamiltonian = LoadData.LoadFromLiquid(orbitals);
            generalHamiltonian.NElectrons = 1L;
            var jwEvolutionSetData = JordanWignerEncoding.Create(generalHamiltonian);
            var termData = jwEvolutionSetData.Terms;
            using (var qsim = new QuantumSimulator())
            {
                PQQRTermFromLiquidOrbitalTestOp.Run(qsim, termData).Wait();
            }
        }

        [Fact]
        public void PQRSTermFromLiquidOrbitalTest()
        {
            string orbitals =  "0,1,0,1=1.0" ;
            var generalHamiltonian = LoadData.LoadFromLiquid(orbitals);
            generalHamiltonian.NElectrons = 1L;
            var jwEvolutionSetData = JordanWignerEncoding.Create(generalHamiltonian);
            var termData = jwEvolutionSetData.Terms;
            using (var qsim = new QuantumSimulator())
            {
                PQRSTermFromLiquidOrbitalTestOp.Run(qsim, termData).Wait();
            }
        }


    }
}
