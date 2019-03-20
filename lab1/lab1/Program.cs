using System;
using System.Collections.Generic;
using System.Reflection;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Информация по типам:"
                + "\n1 – Общая информация по типам"
                + "\n2 – Выбрать из списка"
                + "\n3 – Ввести имя типа"
                + "\n4 – Параметры консоли"
                + "\n0 - Выход из программы");
                switch (char.ToLower(Console.ReadKey(true).KeyChar))
                {
                    case '1': Help(); break;
                    case '2': ChooseFromList(); break;
                    case '3': EnterTypeName(); break;
                    case '4': ConsoleParams(); break;
                    case '0': return;
                }
            }
        }

        private static void ConsoleParams()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(@"1 - Цвет текста
2 - цвет фона
0 - вернуться в главное меню");
                switch (char.ToLower(Console.ReadKey(true).KeyChar))
                {
                    case '1': SetFontColor(); break;
                    case '2': SetBackgroundColor(); break;
                    case '0': return;
                }
            }
        }

        private static void SetFontColor()
        {
            Console.Clear();
            Console.WriteLine("Цвет текста");
            Console.ForegroundColor = askForColor();
        }

        private static void SetBackgroundColor()
        {
            Console.Clear();
            Console.WriteLine("Цвет фона");
            Console.BackgroundColor = askForColor();
        }

        private static ConsoleColor askForColor()
        {
            var values = (ConsoleColor[])Enum.GetValues(typeof(ConsoleColor));
            for (int i = 0; i < values.Length; i++)
            {
                Console.WriteLine("{0} - {1}", i, values[i].ToString());
            }
            int choose;
            while (!int.TryParse(Console.ReadLine(), out choose)
                && (choose < 0 || choose >= values.Length)) { }
            return values[choose];
        }

        private static void EnterTypeName()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите полное имя типа:");
                string input = Console.ReadLine();
                if (input == "0")
                {
                    return;
                }
                Type t = GetTypeFromName(input);
                if (t == null)
                {
                    continue;
                }
                PrintTypeInfo(t);
                return;
            }
        }

        private static Type GetTypeFromName(string input)
        {
            return Type.GetType(input);
        }

        private static void ChooseFromList()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(@"Выберете тип из списка:
1 – uint
2 – int
3 – long
4 – float
5 – double
6 – char
7 - string
8 – MyClass
9 – MyStruct
0 – Выход в главное меню");
                char inputKey = char.ToLower(Console.ReadKey(true).KeyChar);
                if (inputKey == '0')
                {
                    return;
                }
                Type type = GetType(inputKey);
                PrintTypeInfo(type);
                return;
            }
        }

        private static string[] GetNames(Type type, MemberInfo[] infos)
        {
            string[] fieldNames = new string[infos.Length];
            for (int i = 0; i < infos.Length; i++)
            {
                fieldNames[i] = infos[i].Name;
            }
            return fieldNames;
        }

        private static void PrintTypeInfo(Type type)
        {
            string[] propertyNames = new string[type.GetProperties().Length];
            for (int i = 0; i < type.GetProperties().Length; i++)
            {
                propertyNames[i] = type.GetProperties()[i].Name;
            }
            Console.Clear();
            Console.WriteLine(@"Информация по типу: {0}
Значимый тип: {1}
Пространство имен: {2}
Сборка: {3}
Общее число элементов: {4}
Число методов: {5}
Число свойств: {6}
Число полей: {7}
Список полей: {8}
Список свойств: {9}
Нажмите ‘M’ для вывода дополнительной информации по методам:
Нажмите ‘0’ для выхода в главное меню",
            type.FullName,
            type.IsValueType,
            type.Namespace,
            type.Assembly.GetName().Name,
            type.GetMembers().Length,
            type.GetMethods().Length,
            type.GetProperties().Length,
            type.GetFields().Length,
            (type.GetFields().Length == 0 ? "-" : string.Join(", ", GetNames(type, type.GetFields()))),
            (type.GetProperties().Length == 0 ? "-" : string.Join(", ", GetNames(type, type.GetProperties())))
            );

            switch (char.ToLower(Console.ReadKey(true).KeyChar))
            {
                case '0': return;
                case 'm':
                    ShowAllTypeInfo(type);
                    return;
            }
        }

        private static void ShowAllTypeInfo(Type type)
        {
            Dictionary<string, GroupedMethodInfo> groupedMethodInfos = new Dictionary<string, GroupedMethodInfo>();
            foreach (MethodInfo info in type.GetMethods())
            {
                int argsAmount = info.GetParameters().Length;
                if (groupedMethodInfos.ContainsKey(info.Name))
                {
                    GroupedMethodInfo gmi = groupedMethodInfos[info.Name];
                    gmi.overloads++;
                    if (gmi.argsMin > argsAmount)
                    {
                        gmi.argsMin = argsAmount;
                    }
                    if (gmi.argsMax < argsAmount)
                    {
                        gmi.argsMax = argsAmount;
                    }
                }
                else
                {
                    groupedMethodInfos.Add(info.Name, new GroupedMethodInfo() { overloads = 1, argsMin = argsAmount, argsMax = argsAmount });
                }

            }
            Console.Clear();
            Console.WriteLine(@"Методы типа {0}
Название    Число перегрузок    Число параметров",
            type.FullName
            );
            foreach (var kv in groupedMethodInfos)
            {
                Console.WriteLine(@"{0} {1}", kv.Key, kv.Value.ToString());
            }
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey(true);
        }

        private static Type GetType(char typeName)
        {
            switch (typeName)
            {
                case '1': return typeof(uint);
                case '2': return typeof(int);
                case '3': return typeof(long);
                case '4': return typeof(float);
                case '5': return typeof(double);
                case '6': return typeof(char);
                case '7': return typeof(string);
                case '8': return typeof(Program);
                case '9': return typeof(GroupedMethodInfo);
            }
            return null;
        }

        private static void Help()
        {
            Assembly myAsm = Assembly.GetExecutingAssembly();
            Type[] thisAssemblyTypes = myAsm.GetTypes();
            Assembly[] refAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            List<Type> types = new List<Type>();
            foreach (Assembly asm in refAssemblies)
            {
                types.AddRange(asm.GetTypes());
            }
            int nRefTypes = 0;
            int nValueTypes = 0;
            int nInterfaceTypes = 0;
            Type typeWithMaxMethodsAmount = null;
            int maxMethodsAmount = 0;
            string methodWithTheLongestName = "";
            int maxArgsAmount = 0;
            string methodWithMaxArgsAmount = null;

            foreach (var t in types)
            {
                if (t.IsClass)
                {
                    nRefTypes++;
                }
                else if (t.IsValueType)
                {
                    nValueTypes++;
                }
                else if (t.IsInterface)
                {
                    nInterfaceTypes++;
                }
                if (maxMethodsAmount < t.GetMethods().Length)
                {
                    typeWithMaxMethodsAmount = t;
                    maxMethodsAmount = t.GetMethods().Length;
                }
                if (methodWithTheLongestName.Length < t.Name.Length)
                {
                    methodWithTheLongestName = t.Name;
                }
                foreach (var item in t.GetMethods())
                {
                    if (maxArgsAmount < item.GetParameters().Length)
                    {
                        maxArgsAmount = item.GetParameters().Length;
                        methodWithMaxArgsAmount = item.Name;
                    }
                }
            }
            Console.Clear();
            Console.WriteLine(@"Общая информация по типам
Подключенные сборки: {0} 17
Всего типов по всем подключенным сборкам: {1} 26103
Ссылочные типы: {2} 20601
Значимые типы: {3} 4377
Типы-интерфейсы: {4}
Тип с максимальным числом методов: {5}
Самое длинное название метода: {6}
Метод с наибольшим числом аргументов: {7}
Нажмите любую клавишу, чтобы вернуться в главное меню",
            thisAssemblyTypes.Length,
            types.Count,
            nRefTypes,
            nValueTypes,
            nInterfaceTypes,
            typeWithMaxMethodsAmount.Name,
            methodWithTheLongestName,
            methodWithMaxArgsAmount
            );
            Console.ReadKey();
        }
    }

    struct GroupedMethodInfo
    {
        public int overloads { get; set; }
        public int argsMin { get; set; }
        public int argsMax { get; set; }

        public override string ToString()
        {
            return "" + overloads + "\t" + (argsMin == argsMax ? argsMin.ToString() : "" + argsMin + ".." + argsMax);
        }
    }
}
