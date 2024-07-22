using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIE_Draw
{
    public partial class DrawElement : Form
    {
        public DrawElement()
        {
            InitializeComponent();
        }

        public GraphicElement Element { get; set; }
        public Type ElementType { get; set; }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            flowLayout.Controls.Clear();
            switch (comboBox1.SelectedItem)
            {
                case "Line":
                    Element = new LineElement();
                    ElementType = typeof(LineElement);
                    foreach (var prop in ElementType.GetProperties())
                    {
                        flowLayout.Controls.Add(BuildGroup(prop));
                    }
                    break;
                case "Text":
                    Element = new LableElement();
                    ElementType = typeof(LableElement);
                    foreach (var prop in ElementType.GetProperties())
                    {
                        flowLayout.Controls.Add(BuildGroup(prop));
                    }
                    break;
                default:
                    break;
            }
        }

        private GroupBox BuildGroup(PropertyInfo prop)
        {
            var group = new GroupBox();
            var textBox = new TextBox();
            group.Size = new Size(this.Width - 52, textBox.Height + 14);
            group.Text = prop.Name;
            group.Controls.Add(textBox);
            textBox.Location = new Point(2, 14);
            textBox.Width = group.Width - 6;
            return group;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var instance = ElementType.GetConstructor(new Type[0]).Invoke(null);

            foreach (var prop in ElementType.GetProperties())
            {
                foreach (GroupBox group in flowLayout.Controls)
                {
                    if (prop.Name == group.Text)
                    {
                        if (prop.PropertyType == typeof(string))
                        {
                            prop.SetValue(instance, group.Controls[0].Text);
                        }
                        if (prop.PropertyType == typeof(int))
                        {
                            prop.SetValue(instance, int.Parse(group.Controls[0].Text));
                        }
                        break;
                    }
                }
            }

            Element = (GraphicElement)instance;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
