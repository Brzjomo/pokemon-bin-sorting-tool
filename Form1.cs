using System;
using System.Data;
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
            UpdateProgramTitle();
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

        private static string version = "1.0.0";

        private void UpdateProgramTitle() => Text = GetProgramTitle();

        private static string GetProgramTitle()
        {
            return "������bin�ļ�������" + " " + version;
        }

        private PokemonData pokemonData = new();

        private readonly string dataDirectory = "data";
        private readonly string defaultPath = "./data/";
        private readonly string defaultPokemonTXT = "USUM.txt";

        private string fileNotExistInfo = "����dataĿ¼��TXT�ļ��Ƿ���ڡ�";
        private string fileNotExistCaption = "ȱ�ٱ�Ҫ�ļ�";

        private async void ReadFromTXT(string path, string txt)
        {
            string fullPath = path + txt;

            // ��ȡĬ��txt
            if (fullPath != "")
            {
                if (!File.Exists(fullPath))
                {
                    Directory.CreateDirectory(dataDirectory);
                    MessageBox.Show(fileNotExistInfo, fileNotExistCaption, MessageBoxButtons.OK, MessageBoxIcon.Error); return;
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
            MessageBox.Show("���ܻῨסһ��ʱ�䣬�����ĵȴ�~", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            switch (CBGameVersion.Text)
            {
                case "USUM":
                    if (!File.Exists(defaultPath + "USUM.txt"))
                    {
                        Directory.CreateDirectory(dataDirectory);
                        MessageBox.Show(fileNotExistInfo, fileNotExistCaption, MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }

                    ReadFromTXT(defaultPath, "USUM.txt");
                    break;
                default:
                    if (!File.Exists(defaultPath + defaultPokemonTXT))
                    {
                        Directory.CreateDirectory(dataDirectory);
                        MessageBox.Show(fileNotExistInfo, fileNotExistCaption, MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }

                    ReadFromTXT(defaultPath, defaultPokemonTXT);
                    break;
            }

            // ѡȡ�ļ���·��
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
                    // ��ȡ����
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
                            // �����ļ���
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

                // ��ʾ���
                MessageBox.Show("������ɣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}