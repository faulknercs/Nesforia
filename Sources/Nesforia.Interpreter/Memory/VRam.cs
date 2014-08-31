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

namespace Nesforia.Interpreter.Memory
{
    /// <summary>
    /// Represents NES VRAM
    /// </summary>
    public class VRam : RamBase
    {
        private byte[] _vram = new byte[0x800];
        private readonly byte[] _palletes = new byte[0x20];

        /// <summary>
        /// Initialize new VRAM instance
        /// </summary>
        public VRam()
        {
            Map(0x2000, 0x27FF, ReadVRam, WriteVRam);
            Map(0x3F00, 0x3F1F, ReadPallete, WritePallete);
        }

        private void WritePallete(int address, byte value)
        {
            _palletes[(address & 0x3F1F) - 0x3F00] = value;
        }

        private byte ReadPallete(int address)
        {
            return _palletes[(address & 0x3F1F) - 0x3F00];
        }

        private void WriteVRam(int address, byte value)
        {
            throw new NotImplementedException();
        }

        private byte ReadVRam(int address)
        {
            throw new NotImplementedException();
        }

        public override byte Read(int address)
        {
            return base.Read(PrepareAddress(address));
        }

        public override void Write(int address, byte value)
        {
            base.Write(PrepareAddress(address), value);
        }

        private static int PrepareAddress(int address)
        {
            return address & 0x3FFF;
        }
    }
}