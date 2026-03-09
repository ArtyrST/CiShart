using System.Collections.Generic;

namespace generic__collections
{
    internal class Program
    {
        //1
        //public static void Swap<T>(ref T a, ref T b)
        //{
        //    T temp = a;
        //    a = b;
        //    b = temp;
        //}
        class Dict<T>
        {
            public Dictionary<string, string>? dict;
            public Dict()
            {
                dict = new Dictionary<string, string>();

            }
            public void Add(string key, string value)
            {
                if (int.TryParse(key, out int _intk) || float.TryParse(key, out float _floatk) || double.TryParse(key, out double _doublek))
                {
                    throw new Exception("The key word isn't a word :)");
                }
                else if (int.TryParse(value, out int _intv) || float.TryParse(value, out float _floatv) || double.TryParse(value, out double _doublev))
                {
                    throw new Exception("The translate word isn't a word :)");
                }
                else if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(value))
                {
                    throw new Exception("It cant be a nullable value!");
                }
                else
                {
                    this.dict!.Add(key, value);
                }
            }
            public void RemoveKey(string key)
            {
                if (int.TryParse(key, out int _intk) || float.TryParse(key, out float _floatk) || double.TryParse(key, out double _doublek))
                {
                    throw new Exception("The key word isn't a word :)");
                }
                else if (string.IsNullOrEmpty(key))
                {
                    throw new Exception("It cant be a nullable value!");
                }
                else if (!this.dict!.ContainsKey(key))
                {
                    throw new Exception($"{key} not found");
                }
                else
                {
                    this.dict!.Remove(key);
                }
            }
            public void RemoveValue(string key)
            {
                if (int.TryParse(key, out int _intk) || float.TryParse(key, out float _floatk) || double.TryParse(key, out double _doublek))
                {
                    throw new Exception("The key word isn't a word :)");
                }
                
                else if (string.IsNullOrEmpty(key))
                {
                    throw new Exception("It cant be a nullable value!");
                }
                else if (!this.dict!.ContainsKey(key))
                {
                    throw new Exception($"{key} not found");
                }
                else
                {
                    this.dict![key] = "";
                }
            }
            public void ChangeKey(string key, string new_key)
            {
                if (int.TryParse(key, out int _intk) || float.TryParse(key, out float _floatk) || double.TryParse(key, out double _doublek))
                {
                    throw new Exception("The key word isn't a word :)");
                }
                else if (string.IsNullOrEmpty(key))
                {
                    throw new Exception("It cant be a nullable value!");
                }
                else if (!this.dict!.ContainsKey(key))
                {
                    throw new Exception($"{key} not found");
                }
                else
                {
                    this.dict![new_key] = this.dict![key];
                    this.dict!.Remove(key);
                }
            }
            public void ChangeValue(string key, string new_value)
            {
                if (int.TryParse(key, out int _intk) || float.TryParse(key, out float _floatk) || double.TryParse(key, out double _doublek))
                {
                    throw new Exception("The key word isn't a word :)");
                }

                else if (string.IsNullOrEmpty(key))
                {
                    throw new Exception("It cant be a nullable value!");
                }
                else if (!this.dict!.ContainsKey(key))
                {
                    throw new Exception($"{key} not found");
                }
                else
                {
                    this.dict![key] = new_value;
                }
            }
            public void ShowValue(string key)
            {
                if (int.TryParse(key, out int _intk) || float.TryParse(key, out float _floatk) || double.TryParse(key, out double _doublek))
                {
                    throw new Exception("The key word isn't a word :)");
                }
                else if (string.IsNullOrEmpty(key))
                {
                    throw new Exception("It cant be a nullable value!");
                }
                else if (!this.dict!.ContainsKey(key))
                {
                    throw new Exception($"{key} not found");
                }
                else
                {
                    string translate = this.dict![key];
                    Console.WriteLine($"The translate of {key} is {translate}");
                }
            }
        }
        static void Menu(Dict<string> diction)
        {
            
            string word, translate, new_word, new_translate;
            while (true)
            {
                try
                {
                    Console.WriteLine("1. Додавання слова та варіантів перекладу;\r\n2. Видалення слова;\r\n3. Видалення варіанта перекладу;\r\n4. Зміна слова;\r\n5. Зміна варіанта перекладу;\r\n6. Пошук перекладу слова.\n0. Вийти");
                    string answer = Console.ReadLine();
                    switch (answer)
                    {
                        case "1":
                            Console.Clear();
                            Console.Write("Type a word: ");
                            word = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write($"Type a translate to {word}: ");
                            translate = Console.ReadLine();
                            diction.Add(word, translate);
                            continue;
                        case "2":
                            Console.Clear();
                            Console.Write("Type a word to remove: ");
                            word = Console.ReadLine();
                            diction.RemoveKey(word);
                            continue;
                        case "3":
                            Console.Clear();
                            Console.Write("Type a word, that translate will remove: ");
                            word = Console.ReadLine();
                            diction.RemoveValue(word);
                            continue;

                        case "4":
                            Console.Clear();
                            Console.Write("Type a word to change: ");
                            word = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("Type a new word: ");
                            new_word = Console.ReadLine();
                            diction.ChangeKey(word, new_word);
                            continue;
                        case "5":
                            Console.Clear();
                            Console.Write("Type a word to change translate: ");
                            word = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("Type a new translate: ");
                            new_translate = Console.ReadLine();
                            diction.ChangeValue(word, new_translate);
                            continue;
                        

                        case "6":
                            Console.Clear();
                            Console.Write("Type a word: ");
                            word = Console.ReadLine();
                            Console.WriteLine();
                            diction.ShowValue(word);
                            continue;
                        case "0":
                            return;
                            


                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }

        }
            static void Main(string[] args)
            {
                Dict<string> diction = new Dict<string>();
                Menu(diction);
            }
    }
}
