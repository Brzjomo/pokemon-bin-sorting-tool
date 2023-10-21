using System;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using YamlDotNet.Serialization;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace pokemon_bin_sorting_tool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            UpdateResourceManager();
            UpdateProgramTitle();
        }

        private static string version = "1.0.4";

        private void UpdateProgramTitle() => Text = GetProgramTitle();

        private string GetProgramTitle()
        {
            return this.Text + " " + version;
        }

        private ComponentResourceManager resourceManger = new ComponentResourceManager(typeof(Resources.Resource_en));
        private readonly ComponentResourceManager resourceMangerZH = new ComponentResourceManager(typeof(Resources.Resource_zh));
        private readonly ComponentResourceManager resourceMangerEN = new ComponentResourceManager(typeof(Resources.Resource_en));

        private void UpdateResourceManager()
        {
            if (Thread.CurrentThread.CurrentCulture.Name.Contains("zh"))
            {
                resourceManger = resourceMangerZH;
            }
            else
            {
                resourceManger = resourceMangerEN;
            }
        }

        private class PokemonData
        {
            [YamlMember(Alias = "PokemonList", ApplyNamingConventions = false)]
            public List<Pokemon> PokemonList { get; set; } = new List<Pokemon>();
        }

        private class Pokemon
        {
            public int indexStart = 0;
            public int indexEnd = 0;
            public int fileCount = 0;
            public string pokemonName = "";
        }

        private PokemonData pokemonData = new();

        private readonly string dataDirectory = "data";
        private readonly string defaultPath = "./data/";
        private readonly string defaultPokemonTXT = "USUM.txt";

        private async void ReadFromTXT(string path, string txt)
        {
            string fullPath = path + txt;

            // 读取默认txt
            if (fullPath != "")
            {
                if (!File.Exists(fullPath))
                {
                    Directory.CreateDirectory(dataDirectory);
                    MessageBox.Show(resourceManger.GetString("fileNotExistInfo"), resourceManger.GetString("fileNotExistCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                }
                else
                {
                    // 更新文件名
                    string fileName = txt.Split(".")[0];

                    // 读取文件
                    var inputStream = new StreamReader(fullPath, Encoding.UTF8);
                    var input = await inputStream.ReadToEndAsync();
                    inputStream.Close();

                    string[] inputString = input.Split(new char[] { '\r', '\n' });
                    List<string> strings = new List<string>();
                    List<string> outputStrings = new List<string>();

                    // 格式化
                    foreach (var line in inputString)
                    {
                        if (line != "")
                        {
                            if (line.Contains('\t'))
                            {
                                strings.Add(line.Trim(new char[] { '\t' }));
                            }
                            else
                            {
                                strings.Add(line);
                            }
                        }
                    }

                    // 去重
                    foreach (var line in strings)
                    {
                        bool ifExist = false;
                        foreach (var output in outputStrings)
                        {
                            if (line == output)
                            {
                                ifExist = true;
                                break;
                            }
                        }

                        if (!ifExist)
                        {
                            outputStrings.Add(line);
                        }
                    }

                    // 分别储存序号和名称
                    List<string> indexRange = new();
                    List<string> pokemonName = new();

                    foreach (var line in outputStrings)
                    {
                        if (line != "")
                        {
                            indexRange.Add(line.Split(": ")[0]);
                            pokemonName.Add(line.Split(": ")[1]);
                        }
                    }

                    // 处理index信息
                    List<int> indexStart = new();
                    List<int> indexEnd = new();

                    for (int i = 0; i < indexRange.Count; i++)
                    {
                        string[] indexInfo = indexRange[i].Split('-');

                        // 去除头部0
                        for (int j = 0; j < indexInfo.Length; j++)
                        {
                            //
                            string index = indexInfo[j];
                            int trimIndex = -1;
                            for (int k = 0; k < 6; k++)
                            {
                                if (index.IndexOf("0") == k)
                                {
                                    trimIndex++;
                                }
                            }

                            index = index.Remove(0, trimIndex);

                            indexInfo[j] = index;
                        }

                        // 转为int，并存储
                        indexStart.Add(int.Parse(indexInfo[0]));
                        indexEnd.Add(int.Parse(indexInfo[1]));
                    }

                    // 文件计数
                    List<int> fileCount = new();

                    for (int i = 0; i < indexRange.Count; i++)
                    {
                        int count = indexEnd[i] - indexStart[i] + 1;
                        fileCount.Add(count);
                    }

                    // 整理信息
                    List<Pokemon> preparedPokemonList = new();

                    for (int i = 0; i < indexStart.Count; i++)
                    {
                        Pokemon newPokemon = new()
                        {
                            indexStart = indexStart[i],
                            indexEnd = indexEnd[i],
                            fileCount = fileCount[i],
                            pokemonName = pokemonName[i],
                        };

                        preparedPokemonList.Add(newPokemon);
                    }

                    // 更新数据
                    pokemonData.PokemonList = preparedPokemonList;

                    // 输出YML
                    if (CBIfOutputYML.Checked)
                    {
                        await using var streamWriter = new StreamWriter(path + fileName + ".yml");
                        var serializer = new Serializer();
                        await streamWriter.WriteLineAsync(serializer.Serialize(pokemonData));
                        streamWriter.Close();
                    }
                }
            }
        }

        private void BTRun_Click(object sender, EventArgs e)
        {
            MessageBox.Show(resourceManger.GetString("longTimePrompt"), resourceManger.GetString("longTimePromptCaption"), MessageBoxButtons.OK, MessageBoxIcon.Information);

            switch (CBGameVersion.Text)
            {
                case "USUM":
                    if (!File.Exists(defaultPath + "USUM.txt"))
                    {
                        Directory.CreateDirectory(dataDirectory);
                        MessageBox.Show(resourceManger.GetString("fileNotExistInfo"), resourceManger.GetString("fileNotExistCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }

                    ReadFromTXT(defaultPath, "USUM.txt");
                    break;
                default:
                    if (!File.Exists(defaultPath + defaultPokemonTXT))
                    {
                        Directory.CreateDirectory(dataDirectory);
                        MessageBox.Show(resourceManger.GetString("fileNotExistInfo"), resourceManger.GetString("fileNotExistCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }

                    ReadFromTXT(defaultPath, defaultPokemonTXT);
                    break;
            }

            // 选取文件夹路径
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            string floderPath = "";

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                floderPath = folderBrowserDialog.SelectedPath;
            }

            if (floderPath != "")
            {
                DirectoryInfo folderInfo = new(floderPath);

                foreach (var pokemon in pokemonData.PokemonList)
                {
                    // 获取索引
                    int startIndex = pokemon.indexStart;
                    int endIndex = pokemon.indexEnd;

                    for (int i = startIndex; i < endIndex + 1; i++)
                    {
                        string index = i.ToString().PadLeft(5, '0');
                        string preFix = "dec_";
                        string finalFile = preFix + index + ".bin";

                        string sourceFile = floderPath + "\\" + finalFile;

                        if (File.Exists(sourceFile))
                        {
                            // 创建文件夹
                            string pokemonName = pokemon.pokemonName;

                            if (CBIfReplaceBlank.Checked)
                            {
                                pokemonName = pokemonName.Replace(' ', '_');
                            }

                            string directory = floderPath + "\\" + pokemonName;

                            if (!Directory.Exists(directory))
                            {
                                Directory.CreateDirectory(directory);
                            }

                            string destFile = directory + "\\" + finalFile;

                            File.Move(sourceFile, destFile, true);
                        }
                    }
                }

                // 提示完成
                MessageBox.Show(resourceManger.GetString("completePrompt"), resourceManger.GetString("completePromptCaption"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void BTGen_Click(object sender, EventArgs e)
        {
            int startIndex = (int)NUDStartIndex.Value;
            int fileCount = (int)NUDFileCount.Value;
            int endIndex = (int)NUDEndIndex.Value;
            int stringWith = (int)NUDStringWidth.Value;

            // 计算序号
            int index = startIndex;
            int loopCount = (endIndex - startIndex + 1) / fileCount;
            string fileIndex = "";
            string fileEndIndex = "";
            string outputString = "";

            for (int i = 0; i < loopCount; i++)
            {
                int currentEndIndex = index + fileCount - 1;

                fileIndex = index.ToString().PadLeft(stringWith, '0');
                fileEndIndex = currentEndIndex.ToString().PadLeft(stringWith, '0');

                fileIndex = fileIndex + "-" + fileEndIndex;

                outputString += fileIndex + "\r";

                index = currentEndIndex + 1;
            }

            // 保存txt
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                FileName = resourceManger.GetString("indexGenFileName"),
                Filter = resourceManger.GetString("indexGenFilter"),
                Title = resourceManger.GetString("indexGenTitle")
            };
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                await using var streamWriter = new StreamWriter(saveFileDialog.OpenFile());
                await streamWriter.WriteLineAsync(outputString);
                streamWriter.Close();
            }
        }
    }
}