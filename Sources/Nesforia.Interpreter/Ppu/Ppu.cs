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
using Nesforia.Core.IO;
using Nesforia.Core.Memory;
using Nesforia.Core.Ppu;

namespace Nesforia.Interpreter.Ppu
{
    public class Ppu : IPpu
    {
        private readonly IMemory _vram;
        private readonly IGraphicsDevice _graphicsDevice;

        private TvSystem _tvSystem;
        private int _vblStart;
        private int _vblEnd;

        private int _scanLinesCounter;
        
        private bool _isVblank;
        private bool _isSprite0Hit;
        private bool _isSpriteOverflow;

        private bool _nmiEnabled;
        private int _vramAddressIncrement;
        private int _baseNametableAddress;
        private int _sprite8X8PatternTableAddress;
        private int _backgroundPatternTableAddress;
        private bool _isBigSprite;

        private bool _isGrayscale;
        private bool _isBackgroundClipped;
        private bool _isSpriteClipped;
        private bool _showBackground;
        private bool _showSprites;
        private int _emphasis;

        private int _oamAddress;
        private byte[] _oam = new byte[0x100];

        private bool _vramFlipFlop;

        private int _vramAddress;

        /// <summary>
        /// Initialize NES PPU with given VRam and GraphicsDevice
        /// </summary>
        /// <param name="graphicsDevice">Graphics device, used to output resulting image</param>
        /// <param name="vram">NES VRAM implementation</param>
        public Ppu(IGraphicsDevice graphicsDevice, IMemory vram)
        {
            _graphicsDevice = graphicsDevice;
            _vram = vram;
        }

        public void Clock()
        {
            throw new System.NotImplementedException();
        }

        public void SetTvSystem(TvSystem tvSystem)
        {
            _tvSystem = tvSystem;

            switch (_tvSystem)
            {
                case TvSystem.Ntsc:
                    _vblStart = 241;
                    _vblEnd = 261;
                    break;
                case TvSystem.Pal:

                    break;
                case TvSystem.DualCompatible:

                    break;
                default:
                    throw new ArgumentOutOfRangeException("tvSystem", "Unsupported TV Sytem");
            }
        }

        public byte Read2002()
        {
            byte value = 0;

            if (_isSprite0Hit)
            {
                value |= 0x40;
            }

            if (_isVblank)
            {
                value |= 0x80;
            }

            if (_isSpriteOverflow)
            {
                value |= 0x20;
            }

            // this flags should be cleared after reading from 2002
            _vramFlipFlop = false;
            _isVblank = false;

            return value;
        }

        public byte Read2004()
        {
            throw new System.NotImplementedException();
        }

        public byte Read2007()
        {
            throw new System.NotImplementedException();
        }

        public void Write2000(byte value)
        {
            _baseNametableAddress = 0x2000 + 0x400 * (value & 0x03);
            _vramAddressIncrement = (value & 0x04) != 0 ? 32 : 1;
            _sprite8X8PatternTableAddress = (value & 0x08) != 0 ? 0x1000 : 0;
            _backgroundPatternTableAddress = (value & 0x10) != 0 ? 0x1000 : 0;
            _isBigSprite = (value & 0x20) != 0;
            _nmiEnabled = (value & 0x80) != 0;
        }

        public void Write2001(byte value)
        {
            _isGrayscale = (value & 0x01) != 0;
            _isBackgroundClipped = (value & 0x02) == 0;
            _isSpriteClipped = (value & 0x04) == 0;
            _showBackground = (value & 0x08) != 0;
            _showSprites = (value & 0x10) != 0;
            _emphasis = (value & 0xE0) << 1;
        }

        public void Write2003(byte value)
        {
            _oamAddress = value;
        }

        public void Write2004(byte value)
        {
            // todo: check, if rendering is run to emulate glitchy increment of OAMADDR register
            //if ()
            //{
                
            //}
            _oam[_oamAddress++] = value;
        }

        public void Write2005(byte value)
        {
            if (_vramFlipFlop)
            {
                
            }
            else
            {
                
            }

            _vramFlipFlop = !_vramFlipFlop;
        }

        public void Write2006(byte value)
        {
            if (_vramFlipFlop)
            {
                _vramAddress = value << 8;
            }
            else
            {
                _vramAddress |= value;
            }

            _vramFlipFlop = !_vramFlipFlop;
        }

        public void Write2007(byte value)
        {
            _vram.Write(_vramAddress, value);
            _vramAddress = (_vramAddress + _vramAddressIncrement) & 0xFFFF;
        }
    }
}