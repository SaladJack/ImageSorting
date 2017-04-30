using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;
using System.IO;
using System.Collections;
using System.Drawing.Imaging;
using HVS;
using System.Windows.Media.Imaging;
using System.Threading;
using Microsoft.VisualBasic;
//using System.Windows.Media.Imaging.BitmapSource;
using System.Diagnostics;


namespace HVS
{
    /// <summary>
    /// 自定义类TreeViewItems 调用其Add(TreeNode e)方法加载子目录
    /// </summary>
    ///  
    public class Help
    {
    }
    public static class TreeViewItems
    {
        static int filecount;//当前文件夹下文件数目
        static FileInfo[] file=null;
        static TreeNode tNode;
        static TreeView treeView1;
      
        //添加结点e
        public static  void Add(TreeNode e,TreeView treeView11)
        {
           
            treeView1 = treeView11;
            //try..catch异常处理
            try
            {
                //判断"我的电脑"Tag 上面加载的该结点没指定其路径
                if (e.Name.ToString() != "我的电脑")
                {
                    e.Nodes.Clear();                               //清除空节点再加载子节点
                    tNode = e;                       
                    string path = tNode.Name;                      //路径  
                    DirectoryInfo dirs = new DirectoryInfo(path); //获得程序所在路径的目录对象
                    DirectoryInfo[] dir = dirs.GetDirectories();//获得目录下文件夹对象
                    file = null;
                    file = dirs.GetFiles();//获得目录下文件对象
                    int dircount = dir.Count();//获得文件夹对象数量
                     filecount = file.Count();//获得文件对象数量

                    //循环文件夹，向该结点添加文件夹结点，设置结点路径Name,结点缩略图，并给文件夹结点添加空结点以便显示+展开符号
                    for (int i = 0; i < dircount; i++)
                    {
                         TreeNode temp = new TreeNode(dir[i].Name);
                        temp.Name = path + "\\" + dir[i].Name;
                        temp.ImageIndex = IconIndexes.Folder;
                        temp.SelectedImageIndex = IconIndexes.Folder;
                        tNode.Nodes.Add(temp);
                        foreach (TreeNode t in tNode.Nodes)
                        {
                            t.Nodes.Add("");
                        }
                    }

                    //循环文件，判断文件是否是图片，若不是不添加至当前结点
                    //若是文件，添加结点，设置路径Name,缩略图
                    for (int j = 0; j < filecount; j++)
                    {
                        if (file[j].Extension != ".bmp" && file[j].Extension != ".jpg" && file[j].Extension != ".jpeg" && file[j].Extension != ".png" && file[j].Extension != ".gif")
                        {
                            break;
                        }
                        else
                        {
                             TreeNode temp = new TreeNode(file[j].Name);
                       
                            temp.Name = path + "\\" + file[j].Name;

                            
                            Image img = Image.FromFile(temp.Name);
                            treeView1.ImageList.Images.Add(img);//向treeview listview添加图片
                            int index = treeView1.ImageList.Images.Count - 1;
                            temp.ImageIndex = index;
                            temp.SelectedImageIndex = index;
                            tNode.Nodes.Add(temp);
                        }
                    }
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n出错的位置为：TreeViewItems()");
          
            }
        }
    }
}
