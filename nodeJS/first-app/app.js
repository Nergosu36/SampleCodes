const Logger = require('./logger.js');
const path = require('path');
const os = require('os');
const fs = require('fs');
const EventEmitter = require('events');
const http = require('http');

var totaleMemory = os.totalmem();
var freeMemory = os.freemem();

console.log('Free mem: ' + os.freemem()/1024/1024 + " MB", );//os.totalmem());

console.log(`Total Memory: ${totaleMemory}`);
console.log(`Free Memory: ${freeMemory}`);

// const files = fs.readdirSync('./');
// console.log(files);

var pathToFile = "./";

fs.readdir(pathToFile, function(err, files)
{
    if(err) 
        console.log('Error: ', err);
    else
        console.log('Result: ', files);
});

const logger = new Logger();

logger.on('messageLogged', (arg) => {
    console.log('Listener called with id: ' + arg.id + `\n\rMessage: ${arg.message}`);
});

logger.log('message');

const server = http.createServer((req,res) => {
    if(req.url === '/api/courses'){
        res.write(JSON.stringify([1, 2, 3]));
        res.end();
    }
});

server.on('connection', (socket) => {
    console.log('New connection...');
});
server.listen(3000);

console.log('Listening on port 3000...');