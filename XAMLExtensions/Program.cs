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
			 new RunTests();
			//BogusClassGenerator();
			//ResourceDictionaryGenerator();
		    // BogusClassTestObjectsGenerator();
		}

		private static void BogusClassTestObjectsGenerator()
		{
			var allTypes = AppDomain.CurrentDomain.GetAssemblies()
				.Where(a => a.FullName.Contains(BogusAssembly))
				.SelectMany(s => s.GetTypes())
				.Where(m => !m.IsAbstract)
				.Where(typeof(IHasRandomizer).IsAssignableFrom);


			var allmethods = allTypes
				.SelectMany(m => m.GetMethods())
				.Where(m => m.DeclaringType != typeof(object))
				.Where(m => !m.IsGenericMethod)
				.Where(m => !m.IsGenericMethodDefinition)
				.Where(m => !m.IsConstructedGenericMethod)
				.Where(m => m != typeof(IHasRandomizer))
				.Where(mi => !mi.IsSpecialName);
   

			foreach (MethodInfo methodInfo in allmethods)
			{
				var varname = @"var ";
                
				Console.Write(varname);

				var methodSignature = methodInfo.GetSignature();
				var methodSignatureWithoutType = methodInfo.GetSignatureWithoutType();

				if (!methodSignature.Contains(Static))
				{
					var methodcall = methodInfo.Name + " = BogusGenerator." + methodInfo.Name;
					Console.Write(methodcall);



					var argumentsStart = "(";
					Console.Write(argumentsStart);

					foreach (var parameter in methodInfo.GetParameters())
					{
						var isGenericType = parameter.ParameterType;
						if (isGenericType.IsGenericType && isGenericType.GetGenericTypeDefinition() == typeof(Nullable<>))
						{
							var typeName = isGenericType.GetGenericArguments()[0].Name;
							var parameterType = parameter.ParameterType;
							var param = parameter.DefaultValue;
							Console.Write(param);
						}
						else
						{
							var parameterType = parameter.ParameterType;
							var param = parameter.DefaultValue;
							Console.Write(param);
						}


					}

					var argumentsEnd = ")";
					Console.Write(argumentsEnd);
					var varend = ";";
					Console.Write(varend);
                    Console.WriteLine("");
                    				 
					Console.WriteLine("Console.WriteLine(\"" + methodInfo.Name + ":\" +"+ methodInfo.Name +");");

                     
				}
			}



		}

		private static void BogusClassGenerator()
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

		private static void ResourceDictionaryGenerator()
		{
			var allTypes = AppDomain.CurrentDomain.GetAssemblies()
				.Where(a => a.FullName.Contains(BogusAssembly))
				.SelectMany(s => s.GetTypes())
				.Where(m => !m.IsAbstract)
				.Where(typeof(IHasRandomizer).IsAssignableFrom);


			var allmethods = allTypes
				.SelectMany(m => m.GetMethods())
				.Where(m => m.DeclaringType != typeof(object))
				.Where(m => !m.IsGenericMethod)
				.Where(m => !m.IsGenericMethodDefinition)
				.Where(m => !m.IsConstructedGenericMethod)
				.Where(m => m != typeof(IHasRandomizer))
				.Where(mi => !mi.IsSpecialName);

			var resourceDictionaryStart = @"<ResourceDictionary>";

			Console.WriteLine(resourceDictionaryStart);


			foreach (MethodInfo methodInfo in allmethods)
			{

				var methodSignature = methodInfo.GetSignature();
				var methodSignatureWithoutType = methodInfo.GetSignatureWithoutType();

				if (!methodSignature.Contains(Static))
				{
					var staticResourceStart = "<local:BogusGenerator x:Key=\"" + methodInfo.Name + "\" x:FactoryMethod=\"" + methodInfo.Name + "\">";
					Console.WriteLine(staticResourceStart);


					if (methodInfo.GetParameters().Any())
					{
						var argumentsStart = " <x:Arguments>";
						Console.WriteLine(argumentsStart);
					}
					foreach (var parameter in methodInfo.GetParameters())
					{
						var isGenericType = parameter.ParameterType;
						if (isGenericType.IsGenericType && isGenericType.GetGenericTypeDefinition() == typeof(Nullable<>))
						{
							var typeName = isGenericType.GetGenericArguments()[0].Name;
							var parameterType = parameter.ParameterType;
							var param = "<x:" + typeName + ">" + parameter.DefaultValue + "</x:" + typeName + ">";
							Console.WriteLine(param);
						}
						else
						{
							var parameterType = parameter.ParameterType;
							var param = "<x:" + parameterType + ">" + parameter.DefaultValue + "</x:" + parameterType + ">";
							Console.WriteLine(param);
						}


					}
					if (methodInfo.GetParameters().Any())
					{
						var argumentsEnd = " </x:Arguments>";
						Console.WriteLine(argumentsEnd);
					}
					var staticResourceEnd = "</local:BogusGenerator>";
					Console.WriteLine(staticResourceEnd);
				}
			}

			var resourceDictionaryEnd = @"</ResourceDictionary>";
			Console.WriteLine(resourceDictionaryEnd);
		}
	}
}

//Bogus.DataSets.