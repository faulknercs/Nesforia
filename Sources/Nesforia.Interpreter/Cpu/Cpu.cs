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

        // used for temporary saving value from memory
        private byte _currentMemoryValue;

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

            _currentMemoryValue = GetMValueFor(opcode.AddressingMode());

            Action handler = _handlers[opcode];

            if (handler == null)
            {
                throw new BadOpcodeException(opcode, "Unsupported opcode");
            }

            _registers.PC += opcode.Size();

            handler();
        }

        private byte GetMValueFor(AddressingMode mode)
        {
            switch (mode)
            {
                case AddressingMode.Implicit:
                    return 0;

                case AddressingMode.Accumulator:
                    return _registers.A;

                case AddressingMode.Immediate:
                    return _ram.Read(_registers.PC + 1);

                case AddressingMode.ZeroPage:
                    break;
                case AddressingMode.ZeroPageX:
                    break;
                case AddressingMode.ZeroPageY:
                    break;
                case AddressingMode.Relative:
                    break;
                case AddressingMode.Absolute:
                    break;
                case AddressingMode.AbsoluteX:
                    break;
                case AddressingMode.AbsoluteY:
                    break;
                case AddressingMode.Indirect:
                    break;
                case AddressingMode.IndirectX:
                    break;
                case AddressingMode.IndirectY:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("mode");
            }

            return 0;
        }
    }
}