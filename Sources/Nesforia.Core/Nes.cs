﻿#region License
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
using Nesforia.Core.Boards;
using Nesforia.Core.Cpu;
using Nesforia.Core.IO;
using Nesforia.Core.Memory;
using Nesforia.Core.Ppu;

namespace Nesforia.Core
{
    /// <summary>
    /// NES Emulator
    /// </summary>
    public sealed class Nes
    {
        private readonly IGraphicsDevice _graphicsDevice;
        private readonly IInputDevice _inputDevice;
        private readonly IAudioDevice _audioDevice;

        private readonly ICpu _cpu;
        private readonly IPpu _ppu;

        private readonly IMemory _ram;
        private readonly IMemory _vram;

        private ICartridge _cartridge;
        
        public Nes(IGraphicsDevice graphicsDevice, IInputDevice inputDevice, IAudioDevice audioDevice)
        {
            _graphicsDevice = graphicsDevice;
            _inputDevice = inputDevice;
            _audioDevice = audioDevice;

            Initialization();
        }

        public bool IsRun { get; private set; }

        /// <summary>
        /// Load cartridge to emulator
        /// </summary>
        /// <param name="cartridge">NES cartridge</param>
        public void InsertCartridge(ICartridge cartridge)
        {
            _cartridge = cartridge;

            //_ram.Reset();
            _ram.Map(0x4021, 0x5FFF, cartridge.ReadExpansion, cartridge.WriteExpansion);
            _ram.Map(0x6000, 0x7FFF, cartridge.ReadSram, cartridge.WriteSram);
            _ram.Map(0x8000, 0xFFFF, cartridge.ReadPrg, cartridge.WritePrg);

            _vram.Map(0x0000, 0x2000, cartridge.ReadChr, cartridge.WriteChr);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Run emulation of NES
        /// </summary>
        public void Run()
        {
            while (IsRun)
            {
                _cpu.Execute();

                _ppu.Clock();
            }

            throw new NotImplementedException();
        }

        /// <summary>
        /// Toggle pause of emulation
        /// </summary>
        public void TogglePause()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Makes soft reset of system. Equivalent of pressing Reset button on console
        /// </summary>
        public void SoftReset()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Makes hard reset of system. Equivalent of turnig off and on of console
        /// </summary>
        public void HardReset()
        {
            throw new NotImplementedException();
        }

        private void Initialization()
        {
            _ram.Map(0x2000, null, _ppu.Write2000);
            _ram.Map(0x2001, null, _ppu.Write2001);
            _ram.Map(0x2002, _ppu.Read2002, null);
        }
    }
}