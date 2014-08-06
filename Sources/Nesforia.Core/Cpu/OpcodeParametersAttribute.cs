#region License
/****************************************************************************
* Nesforia.Core - NES/Famicom emulator core libraries
*
* Copyright (C) 2014 Nesforia authors
*
* Authors: Artem Stepanyuk <faulknercs@yandex.ru>
*
* This file is part of Nesforia.Core.
*
* This library is free software: you can redistribute it and/or modify
* it under the terms of the GNU Lesser General Public License as published
* by the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This library is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
* GNU Lesser General Public License for more details.
*
* You should have received a copy of the GNU Lesser General Public License
* along with this library. If not, see <http://www.gnu.org/licenses/>.
*****************************************************************************/
#endregion
using System;

namespace Nesforia.Core.Cpu
{
    /// <summary>
    /// Specifies opcode's size, addressing mode and how many cpu cycles needed
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class OpcodeParametersAttribute : Attribute
    {
        /// <summary>
        /// Initialize a new instance of the OpcodeParametersAttribute class with specified parameters.
        /// </summary>
        /// <param name="size">Size of opcode in bytes</param>
        /// <param name="cpuCycles">Cpu cycles, needed for opcode</param>
        /// <param name="addressingMode">Used addressing mode of opcode</param>
        public OpcodeParametersAttribute(byte size, byte cpuCycles, AddressingMode addressingMode)
        {
            AddressingMode = addressingMode;
            Size = size;
            CpuCycles = cpuCycles;
        }

        /// <summary>
        /// Gets size of opcode
        /// </summary>
        public byte Size { get; private set; }

        /// <summary>
        /// Gets Number of cpu cycles for opcode
        /// </summary>
        public byte CpuCycles { get; private set; }

        /// <summary>
        /// Gets addressing mode for opcode
        /// </summary>
        public AddressingMode AddressingMode { get; private set; }
    }
}