using Microsoft.Win32;
using SevenZipExtractor;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
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

        private Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
        private void LoadDescs()
        {
            if (File.Exists("db.json"))
            {
                var content = File.ReadAllText("db.json");
                keyValuePairs = new Dictionary<string, string>();
                keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, string>>(content);
            }
            else
            {
                keyValuePairs = new Dictionary<string, string>();
            }

        }
        private void SaveDescs()
        {
            if (modList == null)
            {
                return;
            }
            foreach (Mod mod in modList)
            {
                if (mod.Desc.Trim() != "")
                {
                    var b = keyValuePairs.TryAdd(mod.Key, mod.Desc);
                    if (!b)
                    {
                        keyValuePairs[mod.Key] = mod.Desc;
                    }
                }
            }
            var content = JsonSerializer.Serialize(keyValuePairs);
            File.WriteAllText("db.json", content);
        }
        private int focusIndex = -1;
        private void LoadMods()
        {
            LoadDescs();
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
                    if (modFile.EndsWith(".ignore"))
                    {
                        continue;
                    }
                    Mod mod = new Mod();
                    mod.Name = Path.GetFileNameWithoutExtension(modFile);
                    string desc = "";
                    keyValuePairs.TryGetValue(mod.Key, out desc);
                    mod.FullPath = modFile;
                    mod.Desc = desc == null ? "" : desc;
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

                if (focusIndex != -1)
                {
                    dataGridView1.Rows[focusIndex].Selected = true;
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
            focusIndex = -1;
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
                focusIndex = -1;
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
            focusIndex = dataIndex;
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
            var isTmp = false;
            if (files.Length == 1)
            {
                if (!files[0].EndsWith(".pak") && !files[0].EndsWith(".zip") && !files[0].EndsWith(".7z"))
                {
                    MessageBox.Show("请拖拽pak文件或zip/7z压缩包");
                    return;
                }
                if (Path.GetExtension(files[0]) == ".zip" || Path.GetExtension(files[0]) == ".7z")
                {
                    var zipPath = files[0];
                    DirectoryInfo di;
                    if (!Directory.Exists("tmp"))
                    {
                        di = Directory.CreateDirectory("tmp");
                    }
                    else
                    {
                        di = new DirectoryInfo("tmp");
                    }
                    //System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, di.FullName);
                    using (ArchiveFile archiveFile = new ArchiveFile(zipPath))
                    {
                        archiveFile.Extract(di.FullName);
                    }
                    var modFiles = Directory.EnumerateFiles(di.FullName, "*.pak", SearchOption.AllDirectories);
                    files = modFiles.ToArray();
                    isTmp = true;
                }
            }
            else if (files.Length > 1)
            {
                foreach (var item in files)
                {
                    if (item.EndsWith(".zip"))
                    {
                        MessageBox.Show("请拖拽单个zip压缩包");
                        return;
                    }
                }
            }



            Form2 form2 = new Form2();
            var dialogResult = form2.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                foreach (var item in files)
                {
                    var dstPath = this.modsPath;
                    var fileName = Path.GetFileName(item);

                    if (fileName.EndsWith("_100_P.pak"))
                    {

                    }
                    else if (fileName.EndsWith("_P.pak"))
                    {
                        fileName = fileName.Replace("_P.pak", "_100_P.pak");
                    }
                    if (fileName.EndsWith("_100_p.pak"))
                    {

                    }
                    else if (fileName.EndsWith("_p.pak"))
                    {
                        fileName = fileName.Replace("_p.pak", "_100_P.pak");
                    }
                    if (form2.Category != "")
                    {
                        dstPath = Path.Join(dstPath, form2.Category);
                        Directory.CreateDirectory(dstPath);
                    }

                    dstPath = Path.Join(dstPath, fileName);
                    if (isTmp)
                    {
                        File.Move(item, dstPath);
                    }
                    else
                    {
                        File.Copy(item, dstPath);
                    }

                }
                LoadMods();

            }

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
            MessageBox.Show("1. 记录上次选择的游戏目录\n2. 拖拽pak文件安装mod\n3. 按照角色名(分类)管理mod\n4. 管理员权限运行支持自动获取游戏目录(拖拽会失效)\n5. 随时启用或禁用一个mod, 需重进游戏\n6. 监听mod目录, 自动刷新\n7. 备注mod");
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("尘白禁区mod管理工具 v0.3");
        }

        private void 备注modToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rowToDesc = dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            if (rowToDesc > this.modList.Count - 1)
            {
                return;
            }
            Form2 form2 = new Form2();
            var cat = (this.modList[rowToDesc] as Mod).Category;
            var desc = (this.modList[rowToDesc] as Mod).Desc;
            var result = form2.ShowWithData(cat, desc);
            if (result == DialogResult.OK)
            {
                (this.modList[rowToDesc] as Mod).Category = form2.Category;
                (this.modList[rowToDesc] as Mod).Desc = form2.Desc;
            }
            SaveDescs();
            focusIndex = rowToDesc;
            LoadMods();
            //dataGridView1.ClearSelection();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dataGridView1.HitTest(e.X, e.Y);
                if (hit.RowIndex == -1)
                {
                    return;
                }
                dataGridView1.ClearSelection();
                dataGridView1.Rows[hit.RowIndex].Selected = true;
                focusIndex = hit.RowIndex;

                contextMenuStrip1.Show(Control.MousePosition);
            }

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 批量改名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dr = MessageBox.Show("批量修改mod文件名吗? \n这是2.7版本之后需要进行的操作, 否则进游戏会提示Game resources broken, 批量将文件名修改为 xxxx_100_P.pak. \n 参考https://www.nexusmods.com/snowbreakcontainmentzone/mods/552", "提示", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                watcher = null;

                var modFiles = Directory.EnumerateFiles(modsPath, "*.pak*", SearchOption.AllDirectories);
                foreach (var modFile in modFiles)
                {
                    var ext = Path.GetExtension(modFile);
                    if (ext == ".pak")
                    {
                        var fileName = Path.GetFileNameWithoutExtension(modFile);
                        if (fileName.Contains("_100_P"))
                        {
                            continue; //skip
                        }
                        fileName = fileName.Replace("_100_P", "");
                        fileName = fileName.Replace("_P", "");
                        fileName = fileName.Replace("_p", "");
                        var newFileName = fileName + "_100_P" + ext;
                        var newPath = Path.Join(Path.GetDirectoryName(modFile), newFileName);
                        File.Move(modFile, newPath);
                    }
                }
                MessageBox.Show("批量改名完成, 请重启程序");


            }
        }

        private void 删除modToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rowToDesc = dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            if (rowToDesc > this.modList.Count - 1)
            {
                return;
            }

            var mod = (this.modList[rowToDesc] as Mod);
            File.Move(mod.FullPath, mod.FullPath + ".ignore");

            focusIndex = rowToDesc-1;
            LoadMods();
        }
    }
}
