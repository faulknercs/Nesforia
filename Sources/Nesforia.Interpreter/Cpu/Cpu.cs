#region License
/****************************************************************************
* Nesforia.Interpreter - NES/Famicom emulator interpreter implementation
*
* Copyright (C) 2014 Nesforia authors
*
* Authors: Artem Stepanyuk <faulknercs@yandex.ru>
*
* This file is part of Nesforia.Interpreter.
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
using Nesforia.Core.Cpu;
using Nesforia.Core.Exceptions;
using Nesforia.Core.Memory;

namespace Nesforia.Interpreter.Cpu
{
    public partial class Cpu : ICpu
    {
        private readonly IMemory _ram;
        private Registers _registers;

        private readonly IDictionary<Opcode, Action> _handlers = new Dictionary<Opcode, Action>();

        // used for temporary saving value from memory and address
        private byte _mValue;
        private int _effectiveAddress;

        public Cpu(IMemory ram)
        {
            _ram = ram;

            InitializeOpcodesHandlers();
        }

        public void HardReset()
        {
            throw new System.NotImplementedException();
        }

        public void SoftReset()
        {
            throw new System.NotImplementedException();
        }

        public void Execute()
        {
            var opcode = (Opcode) _ram.Read(_registers.PC);

            EvaluateAdderessAndMValue(opcode.AddressingMode());

            Action handler = _handlers[opcode];

            if (handler == null)
            {
                throw new BadOpcodeException(opcode, "Unsupported opcode");
            }

            _registers.PC += opcode.Size();

            handler();
        }

        /// <summary>
        /// Evaluates M value and Effective Address for opcode according to addressing mode
        /// </summary>
        /// <param name="mode">Addressing mode of executing opcode</param>
        private void EvaluateAdderessAndMValue(AddressingMode mode)
        {
            byte arg = _ram.Read(_registers.PC + 1);

            switch (mode)
            {
                case AddressingMode.Implicit:
                    return;

                case AddressingMode.Accumulator:
                    _mValue = _registers.A;
                    return;

                case AddressingMode.Immediate:
                case AddressingMode.Relative:
                    _effectiveAddress = _registers.PC + 1;
                    _mValue = arg;
                    return;

                case AddressingMode.ZeroPage:
                    _effectiveAddress = arg;
                    break;

                case AddressingMode.ZeroPageX:
                    _effectiveAddress = 0xFF & arg + _registers.X;
                    break;

                case AddressingMode.ZeroPageY:
                    _effectiveAddress = 0xFF & arg + _registers.Y;
                    break;

                case AddressingMode.Absolute:
                    _effectiveAddress = MakeFullAddress(arg, _ram.Read(_registers.PC + 2));
                    break;

                case AddressingMode.AbsoluteX:
                    _effectiveAddress = MakeFullAddress(arg, _ram.Read(_registers.PC + 2)) + _registers.X;
                    break;

                case AddressingMode.AbsoluteY:
                    _effectiveAddress = MakeFullAddress(arg, _ram.Read(_registers.PC + 2)) + _registers.Y;
                    break;

                case AddressingMode.IndirectX:
                {
                    var temp = (arg + _registers.X) & 0xff;
                    _effectiveAddress = MakeFullAddress(_ram.Read(temp), _ram.Read(++temp));
                    break;
                }

                case AddressingMode.IndirectY:
                    _effectiveAddress = MakeFullAddress(_ram.Read(arg), _ram.Read(arg + 1)) + _registers.Y & 0xFFFF;
                    break;

                case AddressingMode.Indirect:
                    _effectiveAddress = MakeFullAddress(arg, _ram.Read(_registers.PC + 2));
                    return;

                default:
                    throw new ArgumentOutOfRangeException("mode", "Unknown addressing mode!");
            }

            _mValue = _ram.Read(_effectiveAddress);
        }

        /// <summary>
        /// Creates 16 bit address from two bytes
        /// </summary>
        /// <param name="low">Low byte of address</param>
        /// <param name="high">High byte of address</param>
        /// <returns>16 bit address</returns>
        private static int MakeFullAddress(byte low, byte high)
        {
            return high << 8 | low;
        }
    }
}