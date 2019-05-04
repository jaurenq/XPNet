﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace XPNet.CLR.CodeGen
{
    class Program
    {
        static void Main(string[] args)
        {
            if(Directory.Exists("../XPNet.CLR/Data/GeneratedDataRefs"))
                Directory.Delete("../XPNet.CLR/Data/GeneratedDataRefs", true);
            Console.WriteLine($"Reading Datarefs from: {args[0]}");
            IEnumerable<string> dataRefs = Enumerable.Empty<string>();

            if (args.Length > 0 && File.Exists(args[0]))
            {
                dataRefs = File.ReadLines(args[0]);
                Console.WriteLine("Successfully read DataRefs");
            }
            var dataRefClasses = dataRefs
                .Where(d => d.StartsWith("sim") && !d.Contains("???"))
                .Select(d => d.Replace("\t-", " -")) //replace unit tabs with spaces
                .Select(d => d.Split('\t'))
                .Select(d => new DataRef
                {
                    ParentPath = d[0],
                    Name = d[0].LastElementOfPath(),
                    Type = d[1],
                    IsWriteable = d[2] == "y",
                    Units = d.Skip(3).FirstOrDefault(),
                    Description = d.LastOrDefault(f => f.Contains(' '))
                })
                .GroupBy(d =>
                    String.Join("/", d.ParentPath.Split('/').SkipLast(1))
                    , d => d,
                    (path, members) => new DictionaryTree<DataRef>(path, members));

            var classTree = new DictionaryTree<DataRef>("Sim");
            foreach (var d in dataRefClasses)
            {
                var path = d.Name.Split('/');
                var curNode = classTree;
                for (int i = 1; i < path.Length; i++)
                {
                    if (!curNode.Children.ContainsKey(path[i]))
                    {
                        curNode.Children[path[i]] = new DictionaryTree<DataRef>(
                            String.Join('/', path.Take(i + 1)),
                            i == path.Length - 1 ? d.Members : null);
                    }
                    curNode = curNode.Children[path[i]];
                }
            }

            BuildClassDefs(classTree);
            Console.WriteLine("Successfully generated DataRefs");
        }


        public static void BuildClassDefs(DictionaryTree<DataRef> node)
        {
            foreach (var child in node.Children.Values)
            {
                BuildClassDefs(child);
            }

            node.ClassDef = (node.Name == "Sim" ? simTemplate : nonSimTemplate)
                .Replace("{item}", node.Name.Replace('/', '_'))
                .Replace("{childInits}", string.Join("", node.Children.Values.Select(c => $"\n{initsIndent}{c.Name.LastElementOfPath().FixupSpecialKeywords()} = new {c.Name.Replace('/', '_')}DataRefs(data);")))
                .Replace("{childProps}", string.Join("", node.Children.Values.Select(c => $"\n{propsIndent}public {c.Name.Replace('/', '_')}DataRefs {c.Name.LastElementOfPath().FixupSpecialKeywords()} {{ get; }}")))
                .Replace("{members}", string.Join("", node.Members.Select(m =>
                    {
                        string result = string.Empty;
                        if (m.Units == null) 
                            return result;

                        if (m.Units.Equals("string", StringComparison.OrdinalIgnoreCase))
                            return  CreateDataProperty<string>(m);

                        if (m.Units.StartsWith("string[", StringComparison.OrdinalIgnoreCase))
                            return  CreateDataProperty<string[]>(m);

                        if ((m.Units.Equals("bool") || m.Units.Equals("boolean")) && m.Type.Contains("int["))
                            return  CreateDataProperty<bool[]>(m);

                        if ((m.Units.Equals("bool") || m.Units.Equals("boolean")) && m.Type.Equals("int"))
                            return  CreateDataProperty<bool>(m);

                        if (m.Type.Equals("float", StringComparison.OrdinalIgnoreCase))
                            return  CreateDataProperty<float>(m);

                        if (m.Type.StartsWith("float[", StringComparison.OrdinalIgnoreCase))
                            return CreateDataProperty<float[]>(m);

                        if (!m.Units.Contains("bool") && m.Type.Equals("int"))
                            return  CreateDataProperty<int>(m);

                        if (!m.Units.Contains("bool") && m.Type.Contains("int["))
                            return  CreateDataProperty<int[]>(m);

                        if (m.Type.Equals("double", StringComparison.OrdinalIgnoreCase))
                            return  CreateDataProperty<double>(m);

                        if (m.Units.Equals("index", StringComparison.OrdinalIgnoreCase) && m.Type.StartsWith("byte["))
                            return  CreateDataProperty<string[]>(m);

                        throw new Exception($"Unhandled type: {m.Type}, Units={m.Units}");
                    })
                ));
            if (node.Name == "View")
            {
                Console.WriteLine(node.Members.Count());
            }

            var filePath = $"../XPNet.CLR/Data/GeneratedDataRefs/{node.Name}DataRefs.cs";
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            File.WriteAllText(filePath, node.ClassDef);
        }

        private static string CreateDataProperty<T>(DataRef m)
        {
            var name = typeof(T).Name;
            if(!typeMapping.ContainsKey(name))
                throw new Exception($"unknown type: {name}. Path={m.ParentPath}");
            return $"{m.Description.CreateSummaryComment(propsIndent, m.ParentPath, m.Units)}\n{propsIndent}public IXPDataRef<{typeMapping[name].TypeName}> {m.Name.FixupSpecialKeywords()} {{ get {{ return m_data.{typeMapping[name].MethodName}(\"{m.ParentPath.ToLower()}\");}} }}";
        }

        private static Dictionary<string, TypeData> typeMapping = new Dictionary<string, TypeData>()
        {
            {"Boolean", new TypeData("bool", "GetBool")},
            {"Boolean[]", new TypeData("bool[]", "GetBoolArray")},
            {"Single", new TypeData("float", "GetFloat")},
            {"Single[]", new TypeData("float[]", "GetFloatArray")},
            {"String", new TypeData("string", "GetString")},
            {"String[]", new TypeData("byte[]", "GetByteArray")},
            {"Int32", new TypeData("int", "GetInt")},
            {"Int32[]", new TypeData("int[]", "GetIntArray")},
            {"Double", new TypeData("double", "GetDouble")},
        };

        const string initsIndent = "            ";
        const string propsIndent = "        ";

        const string simTemplate = @"using System;
using System.Collections.Generic;
using System.Text;

namespace XPNet.Data
{
    public partial class SimDataRefs
    {
        partial void Init()
        {
            {childInits}
        }

        {childProps}{members}
    }
}";
        const string nonSimTemplate = @"using System;
using System.Collections.Generic;
using System.Text;

namespace XPNet.Data
{
    public class {item}DataRefs
    {
        private readonly IXPlaneData m_data;

        internal {item}DataRefs(IXPlaneData data)
        {
            m_data = data;
            {childInits}
        }{childProps}{members}
    }
}";
    }

    public class DictionaryTree<T>
    {
        public DictionaryTree(string name, IEnumerable<T> dataMembers = null)
        {
            Name = name;
            Members = dataMembers ?? Enumerable.Empty<T>();
            Children = new Dictionary<string, DictionaryTree<T>>();
        }
        public string Name;
        public IEnumerable<T> Members;
        public Dictionary<string, DictionaryTree<T>> Children;
        public string ClassDef { get; set; }
    }

    public class DataRef
    {
        public string ParentPath { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsWriteable { get; set; }
        public string Units { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"Parent: {this.ParentPath}\nName: {this.Name}\nType: {this.Type}\nWriteable: {this.IsWriteable}\nDescription: {this.Description}";
        }
    }

    public class TypeData 
    {
        public TypeData(string typeName, string methodName)
        {
            TypeName = typeName;
            MethodName = methodName;
        }

        public string TypeName { get; set; }
        public string MethodName { get; set; }
    }

    public static class Extensions
    {
        private static Regex bracketsRegex = new Regex(@"\[([0-9]*)\]");
        public static string PathNamesToUpper(this string path)
        {   
            var chars = path
                .Replace("\t-", " -") //replace unit tabs with spaces
                .ToCharArray();
            chars[0] = char.ToUpper(chars[0]);
            for (int i = 1; i < path.Length; i++)
            {
                if (chars[i] == '/' && chars.Length >= i)
                    chars[i + 1] = char.ToUpper(chars[i + 1]);
            }
            return new String(chars);
        }

        public static string LastElementOfPath(this string path)
        {
            return path.Substring(path.LastIndexOf('/') + 1);
        }

        public static string FixupSpecialKeywords(this string name)
        {
            if(name.Contains('['))
                return bracketsRegex.Replace(name, "_$1");
            else if(name.Equals("override"))
                return "override_";
            else return name;
        }
        public static string CreateSummaryComment(this string description, string indent, string path, string units = null)
        {
            var unitString = units == null ? string.Empty : $". Units:{units}";
            return $"\n\n{indent}/// <summary>\n{indent}///  {description}{unitString}\n{indent}///  Raw path: {path}\n{indent}/// </summary>";
        }
    }
}
