/**
*   SVG监控图元素操作封装 
***/

// 需要jquery支持

// 获取SVG jquery对象
function getSVGjQuery(id) {
    return $(document.getElementById(id).getSVGDocument())
}

// 改变颜色
// $elements:SVG.jQuery对象
// color:颜色
function svgChangeColor($elements, color) {
    if ($elements.children().length == 0) {
        changeColor($elements, color);
    } else {
        changeColor($elements.find("*:not(g)"), color);
    }
}

// 改变颜色
// $element:SVG.jQuery对象
// color:颜色
function changeColor($elements, color) {
    $elements.each(function () {
        var $this = $(this);

        if ($this[0].tagName.toLowerCase() == "path")
            $this.css({ "fill": color });
        else
            $this.css({ "stroke": color });
    });
}


// 改变宽度
// $element:SVG.jQuery对象
// width:宽度
function changeWidth($elements, width) {
    $elements.each(function () {
        var $this = $(this);
        $this.attr({ "width": width });
    });
}
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

function changeScroll($elements, scroll) {
    $elements.each(function () {
        var $this = $(this);
        $this.attr("transform", "rotate(" + scroll + ")");
    });
}

function changeScale($elements,varbool) {
    $elements.each(function () {
        var $this = $(this);
        //  alert("transform" + ":" + "rotate(" + scroll + ")");
        //        $this.attr("transform", "translate(100 100)");
        if (varbool) {
            $this.attr("transform", "scale(-1 1),translate(-1900 0)");
        }
        else {
            $this.attr("transform", "scale(1 1),translate(0 0)");
        }
    });
}
