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
using Eto.Drawing;
using Eto.Forms;
using Nesforia.Core;
using Nesforia.Gui.Commands;

namespace Nesforia.Gui.Forms
{
    public sealed class MainForm : Form
    {
        private Nes _nesEmu;
        
        public MainForm()
        {
            Title = Resources.Text.Nesforia;

            ClientSize = new Size(320, 240);

            CreateMenu();
        }

        private void CreateMenu()
        {
            var menu = new MenuBar();
            Application.Instance.CreateStandardMenu(menu.Items);

            var fileMenu = menu.Items.GetSubmenu(Resources.Text.FileMenu, 100);
            fileMenu.Items.Add(new OpenRomCommand(_nesEmu));

            var nesMenu = menu.Items.GetSubmenu(Resources.Text.NesMenu, 200);
            
            var helpMenu = menu.Items.GetSubmenu(Resources.Text.HelpMenu, 1000);

            if (Generator.IsMac)
            {
                // OS X style menu
                var main = menu.Items.GetSubmenu(Application.Instance.Name, 0);
                main.Items.Add(new AboutCommand(), 0);
                main.Items.Add(new QuitCommand(), 1000);
            }
            else
            {
                // windows/gtk style window
                fileMenu.Items.Add(new SeparatorMenuItem());
                fileMenu.Items.Add(new QuitCommand());
                helpMenu.Items.Add(new AboutCommand());
            }


            Menu = menu;
        }
    }
}