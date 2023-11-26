using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace auto_reply3
{
    public partial class AutoReplyForm : Form
    {
        public AutoReplyForm()
        {
            InitializeComponent();
            this.Load += AutoReplyForm_Load;           // Subscribe to Load event
            this.FormClosing += AutoReplyForm_FormClosing; // Subscribe to FormClosing event
  
        }
        private void AutoReplyForm_Load(object sender, EventArgs e)
        {
            // Load and deserialize the TreeView structure from settings
            DeserializeTreeView(Properties.Settings.Default.TreeData, treeView1);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode node = new TreeNode(textBox1.Text);
                treeView1.Nodes.Add(node);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding a node: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
              
             try
            {
                if (treeView1.SelectedNode != null)
                {
                    TreeNode node = new TreeNode(textBox1.Text);
                    treeView1.SelectedNode.Nodes.Add(node);
                }
                else
                {
                    MessageBox.Show("Please select a node to add a subnode.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding a subnode: " + ex.Message);
            }
 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView1.SelectedNode != null)
                {
                    treeView1.SelectedNode.Text = textBox1.Text;
                }
                else
                {
                    MessageBox.Show("Please select a node to edit.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while editing a node: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView1.SelectedNode != null)
                {
                    var nodeToRemove = treeView1.SelectedNode;
                    treeView1.Nodes.Remove(nodeToRemove); // Remove the selected node
                                        
                }
                else
                {
                    MessageBox.Show("Please select a node to delete.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while deleting a node: " + ex.Message);
            }
        }

        private void AutoReplyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Serialize and save the TreeView structure to settings
            Properties.Settings.Default.TreeData = SerializeTreeView(treeView1);
            Properties.Settings.Default.Save();
        }

        private string SerializeTreeView(TreeView treeView)
        {
            // Implementation of your serialization logic
            StringBuilder sb = new StringBuilder();
            foreach (TreeNode node in treeView.Nodes)
            {
                SerializeTreeNode(node, sb, 0);
            }
            return sb.ToString();
        }

        private void SerializeTreeNode(TreeNode node, StringBuilder sb, int level)
        {
            sb.AppendLine(string.Format("{0}{1}", new string('-', level), node.Text));
            foreach (TreeNode childNode in node.Nodes)
            {
                SerializeTreeNode(childNode, sb, level + 1);
            }
        }

        private void DeserializeTreeView(string treeData, TreeView treeView)
        {
            if (string.IsNullOrEmpty(treeData)) return;

            string[] lines = treeData.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            TreeNode lastNode = null;
            int lastLevel = -1;

            foreach (string line in lines)
            {
                int level = line.TakeWhile(c => c == '-').Count();
                string text = line.Substring(level);

                if (lastNode == null || level == 0)
                {
                    lastNode = treeView.Nodes.Add(text);
                    lastLevel = 0;
                }
                else
                {
                    if (level > lastLevel)
                    {
                        lastNode = lastNode.Nodes.Add(text);
                    }
                    else if (level == lastLevel)
                    {
                        lastNode = lastNode.Parent.Nodes.Add(text);
                    }
                    else
                    {
                        while (lastLevel > level && lastNode.Parent != null)
                        {
                            lastNode = lastNode.Parent;
                            lastLevel--;
                        }
                        lastNode = lastNode.Parent.Nodes.Add(text);
                    }
                    lastLevel = level;
                }
            }
        }

    }

}
