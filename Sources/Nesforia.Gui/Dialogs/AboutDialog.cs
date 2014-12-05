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

using Eto.Drawing;
using Eto.Forms;
using Nesforia.Gui.Resources;

namespace Nesforia.Gui.Dialogs
{
    internal class AboutDialog : Dialog
    {
        public AboutDialog()
        {
            Title = Text.Nesforia;

            var layout = new TableLayout
            {
                Padding = new Padding(10, 10),
                Spacing = new Size(5, 5),
                Rows =
                {
                    new TableRow(
                        new ImageView { Image = AppImages.AboutImage },
                        new TableLayout(
                            new Label { Text = Text.Nesforia, Font = new Font(SystemFont.Bold) }, 
                            new Label { Text = Text.NesforiaDescription }
                            )
                        ),
                },
            };
            
            var button = new Button { Text = Text.Ok };
            button.Click += (sender, args) => Close();
            AbortButton = DefaultButton = button;

            layout.Rows.Add(new TableRow(null, button));

            Content = layout;
        }
    }
}