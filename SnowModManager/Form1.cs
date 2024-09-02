using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace SnowModManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private BindingSource modList;
        private string modsPath;
        private string lastGamePath;

        private void LoadMods()
        {
            if (this.textBox1.Text == "")
            {

            }
            else
            {
                if (!Directory.Exists(this.textBox1.Text))
                {
                    MessageBox.Show("目录不存在, 请先选择游戏目录");
                    return;
                }
                modsPath = this.textBox1.Text;
                modsPath = Path.Join(modsPath, "data");
                modsPath = Path.Join(modsPath, "game");
                modsPath = Path.Join(modsPath, "Game");
                modsPath = Path.Join(modsPath, "Content");
                modsPath = Path.Join(modsPath, "Paks");
                modsPath = Path.Join(modsPath, "~mods");
                toolStripStatusLabel1.Text = modsPath;
                if (!Directory.Exists(modsPath))
                {
                    MessageBox.Show("mod目录不存在, 请先创建~mods目录");
                    return;
                }
                if (this.modList == null)
                {
                    this.modList = new BindingSource();
                    this.modList.Clear();
                }
                else
                {
                    this.modList.Clear();
                }

                var modFiles = Directory.EnumerateFiles(modsPath, "*.pak*", SearchOption.AllDirectories);
                foreach (var modFile in modFiles)
                {
                    Mod mod = new Mod();
                    mod.Name = Path.GetFileNameWithoutExtension(modFile);

                    mod.FullPath = modFile;
                    mod.Desc = "";
                    mod.Enabled = !modFile.EndsWith(".disable");
                    mod.Path = Path.GetRelativePath(modsPath, modFile).Replace(".disable", "");
                    if (mod.Path.Contains(Path.DirectorySeparatorChar))
                    {
                        var list = mod.Path.Split(Path.DirectorySeparatorChar);
                        mod.Category = list[0];
                    }
                    else
                    {
                        mod.Category = "通用";
                    }


                    mod.EditTime = File.GetLastWriteTime(modFile);
                    this.modList.Add(mod);
                }
                this.dataGridView1.DataSource = this.modList;
                //this.modBindingSource.DataSource = this.modList;
                toolStripStatusLabel2.Text = $"mod数:{this.modList.Count}";
                lastGamePath = this.textBox1.Text;
                File.WriteAllText("last", lastGamePath);
                if (watcher == null)
                {
                    watcher = new FileSystemWatcher();
                    watcher.Path = this.modsPath;
                    watcher.Filter = "*.pak";

                    watcher.IncludeSubdirectories = true;
                    watcher.EnableRaisingEvents = true;
                    watcher.Changed += FileSystemWatcher_Changed;
                    watcher.Deleted += FileSystemWatcher_Changed;
                    watcher.Renamed += FileSystemWatcher_Changed;
                    watcher.Created += FileSystemWatcher_Changed;
                }

            }

        }

        private void FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            this.Invoke(LoadMods);

        }

        private FileSystemWatcher watcher;

        private void Form1_Load(object sender, EventArgs e)
        {
            // HKEY_LOCAL_MACHINE\SOFTWARE\ProjectSnow
            var dir = CheckGameDir();
            if (dir != "")
            {
                textBox1.Text = dir;
            }
            else
            {
                if (File.Exists("last"))
                {
                    lastGamePath = File.ReadAllText("last");
                    textBox1.Text = lastGamePath;
                }
            }

            LoadMods();
        }
        private string CheckGameDir(string RegistFileName = "ProjectSnow", string RegistKeyName = "InstPath")
        {
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE", true);
                RegistryKey snow = key.OpenSubKey(RegistFileName);
                return (string)snow.GetValue(RegistKeyName);
            }
            catch (Exception)
            {
                return "";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "选择尘白禁区启动程序(snow_launcher.exe)";
            openFileDialog1.FileName = "snow_launcher.exe";
            openFileDialog1.Filter = "尘白启动器|snow_launcher.exe";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.ShowHiddenFiles = false;
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (!openFileDialog1.FileName.EndsWith("snow_launcher.exe"))
                {
                    MessageBox.Show("错误");
                    return;
                }
                var tmp = openFileDialog1.FileName;
                tmp = Path.GetDirectoryName(tmp);
                this.textBox1.Text = tmp;
                LoadMods();
            }
        }
        private bool IsANonHeaderCheckBoxCell(DataGridViewCellEventArgs cellEvent)
        {
            if (dataGridView1.Columns[cellEvent.ColumnIndex] is
                DataGridViewCheckBoxColumn &&
                cellEvent.RowIndex != -1)
            { return true; }
            else { return (false); }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!IsANonHeaderCheckBoxCell(e))
            {
                return;
            }
            var dataIndex = e.RowIndex;
            if (dataIndex > this.modList.Count - 1)
            {
                return;
            }

            (this.modList[dataIndex] as Mod).Enabled = !(this.modList[dataIndex] as Mod).Enabled;


            var mod = (this.modList[dataIndex] as Mod);
            if (!mod.Enabled)
            {
                File.Move(mod.FullPath, mod.FullPath + ".disable");
            }
            else
            {
                File.Move(mod.FullPath, mod.FullPath.Replace(".disable", ""));
            }

            LoadMods();

            //MessageBox.Show($"{dataIndex} is changed: {this.modList[dataIndex]}");
        }

        private void dataGridView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (this.modsPath == null || this.modsPath == "")
            {
                return;
            }
            //var str = "你要将下列mod文件安装吗?\n";
            //foreach (var item in files)
            //{
            //    str += item + "\n";
            //}

            Form2 form2 = new Form2();
            var dialogResult = form2.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                foreach (var item in files)
                {
                    var dstPath = this.modsPath;
                    var fileName = Path.GetFileName(item);
                    if (form2.Category != "")
                    {
                        dstPath = Path.Join(dstPath, form2.Category);
                        Directory.CreateDirectory(dstPath);
                    }
                    dstPath = Path.Join(dstPath, fileName);
                    File.Copy(item, dstPath);
                }
                LoadMods();

            }
            //var result = MessageBox.Show(str, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (result == DialogResult.Yes)
            //{




            //}



        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(this.modsPath))
            {
                Process.Start("explorer.exe", this.modsPath);
            }

        }

        private void 功能ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1. 记录上次选择的游戏目录\n2. 拖拽pak文件安装mod\n3. 按照角色名(分类)管理mod\n4. 管理员权限运行支持自动获取游戏目录(拖拽会失效)\n5. 随时启用或禁用一个mod, 需重进游戏\n6. 监听mod目录, 自动刷新");
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("尘白禁区mod管理工具 v0.1");
        }
    }
}
