 
/*CEF测试页*/

var CefTesterV8Cef;
if (!CefTesterV8Cef)CefTesterV8Cef = {};
    
(function() {
    // 发送消息到Render
    CefTesterV8Cef.sendMessage = function(name,arguments) {
    native function sendMessage();
    return sendMessage(name,arguments);
    };  
      
})(); 