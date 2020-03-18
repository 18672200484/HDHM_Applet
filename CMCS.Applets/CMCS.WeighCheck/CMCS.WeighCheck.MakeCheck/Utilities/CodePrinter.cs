using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
//
using DevComponents.DotNetBar;

/// <summary>
/// 磅单打印
/// </summary>
public class CodePrinter
{
    Font FontContent = new Font("宋体", 12, FontStyle.Regular, GraphicsUnit.Pixel);
    PrintDocument PringDoc = null;
    DotNetBarcode bc = new DotNetBarcode();

    /// <summary>
    /// 联索引
    /// </summary>
    int PageIndex = 0;
    List<string> _listCode = new List<string>();

    /// <summary>
    /// TicketPrint
    /// </summary>
    /// <param name="pringDoc">PrintDocument</param>
    public CodePrinter(PrintDocument pringDoc)
    {
        bc.Type = DotNetBarcode.Types.QRCode;
        bc.PrintCheckDigitChar = true;
        bc.PrintChar = true;
        bc.PrintCheckDigitChar = true;

        this.PringDoc = pringDoc;
        this.PringDoc.DefaultPageSettings.PaperSize = new PaperSize("Custum", 320, 160);
        this.PringDoc.OriginAtMargins = true;
        this.PringDoc.DefaultPageSettings.Margins.Left = 0;
        this.PringDoc.DefaultPageSettings.Margins.Right = 0;
        this.PringDoc.DefaultPageSettings.Margins.Top = 0;
        this.PringDoc.DefaultPageSettings.Margins.Bottom = 0;
        this.PringDoc.DefaultPageSettings.Landscape = false;
        this.PringDoc.PrintController = new StandardPrintController();
        this.PringDoc.PrintPage += new PrintPageEventHandler(prtdoc_PrintPage);
    }

    /// <summary>
    /// 打印
    /// </summary>
    /// <param name="listCode"></param>
    public void Print(List<string> listCode)
    {
        try
        {
            this._listCode.Clear();
            foreach (string item in listCode)
            {
                this._listCode.Add(item);
            }

            this.PringDoc.Print();
        }
        catch (Exception ex)
        {
            MessageBoxEx.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// 打印单个
    /// </summary>
    /// <param name="Code"></param>
    public void Print(string Code)
    {
        try
        {
            this._listCode.Clear();
            this._listCode.Add(Code);
            this.PringDoc.Print();
        }
        catch (Exception ex)
        {
            MessageBoxEx.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    void prtdoc_PrintPage(object sender, PrintPageEventArgs e)
    {
        if (_listCode != null)
        {
            if (_listCode.Count > 0)
            {
                if (PageIndex == _listCode.Count) PageIndex = 0;
                Graphics g = e.Graphics;
                e.HasMorePages = true; //此处打开多页打印属性
                bc.WriteBar(_listCode[PageIndex], 40, 20, 140, 140, g);
                float titleWidth = g.MeasureString(_listCode[PageIndex], FontContent).Width;
                g.DrawString(_listCode[PageIndex], FontContent, Brushes.Black, new PointF((140 - titleWidth) / 2 + 30, 20));

                //在左上角0,0的位置打印图像
                if (PageIndex == _listCode.Count - 1) //共打印10张
                    e.HasMorePages = false; //关掉多页打印属性
                PageIndex++;             //il是一个计数器，即页数
            }
        }
    }

    #region 加、解密字符串
    static string encryptKey = "Oyea";    //定义密钥

    /// <summary>
    /// 加密字符串
    /// </summary>  
    /// <param name="str">要加密的字符串</param>  
    /// <returns>加密后的字符串</returns>  
    public string Encrypt(string str)
    {
        try
        {
            DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();   //实例化加/解密类对象   

            byte[] key = Encoding.Unicode.GetBytes(encryptKey); //定义字节数组，用来存储密钥    

            byte[] data = Encoding.Unicode.GetBytes(str);//定义字节数组，用来存储要加密的字符串  

            MemoryStream MStream = new MemoryStream(); //实例化内存流对象      

            //使用内存流实例化加密流对象   
            CryptoStream CStream = new CryptoStream(MStream, descsp.CreateEncryptor(key, key), CryptoStreamMode.Write);

            CStream.Write(data, 0, data.Length);  //向加密流中写入数据      

            CStream.FlushFinalBlock();              //释放加密流      

            return Convert.ToBase64String(MStream.ToArray());//返回加密后的字符串
        }
        catch (Exception ex)
        {
            //MessageBoxEx.Show("加密失败" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return str;
        }
    }

    /// <summary>  
    /// 解密字符串   
    /// </summary>  
    /// <param name="str">要解密的字符串</param>  
    /// <returns>解密后的字符串</returns>  
    public string Decrypt(string str)
    {
        try
        {
            DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();   //实例化加/解密类对象    

            byte[] key = Encoding.Unicode.GetBytes(encryptKey); //定义字节数组，用来存储密钥    

            byte[] data = Convert.FromBase64String(str);//定义字节数组，用来存储要解密的字符串  

            MemoryStream MStream = new MemoryStream(); //实例化内存流对象      

            //使用内存流实例化解密流对象       
            CryptoStream CStream = new CryptoStream(MStream, descsp.CreateDecryptor(key, key), CryptoStreamMode.Write);

            CStream.Write(data, 0, data.Length);      //向解密流中写入数据     

            CStream.FlushFinalBlock();               //释放解密流      

            return Encoding.Unicode.GetString(MStream.ToArray());       //返回解密后的字符串  
        }
        catch (Exception ex)
        {
            //MessageBoxEx.Show("解密失败" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return str;
        }
    }
    #endregion
}

