import Foundation
import Glibc
 
//**************************** DNI TYGODNIA JAKO ENUMERABLE (ZAD. 2) ***************************************

 enum DaysOfAWeek 
 {
   case Pon
   case Wt
   case Sr
   case Czw
   case Pt
   case Sob
   case Nd
}

//**************************** PROTOKÓŁ WYMAGAJĄCY WYSTĄPIENIA JEDNEGO JUŻ WCZEŚNIEJ ZADEKLAROWANEGO POLA (ZAD. 3) ***************************************

protocol MyProtocol
{
    init(IsCompleted_: Bool)
}

//**************************** PROTOKÓŁ DO DELEGACJI(KOMUNIKACJI) (ZAD. 4) ***************************************

protocol CheckListCommunicator: class
{
    func showList()
}

//**************************** KLASA CheckListElement (ZAD. 1) ***************************************

class CheckListElement: CustomStringConvertible, MyProtocol
{
    var Text: String;
    var IsCompleted: Bool;
    var DayOfWeek: String;
    
    var delegate: CheckListCommunicator?;
    
    init()
    {
        self.Text = "Przykładowa czynność";
        self.IsCompleted = false;
        self.DayOfWeek = "Poniedziałek";
    }
    
    required init(IsCompleted_: Bool)
    {
        self.IsCompleted = IsCompleted_;
        self.Text = "Przykładowa czynność";
        self.DayOfWeek = "Poniedziałek";
    }
    
    init(Text_: String, IsCompleted_: Bool, DayOfWeek_: DaysOfAWeek)
    {
        self.IsCompleted = IsCompleted_;
        self.Text = Text_;

        switch DayOfWeek_
        {
            case .Pon:
                self.DayOfWeek = "Poniedziałek";
            case .Wt:
                self.DayOfWeek = "Wtorek";
            case .Sr:
                self.DayOfWeek = "Środa";
            case .Czw:
                self.DayOfWeek = "Czwartek";
            case .Pt:
                self.DayOfWeek = "Piątek";
            case .Sob:
                self.DayOfWeek = "Sobota";
            case .Nd:
                self.DayOfWeek = "Niedziela";
        }
    }
    
    var description: String 
    {
        var str = "\(self.DayOfWeek) \(self.Text) -> ";
        str += self.IsCompleted ? "Gotowe" : "Do Wykonania";
        return str;
    }
   
   func changeStatus(Status_: Bool)
   {
       self.IsCompleted = Status_;
       delegate?.showList(); // WYWOŁANIE FUNKCJI W DELEGACIE // CheckListElement -> delegate -> CheckList.showList()
   }
}

//**************************** KLASA CheckList ZAWIERAJĄCA CheckListElements  (ZAD. 4) ***************************************

class CheckList: CheckListCommunicator
{
    var CheckListElements = [CheckListElement]();
    
    init(CheckListElements_: [CheckListElement])
    {
        self.CheckListElements=CheckListElements_;
    }
    
    func showList()
    {
        for i in CheckListElements
        {
            print(i); // ZAPEWNIONE PRZEZ CustomStringConvertible
        }
    }

    func show3rd()
    {
        for i in stride(from: 2, to: CheckListElements.count, by: 3)
        {
            print(CheckListElements[i].description);
        }
    }
}

//**************************** PRZYKŁADOWE OBIEKTY (ZAD. 5) ***************************************

let obj = CheckListElement(IsCompleted_: true);
let testObj = CheckListElement();
let testObj2 = CheckListElement(Text_: "Zrobić pranie", IsCompleted_: false, DayOfWeek_: DaysOfAWeek.Pon);

let objX = CheckListElement(IsCompleted_: true);
let testObjX = CheckListElement();
let testObj2X = CheckListElement(Text_: "Zrobić pranie X", IsCompleted_: false, DayOfWeek_: DaysOfAWeek.Wt);

let objY = CheckListElement(IsCompleted_: true);
let testObjY = CheckListElement();
let testObj2Y = CheckListElement(Text_: "Zrobić pranie Y", IsCompleted_: false, DayOfWeek_: DaysOfAWeek.Sr);

let objZ = CheckListElement(IsCompleted_: true);
let testObjZ = CheckListElement();
let testObj2Z = CheckListElement(Text_: "Zrobić pranie Z", IsCompleted_: false, DayOfWeek_: DaysOfAWeek.Czw);

//**************************** MACIERZ Z OBIEKTAMI (ZAD. 5) ***************************************

let CheckListElements = [obj, testObj, testObj2, objX, testObjX, testObj2X, objY, testObjY, testObj2Y, objZ, testObjZ, testObj2Z];

//**************************** CHECK LIST (ZAD. 5) ***************************************

let array = CheckList(CheckListElements_: CheckListElements);

//**************************** PRZYPISANIE DELEGATÓW (ZAD. 5) ***************************************

for i in CheckListElements
{
    i.delegate = array;
}

//**************************** ZMIANA STATUSU (ZAD. 5) ***************************************

testObj2Y.changeStatus(Status_: true);

print(""); //moja wstawka dla lepszej czytelności

//**************************** WYWOŁANIE FUNKCJI WYŚWIETLANIA CO TRZECIEJ POZYCJI W MACIERZY (ZAD. 5) ***************************************

array.show3rd();
