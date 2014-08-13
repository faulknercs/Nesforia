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
        /// <summary>
        /// Initialize handlers for MOS6502 opcodes
        /// </summary>
        private void InitializeOpcodesHandlers()
        {
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

                SetZeroAndNegative((byte)temp);

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
                SetZeroAndNegative(_registers.A);
            };

            _handlers[Opcode.Asl0A] = () =>
            {
                _registers.C = (_registers.A & 0x80) != 0;
                _registers.A <<= 1;
                SetZeroAndNegative(_registers.A);
            };

            _handlers[Opcode.Asl06] =
            _handlers[Opcode.Asl0E] =
            _handlers[Opcode.Asl16] =
            _handlers[Opcode.Asl1E] = () =>
            {
                _registers.C = (_mValue & 0x80) != 0;

                _mValue <<= 1;

                SetZeroAndNegative(_mValue);

                _ram.Write(_effectiveAddress, _mValue);
            };

            _handlers[Opcode.Bcc] = () =>
            {
                if (!_registers.C)
                    Branch();
            };

            _handlers[Opcode.Bcs] = () =>
            {
                if (_registers.C)
                    Branch();
            };

            _handlers[Opcode.Beq] = () =>
            {
                if (_registers.Z)
                    Branch();
            };

            _handlers[Opcode.Bit24] =
            _handlers[Opcode.Bit2C] = () =>
            {
                _registers.Z = (_registers.A & _mValue) == 0;
                _registers.N = (_mValue & 0x80) != 0;
                _registers.V = (_mValue & 0x40) != 0;
            };

            _handlers[Opcode.Bmi] = () =>
            {
                if (_registers.N)
                    Branch();
            };

            _handlers[Opcode.Bne] = () =>
            {
                if (!_registers.Z)
                    Branch();
            };

            _handlers[Opcode.Bpl] = () =>
            {
                if (!_registers.N)
                    Branch();
            };

            _handlers[Opcode.Brk] = () =>
            {
                _registers.B = true;
                Push16(_registers.PC);
                Push(_registers.PS);

                _registers.PC = MakeFullAddress(_ram.Read(0xFFFE), _ram.Read(0xFFFF));
            };

            _handlers[Opcode.Bvc] = () =>
            {
                if (!_registers.V)
                    Branch();
            };

            _handlers[Opcode.Bvs] = () =>
            {
                if (_registers.V)
                    Branch();
            };

            _handlers[Opcode.Clc] = () => _registers.C = false;

            _handlers[Opcode.Cld] = () => _registers.D = false;

            _handlers[Opcode.Cli] = () => _registers.I = false;

            _handlers[Opcode.Clv] = () => _registers.V = false;

            _handlers[Opcode.CmpC1] =
            _handlers[Opcode.CmpC5] =
            _handlers[Opcode.CmpC9] =
            _handlers[Opcode.CmpCd] =
            _handlers[Opcode.CmpD1] =
            _handlers[Opcode.CmpD5] =
            _handlers[Opcode.CmpD9] =
            _handlers[Opcode.CmpDd] = () =>
            {
                int temp = _registers.A - _mValue;
                SetZeroAndNegative((byte)temp);
                _registers.C = (_registers.A >= _mValue);
            };

            _handlers[Opcode.CpxE0] =
            _handlers[Opcode.CpxE4] =
            _handlers[Opcode.CpxEc] = () =>
            {
                int temp = _registers.X - _mValue;
                SetZeroAndNegative((byte)temp);
                _registers.C = (_registers.X >= _mValue);
            };

            _handlers[Opcode.CpyC0] =
            _handlers[Opcode.CpyC4] =
            _handlers[Opcode.CpyCc] = () =>
            {
                int temp = _registers.Y - _mValue;
                SetZeroAndNegative((byte)temp);
                _registers.C = (_registers.Y >= _mValue);
            };

            _handlers[Opcode.DecC6] =
            _handlers[Opcode.DecCe] =
            _handlers[Opcode.DecD6] =
            _handlers[Opcode.DecDe] = () =>
            {
                _mValue--;
                SetZeroAndNegative(_mValue);

                _ram.Write(_effectiveAddress, _mValue);
            };

            _handlers[Opcode.Dex] = () =>
            {
                _registers.X--;
                SetZeroAndNegative(_registers.X);
            };

            _handlers[Opcode.Dey] = () =>
            {
                _registers.Y--;
                SetZeroAndNegative(_registers.Y);
            };

            _handlers[Opcode.Eor41] =
            _handlers[Opcode.Eor45] =
            _handlers[Opcode.Eor49] =
            _handlers[Opcode.Eor4D] =
            _handlers[Opcode.Eor51] =
            _handlers[Opcode.Eor55] =
            _handlers[Opcode.Eor59] =
            _handlers[Opcode.Eor5D] = () =>
            {
                _registers.A ^= _mValue;
                SetZeroAndNegative(_registers.A);
            };

            _handlers[Opcode.IncE6] =
            _handlers[Opcode.IncEe] =
            _handlers[Opcode.IncF6] =
            _handlers[Opcode.IncFe] = () =>
            {
                _mValue++;
                SetZeroAndNegative(_mValue);

                _ram.Write(_effectiveAddress, _mValue);
            };

            _handlers[Opcode.Inx] = () =>
            {
                _registers.X++;
                SetZeroAndNegative(_registers.X);
            };

            _handlers[Opcode.Iny] = () =>
            {
                _registers.Y++;
                SetZeroAndNegative(_registers.Y);
            };

            _handlers[Opcode.Jmp4C] = () => _registers.PC = _effectiveAddress;

            _handlers[Opcode.Jmp6C] = () =>
            {
                // emulate buggy behavior of indirect jmp, when vector falls on a page boundary 
                _registers.PC = MakeFullAddress(_ram.Read(_effectiveAddress), 
                    (_effectiveAddress & 0xFF) == 0xFF ? _ram.Read(_effectiveAddress & 0xFF00) : _ram.Read(_effectiveAddress + 1));
            };

            _handlers[Opcode.Jsr] = () =>
            {
                Push16(_registers.PC + 2);
                _registers.PC = _effectiveAddress;
            };

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
                SetZeroAndNegative(_registers.A);
            };

            _handlers[Opcode.LdxA2] =
            _handlers[Opcode.LdxA6] =
            _handlers[Opcode.LdxAe] =
            _handlers[Opcode.LdxB6] =
            _handlers[Opcode.LdxBe] = () =>
            {
                _registers.X = _mValue;
                SetZeroAndNegative(_registers.X);
            };

            _handlers[Opcode.LdyA0] =
            _handlers[Opcode.LdyA4] =
            _handlers[Opcode.LdyAc] =
            _handlers[Opcode.LdyB4] =
            _handlers[Opcode.LdyBc] = () =>
            {
                _registers.Y = _mValue;
                SetZeroAndNegative(_registers.Y);
            };

            _handlers[Opcode.Nop] = () => { };

            _handlers[Opcode.Lsr4A] = () =>
            {
                _registers.C = (_registers.A & 0x01) != 0;
                _registers.A >>= 1;
                SetZeroAndNegative(_registers.A);
            };

            _handlers[Opcode.Lsr46] =
            _handlers[Opcode.Lsr4E] =
            _handlers[Opcode.Lsr56] =
            _handlers[Opcode.Lsr5E] = () =>
            {
                _registers.C = (_mValue & 0x01) != 0;

                _mValue >>= 1;

                SetZeroAndNegative(_mValue);

                _ram.Write(_effectiveAddress, _mValue);
            };

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
                SetZeroAndNegative(_registers.A);
            };

            _handlers[Opcode.Pha] = () => Push(_registers.A);

            _handlers[Opcode.Php] = () => Push(_registers.PS);

            _handlers[Opcode.Pla] = () => _registers.A = Pull();

            _handlers[Opcode.Plp] = () => _registers.PS = Pull();

            _handlers[Opcode.Rol2A] = () =>
            {
                var temp = (byte)(_registers.A << 1 | (_registers.C ? 1 : 0));

                _registers.C = (_registers.A & 0x80) != 0;
                SetZeroAndNegative(temp);

                _registers.A = temp;
            };

            _handlers[Opcode.Rol26] =
            _handlers[Opcode.Rol2E] =
            _handlers[Opcode.Rol36] =
            _handlers[Opcode.Rol3E] = () =>
            {
                var temp = (byte)(_mValue << 1 | (_registers.C ? 1 : 0));
                
                _registers.C = (_mValue & 0x80) != 0;
                SetZeroAndNegative(temp);

                _ram.Write(_effectiveAddress, temp);
            };

            _handlers[Opcode.Ror6A] = () =>
            {
                var temp = (byte)(_registers.A >> 1 | (_registers.C ? 0x80 : 0));

                _registers.C = (_registers.A & 0x01) != 0;
                SetZeroAndNegative(temp);

                _ram.Write(_effectiveAddress, temp);
            };

            _handlers[Opcode.Ror66] =
            _handlers[Opcode.Ror6E] =
            _handlers[Opcode.Ror76] =
            _handlers[Opcode.Ror7E] = () =>
            {
                var temp = (byte)(_mValue >> 1 | (_registers.C ? 0x80 : 0));

                _registers.C = (_mValue & 0x01) != 0;
                SetZeroAndNegative(temp);

                _registers.A = temp;
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

            _handlers[Opcode.SbcE1] =
            _handlers[Opcode.SbcE5] =
            _handlers[Opcode.SbcE9] =
            _handlers[Opcode.SbcEd] =
            _handlers[Opcode.SbcF1] =
            _handlers[Opcode.SbcF5] =
            _handlers[Opcode.SbcF9] =
            _handlers[Opcode.SbcFd] = () =>
            {
                int temp = _registers.A - _mValue - (_registers.C ? 0 : 1);

                SetZeroAndNegative((byte)temp);
                _registers.C = (temp >> 8) != 0;
                _registers.V = ((temp ^ _registers.A) & (temp ^ _mValue) & 0x80) != 0;

                _registers.A = (byte) (temp & 0xFF);
            };

            _handlers[Opcode.Sec] = () => _registers.C = true;

            _handlers[Opcode.Sed] = () => _registers.D = true;

            _handlers[Opcode.Sei] = () => _registers.I = true;

            _handlers[Opcode.Sta81] = 
            _handlers[Opcode.Sta85] = 
            _handlers[Opcode.Sta8D] = 
            _handlers[Opcode.Sta91] = 
            _handlers[Opcode.Sta95] = 
            _handlers[Opcode.Sta99] = 
            _handlers[Opcode.Sta9D] = () => _ram.Write(_effectiveAddress, _registers.A);

            _handlers[Opcode.Stx86] = 
            _handlers[Opcode.Stx8E] = 
            _handlers[Opcode.Stx96] = () => _ram.Write(_effectiveAddress, _registers.X);

            _handlers[Opcode.Sty84] = 
            _handlers[Opcode.Sty8C] = 
            _handlers[Opcode.Sty94] = () => _ram.Write(_effectiveAddress, _registers.Y);

            _handlers[Opcode.Tax] = () =>
            {
                _registers.X = _registers.A;
                SetZeroAndNegative(_registers.X);
            };

            _handlers[Opcode.Tay] = () =>
            {
                _registers.Y = _registers.A;
                SetZeroAndNegative(_registers.Y);
            };

            _handlers[Opcode.Tsx] = () =>
            {
                _registers.X = _registers.S;
                SetZeroAndNegative(_registers.X);
            };

            _handlers[Opcode.Txa] = () =>
            {
                _registers.A = _registers.X;
                SetZeroAndNegative(_registers.A);
            };

            _handlers[Opcode.Txs] = () =>
            {
                _registers.S = _registers.X;
                SetZeroAndNegative(_registers.S);
            };

            _handlers[Opcode.Tya] = () =>
            {
                _registers.A = _registers.Y;
                SetZeroAndNegative(_registers.A);
            };
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

        /// <summary>
        /// Provides branching to new location, changes PC register
        /// </summary>
        private void Branch()
        {
            _registers.PC += (sbyte)_mValue;
        }

        /// <summary>
        /// Sets Zero flag, if <paramref name="value"/> is zero and sets Negative flag, if highest bit of <paramref name="value"/> is set
        /// </summary>
        /// <param name="value">Value for checking</param>
        private void SetZeroAndNegative(byte value)
        {
            _registers.Z = value == 0;
            _registers.N = (value & 0x80) != 0;
        }
    }
}