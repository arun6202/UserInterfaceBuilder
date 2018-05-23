using System;
using System.Linq;
using System.Reflection;
using Bogus;

namespace XAMLExtensions
{
	class Program
	{
		private const string Static = "static";
		private static readonly string BogusAssembly = "Bogus";

		static void Main(string[] args)
		{

			var allTypes = AppDomain.CurrentDomain.GetAssemblies()
			    .Where(a => a.FullName.Contains(BogusAssembly))
				.SelectMany(s => s.GetTypes())
			    .Where(m => !m.IsAbstract)
				.Where(m => m != typeof(IHasRandomizer))
				.Where(typeof(IHasRandomizer).IsAssignableFrom);


			var allmethods = allTypes
				.SelectMany(m => m.GetMethods())
				.Where(m => m.DeclaringType != typeof(object))
				.Where(mi => !mi.IsSpecialName);

			var usingContent = @"
                                using System;
                                using System.Collections.Generic;
                                using Bogus;
                                using Bogus.DataSets;
                                using Bogus.Premium;
                                using static Bogus.DataSets.Name;";

			Console.WriteLine(usingContent);

			var classStartName = @"{";
			var className = @"public static class BogusGenerator";
			var classEndName = @"}";
			Console.WriteLine(className + classStartName);

			Console.WriteLine("private const string Locale = \"en\";");
		 


			foreach (var typeInfo in allTypes)
			{

				Console.WriteLine(@"public static readonly " + typeInfo.Name + " " + typeInfo.Name + "  = new " + typeInfo.Name + "(Locale);");
			}

			foreach (MethodInfo methodInfo in allmethods)
			{

				var methodSignature = methodInfo.GetSignature();
				var methodSignatureWithoutType = methodInfo.GetSignatureWithoutType();

				if (!methodSignature.Contains(Static))
				{
					methodSignature = methodSignature.Replace("public", "public static");
					Console.WriteLine(methodSignature + "=>" + methodInfo.DeclaringType.Name + "." + methodInfo.Name + methodSignatureWithoutType);
  				}
			}

			Console.WriteLine(classEndName);

		}
	}
}

//Bogus.DataSets.