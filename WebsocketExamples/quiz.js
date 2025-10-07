// Example of a quiz game built with NodeJS

// Required packages
var app = require('express')();
var http = require('http').Server(app);
var io = require('socket.io')(http);

// Return the teacher page
app.get('/teacher', function(req,res){
  res.sendFile(__dirname + '/teacher.html');
});

// Return the student page
app.get('/student', function(req,res){
  res.sendFile(__dirname + '/student.html');
});

// Variable for storing the actual correct answer
var correctanswer;

// If we have a connection....
io.on('connection', function(socket){
  
  // when the teacher submits a question...
  socket.on("submitquestion", function(quesdata)
  {

    // Set the correct answer
    correctanswer = quesdata.answer;

    // Make sure we've received the question OK
    console.log("Question submitted: " + JSON.stringify(quesdata));
   
    // Broadcast the question to all the students (but not the teacher/sender)
    socket.broadcast.emit("deliverquestion", quesdata.question);

  });
  
  // when a student submits an answer...
  socket.on("answerquestion", function(answerdata){

    // Send back the result (right or wrong), along with 
    // the right answer, to the student that answered the question
    // specifically (notice io.to(socket.id).emit)
    io.to(socket.id).emit("resultquestion",
    	                  {correct: (correctanswer == answerdata),
    	                   answer: correctanswer});
  });

});

// Start the server
http.listen(3000, function(){
  console.log('listening on *:3000');
});

