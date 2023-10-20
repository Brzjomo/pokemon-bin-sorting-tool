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
                FileName = "选择一个txt文件",
                Filter = "txt文件(*.txt)|*.txt",
                Title = "打开txt文件"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 更新文件名
                string[] fileName = openFileDialog.FileName.Split("\\");
                string openFileName = fileName[^1];

                //Cursor = Cursors.WaitCursor;

                // 读取文件
                var inputStream = new StreamReader(openFileDialog.FileName, Encoding.UTF8);
                var input = await inputStream.ReadToEndAsync();
                inputStream.Close();

                string[] inputString = input.Split(new char[] { '\r', '\n'});
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
                            strings.Add(line.Trim(new char[] { '\t'}));
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

                // 去除txt后缀
                openFileName = openFileName.Split(".txt")[0];

                // 保存yml
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    FileName = openFileName,
                    Filter = "yml文件(*.yml)|*.yml",
                    Title = "保存yml文件"
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