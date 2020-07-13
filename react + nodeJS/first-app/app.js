// const Logger = require('./logger.js');
// const path = require('path');
// const os = require('os');
// const fs = require('fs');
const EventEmitter = require('events');
const http = require('http');
const notificator = require('./notificator.js');
const Figure = require('./figure.js'); 
const bodyParser = require('body-parser');
const express = require('express');
const Account = require('./account.js');
var app = express();

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

// ************************* API EXAMPLES *******************************************
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
// *********************************************************************

// ************************* RUNTIME EXAMPLES *******************************************
egNotes=["Note 1", "Note second", "NooN", "Nan", "Note idk number"];
notificator.addNotes(egNotes);

let n=6;
let text = "Simple";

console.log(`Silnia z ${n} = `+fn(n));
console.log(`Fibonacci dla ${n} liczby z kolei = `+fibonacci(n));
console.log(`Strlen ze stringa "${text}" = ` + strlen(text));

var figure = new Figure.Rectangle();
var tri = new Figure.Triangle();

figure.draw();
tri.draw();

var account = new Account(5000, 100, 'John\'s Account');
var accountInfo = account.getInfo()
console.log(accountInfo);

console.log(palindromCheck("asLsA"));

//console.log(Figure.COUNT);
// *********************************************************************

// ************************** FUNKCJE ******************************
function fn(n)
{
    return n<2 ? n : fn(n-1)*n;
}
function fibonacci(n)
{
    return n<2 ? n : fibonacci(n-1)+fibonacci(n-2);
}
function strlen(text)
{
    let i=0;
    text=text.split("");
    text.push('\0');
    while(text[i] !== '\0')
    {
        i++;
    }
    return i;
}
function palindromCheck(text)
{
    let rng = Math.round(Math.random());
    switch(rng)
    {
        case 0:{
            return (text.toLowerCase().split("").reverse().join("")===text.toLowerCase()) + " method 1";
        }
        case 1:{
            text=text.toLowerCase();
            for(let i=0; i<text.length; i++)
            {
                if(text[i]!==text[text.length-1-i])
                    return false + " method 2";
            }
            return true + " method 2";
        }
    }
}
// *********************************************************************