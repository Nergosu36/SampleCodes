import Foundation
import Glibc
 
class CheckListElement: CustomStringConvertible
{
    var Text: String;
    var IsCompleted: Bool;
    init()
    {
        self.Text = "PlaceholderText";
        self.IsCompleted = false;
    }
    init(Text_: String, IsCompleted_: Bool)
    {
        self.IsCompleted = IsCompleted_;
        self.Text = Text_;
    }
    var description: String 
    {
        var str = "\(self.Text) -> ";
        str += self.IsCompleted ? "Gotowe" : "Do Wykonania";
      return str;
   }
}

let testObj = CheckListElement(Text_: "Poniedziałek Zrobić pranie", IsCompleted_: false);
let testObj2 = CheckListElement();

print(testObj.description);
print(testObj2.description);
