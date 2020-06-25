const EventEmitter = require('events');
class Notificator extends EventEmitter
{
    constructor()
    {
        super();
        this.notes= new Array();
    }
    addNote(text)
    {
        this.notes.push(text);
    }
    releaseNote()
    {
        return this.notes.pop();
    }
    releaseNoteTimer()
    {
        if(this.notes.length>0)
            this.htmlContent += `<p style='font-weight:bold'>${this.releaseNote()}</p>`;
        else
            clearInterval(this.notesInterval);
    }
    releaseNotes()
    {
        this.notesInterval = setInterval(this.releaseNoteTimer, 3000);
        return this.htmlContent;
    }
    getNotes()
    {
        return this.notes.toLocaleString();
    }
}

module.exports = Notificator;