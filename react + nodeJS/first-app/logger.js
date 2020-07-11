const EventEmitter = require('events');
const emitter = new EventEmitter();

var url = 'http://mylogger.io/log';

class Logger extends EventEmitter
{
    log(message) 
    {
        // Send an http request
        //console.log(message);

        this.emit('messageLogged', {id: 1, url :'http://', message : message});
    }    
}

// module.exports.endPoint = url;


module.exports = Logger;