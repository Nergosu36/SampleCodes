class Figure{
    constructor(){
        Figure.count++;
    }
    draw(){
        console.log("Rysuje... ")
    }
    static get COUNT(){
        return Figure.count;
    }
}
class Rectangle extends Figure{
    constructor(){
        super();
    }
    draw(){
        super.draw();
        console.log("kwadrat");
    }

}
class Triangle extends Figure{
    constructor(){
        super();
    }
    draw(){
        super.draw();
        console.log("trojkat");
    }
}

module.exports={
    Figure: Figure,
    Rectangle: Rectangle,
    Triangle: Triangle,
}