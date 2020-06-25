using System;

namespace SoftStar.Pal6
{
	public class ElementPhaseTool
	{
		private static int startIndex = 1001;

		private static int[] ToDesingerOrderArray = new int[]
		{
			2,
			0,
			3,
			4,
			1,
			7,
			5,
			6
		};

		private static int[] ToProgramOrderArray = new int[]
		{
			1,
			4,
			0,
			2,
			3,
			6,
			7,
			5
		};

		private static string[] Names = null;

		public static int ToDesingerOrder(ElementPhase s)
		{
			return ElementPhaseTool.ToDesingerOrderArray[(int)s];
		}

		public static ElementPhase ToProgramOrder(int s)
		{
			return (ElementPhase)ElementPhaseTool.ToProgramOrderArray[s];
		}

		public static string Name(int e)
		{
			if (ElementPhaseTool.Names == null)
			{
				ElementPhaseTool.Names = new string[Enum.GetNames(typeof(ElementPhase)).Length];
				for (int i = 0; i < Enum.GetNames(typeof(ElementPhase)).Length; i++)
				{
					//ElementPhaseTool.Names[i] = Langue.get_string((ulong)((long)(ElementPhaseTool.startIndex + i)), "UI");
				}
			}
			return ElementPhaseTool.Names[e];
		}

		public static string Name(ElementPhase e)
		{
			if (ElementPhaseTool.Names == null)
			{
				ElementPhaseTool.Names = new string[Enum.GetNames(typeof(ElementPhase)).Length];
				for (int i = 0; i < Enum.GetNames(typeof(ElementPhase)).Length; i++)
				{
					//ElementPhaseTool.Names[i] = Langue.get_string((ulong)((long)(ElementPhaseTool.startIndex + i)), "UI");
				}
			}
			return ElementPhaseTool.Names[(int)e];
		}
	}
}
