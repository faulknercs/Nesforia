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
using Nesforia.Core.Boards;
using Nesforia.Core.Loaders;

namespace Nesforia.Interpreter.Boards
{
    /// <summary>
    /// Represents NROM Nes cartridge board
    /// </summary>
    public class NRomBoard : ICartridge
    {
        private readonly byte[] _prgRom = new byte[0x8000];
        private byte[] _chrRom = new byte[0x2000];

        public NRomBoard(RomData romData)
        {
            _prgRom = romData.PrgRomDump;
            _chrRom = romData.ChrRomDump;

        }
        
        public bool HasSaveRam { get; private set; }
        public bool HasTrainer { get; private set; }
        
        public byte ReadPrg(int address)
        {
            return _prgRom[address - 0x8000];
        }

        public byte ReadExpansion(int address)
        {
            throw new InvalidOperationException();
        }

        public byte ReadSram(int address)
        {
            throw new InvalidOperationException();
        }

        public byte ReadChr(int address)
        {
            throw new System.NotImplementedException();
        }

        public void WritePrg(int address, byte value)
        {
            throw new InvalidOperationException();
        }

        public void WriteExpansion(int address, byte value)
        {
            throw new InvalidOperationException();
        }

        public void WriteSram(int address, byte value)
        {
            throw new InvalidOperationException();
        }

        public void WriteChr(int address, byte value)
        {
            throw new InvalidOperationException();
        }
    }
}