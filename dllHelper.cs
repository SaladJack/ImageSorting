using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace HVS
{
    public class dllHelper
    {
        public string FR_dll_path;
        public string RR_dll_path;
        public string NR_dll_path;
        public Dictionary<string, Type> FR_methods;
        public Dictionary<string, Type> RR_methods;
        public Dictionary<string, Type> NR_methods;

        public dllHelper(string FR_dll_path, string RR_dll_path, string NR_dll_path)
        {
            this.FR_dll_path = FR_dll_path;
            this.RR_dll_path = RR_dll_path;
            this.NR_dll_path = NR_dll_path;
            get_methods();
        }

        public void get_methods()
        {
            FR_methods = getFR_methods();
            RR_methods = getRR_methods();
            NR_methods = getNR_methods();
        }

        public Dictionary<string, Type> getFR_methods()
        {
            NR_methods = new Dictionary<string, Type>();
            Assembly assembly;
            Type[] tys;
            if (Directory.Exists(FR_dll_path))
            {
                DirectoryInfo dllFolder = new DirectoryInfo(FR_dll_path);
                FileInfo[] dllInfo = dllFolder.GetFiles();
                foreach (FileInfo dllFile in dllInfo)
                {
                    if (isDll(dllFile.Name))
                    {
                        try
                        {
                            assembly = Assembly.LoadFile(dllFile.FullName);
                            tys = assembly.GetTypes();
                            foreach (Type ty in tys)
                            {
                                if (ty.Name == "FR")
                                {
                                    NR_methods[dllFile.Name.Substring(0, dllFile.Name.Length - 4)] = ty;
                                    break;
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }
                    }
                }
            }
            return NR_methods;
        }

        public Dictionary<string, Type> getRR_methods()
        {
            NR_methods = new Dictionary<string, Type>();
            Assembly assembly;
            Type[] tys;
            if (Directory.Exists(RR_dll_path))
            {
                DirectoryInfo dllFolder = new DirectoryInfo(RR_dll_path);
                FileInfo[] dllInfo = dllFolder.GetFiles();
                foreach (FileInfo dllFile in dllInfo)
                {
                    if (isDll(dllFile.Name))
                    {
                        try
                        {
                            assembly = Assembly.LoadFile(dllFile.FullName);
                            tys = assembly.GetTypes();
                            foreach (Type ty in tys)
                            {
                                if (ty.Name == "RR")
                                {
                                    NR_methods[dllFile.Name.Substring(0, dllFile.Name.Length - 4)] = ty;
                                    break;
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }
                    }
                }
            }
            return NR_methods;
        }

        public Dictionary<string, Type> getNR_methods()
        {
            NR_methods = new Dictionary<string, Type>();
            Assembly assembly;
            Type[] tys;
            if (Directory.Exists(NR_dll_path))
            {
                DirectoryInfo dllFolder = new DirectoryInfo(NR_dll_path);
                FileInfo[] dllInfo = dllFolder.GetFiles();
                foreach (FileInfo dllFile in dllInfo)
                {
                    if (isDll(dllFile.Name))
                    {
                        try
                        {
                            assembly = Assembly.LoadFile(dllFile.FullName);
                            tys = assembly.GetTypes();
                            foreach (Type ty in tys)
                            {
                                if (ty.Name == "NR")
                                {
                                    NR_methods[dllFile.Name.Substring(0, dllFile.Name.Length - 4)] = ty;
                                    break;
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }
                    }
                }
            }
            return NR_methods;
        }

        public bool isDll(string dllName)
        {
            int length = dllName.Length;
            if (length <= 4 || dllName.Substring(length - 4, 4) != ".dll")
            {
                return false;
            }
            return true;
        }

        public void change_FR_dll_path(string FR_dll_path)
        {
            this.FR_dll_path = FR_dll_path;
        }

        public void change_RR_dll_path(string RR_dll_path)
        {
            this.RR_dll_path = RR_dll_path;
        }

        public void change_NR_dll_path(string NR_dll_path)
        {
            this.NR_dll_path = NR_dll_path;
        }
    }
}
