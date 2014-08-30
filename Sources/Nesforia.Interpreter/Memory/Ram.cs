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

namespace Nesforia.Interpreter.Memory
{
    /// <summary>
    /// Represents NES system RAM (CPU Address space)
    /// </summary>
    public class Ram : RamBase
    {
        private readonly byte[] _systemRam = new byte[0x800];

        /// <summary>
        /// Creates new instance of RAM
        /// </summary>
        public Ram()
        {
            Map(0x0000, 0x1FFF, ReadSystemRam, WriteSystemRam);
        }

        /// <summary>
        /// Read byte from given address at system RAM, applies mirroring for RAM addresses and PPU registers addresses.
        /// </summary>
        /// <param name="address">16-bit address in memory (using int for CLS-compliance)</param>
        /// <returns>Value at <paramref name="address"/></returns>
        public override byte Read(int address)
        {
            return base.Read(PrepareAddress(address));
        }

        /// <summary>
        /// Write byte at given address at system RAM, applies mirroring for RAM addresses and PPU registers addresses.
        /// </summary>
        /// <param name="address">16-bit address in memory (using int for CLS-compliance)</param>
        /// <param name="value">Value for write</param>
        public override void Write(int address, byte value)
        {
            base.Write(PrepareAddress(address), value);
        }

        /// <summary>
        /// Provides writing to system ram
        /// </summary>
        /// <param name="address">Memory address</param>
        /// <param name="value">Value to write</param>
        private void WriteSystemRam(int address, byte value)
        {
            _systemRam[address] = value;
        }

        /// <summary>
        /// Provides reading from system ram
        /// </summary>
        /// <param name="address">Memory address</param>
        /// <returns>Value at given address</returns>
        private byte ReadSystemRam(int address)
        {
            return _systemRam[address];
        }

        /// <summary>
        /// Applies mirroring of 0x0000 - 0x07FF addresses to 0x0800 - 0x1FFF and mirroring of 0x2000 - 0x2007 to 0x2008 - 0x3FF8. Other addresses don't change.
        /// </summary>
        /// <param name="address">Original address</param>
        /// <returns>Address after applying mirroring</returns>
        private static int PrepareAddress(int address)
        {
            if (address < 0x2000)
            {
                return address & 0x07FF;
            }

            if (address < 0x4000)
            {
                return address & 0x2007;
            }

            return address;
        }
    }
}