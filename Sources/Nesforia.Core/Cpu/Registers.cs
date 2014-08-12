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
namespace Nesforia.Core.Cpu
{
    /// <summary>
    /// Represents registers of MOS6502 processor
    /// </summary>
    public struct Registers
    {
        /// <summary>
        /// Accumulator register
        /// </summary>
        public byte A;

        /// <summary>
        /// Index Register X
        /// </summary>
        public byte X;

        /// <summary>
        /// Index Register Y
        /// </summary>
        public byte Y;

        /// <summary>
        /// Stack Pointer
        /// </summary>
        public byte S;

        /// <summary>
        /// Program Counter
        /// </summary>
        public int PC;

        /// <summary>
        /// Processor Status (Flags)
        /// </summary>
        public byte PS;

        /// <summary>
        /// Carry Flag
        /// </summary>
        public bool C
        {
            get { return (PS & 0x01) != 0; }
            set { PS = (byte)(value ? PS | 0x01 : PS & ~0x01); }
        }

        /// <summary>
        /// Zero Flag
        /// </summary>
        public bool Z
        {
            get { return (PS & 0x02) != 0; }
            set { PS = (byte)(value ? PS | 0x02 : PS & ~0x02); }
        }

        /// <summary>
        /// Interrupt Disable Flag
        /// </summary>
        public bool I
        {
            get { return (PS & 0x04) != 0; }
            set { PS = (byte)(value ? PS | 0x04 : PS & ~0x04); }
        }

        /// <summary>
        /// Decimal Mode Flag
        /// </summary>
        public bool D
        {
            get { return (PS & 0x08) != 0; }
            set { PS = (byte)(value ? PS | 0x08 : PS & ~0x08); }
        }

        /// <summary>
        /// Break Command Flag
        /// </summary>
        public bool B
        {
            get { return (PS & 0x10) != 0; }
            set { PS = (byte)(value ? PS | 0x10 : PS & ~0x10); }
        }

        /// <summary>
        /// Overflow Flag
        /// </summary>
        public bool V
        {
            get { return (PS & 0x40) != 0; }
            set { PS = (byte)(value ? PS | 0x40 : PS & ~0x40); }
        }

        /// <summary>
        /// Negative Flag
        /// </summary>
        public bool N
        {
            get { return (PS & 0x80) != 0; }
            set { PS = (byte)(value ? PS | 0x80 : PS & ~0x80); }
        }
    }
}