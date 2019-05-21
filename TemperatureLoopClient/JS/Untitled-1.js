function RequestData()
        {
            fetch('http://localhost:9650/temp/current')
                .then(function(response) {
                                         return response.text();
                })
                .then(function(val) {
                    document.getElementById("tempHolder").innerText = val;
                })
        }
        
        setInterval(RequestData, 4*1000);