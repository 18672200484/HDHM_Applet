 
/*智能存样柜及气动传输*/
 
 var AutoCupboardV8Cef;
    if (!AutoCupboardV8Cef)AutoCupboardV8Cef = {};

    (function() {
      
      //查看故障信息
      AutoCupboardV8Cef.GetHitchs=function(paramSampler){
      native function GetHitchs(paramSampler);
      return GetHitchs(paramSampler);
      };

    })(); 