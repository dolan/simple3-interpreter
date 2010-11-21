using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleREPL {
    class ReplFactory {
        public static IRun CreateReplByVersion(int version){
            switch(version){
                case 2:
                    return new Simple2.REPLCator();
                case 3:
                    return new Simple3.REPLCator3();
                default:
                    throw new Exception("We only have Simple versions 2 and 3. Try again next time.");
            }
        }
    }
}
