using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using YamlDotNet.Serialization;

namespace pokemon_bin_sorting_tool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            public string pokemonName = "";
        }

        private PokemonData pokemonData = new();

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
                    var dataDirectory = "data";
                    Directory.CreateDirectory(dataDirectory);
                    MessageBox.Show("请检查data目录下" + txt + "是否存在。", "缺少必要文件", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
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
                        //Cursor.Current = Cursors.WaitCursor;

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
                        //Cursor.Current = Cursors.WaitCursor;

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

                    // 整理信息
                    List<Pokemon> preparedPokemonList = new();

                    for (int i = 0; i < indexStart.Count; i++)
                    {
                        Pokemon newPokemon = new()
                        {
                            indexStart = indexStart[i],
                            indexEnd = indexEnd[i],
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
            switch (CBGameVersion.Text)
            {
                case "USUM":
                    ReadFromTXT(defaultPath, "USUM.txt");
                    break;
                default:
                    ReadFromTXT(defaultPath, defaultPokemonTXT);
                    break;
            }
        }
    }
}