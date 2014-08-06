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
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Nesforia.Core.Cpu
{
    /// <summary>
    /// Helper class for working with <see cref="Opcode"/>
    /// </summary>
    public static class OpcodesHelper
    {
        private static readonly byte[] SizeTable;
        private static readonly byte[] CyclesTable;
        private static readonly AddressingMode[] AddressingTable;

        /// <summary>
        /// Initialize Size, CpuCycles and Addressing mode tables from attributes of Opcodes
        /// </summary>
        /// <remarks>
        /// For perfomance reasons, do initialization of all tables in single pass, instead of retrieving information for each request
        /// </remarks>
        static OpcodesHelper()
        {
            var opcodes = GetOpcodes().ToList();

            SizeTable = new byte[opcodes.Count()];
            CyclesTable = new byte[opcodes.Count()];
            AddressingTable = new AddressingMode[opcodes.Count()];

            foreach (var opcode in opcodes)
            {
                OpcodeParametersAttribute attr = opcode.GetParameters();

                SizeTable[(int) opcode] = attr.Size;
                CyclesTable[(int) opcode] = attr.CpuCycles;
                AddressingTable[(int) opcode] = attr.AddressingMode;
            }
        }

        /// <summary>
        /// Gets size of given opcode
        /// </summary>
        /// <param name="opcode">MOS6502 opcode</param>
        /// <returns>Size of operation in bytes</returns>
        public static byte Size(this Opcode opcode)
        {
            return SizeTable[(int) opcode];
        }

        /// <summary>
        /// Gets needed cpu cycles for given opcode
        /// </summary>
        /// <param name="opcode">MOS6502 opcode</param>
        /// <returns>Number of cpu cycles</returns>
        public static byte CpuCycles(this Opcode opcode)
        {
            return CyclesTable[(int) opcode];
        }

        /// <summary>
        /// Gets addressing mode, which is used by given opcode
        /// </summary>
        /// <param name="opcode">MOS6502 opcode</param>
        /// <returns>Addressing mode of opcode</returns>
        public static AddressingMode AddressingMode(this Opcode opcode)
        {
            return AddressingTable[(int) opcode];
        }

        /// <summary>
        /// Helper method to retrive <see cref="OpcodeParametersAttribute"/>
        /// </summary>
        /// <param name="opcode">MOS6502 opcode</param>
        /// <returns><see cref="OpcodeParametersAttribute"/> attribute</returns>
        private static OpcodeParametersAttribute GetParameters(this Opcode opcode)
        {
            MemberInfo a = (typeof (Opcode).GetMember(opcode.ToString())[0]);
            return (OpcodeParametersAttribute)Attribute.GetCustomAttribute(a, typeof(Opcode));
        }

        /// <summary>
        /// Helper method to retriev all values of Opcodes enum
        /// </summary>
        /// <returns>All values of Opcodes enum</returns>
        /// <remarks>
        /// This method is needed, because using of Enum.GetValues in PCL with .net 4.0 support is forbidden.
        /// See http://msdn.microsoft.com/en-us/library/system.enum.getvalues%28v=vs.100%29.aspx
        /// </remarks>
        private static IEnumerable<Opcode> GetOpcodes()
        {
            return typeof(Opcode)
                .GetFields(BindingFlags.Static | BindingFlags.Public)
                .Select(fieldInfo => (Opcode) fieldInfo.GetValue(null));
        }
    }
}