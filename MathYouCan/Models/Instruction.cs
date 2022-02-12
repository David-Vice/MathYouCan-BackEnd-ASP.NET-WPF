using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathYouCan.Models
{
    public class Instruction
    {
        /*
             If word has a differt style or font weight use specificators to show it     
             DO NOT forget to show end of line using '\n' character

             SPECIFICATORS:


               text          -->  Default text
          |~B~|text|~B~|     -->  Bold text
          |~I~|text|~I~|     -->  Italic text
          |~U~|text|~U~|     -->  UnderLine text


        */


        public string InstructionText { get; set; }


        public string Header { get; set; }

    }
}
