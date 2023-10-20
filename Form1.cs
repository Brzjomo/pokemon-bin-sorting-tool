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
            [YamlMember(Alias = "Pokemon", ApplyNamingConventions = false)]
            public List<string> Pokemon { get; set; } = new List<string>();
        }

        private class Pokemon
        {
            [YamlMember(Alias = "Index", ApplyNamingConventions = false)]
            public List<string> FileIndex { get; set; } = new List<string>();

            [YamlMember(Alias = "PokemonName", ApplyNamingConventions = false)]
            public List<string> PokemonName { get; set; } = new List<string>();
        }

        private PokemonData pokemonData = new();
        private Pokemon pokemon = new();

        private string defaultPokemonYML = "USUM.yml";
        private string defaultPokemonYMLPath = "./data/USUM.yml";
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

                string[] inputString = input.Split(new char[] { '\r', '\n'});
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
                            strings.Add(line.Trim(new char[] { '\t'}));
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

                //
                List<string> indexRange = new List<string>();
                List<string> pokemonName = new List<string>();

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
                saveFileDialog.ShowDialog();

                if (saveFileDialog.FileName != "")
                {
                    var DataForTrans = new Pokemon
                    {
                        FileIndex = indexRange,
                        PokemonName = pokemonName
                    };

                    await using var streamWriter = new StreamWriter(saveFileDialog.OpenFile());
                    var serializer = new Serializer();
                    await streamWriter.WriteLineAsync(serializer.Serialize(DataForTrans));
                    streamWriter.Close();
                }
            }
        }
    }
}