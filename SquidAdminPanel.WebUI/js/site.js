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
                        //document.getElementById("spnMessage").innerHTML +=
                        const logmessage = line[log].Time + line[log].User + line[log].Address + line[log].StatusCode + 
                              line[log].Description + line[log].FromAddress + "\n";

                        //const someValue = uuidv4();
                        const jQItem = $('<p class="fs-6">' + logmessage + '</p>');
                        $('#logsContainer').append(jQItem);
                        jQItem.css('color', 'red');
                        //$('#'+someValue).css('color','red');

                        setTimeout(function() {
                              jQItem .css('color', 'black');
                            }, 500);
                        

                  }
                  $('#logsContainer').scrollTop($('#logsContainer')[0].scrollHeight);
                  console.log("Получение данных с сервера");
            }

      }     

      
      function uuidv4() {
            return ([1e7]+-1e3+-4e3+-8e3+-1e11).replace(/[018]/g, c =>
            (c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
            );
      }
});
