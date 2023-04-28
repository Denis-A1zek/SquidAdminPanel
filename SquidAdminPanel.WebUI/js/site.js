// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(function(){
      var id = uuidv4();
      var source = new EventSource("https://localhost:7075/streamlogs/" + id);
      source.onmessage = function(event){            
            const logs = JSON.parse(event.data);
            const line = logs.Logs;
            if(line.length != 0)
            {
                  for(log in line){
                        const logmessage = line[log].Time + line[log].User + line[log].Address + line[log].StatusCode + 
                              line[log].Description + line[log].FromAddress + "\n";
                      
                        var divLog = document.querySelector("div.divLog");
                        let item = document.createElement("p");
                        item.classList.add("fs-6");
                        item.textContent = logmessage
                        divLog.appendChild(item);

                        item.style.color = "red";

                        setTimeout(function() {
                              item.style.color = "black";
                            }, 500);
                        

                  }
                  divLog.scrollTop = divLog.scrollHeight;
                  console.log("Получение данных с сервера");
            }

      }     

      
      function uuidv4() {
            return ([1e7]+-1e3+-4e3+-8e3+-1e11).replace(/[018]/g, c =>
            (c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
            );
      }
});
