using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Runtime.InteropServices;

namespace LED.YB14
{
    /// <summary>
    /// 上海仰邦 LED 14版DLL LedDynamicArea 动态区域
    /// </summary>
    public class YB14DynamicAreaLeder
    {
        /// <summary>
        /// 向动态库中添加显示屏信息；该函数不与显示屏通讯。
        /// </summary>
        /// <param name="nControlType">显示屏的控制器型号，目前该动态区域动态库只支持BX-5E1、BX-5E2、BX-5E3等BX-5E系列控制器。</param>
        /// <param name="nScreenNo">显示屏屏号；该参数与LedshowTW 2013软件中"设置屏参"模块的"屏号"参数一致。</param>
        /// <param name="nSendMode">通讯模式；目前动态库中支持0:串口通讯；2：网络通讯(只支持固定IP模式)；5：保存到文件等三种通讯模式。</param>
        /// <param name="nWidth">显示屏宽度；单位：像素。</param>
        /// <param name="nHeight">显示屏高度；单位：像素。</param>
        /// <param name="nScreenType">显示屏类型；1：单基色；2：双基色。</param>
        /// <param name="nPixelMode">点阵类型，只有显示屏类型为双基色时有效；1：R+G；2：G+R。</param>
        /// <param name="pCom">通讯串口，只有在串口通讯时该参数有效；例："COM1"</param>
        /// <param name="nBaud">通讯串口波特率，只有在串口通讯时该参数有效；目前只支持9600、57600两种波特率。</param>
        /// <param name="pSocketIP">控制器的IP地址；只有在网络通讯(固定IP模式)模式下该参数有效，例："192.168.0.199"</param>
        /// <param name="nSocketPort">控制器的端口地址；只有在网络通讯(固定IP模式)模式下该参数有效，例：5005</param>
        /// <param name="pCommandDataFile">保存到文件方式时，命令保存命令文件名称。只有在保存到文件模式下该参数有效，例："curCommandData.dat"</param>
        /// <returns>详见返回状态代码定义</returns>
        [DllImport("LedDynamicArea.dll")]
        public static extern int AddScreen(int nControlType, int nScreenNo, int nSendMode, int nWidth, int nHeight,
              int nScreenType, int nPixelMode, string pCom, int nBaud, string pSocketIP, int nSocketPort,
              string pCommandDataFile);

        /// <summary>
        /// 向动态库中指定显示屏添加动态区域；该函数不与显示屏通讯。
        /// </summary>
        /// <param name="nScreenNo">显示屏屏号；该参数与AddScreen函数中的nScreenNo参数对应。</param>
        /// <param name="nDYAreaID">动态区域编号；目前系统中最多5个动态区域；该值取值范围为0~4;</param>
        /// <param name="nRunMode">动态区域运行模式：0:动态区数据循环显示；1:动态区数据显示完成后静止显示最后一页数据； 2:动态区数据循环显示，超过设定时间后数据仍未更新时不再显示；3:动态区数据循环显示，超过设定时间后数据仍未更新时显示Logo信息,Logo 信息即为动态区域的最后一页信息；4:动态区数据顺序显示，显示完最后一页后就不再显示</param>
        /// <param name="nTimeOut">动态区数据超时时间；单位：秒 </param>
        /// <param name="nAllProRelate">节目关联标志；1：所有节目都显示该动态区域；0：在指定节目中显示该动态区域，如果动态区域要独立于节目显示，则下一个参数为空。</param>
        /// <param name="pProRelateList">节目关联列表，用节目编号表示；节目编号间用","隔开,节目编号定义为LedshowTW 2013软件中"P***"中的"***"</param>
        /// <param name="nPlayImmediately">动态区域是否立即播放0：该动态区域与异步节目一起播放；1：异步节目停止播放，仅播放该动态区域</param>
        /// <param name="nAreaX">动态区域起始横坐标；单位：像素</param>
        /// <param name="nAreaY">动态区域起始纵坐标；单位：像素</param>
        /// <param name="nAreaWidth">动态区域宽度；单位：像素</param>
        /// <param name="nAreaHeight">动态区域高度；单位：像素</param>
        /// <param name="nAreaFMode">动态区域边框显示标志；0：纯色；1：花色；255：无边框</param>
        /// <param name="nAreaFLine">动态区域边框类型, 纯色最大取值为FRAME_SINGLE_COLOR_COUNT；花色最大取值为：FRAME_MULI_COLOR_COUNT</param>
        /// <param name="nAreaFColor">边框显示颜色；选择为纯色边框类型时该参数有效；</param>
        /// <param name="nAreaFStunt">边框运行特技；0：闪烁；1：顺时针转动；2：逆时针转动；3：闪烁加顺时针转动；4:闪烁加逆时针转动；5：红绿交替闪烁；6：红绿交替转动；7：静止打出</param>
        /// <param name="nAreaFRunSpeed">边框运行速度；</param>
        /// <param name="nAreaFMoveStep">边框移动步长；该值取值范围：1~8；</param>
        /// <returns>详见返回状态代码定义</returns>
        [DllImport("LedDynamicArea.dll")]
        public static extern int AddScreenDynamicArea(int nScreenNo, int nDYAreaID, int nRunMode,
            int nTimeOut, int nAllProRelate, string pProRelateList, int nPlayImmediately,
            int nAreaX, int nAreaY, int nAreaWidth, int nAreaHeight, int nAreaFMode, int nAreaFLine, int nAreaFColor,
            int nAreaFStunt, int nAreaFRunSpeed, int nAreaFMoveStep);

        /// <summary>
        /// 向动态库中指定显示屏的指定动态区域添加信息文件；该函数不与显示屏通讯。
        /// </summary>
        /// <param name="nScreenNo">显示屏屏号；该参数与AddScreen函数中的nScreenNo参数对应。</param>
        /// <param name="nDYAreaID">动态区域编号；该参数与AddScreenDynamicArea函数中的nDYAreaID参数对应</param>
        /// <param name="pFileName">添加的信息文件名称；目前只支持txt(支持ANSI、UTF-8、Unicode等格式编码)、bmp的文件格式</param>
        /// <param name="nShowSingle">文字信息是否单行显示；0：多行显示；1：单行显示；显示该参数只有szFileName为txt格式文档时才有效；</param>
        /// <param name="pFontName">文字信息显示字体；该参数只有szFileName为txt格式文档时才有效；</param>
        /// <param name="nFontSize">文字信息显示字体的字号；该参数只有szFileName为txt格式文档时才有效；</param>
        /// <param name="nBold">文字信息是否粗体显示；0：正常；1：粗体显示；该参数只有szFileName为txt格式文档时才有效；</param>
        /// <param name="nFontColor">文字信息显示颜色；该参数只有szFileName为txt格式文档时才有效；</param>
        /// <param name="nStunt">动态区域信息运行特技；00：随机显示 01：静止显示 02：快速打出 03：向左移动 04：向左连移 05：向上移动 06：向上连移 07：闪烁 08：飘雪 09：冒泡 10：中间移出 11：左右移入 12：左右交叉移入 13：上下交叉移入 14：画卷闭合 15：画卷打开 16：向左拉伸 17：向右拉伸 18：向上拉伸 19：向下拉伸 20：向左镭射 21：向右镭射 22：向上镭射 23：向下镭射 24：左右交叉拉幕 25：上下交叉拉幕 26：分散左拉 27：水平百页 28：垂直百页 29：向左拉幕 30：向右拉幕 31：向上拉幕 32：向下拉幕 33：左右闭合 34：左右对开 35：上下闭合 36：上下对开 37：向右移动 38：向右连移 39：向下移动 40：向下连移</param>        
        /// <param name="nRunSpeed">动态区域信息运行速度</param>        
        /// <param name="nShowTime">动态区域信息显示时间；单位：10ms</param>
        /// <returns>详见返回状态代码定义</returns>
        [DllImport("LedDynamicArea.dll")]
        public static extern int AddScreenDynamicAreaFile(int nScreenNo, int nDYAreaID,
            string pFileName, int nShowSingle, string pFontName, int nFontSize, int nBold, int nFontColor,
            int nStunt, int nRunSpeed, int nShowTime);

        /// <summary>
        /// 删除动态库中指定显示屏的所有信息；该函数不与显示屏通讯。
        /// </summary>
        /// <param name="nScreenNo">显示屏屏号；该参数与AddScreen函数中的nScreenNo参数对应。</param>
        /// <returns>详见返回状态代码定义</returns>
        [DllImport("LedDynamicArea.dll")]
        public static extern int DeleteScreen(int nScreenNo);

        /// <summary>
        ///  删除动态库中指定显示屏指定的动态区域指定文件信息；该函数不与显示屏通讯。
        /// </summary>
        /// <param name="nScreenNo">显示屏屏号；该参数与AddScreen函数中的nScreenNo参数对应。</param>
        /// <param name="nDYAreaID">动态区域编号；该参数与AddScreenDynamicArea函数中的nDYAreaID参数对应</param>
        /// <param name="nFileOrd">动态区域的指定文件的文件序号；该序号按照文件添加顺序，从0顺序递增，如删除中间的文件，后面的文件序号自动填充。</param>
        /// <returns>详见返回状态代码定义</returns>
        [DllImport("LedDynamicArea.dll")]
        public static extern int DeleteScreenDynamicAreaFile(int nScreenNo, int nDYAreaID, int nFileOrd);

        /// <summary>
        /// 发送动态库中指定显示屏指定的动态区域信息到显示屏；该函数与显示屏通讯。
        /// </summary>
        /// <param name="nScreenNo">显示屏屏号；该参数与AddScreen函数中的nScreenNo参数对应。</param>
        /// <param name="nDYAreaID">动态区域编号；该参数与AddScreenDynamicArea函数中的nDYAreaID参数对应</param>
        /// <returns>详见返回状态代码定义</returns>
        [DllImport("LedDynamicArea.dll")]
        public static extern int SendDynamicAreaInfoCommand(int nScreenNo, int nDYAreaID);

        /// <summary>
        ///  删除动态库中指定显示屏指定的动态区域信息；同时向显示屏通讯删除指定的动态区域信息。该函数与显示屏通讯
        /// </summary>
        /// <param name="nScreenNo">显示屏屏号；该参数与AddScreen函数中的nScreenNo参数对应。</param>
        /// <param name="nDelAllDYArea">动态区域编号；该参数与AddScreenDynamicArea函数中的nDYAreaID参数对应</param>
        /// <param name="pDYAreaIDList">动态区域编号列表；如果同时删除多个动态区域，动态区域编号间用","隔开。如"0,1"</param>
        /// <returns>详见返回状态代码定义</returns>
        [DllImport("LedDynamicArea.dll")]
        public static extern int SendDeleteDynamicAreasCommand(int nScreenNo, int nDelAllDYArea, string pDYAreaIDList);

        // 三种控制器型号 BX-5E1  BX-5E2  BX-5E3
        public const int CONTROLLER_BX_5E1 = 0x0154;
        public const int CONTROLLER_BX_5E2 = 0x0254;
        public const int CONTROLLER_BX_5E3 = 0x0354;

        public const int CONTROLLER_BX_5E1_INDEX = 0;
        public const int CONTROLLER_BX_5E2_INDEX = 1;
        public const int CONTROLLER_BX_5E3_INDEX = 2;

        public const int FRAME_SINGLE_COLOR_COUNT = 23; //纯色边框图片个数
        public const int FRAME_MULI_COLOR_COUNT = 47; //花色边框图片个数

        /// <summary>
        /// 通讯模式-串口
        /// </summary>
        public const int SEND_MODE_SERIALPORT = 0;
        /// <summary>
        /// 通讯模式-网络
        /// </summary>
        public const int SEND_MODE_NETWORK = 2;
        /// <summary>
        /// 通讯模式-文件
        /// </summary>
        public const int SEND_MODE_SAVEFILE = 5;

        /// <summary>
        /// 动态区域运行模式-动态区数据循环显示；
        /// </summary>
        public const int RUN_MODE_CYCLE_SHOW = 0;
        /// <summary>
        /// 动态区域运行模式-动态区数据显示完成后静止显示最后一页数据；
        /// </summary>
        public const int RUN_MODE_SHOW_LAST_PAGE = 1;
        /// <summary>
        /// 动态区域运行模式-动态区数据循环显示，超过设定时间后数据仍未更新时不再显示；
        /// </summary>
        public const int RUN_MODE_SHOW_CYCLE_WAITOUT_NOSHOW = 2;
        /// <summary>
        /// 动态区域运行模式-动态区数据顺序显示，显示完最后一页后就不再显示
        /// </summary>
        public const int RUN_MODE_SHOW_ORDERPLAYED_NOSHOW = 4;

        /// <summary>
        /// 返回状态代码定义-没有找到有效的动态区域。
        /// </summary>
        public const int RETURN_ERROR_NOFIND_DYNAMIC_AREA = 0xE1;
        /// <summary>
        /// 返回状态代码定义-在指定的动态区域没有找到指定的文件序号。
        /// </summary>
        public const int RETURN_ERROR_NOFIND_DYNAMIC_AREA_FILE_ORD = 0xE2;
        /// <summary>
        /// 返回状态代码定义-在指定的动态区域没有找到指定的页序号。
        /// </summary>
        public const int RETURN_ERROR_NOFIND_DYNAMIC_AREA_PAGE_ORD = 0xE3;
        /// <summary>
        /// 返回状态代码定义-不支持该文件类型。
        /// </summary>
        public const int RETURN_ERROR_NOSUPPORT_FILETYPE = 0xE4;
        /// <summary>
        /// 返回状态代码定义-已经有该显示屏信息。如要重新设定请先DeleteScreen删除该显示屏再添加；
        /// </summary>
        public const int RETURN_ERROR_RA_SCREENNO = 0xF8;
        /// <summary>
        /// 返回状态代码定义-没有找到有效的显示区域；可以使用AddScreenProgramBmpTextArea添加区域信息。
        /// </summary>
        public const int RETURN_ERROR_NOFIND_AREA = 0xFA;
        /// <summary>
        /// 返回状态代码定义-系统内没有查找到该显示屏；可以使用AddScreen函数添加显示屏
        /// </summary>
        public const int RETURN_ERROR_NOFIND_SCREENNO = 0xFC;
        /// <summary>
        /// 返回状态代码定义-系统内正在向该显示屏通讯，请稍后再通讯；
        /// </summary>
        public const int RETURN_ERROR_NOW_SENDING = 0xFD;
        /// <summary>
        /// 返回状态代码定义-其它错误；
        /// </summary>
        public const int RETURN_ERROR_OTHER = 0xFF;
        /// <summary>
        /// 返回状态代码定义-没有错误
        /// </summary>
        public const int RETURN_NOERROR = 0;
        //==============================================================================  

        /// <summary>
        /// 生成错误文字信息
        /// </summary>
        /// <param name="szfunctionName"></param>
        /// <param name="nResult"></param>
        /// <returns></returns>
        public static string GetErrorMessage(string szfunctionName, int nResult)
        {
            string szResult;
            string message = string.Empty;
            DateTime dt = DateTime.Now;
            szResult = dt.ToString() + "---执行函数：" + szfunctionName + "---返回结果：";
            switch (nResult)
            {
                case RETURN_ERROR_NOFIND_DYNAMIC_AREA:
                    message = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + szResult + "没有找到有效的动态区域。";
                    break;
                case RETURN_ERROR_NOFIND_DYNAMIC_AREA_FILE_ORD:
                    message = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + szResult + "在指定的动态区域没有找到指定的文件序号。";
                    break;
                case RETURN_ERROR_NOFIND_DYNAMIC_AREA_PAGE_ORD:
                    message = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + szResult + "在指定的动态区域没有找到指定的页序号。";
                    break;
                case RETURN_ERROR_NOSUPPORT_FILETYPE:
                    message = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + szResult + "动态库不支持该文件类型。";
                    break;
                case RETURN_ERROR_RA_SCREENNO:
                    message = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + szResult + "系统中已经有该显示屏信息。如要重新设定请先执行DeleteScreen函数删除该显示屏后再添加。";
                    break;
                case RETURN_ERROR_NOFIND_AREA:
                    message = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + szResult + "系统中没有找到有效的动态区域；可以先执行AddScreenDynamicArea函数添加动态区域信息后再添加。";
                    break;
                case RETURN_ERROR_NOFIND_SCREENNO:
                    message = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + szResult + "系统内没有查找到该显示屏；可以使用AddScreen函数添加该显示屏。";
                    break;
                case RETURN_ERROR_NOW_SENDING:
                    message = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + szResult + "系统内正在向该显示屏通讯，请稍后再通讯。";
                    break;
                case RETURN_ERROR_OTHER:
                    message = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + szResult + "其它错误。";
                    break;
                case RETURN_NOERROR:
                    message = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + szResult + "函数执行成功。";
                    break;
            }
            return message;
        }
    }
}
