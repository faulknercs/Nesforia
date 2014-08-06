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
            _handlers[Opcode.Brk] = () => { };

            _handlers[Opcode.Ora01] =
            _handlers[Opcode.Ora05] =
            _handlers[Opcode.Ora09] =
            _handlers[Opcode.Ora0D] =
            _handlers[Opcode.Ora11] =
            _handlers[Opcode.Ora15] =
            _handlers[Opcode.Ora19] =
            _handlers[Opcode.Ora1D] = () =>
                {
                    _registers.A |= _currentMemoryValue;
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
                    int temp = _registers.A + _currentMemoryValue + (_registers.C ? 1 : 0);

                    _registers.Z = (temp & 0xFF) == 0;
                    _registers.N = (temp & 0x80) != 0;
                    _registers.C = (temp >> 8) != 0;
                    _registers.V = (((temp ^ _registers.A) & (temp ^ _currentMemoryValue)) & 0x80) != 0;

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
                    _registers.A &= _currentMemoryValue;
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
                    _registers.A = _currentMemoryValue;
                    _registers.Z = _registers.A == 0;
                    _registers.N = (_registers.A & 0x80) != 0;
                };

            _handlers[Opcode.Sec] = () => _registers.C = true;

            _handlers[Opcode.Sed] = () => _registers.D = true;

            _handlers[Opcode.Sei] = () => _registers.I = true;
        }
    }
}