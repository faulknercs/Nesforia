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
using System.IO;
using Nesforia.Core.Exceptions;
using Nesforia.Core.Memory;
using Nesforia.Core.Ppu;

namespace Nesforia.Core.Loaders
{
    /// <summary>
    /// Loader for iNES format. 
    /// </summary>
    public class NesFormatLoader : IRomLoader
    {
        /// <summary>
        /// Loads rom from iNES file, wrapped into binary reader.
        /// </summary>
        /// <param name="reader">Binary reader, wrapped over data stream</param>
        /// <returns>Content of NES rom in <see cref="RomData"/> structure</returns>
        /// <exception cref="BadRomException">Throws, when iNES rom has corrupted header</exception>
        public RomData LoadRom(BinaryReader reader)
        {
            var romData = new RomData();

            var header = reader.ReadBytes(16);

            // 0-3 bytes of iNES rom should be equal to "0x4e 0x45 0x53 0x1a" (or "NES^Z" in DOS encoding)
            if (header[0] != 0x4E &&
                header[1] != 0x45 &&
                header[2] != 0x53 &&
                header[3] != 0x1A)
            {
                throw new BadRomException("Not a iNES Rom");
            }

            int prgRomSize = header[4];
            int chrRomSize = header[5];

            bool hasTrainer = (header[6] & 0x04) != 0;
            //hasSram = (flags & 0x02) != 0;
            switch (header[6] & 0x09)
            {
                case 0x00:
                    romData.Mirroring = Mirroring.Horizontal;
                    break;
                case 0x01:
                    romData.Mirroring = Mirroring.Vertical;
                    break;
                case 0x08:
                case 0x09:
                    romData.Mirroring = Mirroring.FourScreen;
                    break;
            }


            //Lower 4 bits of the mapper number
            int mapperNo = header[6] >> 4;
            //Upper 4 bits of the mapper number
            mapperNo |= header[7] & 0xF0;

            bool isInes2 = (header[7] & 0xC) == 0x0C;
            romData.IsPlaychoice = (header[7] & 0x02) != 0;
            romData.IsVsUnisystem = (header[7] & 0x01) != 0;

            // todo: finish INES 2 support
            if (isInes2)
            {
                //_subMapper = header[8] >> 4;
                // Bits 11-8 of mapper number.
                mapperNo |= (header[8] & 0x0F) << 8;

                chrRomSize |= (header[9] & 0xF0) << 4;
                prgRomSize |= (header[9] & 0x0F) << 8;

                romData.TvSystem = (header[12] & 0x01) != 0 ? TvSystem.Pal : TvSystem.Ntsc;
                if ((header[12] & 0x02) != 0)
                {
                    romData.TvSystem = TvSystem.DualCompatible;
                }

                //_prgRamSize = header[10] & 0x0f;
                //_battaryBackedPrgRamSize = header[10] >> 4;

                //_prgChrSize = header[11] & 0x0f;
                //_battaryBackedChrRamSize = header[11] >> 4;
            }
            else
            {
                romData.TvSystem = (header[9] & 1) == 1 ? TvSystem.Pal : TvSystem.Ntsc;
            }

            if (hasTrainer)
            {
                romData.TrainerDump = reader.ReadBytes(0x200);
            }

            romData.PrgRomDump = reader.ReadBytes(prgRomSize * 0x4000);
            romData.ChrRomDump = reader.ReadBytes(chrRomSize * 0x2000);

            return romData;
        }

        /// <summary>
        /// Name of supported format
        /// </summary>
        public String FormatName
        {
            get { return "iNES Format"; }
        }

        /// <summary>
        /// Array of supported file extensions of iNES format
        /// </summary>
        public String[] FileExtensions
        {
            get { return new[] { "nes" }; }
        }

        /// <summary>
        /// Header value, which marks supported format. For iNES it is "NES^Z" - null-terminated string (0x4E 0x45 0x53 0x15)
        /// </summary>
        public byte[] Header
        {
            get { return new byte[] { 0x4E, 0x45, 0x53, 0x15 }; }
        }
    }
}