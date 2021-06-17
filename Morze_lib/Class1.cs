using System;
using System.Collections.Generic;
using System.IO;

namespace morze_lib
{
	public class Morze
	{

		private Dictionary<char, string> en_m;
		private Dictionary<char, string> ru_m;
		private Dictionary<string, char> m_en;
		private Dictionary<string, char> m_ru;

		public Morze()
		{
			en_m = new Dictionary<char, string>();
			ru_m = new Dictionary<char, string>();
			m_en = new Dictionary<string, char>();
			m_ru = new Dictionary<string, char>();
			string temp;
			string buf;
			using (StreamReader lib = new StreamReader("1.txt", System.Text.Encoding.Default))
			{
				temp = lib.ReadLine();
				buf = "";
				while (lib.Peek() > 0)
				{
					buf = "";
					for (int i = 3; i < temp.Length; i++)
					{
						buf += temp[i];
					}
					if (temp[0] != '@')
					{
						ru_m.Add(temp[0], buf);
					}
					if (temp[1] != '@')
					{
						en_m.Add(temp[1], buf);
					}
					m_en.Add(buf, temp[1]);
					m_ru.Add(buf, temp[0]);
					temp = lib.ReadLine();
				}
			}
		}


		public string in_morze(char input, string language)
		{
			//string output = "";
			//using (StreamReader lib = new StreamReader("1.txt", System.Text.Encoding.Default))
			//{
			//	string temp = "";
			//	if (input == ' ' || input == '\n')
			//	{
			//		output += input;
			//	}
			//	else
			//	{
			//		temp = lib.ReadLine();
			//		while (lib.Peek() > 0)
			//		{
			//			bool flag = false;
			//			bool pr = false;
			//			for (int j = 0; j < temp.Length; j++)
			//			{
			//				if (temp[j] == '/')
			//				{
			//					if (language == "ru" && temp[j - 1] == input)
			//					{
			//						flag = true;
			//					}
			//					else if (language == "en" && temp[j + 1] == input)
			//					{
			//						flag = true;
			//					}
			//				}
			//				if (temp[j] == ' ')
			//				{
			//					pr = true;
			//				}
			//				else if (pr == true && flag == true)
			//				{
			//					output += temp[j];
			//				}
			//			}
			//			temp = lib.ReadLine();
			//		}
			//		output += ' ';
			//		lib.BaseStream.Position = 0;
			//	}
			//}
			input = pr(input);
			if (input == ' ' || input == '\n')
			{
				return input.ToString();
			}
			if (en_m.ContainsKey(input) && language == "en")
			{
				return en_m[input] + ' ';
			}
			else if (ru_m.ContainsKey(input) && language == "ru")
			{
				return ru_m[input] + ' ';
			}
			else return "";
		}

		public char fr_morze(string input, string language)
		{
			//string output = "";
			//using (StreamReader lib = new StreamReader("1.txt", System.Text.Encoding.Default))
			//{
			//	string temp_read = "";
			//	for (int i = 0; i < input.Length; i++)
			//	{
			//		temp_read = lib.ReadLine();
			//		while (lib.Peek() > 0)
			//		{
			//			string t = "";
			//			bool pr = false;
			//			for (int j = 0; j < temp_read.Length; j++)
			//			{
			//				if (temp_read[j] == ' ')
			//				{
			//					pr = true;
			//				}
			//				else if (pr == true)
			//				{
			//					t += temp_read[j];
			//				}
			//			}
			//			if (input == t)
			//			{
			//				for (int j = 0; j < temp_read.Length; j++)
			//				{
			//					if (temp_read[j] == '/')
			//					{
			//						if (language == "ru")
			//						{
			//							output += temp_read[j - 1];
			//						}
			//						else if (language == "en")
			//						{
			//							output += temp_read[j + 1];
			//						}
			//					}
			//				}
			//			}
			//			temp_read = lib.ReadLine();
			//		}
			//	}
			//}
			//return output;
			input = pr_morze(input);
			if (m_en.ContainsKey(input) && language == "en")
			{
				return m_en[input];
			}
			else if (m_ru.ContainsKey(input) && language == "ru")
			{
				return m_ru[input];
			}
			else return ' ';
		}

		private char pr(char inp)
		{
			inp = char.ToUpper(inp);
			if ((inp >= 65 && inp <= 90) || (inp >= 1040 && inp <= 1071) || inp == ' ' || inp == '\n' || inp == '.' || inp == ',')
			{
				return inp;
			}
			else return ' ';
		}

		private string pr_morze(string inp)
		{
			for (int i = 0; i < inp.Length; i++)
			{
				if (inp[i] == '-' && inp[i] == '.' && inp[i] == ' ')
				{
					return "";
				}
			}
			return inp;
		}
	}
}