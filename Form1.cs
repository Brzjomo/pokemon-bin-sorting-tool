using System;
using System.Data;
using System.Text;
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

        private readonly string defaultPokemonYML = "USUM.yml";
        private readonly string defaultPokemonYMLPath = "./data/USUM.yml";
        private string pokemonYML = "";
        private string pokemonYMLPath = "";

        private async void BTTXTToYML_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                FileName = "ѡ��һ��txt�ļ�",
                Filter = "txt�ļ�(*.txt)|*.txt",
                Title = "��txt�ļ�"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // �����ļ���
                string[] fileName = openFileDialog.FileName.Split("\\");
                string openFileName = fileName[^1];

                //Cursor = Cursors.WaitCursor;

                // ��ȡ�ļ�
                var inputStream = new StreamReader(openFileDialog.FileName, Encoding.UTF8);
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
                //Cursor.Current = Cursors.Default;

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

                // ȥ��txt��׺
                openFileName = openFileName.Split(".txt")[0];

                // ����yml
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    FileName = openFileName,
                    Filter = "yml�ļ�(*.yml)|*.yml",
                    Title = "����yml�ļ�"
                };

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

                // ������Ϣ׼�����
                List<Pokemon> outputPokemonList = new();

                for (int i = 0; i < indexStart.Count; i++)
                {
                    Pokemon newPokemon = new()
                    {
                        indexStart = indexStart[i],
                        indexEnd = indexEnd[i],
                        pokemonName = pokemonName[i],
                    };

                    outputPokemonList.Add(newPokemon);
                }

                saveFileDialog.ShowDialog();

                if (saveFileDialog.FileName != "")
                {
                    var OutputData = new PokemonData
                    {
                        PokemonList = outputPokemonList,
                    };

                    await using var streamWriter = new StreamWriter(saveFileDialog.OpenFile());
                    var serializer = new Serializer();
                    await streamWriter.WriteLineAsync(serializer.Serialize(OutputData));
                    streamWriter.Close();
                }
            }
        }
    }
}