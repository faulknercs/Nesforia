#region License
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
using System.Collections.Generic;
using System.IO;
using Eto.Forms;
using Nesforia.Core;
using Nesforia.Core.Loaders;

namespace Nesforia.Gui.Commands
{
    internal sealed class OpenRomCommand : Command
    {
        private readonly Nes _nesEmulator;
        private readonly ILoaderProvider _loaderProvider;

        public OpenRomCommand(Nes nesEmulator, ILoaderProvider loaderProvider)
        {
            _nesEmulator = nesEmulator;
            _loaderProvider = loaderProvider;

            MenuText = Resources.Text.FileOpen;
            Shortcut = Application.Instance.CommonModifier | Keys.O;
        }

        public override void OnExecuted(EventArgs e)
        {
            base.OnExecuted(e);

            var dlg = new OpenFileDialog { Filters = CreateFilters(), Title = Resources.Text.OpenRomDlg };

            if (dlg.ShowDialog(Application.Instance.MainForm) == DialogResult.Ok)
            {
                using (var reader = new BinaryReader(File.OpenRead(dlg.FileName)))
                {
                    
                }
            }
        }

        private static IEnumerable<IFileDialogFilter> CreateFilters()
        {
            yield return new FileDialogFilter("iNES Format", "nes");
            yield return new FileDialogFilter("UNIF Format", "unf", "unif");
        }
    }
}