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
    addNotes(texts)
    {
        for(let i=0; i<texts.length; i++)
            this.notes.push(texts[i]);
    }
    releaseNote()
    {
        return this.notes.pop();
    }
    releaseNoteTimer()
    {
        if(this.notes.length>0)
            this.htmlContent += `<h3>${this.releaseNote()}</h3>`;
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

const instance = new Notificator();
Object.freeze(instance);

module.exports = instance;