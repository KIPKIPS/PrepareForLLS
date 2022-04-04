using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ExportConfig {
    class Program {
        static int maxLayer = 0;
        private static readonly bool isMinify = false;
        private static string splicerN = "";
        private static string splicerT = "";
        private static Dictionary<string, string> typeDict = new Dictionary<string, string>();
        static void Main(string[] args) {
            splicerN = isMinify ? "" : "\n";
            splicerT = isMinify ? "" : "\t";
            if (args.Length > 0) {
                string root = args[0].Replace('\\', '/');
                string csvPath = root + "csv";
                string jsonPath = root + "json";
                Console.WriteLine("配置表目录:" + csvPath);
                Console.WriteLine("导出目标目录:" + jsonPath);
                //获取目录下所有文件
                DirectoryInfo csvDir = new DirectoryInfo(csvPath);
                FileSystemInfo[] csvFiles = csvDir.GetFileSystemInfos();
                int ignoreLine = 3;
                foreach (FileInfo fileInfo in csvFiles) {
                    if (fileInfo.Extension == ".csv") {
                        string str = string.Empty;
                        try {
                            using (StreamReader csvSR = new StreamReader(fileInfo.FullName, new UTF8Encoding())) {
                                str = csvSR.ReadToEnd();
                                csvSR.Close();
                            }
                            //以UTF-8 NO-BOM格式重新写入文件
                            Encoding newEncoding = new UTF8Encoding(false);
                            using (StreamWriter csvSW = new StreamWriter(fileInfo.FullName, false, newEncoding)) {
                                csvSW.Write(str);
                                csvSW.Close();
                                //Console.WriteLine(str);
                            }
                            string strLine = string.Empty;
                            FileStream csvFS = new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read);
                            StreamReader formatCsvSR = new StreamReader(csvFS, Encoding.Default);
                            int row = 0;
                            string[] keys = null;
                            string[] types = null;
                            string[] values;
                            string json = string.Empty;
                            string obj;
                            json += "[";
                            int curLayer = 0;
                            int commentNum = 0;
                            if (!typeDict.ContainsKey("__metatable")) {
                                typeDict.Add("__metatable", "true");
                            }
                            while ((strLine = formatCsvSR.ReadLine()) != null) {
                                // Console.WriteLine(strLine);
                                if (row != ignoreLine && row != 0) {
                                    if (row == 1) {
                                        keys = SplitCSVLineStr(strLine);
                                        for (int i = 0; i < keys.Length; i++) {
                                            if (keys[i].StartsWith('_')) {
                                                commentNum++;
                                            }
                                        }
                                    }
                                    if (row == 2) {
                                        types = SplitCSVLineStr(strLine);
                                    }
                                    obj = string.Empty;
                                    if (row >= 4) {
                                        values = SplitCSVLineStr(strLine);
                                        curLayer = 1;
                                        obj = splicerN + GetTableAndRecord(curLayer) + "{" + splicerN;
                                        for (int i = 0; i < values.Length; i++) {
                                            if (!keys[i].StartsWith('_')) {
                                                curLayer = 2;
                                                obj += GetTableAndRecord(curLayer);
                                                string value = string.Empty;
                                                switch (types[i]) {
                                                    case "int":
                                                        value = values[i];
                                                        break;
                                                    case "float":
                                                        value = values[i];
                                                        break;
                                                    case "bool":
                                                        value = values[i].ToLower();
                                                        break;
                                                    case "string":
                                                        value = "\"" + values[i] + "\"";
                                                        break;
                                                    case "list<int>":
                                                        value = GetNormalList(values[i], '|');
                                                        break;
                                                    case "list<float>":
                                                        value = GetNormalList(values[i], '|');
                                                        break;
                                                    case "list<bool>":
                                                        value = GetNormalList(values[i], '|');
                                                        break;
                                                    case "list<string>":
                                                        value = GetStringList(values[i], '|');
                                                        break;
                                                    case "list<list<int>>":
                                                        value = GetNormalNestList(values[i], curLayer);
                                                        break;
                                                    case "list<list<float>>":
                                                        value = GetNormalNestList(values[i], curLayer);
                                                        break;
                                                    case "list<list<bool>>":
                                                        value = GetNormalNestList(values[i], curLayer);
                                                        break;
                                                    case "list<list<string>>":
                                                        value = GetStringNestList(values[i], curLayer);
                                                        break;
                                                    case "dict<int,int>":
                                                        value = GetDict(values[i], curLayer);
                                                        break;
                                                    case "dict<int,float>":
                                                        value = GetDict(values[i], curLayer);
                                                        break;
                                                    case "dict<int,bool>":
                                                        value = GetDict(values[i], curLayer);
                                                        break;
                                                    case "dict<int,string>":
                                                        value = GetDict(values[i], curLayer, true);
                                                        break;
                                                    case "dict<float,int>":
                                                        value = GetDict(values[i], curLayer);
                                                        break;
                                                    case "dict<float,float>":
                                                        value = GetDict(values[i], curLayer);
                                                        break;
                                                    case "dict<float,bool>":
                                                        value = GetDict(values[i], curLayer);
                                                        break;
                                                    case "dict<float,string>":
                                                        value = GetDict(values[i], curLayer, true);
                                                        break;
                                                    case "dict<string,int>":
                                                        value = GetDict(values[i], curLayer);
                                                        break;
                                                    case "dict<string,float>":
                                                        value = GetDict(values[i], curLayer);
                                                        break;
                                                    case "dict<string,bool>":
                                                        value = GetDict(values[i], curLayer);
                                                        break;
                                                    case "dict<string,string>":
                                                        value = GetDict(values[i], curLayer, true);
                                                        break;
                                                }
                                                obj += string.Format("\"{0}\":{1}", keys[i], value);
                                                obj += (i == values.Length - 1 - commentNum) ? splicerN : ("," + splicerN);
                                                if (!typeDict.ContainsKey(keys[i])) {
                                                    // Console.WriteLine(keys[i] + "_" + types[i]);
                                                    typeDict.Add(keys[i], types[i]);
                                                }
                                            }
                                        }
                                        curLayer = 1;
                                        obj += GetTableAndRecord(curLayer) + "},";
                                        json += obj;
                                    }
                                    //Console.WriteLine("第"+row+"行:"+strLine);
                                }
                                row++;
                            }
                            curLayer = 1;
                            // metatable
                            string dt = splicerT + splicerT;
                            json += splicerN + splicerT + "{";
                            string typeStr = "";
                            int idx = 0;
                            string suffix;
                            // Console.WriteLine(typeDict.Count);
                            foreach (KeyValuePair<string, string> kvp in typeDict) {
                                idx++;
                                suffix = idx == typeDict.Count ? "" : ",";
                                typeStr += splicerN + dt + "\"" + kvp.Key + "\":" + "\"" + kvp.Value + "\"" + suffix;
                            }
                            json += typeStr + splicerN + splicerT + "}" + splicerN + "]";
                            for (int i = 0; i <= maxLayer; i++) {
                                json = json.Replace("," + splicerN + GetTable(i) + "]", splicerN + GetTable(i) + "]");
                            }
                            // end metatable
                            formatCsvSR.Close();
                            string exportFile = fileInfo.FullName.Replace("csv", "json");
                            if (!File.Exists(exportFile)) {
                                Console.WriteLine("创建文件" + exportFile);
                                FileStream createFS = File.Create(exportFile);
                                createFS.Close();
                            }
                            try {
                                using (FileStream jsonFS = File.Create(exportFile)) {
                                    byte[] info = new UTF8Encoding(true).GetBytes(json);
                                    // 向文件中写入一些信息。
                                    jsonFS.Write(info, 0, info.Length);
                                    jsonFS.Close();
                                }
                                Console.WriteLine(exportFile + "导出完成");
                            } catch (Exception ex) {
                                Console.WriteLine(ex.ToString());
                            }
                            //Console.WriteLine(json);
                        } catch (Exception ex) {
                            Console.WriteLine(ex.ToString());
                        }

                    }
                }
                // Console.WriteLine(jsonPath);
                // Console.WriteLine(root);
                string targetPath = root.Replace("/Config", "");
                // Console.WriteLine(targetPath);
                ListFiles(new DirectoryInfo(jsonPath), targetPath + "Client/Config", "json");
                Console.WriteLine("Copy finished");
            }

            Console.WriteLine("任意输入关闭控制台...");
            Console.ReadKey();
            Environment.Exit(0);
        }

        public static string[] SplitCSVLineStr(string str) {
            List<string> strList = new List<string>();
            string temp = string.Empty;
            bool doFind = false;
            for (int i = 0; i < str.Length; i++) {
                char c = str[i];
                if (c == '"' && !doFind) {
                    doFind = true;
                    continue;
                }
                if (doFind) {
                    if (c == '"') {
                        doFind = false;
                        strList.Add(temp);
                        temp = string.Empty;
                    } else {
                        temp += c;
                    }
                } else {
                    if (c == ',') {
                        if (temp != string.Empty) {
                            strList.Add(temp);
                            temp = string.Empty;
                        }
                    } else {
                        temp += c;
                    }
                }
            }
            if (temp != string.Empty) {
                strList.Add(temp);
            }

            // for (int i = 0; i < strList.Count; i++) {
            //     Console.WriteLine(strList[i]);
            // }
            return strList.ToArray();
        }

        /// <summary>
        /// 查找固定后缀文件
        /// </summary>
        /// <param name="info"></param>
        /// <param name="tarDir"></param>
        /// <param name="fileType"></param>
        /// <returns></returns>
        public static void ListFiles(FileSystemInfo info, string tarDir, string fileType) {
            if (!info.Exists)
                return;
            DirectoryInfo dir = info as DirectoryInfo;
            //不是目录
            if (dir == null)
                return;
            FileSystemInfo[] files = dir.GetFileSystemInfos();
            for (int i = 0; i < files.Length; i++) {
                FileInfo file = files[i] as FileInfo;
                if (file != null) {
                    //Console.WriteLine(file.Extension);
                    //if (file.Extension == "."+ fileType) {
                    if (file.Extension == "." + fileType) {
                        Console.WriteLine(file.FullName);
                        string desPath = tarDir + "/" + file.Name;
                        file.CopyTo(desPath, true);//允许覆盖文件
                    }
                } else { //子目录递归查找
                    ListFiles(files[i], tarDir, fileType);
                }
            }
        }

        /// <summary>
        /// dict<T,T>导出方案
        /// </summary>
        /// <param name="str">解析串</param>
        /// <param name="layer">层级</param>
        /// <returns>list对应的嵌套的json字符串</returns>
        public static string GetDict(string str, int layer, bool isString = false) {
            // Console.WriteLine(str);
            string res = "{";
            string[] arr = str.Split('|');
            int invalidNum = CalculateInvalidNum(arr);
            for (int i = 0; i < arr.Length; i++) {
                if (arr[i] != string.Empty) {
                    res += (splicerN + GetTable(layer + 1) + GetDictKeyValuePair(arr[i], '#', isString) + (i == arr.Length - 1 - invalidNum ? "" : ","));
                }
            }
            res += splicerN + GetTable(layer) + "}";
            return res;
        }

        public static string GetDictKeyValuePair(string str, char split, bool isString = false) {
            string[] arr = str.Split(split);
            string res = "";
            if (arr.Length == 2) {
                res = "\"" + arr[0] + "\":" + (isString ? "\"" + arr[1] + "\"" : arr[1]);
            }
            return res;
        }

        /// <summary>
        /// 嵌套list<list<数值型>>导出方案
        /// </summary>
        /// <param name="str">解析串</param>
        /// <param name="layer">层级</param>
        /// <returns>list对应的嵌套的json字符串</returns>
        static string GetNormalNestList(string str, int layer) {
            string[] arr = str.Split('|');
            string res = string.Empty;
            int invalidNum = CalculateInvalidNum(arr);
            res += "[";
            for (int i = 0; i < arr.Length; i++) {
                if (arr[i] != string.Empty) {
                    res += (splicerN + GetTable(layer + 1) + GetNormalList(arr[i], '#') + (i == arr.Length - 1 - invalidNum ? "" : ","));
                }
            }
            res += splicerN + GetTable(layer) + "]";
            return res;
        }
        /// <summary>
        /// 嵌套list<list<string>>导出方案
        /// </summary>
        /// <param name="str">解析串</param>
        /// <param name="layer">层级</param>
        /// <returns>list对应的嵌套的json字符串</returns>
        static string GetStringNestList(string str, int layer) {
            string[] arr = str.Split('|');
            string res = string.Empty;
            int invalidNum = CalculateInvalidNum(arr);
            res += "[";
            for (int i = 0; i < arr.Length; i++) {
                if (arr[i] != string.Empty) {
                    res += (splicerN + GetTable(layer + 1) + GetStringList(arr[i], '#') + (i == arr.Length - 1 - invalidNum ? "" : ","));
                }
            }
            res += splicerN + GetTable(layer) + "]";
            return res;
        }
        /// <summary>
        /// 根据指定类型(数值型)拆分字符串为数组并拼接成json数组
        /// </summary>
        /// <param name="str">解析串</param>
        /// <param name="split">划分字符</param>
        /// <returns>list对应的嵌套的json字符串</returns>
        static string GetNormalList(string str, char split) {
            string[] arr = str.Split(split);
            string res = string.Empty;
            int invalidNum = CalculateInvalidNum(arr);
            for (int i = 0; i < arr.Length; i++) {
                if (arr[i] != string.Empty) {
                    res += (arr[i] + (i == arr.Length - 1 - invalidNum ? "" : ","));
                }
            }
            return "[" + res + "]";
        }
        /// <summary>
        /// 根据指定类型(字符型)拆分字符串为数组并拼接成json数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        static string GetStringList(string str, char split) {
            string[] arr = str.Split(split);
            string res = string.Empty;
            int invalidNum = CalculateInvalidNum(arr);
            for (int i = 0; i < arr.Length; i++) {
                if (arr[i] != string.Empty) {
                    res += (("\"" + arr[i] + "\"") + (i == arr.Length - 1 - invalidNum ? "" : ","));
                }
            }
            return "[" + res + "]";
        }
        /// <summary>
        /// 拼接\t并记录最大拼接数量
        /// </summary>
        /// <param name="layer"></param>
        /// <returns></returns>
        static string GetTableAndRecord(int layer) {
            if (layer > maxLayer) {
                maxLayer = layer;
            }
            return GetTable(layer);
        }
        /// <summary>
        /// 拼接\t
        /// </summary>
        /// <param name="layer"></param>
        /// <returns></returns>
        static string GetTable(int layer) {
            string str = "";
            for (int i = 0; i < layer; i++) {
                str += splicerT;
            }
            return str;
        }
        /// <summary>
        /// 计算无效元素数量
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        static int CalculateInvalidNum(string[] strs) {
            int num = 0;
            for (int i = 0; i < strs.Length; i++) {
                if (strs[i] == string.Empty) {
                    num++;
                }
            }
            return num;
        }
    }
}