import Foundation
import Glibc
 
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

protocol MyProtocol
{
    init(IsCompleted_: Bool)
}

class CheckListElement: CustomStringConvertible, MyProtocol
{
    var Text: String;
    var IsCompleted: Bool;
    var DayOfWeek: String;
    init()
    {
        self.Text = "Przyk³adowa czynnoœæ";
        self.IsCompleted = false;
        self.DayOfWeek = "Poniedzia³ek";
    }
    required init(IsCompleted_: Bool)
    {
        self.IsCompleted = IsCompleted_;
        self.Text = "Przyk³adowa czynnoœæ";
        self.DayOfWeek = "Poniedzia³ek";
    }
    init(Text_: String, IsCompleted_: Bool, DayOfWeek_: DaysOfAWeek)
    {
        self.IsCompleted = IsCompleted_;
        self.Text = Text_;
        switch DayOfWeek_
        {
            case .Pon:
                self.DayOfWeek = "Poniedzia³ek";
            case .Wt:
                self.DayOfWeek = "Wtorek";
            case .Sr:
                self.DayOfWeek = "Œroda";
            case .Czw:
                self.DayOfWeek = "Czwartek";
            case .Pt:
                self.DayOfWeek = "Pi¹tek";
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
   }
}

let obj = CheckListElement(IsCompleted_: true);
let testObj = CheckListElement(Text_: "Zrobiæ pranie", IsCompleted_: false, DayOfWeek_: DaysOfAWeek.Wt);
let testObj2 = CheckListElement();

testObj.changeStatus(Status_: true);

print(obj.description);
print(testObj.description);
print(testObj2.description);