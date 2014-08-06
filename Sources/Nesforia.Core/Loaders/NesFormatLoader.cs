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
using System.IO;
using Nesforia.Core.Exceptions;
using Nesforia.Core.Memory;
using Nesforia.Core.Ppu;

namespace Nesforia.Core.Loaders
{
    public class NesFormatLoader : IRomLoader
    {
        public RomData LoadCartridge(BinaryReader reader)
        {
            var romData = new RomData();

            var header = reader.ReadBytes(16);

            // 0-3 bytes of iNES rom should be equal to "0x4e 0x45 0x53 0x1a" (or "NES^Z" in DOS encoding)
            if (header[0] != 0x4e &&
                header[1] != 0x45 &&
                header[2] != 0x53 &&
                header[3] != 0x1a)
            {
                throw new CannotOpenRomException("Not a NES Rom");
            }

            int prgRomSize = header[4];
            int chrRomSize = header[5];

            bool hasTrainer = (header[6] & 0x04) != 0;
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
            mapperNo |= header[7] & 0xf0;

            bool isInes2 = (header[7] & 0xc) == 0x0c;
            romData.IsPlaychoice = (header[7] & 0x02) != 0;
            romData.IsVsUnisystem = (header[7] & 0x01) != 0;

            // todo: finish INES 2 support
            if (isInes2)
            {
                //_subMapper = header[8] >> 4;
                // Bits 11-8 of mapper number.
                mapperNo |= (header[8] & 0x0f) << 8;

                chrRomSize |= (header[9] & 0xf0) << 4;
                prgRomSize |= (header[9] & 0x0f) << 8;

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

            for (int i = 0; i < prgRomSize; i++)
            {
                
            }

            for (int i = 0; i < chrRomSize; i++)
            {
                
            }

            return romData;
        }

        private void ReadFlags6(byte flags)
        {
        //    _hasSram = (flags & 0x02) != 0;
        //    _fourScreenModeEnabled = (flags & 0x08) != 0;
        }
    }
}