using Eto.Drawing;
using Eto.Forms;
using System;
using Eliza.Core;
using Eliza.UI;
using Eliza.UI.Forms;

namespace Eliza
{
    public partial class MainForm : Form
    {
        private Model.SaveData.SaveData _saveData;
        private string _path;

        public MainForm()
        {
            Title = "Eliza";
            MinimumSize = new Size(200, 200);

            var headerButton = new Button { Text = "Header" };
            headerButton.Enabled = false;
            headerButton.Click += HeaderButton_Click;

            var data = new Button { Text = "Data" };
            data.Enabled = false;
            data.Click += DataButton_Click;

            var footer = new Button { Text = "Footer" };
            footer.Enabled = false;
            footer.Click += FooterButton_Click;

            var layout = new StackLayout { Orientation = Orientation.Vertical, HorizontalContentAlignment = HorizontalAlignment.Center, Spacing = 5, Padding = new Padding(10) };

            StackLayoutItem[] stackLayoutItems =
            {
                headerButton,
                data,
                footer
            };

            foreach (var item in stackLayoutItems)
            {
                layout.Items.Add(item);
            }

            //Need this, so it doesn't an error of no instance
            Content = layout;
            
            var openMenuButton = new Command { MenuText = "Open", Shortcut = Keys.Control | Keys.O };
            openMenuButton.Executed += (sender, e) => OpenMenuButton_Executed(sender, e);

            var saveMenuButton = new Command { MenuText = "Save", Shortcut = Keys.Control | Keys.S };
            saveMenuButton.Executed += SaveMenuButton_Executed;

            Menu = new MenuBar
            {
                Items =
                {
					// File submenu
					new SubMenuItem 
                    { 
                        Text = "&File", Items = 
                        { 
                            openMenuButton,
                            saveMenuButton
                        } 
                    },
				},
            };

            void OpenMenuButton_Executed(object sender, EventArgs e)
            {
                using (var openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filters.Add(
                        new FileFilter("All Files", ".*")
                    );

                    if (openFileDialog.ShowDialog(Parent) == DialogResult.Ok)
                    {
                        _path = openFileDialog.FileName;

                        try
                        {
                            _saveData = Model.SaveData.SaveData.Read(_path);
                        }
                        catch
                        {
                            MessageBox.Show("Error: Incompatible/invalid save file found. Please report the issue on Github.");
                        }
                        
                        headerButton.Enabled = true;
                        data.Enabled = true;
                        footer.Enabled = true;
                    }
                }
            }

            void SaveMenuButton_Executed(object sender, EventArgs e)
            {
                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filters.Add(
                        new FileFilter("All Files", ".*")
                    );

                    if (saveFileDialog.ShowDialog(Parent) == DialogResult.Ok)
                    {
                        var path = saveFileDialog.FileName;
                        Model.SaveData.SaveData.Write(path, _saveData);
                    }
                }
            }

            void HeaderButton_Click(object sender, EventArgs e)
            {
                var headerForm = new HeaderForm(_saveData);
                headerForm.Show();
            }

            void DataButton_Click(object sender, EventArgs e)
            {
                var dataForm = new DataForm(_saveData);
                dataForm.Show();
            }


            void FooterButton_Click(object sender, EventArgs e)
            {
                throw new NotImplementedException();
            }
        }
    }
}
