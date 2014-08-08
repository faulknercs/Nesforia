﻿#region License
/****************************************************************************
* Nesforia - NES/Famicom emulator
*
* Copyright (C) 2014 Nesforia authors
*
* Authors: Artem Stepanyuk <faulknercs@yandex.ru>
*
* This file is part of Nesforia.
*
* This library is free software: you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published
* by the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This library is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
* GNU General Public License for more details.
*
* You should have received a copy of the GNU General Public License
* along with this library. If not, see <http://www.gnu.org/licenses/>.
*****************************************************************************/
#endregion
using System;
using Eto;
using Eto.Forms;
using Nesforia.Gui.Forms;

namespace Nesforia.Gui
{
    public class NesforiaApplication : Application
    {
        public NesforiaApplication(Generator generator) : base(generator) { }

        public override void OnInitialized(EventArgs e)
        {
            MainForm = new MainForm();

            base.OnInitialized(e);

            MainForm.Show();
        }
    }
}