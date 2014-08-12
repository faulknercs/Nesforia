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
using Nesforia.Core.Cpu;

namespace Nesforia.Interpreter.Cpu
{
    public partial class Cpu
    {
        private void InitializeOpcodesHandlers()
        {
            _handlers[Opcode.Brk] = () =>
                {
                    _registers.B = true;
                    Push16(_registers.PC);
                    Push(_registers.PS);

                    _registers.PC = MakeFullAddress(_ram.Read(0xFFFE), _ram.Read(0xFFFF));
                };

            _handlers[Opcode.Rti] = () =>
                {
                    _registers.PS = Pull();
                    _registers.PC = Pull16();

                };

            _handlers[Opcode.Rts] = () =>
                {
                    _registers.PC = Pull16();
                    _registers.PC++;
                };

            _handlers[Opcode.Pha] = () => Push(_registers.A);

            _handlers[Opcode.Php] = () => Push(_registers.PS);

            _handlers[Opcode.Pla] = () => _registers.A = Pull();

            _handlers[Opcode.Plp] = () => _registers.PS = Pull();

            _handlers[Opcode.Ora01] =
            _handlers[Opcode.Ora05] =
            _handlers[Opcode.Ora09] =
            _handlers[Opcode.Ora0D] =
            _handlers[Opcode.Ora11] =
            _handlers[Opcode.Ora15] =
            _handlers[Opcode.Ora19] =
            _handlers[Opcode.Ora1D] = () =>
                {
                    _registers.A |= _mValue;
                    _registers.Z = _registers.A == 0;
                    _registers.N = (_registers.A & 0x80) != 0;
                };

            _handlers[Opcode.Nop] = () => { };

            _handlers[Opcode.Adc61] =
            _handlers[Opcode.Adc65] =
            _handlers[Opcode.Adc69] =
            _handlers[Opcode.Adc6D] =
            _handlers[Opcode.Adc71] =
            _handlers[Opcode.Adc75] =
            _handlers[Opcode.Adc79] =
            _handlers[Opcode.Adc7D] = () =>
                {
                    int temp = _registers.A + _mValue + (_registers.C ? 1 : 0);

                    _registers.Z = (temp & 0xFF) == 0;
                    _registers.N = (temp & 0x80) != 0;
                    _registers.C = (temp >> 8) != 0;
                    _registers.V = (((temp ^ _registers.A) & (temp ^ _mValue)) & 0x80) != 0;

                    _registers.A = (byte)temp;
                };

            _handlers[Opcode.And21] =
            _handlers[Opcode.And25] =
            _handlers[Opcode.And29] =
            _handlers[Opcode.And2D] =
            _handlers[Opcode.And31] =
            _handlers[Opcode.And35] =
            _handlers[Opcode.And39] =
            _handlers[Opcode.And3D] = () =>
                {
                    _registers.A &= _mValue;
                    _registers.Z = _registers.A == 0;
                    _registers.N = (_registers.A & 0x80) != 0;
                };

            _handlers[Opcode.Clc] = () => _registers.C = false;

            _handlers[Opcode.Cld] = () => _registers.D = false;

            _handlers[Opcode.Cli] = () => _registers.I = false;

            _handlers[Opcode.Clv] = () => _registers.V = false;

            _handlers[Opcode.LdaA1] =
            _handlers[Opcode.LdaA5] =
            _handlers[Opcode.LdaA9] =
            _handlers[Opcode.LdaAd] =
            _handlers[Opcode.LdaB1] =
            _handlers[Opcode.LdaB5] =
            _handlers[Opcode.LdaB9] =
            _handlers[Opcode.LdaBd] = () =>
                {
                    _registers.A = _mValue;
                    _registers.Z = _registers.A == 0;
                    _registers.N = (_registers.A & 0x80) != 0;
                };

            _handlers[Opcode.Sec] = () => _registers.C = true;

            _handlers[Opcode.Sed] = () => _registers.D = true;

            _handlers[Opcode.Sei] = () => _registers.I = true;


        }

        /// <summary>
        /// Pushes byte to stack, decrements S register
        /// </summary>
        /// <param name="value">Byte to store</param>
        private void Push(byte value)
        {
            _ram.Write(_registers.S + 0x100, value);
            _registers.S--;
        }

        /// <summary>
        /// Pushes 16 bit value to stack, decrements S register twice
        /// </summary>
        /// <param name="value">Value to store</param>
        private void Push16(int value)
        {
            Push((byte)((value & 0xFF00) >> 8));
            Push((byte)(value & 0x00FF));
        }

        /// <summary>
        /// Pulls value from stack, increments S register
        /// </summary>
        /// <returns>Value from stack</returns>
        private byte Pull()
        {
            _registers.S++;
            return _ram.Read(_registers.S + 0x100);
        }

        /// <summary>
        /// Pulls 16 bit value from stack, increments S register twice
        /// </summary>
        /// <returns>16 bit value from stack</returns>
        private int Pull16()
        {
            return Pull() | Pull() << 8;
        }
    }
}