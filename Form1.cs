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
            // ��ȡĬ��txt
            if (fullPath != "")
            {
                if (!File.Exists(fullPath))
                {
                    var dataDirectory = "data";
                    Directory.CreateDirectory(dataDirectory);
                    MessageBox.Show("����dataĿ¼��" + txt + "�Ƿ���ڡ�", "ȱ�ٱ�Ҫ�ļ�", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                }
                else
                {
                    // �����ļ���
                    string fileName = txt.Split(".")[0];

                    // ��ȡ�ļ�
                    var inputStream = new StreamReader(fullPath, Encoding.UTF8);
                    var input = await inputStream.ReadToEndAsync();
                    inputStream.Close();

                    string[] inputString = input.Split(new char[] { '\r', '\n' });
                    List<string> strings = new List<string>();
                    List<string> outputStrings = new List<string>();

                    // ��ʽ��
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

                    // ȥ��
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

                    // �ֱ𴢴���ź�����
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

                    // ����index��Ϣ
                    List<int> indexStart = new();
                    List<int> indexEnd = new();

                    for (int i = 0; i < indexRange.Count; i++)
                    {
                        string[] indexInfo = indexRange[i].Split('-');

                        // ȥ��ͷ��0
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

                        // תΪint�����洢
                        indexStart.Add(int.Parse(indexInfo[0]));
                        indexEnd.Add(int.Parse(indexInfo[1]));
                    }

                    // ������Ϣ
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

                    // ��������
                    pokemonData.PokemonList = preparedPokemonList;

                    // ���YML
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