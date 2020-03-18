/**
*   zzl
*   2014-01-08
**/

/************************以下为通用方法，请勿随意修改************************/

var svgObjDoc;

/*
初始化SVG，获取SVGDoc对象 
id：svg_id
*/
function InitSVG(id) {
    try {
        if (checkSVGSupport()) {
            svgObjDoc = document.getElementById(id).getSVGDocument();
            return true;
        }
        else {
            if (window.confirm("您尚未安装图形插件，点击下载安装！"))
                window.open("/" + appEnName + "/SubPresentation/BST.Biz.Cmcs.Presentation.Web/Resource/svg/Adobe SVG Viewer v3.0.exe", "_self");
        }
    }
    catch (ex) {

    }

    return false;
}

/*
检查浏览器对SVG的支持
主要对IE进行检测
其他高级浏览器视为支持
*/
function checkSVGSupport() {
    try {
        return ((window.ActiveXObject) ? !!(new ActiveXObject("Adobe.SVGCtl")) : true);
    }
    catch (ex) {
        return false;
    }
}

// 需要jquery支持

// 获取SVG jquery对象
function getSVGjQuery(id) {
    return $(document.getElementById(id).getSVGDocument())
}
/*
根据id获取元素
id：id
*/
function GetSVGElementById(id) {
    if (svgObjDoc == null) {
        alert("操作失败，原因可能是初始化错误！");
        return false;
    }

    var obj = svgObjDoc.getElementById(id);

    if (obj == null) {
        alert("未找到元素 id:" + id);
        return false;
    }

    return obj;
}

/*
针对单个或者群组进行颜色填充
id：id
color：十六进制色或者普通颜色
*/
function FillColorSVG(id, color) {
    var obj = GetSVGElementById(id);
    if (obj != null) {
        if (obj.childNodes.length == 0) {
            // 单个对象
            obj.style.setProperty("fill", color);
        }
        else {
            // 群组
            for (var i = 0; i < obj.childNodes.length; i++) {
                var childNode = obj.childNodes.item(i);

                // #text用于排除某些空对象
                if (childNode.nodeName != "#text") {
                    // 排除文本
                    if (childNode.nodeName == "text")
                        break;

                    childNode.style.setProperty("fill", color);
                }
            }
        }
    }
}

/*
设置text节点的内容
id：id
value：填充的内容
*/
function SetTextValueSVG(id, value) {
    var obj = GetSVGElementById(id);

    if (obj != null) {
        obj.childNodes.item(0).data = value;
    }
}

/*
隐藏或显示元素
id：id
visible：bool 是否显示
*/
function DisplaySVG(id, visible) {
    var obj = GetSVGElementById(id);

    if (obj != null) {
        obj.style.setProperty("display", visible ? "none" : "block");
    }
}

/*
旋转变换
id：id
angle：旋转角度,缺省单位是“度”
cx：旋转中心x坐标,缺省值是0
cy：旋转中心y坐标,缺省值是0
*/
function RotateSVG(id, angle, cx, cy) {
    var obj = GetSVGElementById(id);

    if (obj != null) {
        obj.setAttribute("transform", "rotate(" + angle + " " + cx + "," + cy + ")");
    }
}

/*
平移变换
id：id
x：x轴位移
y：y轴位移
*/
function TranslateSVG(id, x, y) {
    var obj = GetSVGElementById(id);

    if (obj != null) {
        obj.setAttribute("transform", "translate(" + x + "," + y + ")");
    }
}

/************************以上为通用方法，请勿随意修改************************/

// $elements:SVG.jQuery对象
// color:颜色
function svgChangeColor1($elements, color) {
    if ($elements.children().length == 0) {
        changeColor1($elements, color);
    } else {
        changeColor1($elements.find("*:not(g)"), color);
    }
}
// 改变颜色
// $element:SVG.jQuery对象
// color:颜色
function changeColor1($elements, color) {
    $elements.each(function () {
        var $this = $(this);
        $this.css({ "fill": color });
    });
}


/*
设置text节点的内容
id：id
value：填充的内容
*/
function svgTextValue($elements, value) {
    $elements.each(function () {
        var $this = $(this);
        $this.data = value;
    });
}



function changeScroll($elements, scroll) {
    $elements.each(function () {
        var $this = $(this);
        $this.attr("transform", "rotate(" + scroll + ")");
    });
}
/************************以上为通用方法，请勿随意修改************************/
// $elements:SVG.jQuery对象
// color:颜色
function svgChangeColor1($elements, color) {
    if ($elements.children().length == 0) {
        changeColor1($elements, color);
    } else {
        changeColor1($elements.find("*:not(g)"), color);
    }
}

// 改变颜色
// $element:SVG.jQuery对象
// color:颜色
function changeColor1($elements, color) {
    $elements.each(function () {
        var $this = $(this);
        $this.css({ "fill": color });
    });
}
function changeScale($elements, varbool) {
    $elements.each(function () {
        var $this = $(this);
        //  alert("transform" + ":" + "rotate(" + scroll + ")");
        //        $this.attr("transform", "translate(100 100)");
        if (varbool) {
            $this.attr("transform", "scale(-1 1),translate(-1150 0)");
        }
        else {
            $this.attr("transform", "scale(1 1),translate(0 0)");
        }
    });
}
