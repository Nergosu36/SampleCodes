// const Logger = require('./logger.js');
// const path = require('path');
// const os = require('os');
// const fs = require('fs');
const EventEmitter = require('events');
const http = require('http');
const Notificator = require('./notificator.js');
const bodyParser = require('body-parser');
const express = require('express');
var app = express();

const notificator = new Notificator();

// var totaleMemory = os.totalmem();
// var freeMemory = os.freemem();

// console.log('Free mem: ' + os.freemem()/1024/1024 + " MB", );//os.totalmem());

// console.log(`Total Memory: ${totaleMemory}`);
// console.log(`Free Memory: ${freeMemory}`);

// // const files = fs.readdirSync('./');
// // console.log(files);

// var pathToFile = "./";

// fs.readdir(pathToFile, function(err, files)
// {
//     if(err) 
//         console.log('Error: ', err);
//     else
//         console.log('Result: ', files);
// });

// const logger = new Logger();

// logger.on('messageLogged', (arg) => {
//     console.log('Listener called with id: ' + arg.id + `\n\rMessage: ${arg.message}`);
// });

// logger.log('message');

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({extended: true}));

app.get('/api/notes/all', (req, res) =>{
    res.writeHeader(200, {"Content-Type": "text/html"})
    res.write(notificator.releaseNotes());
    res.end();
})
app.get('/api/notes', (req, res) =>{
    res.write(notificator.getNotes());
    res.end();
})
app.get('/api/notes/single', (req, res) =>{
    res.write(notificator.releaseNote());
    res.end();
})
app.post('/api/notes', (req, res) =>{
    notificator.addNote(req.body.message);
    res.write('Added new notification\n');
    res.end();
})
app.put('/api/notes', (req,res) =>{
    res.write('Updated a notification with ID: \n');
    res.end();
})
app.delete('/api/notes', (req, res) =>{
    res.write('Deleted a notification with ID: \n');
    res.end();
})

app.listen(3000);

// server.on('connection', (socket) => {
//     console.log('New connection...');
// });
// server.listen(3000);

// console.log('Listening on port 3000...');

