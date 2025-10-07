// Example of using websockets to create a chat program
//
// After running the below script, try navigating to localhost:3000 in multiple
// browser tabs, notice how chat messages appear in all windows after they are 
// entered.
//
var app = require('express')();
var http = require('http').Server(app);
var io = require('socket.io')(http);

// send index.html in response to a request for the root URL
app.get('/', function(req, res){  
  res.sendFile(__dirname + '/index.html');});

// callback function sets up a new connection (represented by socket), including
// setting up an event handler for when a chat message is received from this 
// connection.
io.on('connection', function(socket) {  
  
  // when a message is received, emit that message to *all* connections so it 
  // can be displayed in all chat windows 
  socket.on('chat message', function(msg){    
    io.emit('chat message', msg);  
  });

});

// start the server
http.listen(3000, function(){  console.log('listening on *:3000');});
