
/*汽车衡监控界面*/

var AutoMakerV8Cef;
if (!AutoMakerV8Cef) AutoMakerV8Cef = {};

(function () {
    //切换设备选中
    AutoMakerV8Cef.ChangeSelected = function (paramSampler) {
        native function ChangeSelected(paramSampler);
        return ChangeSelected(paramSampler);
    };

})(); 