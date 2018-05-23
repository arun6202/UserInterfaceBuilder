using System;
using System.Linq;
using System.Reflection;
using Bogus;

namespace XAMLExtensions
{
	class Program
	{
		private static readonly string BogusAssembly = "Bogus";

		static void Main(string[] args)
		{
   
			var allmethods = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.Contains(BogusAssembly))
				.SelectMany(s => s.GetTypes())
				.Where(typeof(IHasRandomizer).IsAssignableFrom)
				.SelectMany(m => m.GetMethods())
				.Where(m => m.DeclaringType != typeof(object))
			    .Where(mi => !mi.IsSpecialName);


			foreach (MethodInfo methodInfo in allmethods)
			{
				Console.WriteLine(methodInfo.GetSignature());
			}

		}
	}
}
