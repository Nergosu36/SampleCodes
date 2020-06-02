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

class CheckListElement: CustomStringConvertible
{
    var Text: String;
    var IsCompleted: Bool;
    var DayOfWeek: String;
    init()
    {
        self.Text = "Przyk�adowa czynno��";
        self.IsCompleted = false;
        self.DayOfWeek = "Poniedzia�ek";
    }
    init(Text_: String, IsCompleted_: Bool, DayOfWeek_: DaysOfAWeek)
    {
        self.IsCompleted = IsCompleted_;
        self.Text = Text_;
        switch DayOfWeek_
        {
            case .Pon:
                self.DayOfWeek = "Poniedzia�ek";
            case .Wt:
                self.DayOfWeek = "Wtorek";
            case .Sr:
                self.DayOfWeek = "�roda";
            case .Czw:
                self.DayOfWeek = "Czwartek";
            case .Pt:
                self.DayOfWeek = "Pi�tek";
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
}

let testObj = CheckListElement(Text_: "Zrobi� pranie", IsCompleted_: false, DayOfWeek_: DaysOfAWeek.Wt);
let testObj2 = CheckListElement();

print(testObj.description);
print(testObj2.description);