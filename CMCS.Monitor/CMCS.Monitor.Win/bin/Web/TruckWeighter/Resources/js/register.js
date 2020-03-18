 
/*汽车衡监控界面*/
 
 var TruckWeighterV8Cef;
    if (!TruckWeighterV8Cef)TruckWeighterV8Cef = {};

    (function() {
        // 道闸1升杆
      TruckWeighterV8Cef.Gate1Up = function(paramSampler) {
        native function Gate1Up(paramSampler);
        Gate1Up(paramSampler);
      };   
      
        // 道闸1降杆
      TruckWeighterV8Cef.Gate1Down = function(paramSampler) {
        native function Gate1Down(paramSampler);
        Gate1Down(paramSampler);
      };   
      
        // 道闸2升杆
      TruckWeighterV8Cef.Gate2Up = function(paramSampler) {
        native function Gate2Up(paramSampler);
        Gate2Up(paramSampler);
      };   
      
        // 道闸2降杆
      TruckWeighterV8Cef.Gate2Down = function(paramSampler) {
        native function Gate2Down(paramSampler);
        Gate2Down(paramSampler);
      };  
      
      //切换采样机选中
      TruckWeighterV8Cef.ChangeSelected=function(paramSampler){
      native function ChangeSelected(paramSampler);
      return ChangeSelected(paramSampler);
      };
      
    })(); 