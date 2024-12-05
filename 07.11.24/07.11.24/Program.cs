using System;
using System.Windows.Forms;

namespace _07._11._24
{
    public class MainForm : Form
    {
        public MainForm()
        {
            var mainMenu = new MenuStrip();
            var menuItem1 = new ToolStripMenuItem("1");
            menuItem1.Click += MenuItem_Click;

            mainMenu.Items.Add(menuItem1);
            this.MainMenuStrip = mainMenu;
            this.Controls.Add(mainMenu);
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem clickedItem)
            {
                if (clickedItem.DropDownItems.Count == 0)
                {
                    var newChild = new ToolStripMenuItem((Int32.Parse(clickedItem.Text) + 1).ToString());
                    newChild.Click += MenuItem_Click;
                    clickedItem.DropDownItems.Add(newChild);
                }
            }
        }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}