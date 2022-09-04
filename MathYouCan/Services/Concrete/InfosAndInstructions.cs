using MathYouCan.Models.Exams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathYouCan.Services.Concrete
{
    public class InfosAndInstructions
    {
        public Section Section { get; set; }
        public InfosAndInstructions(Section section)
        {
            Section = section;
            getAllText();
        }

        public string GetInfo()
        {
            return infoText;
        }
        public Instruction GetInstructions()
        {
            return instText;
        }


        private string infoText = "";
        private Instruction instText = null;
        private void getAllText()
        {
            if (Section.Name.Contains("English"))
            {
                infoText = EngInfo();
                instText = EngInst();
            }
            else if (Section.Name.Contains("Math"))
            {
                infoText = MathInfo();
                instText = MathInst();
            }

            else if (Section.Name.Contains("Science"))
            {
                infoText = ScienceInfo();
                instText = ScienceInst();
            }
            else if (Section.Name.Contains("Reading"))
            {
                infoText = ReadingInfo();
                instText = ReadingInst();
            }
        }

        private string EngInfo()
        {
            return $"<strong>English&nbsp;Test&nbsp;Directions\n\nYou&nbsp;will&nbsp;have&nbsp;{Section.Duration}&nbsp;minutes&nbsp;to&nbsp;complete&nbsp;this&nbsp;section.&nbsp;</strong>&nbsp;\n&nbsp;SECTION&nbsp;DIRECTIONS:&nbsp;The&nbsp;first&nbsp;screen&nbsp;in&nbsp;this&nbsp;section&nbsp;contains&nbsp;instructions&nbsp;about&nbsp;the&nbsp;English&nbsp;test.&nbsp;That&nbsp;screen&nbsp;is&nbsp;not&nbsp;part&nbsp;of&nbsp;the\n&nbsp;scored&nbsp;questions.&nbsp;You&nbsp;can&nbsp;return&nbsp;to&nbsp;the&nbsp;instructions&nbsp;at&nbsp;any&nbsp;time&nbsp;by&nbsp;selecting&nbsp;the&nbsp;<strong>&nbsp;Nav&nbsp;</strong>&nbsp;button&nbsp;at&nbsp;the&nbsp;top&nbsp;of&nbsp;the&nbsp;screen&nbsp;and&nbsp;then&nbsp;selecting&nbsp;<strong>&nbsp;Instr&nbsp;</strong>&nbsp;\n\nYou&nbsp;may&nbsp;use&nbsp;your&nbsp;scratch&nbsp;paper&nbsp;on&nbsp;this&nbsp;test.&nbsp;You&nbsp;will&nbsp;hand&nbsp;that&nbsp;in&nbsp;to&nbsp;the&nbsp;room&nbsp;supervisor&nbsp;at&nbsp;the&nbsp;end&nbsp;of&nbsp;testing.\nSelect&nbsp;the&nbsp;<strong>&nbsp;Next&nbsp;</strong>&nbsp;button&nbsp;to&nbsp;proceed.\n";
        }

        private Instruction EngInst()
        {
            return new Instruction()
            {

                Header = $"Begin&nbsp;English&nbsp;Test—{Section.Duration}&nbsp;minutes,&nbsp;{Section.Questions.ToList().Count}&nbsp;questions\n",
                InstructionText =
"In&nbsp;the&nbsp;five&nbsp;passages&nbsp;that&nbsp;follow,&nbsp;certain&nbsp;words&nbsp;and&nbsp;phrases&nbsp;are&nbsp;underlined&nbsp;and&nbsp;highlighted.&nbsp;On&nbsp;the&nbsp;right-hand&nbsp;side&nbsp;of&nbsp;the&nbsp;screen,&nbsp;you&nbsp;will&nbsp;find&nbsp;alternatives&nbsp;for&nbsp;the&nbsp;underlined&nbsp;and&nbsp;highlighted&nbsp;part.&nbsp;In&nbsp;most&nbsp;cases,&nbsp;you&nbsp;are&nbsp;to&nbsp;choose&nbsp;the&nbsp;one&nbsp;that&nbsp;best&nbsp;expresses&nbsp;the&nbsp;idea,&nbsp;makes&nbsp;the&nbsp;statement&nbsp;appropriate&nbsp;for&nbsp;standard&nbsp;written&nbsp;English,&nbsp;or&nbsp;is&nbsp;worded&nbsp;most&nbsp;consistently&nbsp;with&nbsp;the&nbsp;style&nbsp;and&nbsp;tone&nbsp;of&nbsp;the&nbsp;passage&nbsp;as&nbsp;a&nbsp;whole.&nbsp;If&nbsp;you&nbsp;think&nbsp;the&nbsp;original&nbsp;version&nbsp;is&nbsp;best,&nbsp;choose&nbsp;“NO&nbsp;CHANGE.”&nbsp;In&nbsp;some&nbsp;cases,&nbsp;you&nbsp;will&nbsp;find&nbsp;on&nbsp;the&nbsp;right-hand&nbsp;side&nbsp;of&nbsp;the&nbsp;screen&nbsp;a&nbsp;question&nbsp;about&nbsp;the&nbsp;underlined&nbsp;and&nbsp;highlighted&nbsp;part.&nbsp;You&nbsp;are&nbsp;to&nbsp;choose&nbsp;the&nbsp;best&nbsp;answer&nbsp;to&nbsp;the&nbsp;question.\n\nYou&nbsp;will&nbsp;also&nbsp;find&nbsp;questions&nbsp;about&nbsp;a&nbsp;section&nbsp;of&nbsp;the&nbsp;passage,&nbsp;or&nbsp;about&nbsp;the&nbsp;passage&nbsp;as&nbsp;a&nbsp;whole.&nbsp;These&nbsp;questions&nbsp;do&nbsp;not&nbsp;refer&nbsp;to&nbsp;an&nbsp;underlined&nbsp;portion&nbsp;of&nbsp;the&nbsp;passage,&nbsp;but&nbsp;rather&nbsp;refer&nbsp;to&nbsp;a&nbsp;letter&nbsp;or&nbsp;letters,&nbsp;a&nbsp;number&nbsp;or&nbsp;numbers,&nbsp;or&nbsp;an&nbsp;asterisk&nbsp;within&nbsp;square&nbsp;brackets&nbsp;[&nbsp;].\n\nFor&nbsp;each&nbsp;question,&nbsp;choose&nbsp;the&nbsp;alternative&nbsp;you&nbsp;consider&nbsp;best,&nbsp;select&nbsp;the&nbsp;circle&nbsp;next&nbsp;to&nbsp;your&nbsp;answer,&nbsp;then&nbsp;select&nbsp;the&nbsp;<strong>&nbsp;Next&nbsp;</strong>&nbsp;button.&nbsp;Read&nbsp;each&nbsp;passage&nbsp;through&nbsp;once,&nbsp;using&nbsp;the&nbsp;scroll&nbsp;bar&nbsp;to&nbsp;see&nbsp;the&nbsp;entire&nbsp;passage,&nbsp;before&nbsp;you&nbsp;begin&nbsp;to&nbsp;answer&nbsp;the&nbsp;questions&nbsp;that&nbsp;accompany&nbsp;the&nbsp;passage.&nbsp;For&nbsp;many&nbsp;of&nbsp;the&nbsp;questions,&nbsp;you&nbsp;must&nbsp;read&nbsp;several&nbsp;sentences&nbsp;beyond&nbsp;the&nbsp;question&nbsp;to&nbsp;determine&nbsp;the&nbsp;answer.&nbsp;Be&nbsp;sure&nbsp;that&nbsp;you&nbsp;have&nbsp;read&nbsp;far&nbsp;enough&nbsp;ahead&nbsp;each&nbsp;time&nbsp;you&nbsp;choose&nbsp;an&nbsp;alternative.\n\nSelect&nbsp;the&nbsp;<strong>&nbsp;Next&nbsp;</strong>&nbsp;button&nbsp;to&nbsp;proceed."
            };
        }

        private string MathInfo()
        {
            return $"<strong>Mathematics&nbsp;Test&nbsp;Directions\n\nYou&nbsp;will&nbsp;have&nbsp;{Section.Duration}&nbsp;minutes&nbsp;to&nbsp;complete&nbsp;this&nbsp;section.&nbsp;</strong>\nSECTION&nbsp;DIRECTIONS:&nbsp;The&nbsp;first&nbsp;screen&nbsp;in&nbsp;this&nbsp;section&nbsp;contains&nbsp;instructions&nbsp;about&nbsp;the&nbsp;mathematics&nbsp;test.&nbsp;That&nbsp;screen&nbsp;is&nbsp;not&nbsp;part&nbsp;of&nbsp;the\n&nbsp;scored&nbsp;questions.&nbsp;You&nbsp;can&nbsp;return&nbsp;to&nbsp;the&nbsp;instructions&nbsp;at&nbsp;any&nbsp;time&nbsp;by&nbsp;selecting&nbsp;the&nbsp;\n<strong>&nbsp;Nav&nbsp;</strong>&nbsp;button&nbsp;at&nbsp;the&nbsp;top&nbsp;of&nbsp;the&nbsp;screen&nbsp;and&nbsp;then&nbsp;selecting&nbsp;<strong>&nbsp;Instr&nbsp;</strong>.&nbsp;\nYou&nbsp;are&nbsp;permitted&nbsp;to&nbsp;use&nbsp;a&nbsp;calculator&nbsp;on&nbsp;this&nbsp;test,&nbsp;and&nbsp;you&nbsp;may&nbsp;get&nbsp;it&nbsp;out&nbsp;now.&nbsp;Some&nbsp;types&nbsp;of&nbsp;calculators&nbsp;are&nbsp;prohibited.&nbsp;For&nbsp;example,&nbsp;you&nbsp;may&nbsp;not&nbsp;use&nbsp;any&nbsp;version&nbsp;of&nbsp;the&nbsp;TI-89.&nbsp;You&nbsp;are&nbsp;responsible&nbsp;for&nbsp;knowing&nbsp;if&nbsp;your&nbsp;calculator&nbsp;is&nbsp;permitted.&nbsp;Testing&nbsp;staff&nbsp;will&nbsp;check&nbsp;your&nbsp;calculator&nbsp;periodically&nbsp;during&nbsp;the&nbsp;test.&nbsp;If&nbsp;you&nbsp;use&nbsp;a&nbsp;prohibited&nbsp;calculator,&nbsp;you&nbsp;will&nbsp;be&nbsp;dismissed&nbsp;and&nbsp;your&nbsp;tests&nbsp;will&nbsp;not&nbsp;be&nbsp;scored.\n\nYou&nbsp;are&nbsp;also&nbsp;responsible&nbsp;for&nbsp;making&nbsp;sure&nbsp;your&nbsp;calculator&nbsp;is&nbsp;working&nbsp;properly.&nbsp;You&nbsp;will&nbsp;not&nbsp;be&nbsp;provided&nbsp;with&nbsp;backup&nbsp;batteries&nbsp;or&nbsp;a&nbsp;replacement&nbsp;calculator.\nDo&nbsp;not&nbsp;share&nbsp;your&nbsp;calculator&nbsp;with&nbsp;another&nbsp;examinee.&nbsp;Do&nbsp;not&nbsp;connect&nbsp;your&nbsp;calculator&nbsp;in&nbsp;any&nbsp;way&nbsp;to&nbsp;the&nbsp;computer.\nIf&nbsp;you&nbsp;need&nbsp;to&nbsp;use&nbsp;your&nbsp;backup&nbsp;calculator,&nbsp;raise&nbsp;your&nbsp;hand&nbsp;and&nbsp;testing&nbsp;staff&nbsp;will&nbsp;check&nbsp;it.&nbsp;You&nbsp;may&nbsp;have&nbsp;only&nbsp;one&nbsp;calculator&nbsp;on&nbsp;your&nbsp;workstation&nbsp;or&nbsp;in&nbsp;operation&nbsp;at&nbsp;a&nbsp;time.&nbsp;If&nbsp;you&nbsp;did&nbsp;not&nbsp;bring&nbsp;a&nbsp;backup&nbsp;calculator&nbsp;and&nbsp;yours&nbsp;malfunctions,&nbsp;continue&nbsp;testing.If&nbsp;your&nbsp;calculator&nbsp;has&nbsp;games&nbsp;or&nbsp;other&nbsp;functions,&nbsp;you&nbsp;may&nbsp;not&nbsp;use&nbsp;those&nbsp;functions&nbsp;during&nbsp;the&nbsp;test;&nbsp;you&nbsp;may&nbsp;use&nbsp;only&nbsp;the&nbsp;mathematics&nbsp;functions.&nbsp;Keep&nbsp;your&nbsp;calculator&nbsp;flat&nbsp;on&nbsp;your&nbsp;workstation.You&nbsp;may&nbsp;use&nbsp;your&nbsp;scratch&nbsp;paper&nbsp;on&nbsp;this&nbsp;test.&nbsp;You&nbsp;will&nbsp;hand&nbsp;that&nbsp;in&nbsp;to&nbsp;the&nbsp;room&nbsp;supervisor&nbsp;at&nbsp;the&nbsp;end&nbsp;of&nbsp;testing.\nSelect&nbsp;the&nbsp;<strong>&nbsp;Next&nbsp;</strong>&nbsp;button&nbsp;to&nbsp;proceed.\n";
        }
        private Instruction MathInst()
        {
            return new Instruction()
            {
                Header =
$"Begin&nbsp;Mathematics&nbsp;Test—{Section.Duration}&nbsp;minutes,&nbsp;{Section.Questions.ToList().Count}&nbsp;questions",
                InstructionText =
"Solve&nbsp;each&nbsp;problem,&nbsp;choose&nbsp;the&nbsp;correct&nbsp;answer,&nbsp;and&nbsp;then&nbsp;select&nbsp;your&nbsp;answer.&nbsp;Select&nbsp;the&nbsp;<strong>&nbsp;Next&nbsp;</strong>&nbsp;button.\n\nDo&nbsp;not&nbsp;linger&nbsp;over&nbsp;problems&nbsp;that&nbsp;take&nbsp;too&nbsp;much&nbsp;time.&nbsp;Solve&nbsp;as&nbsp;many&nbsp;as&nbsp;you&nbsp;can;&nbsp;then&nbsp;return&nbsp;to&nbsp;the&nbsp;others&nbsp;in&nbsp;the&nbsp;time&nbsp;you&nbsp;have&nbsp;left&nbsp;for&nbsp;this&nbsp;test.\nYou&nbsp;may&nbsp;use&nbsp;your&nbsp;calculator&nbsp;for&nbsp;any&nbsp;problems&nbsp;you&nbsp;choose,&nbsp;but&nbsp;some&nbsp;of&nbsp;the&nbsp;problems&nbsp;may&nbsp;best&nbsp;be&nbsp;done&nbsp;without&nbsp;using&nbsp;a&nbsp;calculator.\nNote:&nbsp;Unless&nbsp;otherwise&nbsp;stated,&nbsp;all&nbsp;of&nbsp;the&nbsp;following&nbsp;should&nbsp;be&nbsp;assumed.\n&nbsp;1.Illustrative&nbsp;figures&nbsp;are&nbsp;NOT&nbsp;necessarily&nbsp;drawn&nbsp;to&nbsp;scale.\n&nbsp;2.Geometric&nbsp;figures&nbsp;lie&nbsp;in&nbsp;a&nbsp;plane.\n&nbsp;3.The&nbsp;word&nbsp;<em>&nbsp;line&nbsp;</em>&nbsp;indicates&nbsp;a&nbsp;straight&nbsp;line.\n&nbsp;4.The&nbsp;word&nbsp;<em>&nbsp;average&nbsp;</em>&nbsp;indicates&nbsp;arithmetic&nbsp;mean\n\nSelect&nbsp;the&nbsp;<strong>&nbsp;Next&nbsp;</strong>&nbsp;button&nbsp;to&nbsp;proceed.\n"
            };
        }
        private string ScienceInfo()
        {
            return $"<strong>&nbsp;Science&nbsp;Test&nbsp;Directions\n\nYou&nbsp;will&nbsp;have&nbsp;{Section.Duration}&nbsp;minutes&nbsp;to&nbsp;complete&nbsp;this&nbsp;section.&nbsp;</strong>\nSECTION&nbsp;DIRECTIONS:&nbsp;The&nbsp;first&nbsp;screen&nbsp;in&nbsp;this&nbsp;section&nbsp;contains&nbsp;instructions&nbsp;about&nbsp;the&nbsp;science&nbsp;test.&nbsp;That&nbsp;screen&nbsp;is&nbsp;not&nbsp;part&nbsp;of&nbsp;the\n&nbsp;scored&nbsp;questions.&nbsp;You&nbsp;can&nbsp;return&nbsp;to&nbsp;the&nbsp;instructions&nbsp;at&nbsp;any&nbsp;time&nbsp;by&nbsp;selecting&nbsp;the&nbsp;\n<strong>&nbsp;Nav&nbsp;</strong>&nbsp;button&nbsp;at&nbsp;the&nbsp;top&nbsp;of&nbsp;the&nbsp;screen&nbsp;and&nbsp;then&nbsp;selecting&nbsp;<strong>&nbsp;Instr&nbsp;</strong>.\n\nYou&nbsp;may&nbsp;use&nbsp;your&nbsp;scratch&nbsp;paper&nbsp;on&nbsp;this&nbsp;test.&nbsp;You&nbsp;will&nbsp;hand&nbsp;that&nbsp;in&nbsp;to&nbsp;the&nbsp;room&nbsp;supervisor&nbsp;at&nbsp;the&nbsp;end&nbsp;of&nbsp;testing.\nSelect&nbsp;the&nbsp;<strong>&nbsp;Next&nbsp;</strong>&nbsp;button&nbsp;to&nbsp;proceed.\n";
        }
        private Instruction ScienceInst()
        {
            return new Instruction()
            {
                Header =
$"Begin&nbsp;Science&nbsp;Test—{Section.Duration}&nbsp;minutes,&nbsp;{Section.Questions.ToList().Count}&nbsp;questions",
                InstructionText =
"There&nbsp;are&nbsp;several&nbsp;passages&nbsp;in&nbsp;this&nbsp;section.&nbsp;Each&nbsp;passage&nbsp;is&nbsp;followed&nbsp;by&nbsp;several&nbsp;questions.&nbsp;Read&nbsp;each&nbsp;passage&nbsp;through&nbsp;once,&nbsp;using&nbsp;the&nbsp;scroll&nbsp;bar&nbsp;to&nbsp;see&nbsp;the&nbsp;entire&nbsp;passage,&nbsp;before&nbsp;you&nbsp;begin&nbsp;to&nbsp;answer&nbsp;the&nbsp;questions&nbsp;that&nbsp;accompany&nbsp;it.&nbsp;After&nbsp;reading&nbsp;a&nbsp;passage,&nbsp;choose&nbsp;the&nbsp;best&nbsp;answer&nbsp;to&nbsp;each&nbsp;question,&nbsp;select&nbsp;the&nbsp;circle&nbsp;next&nbsp;to&nbsp;it,&nbsp;then&nbsp;select&nbsp;the&nbsp;<strong>&nbsp;Next&nbsp;</strong>&nbsp;button.&nbsp;You&nbsp;may&nbsp;refer&nbsp;to&nbsp;the&nbsp;passages&nbsp;as&nbsp;often&nbsp;as&nbsp;necessary.\nYou&nbsp;are&nbsp;NOT&nbsp;permitted&nbsp;to&nbsp;use&nbsp;a&nbsp;calculator&nbsp;on&nbsp;this&nbsp;section.\nSelect&nbsp;the&nbsp;<strong>&nbsp;Next&nbsp;</strong>&nbsp;button&nbsp;to&nbsp;proceed.\n"
            };
        }
        private string ReadingInfo()
        {
            return "<strong>&nbsp;Reading&nbsp;Test&nbsp;Directions&nbsp;</strong>&nbsp;\nYou&nbsp;may&nbsp;now&nbsp;resume&nbsp;testing.&nbsp;Remember,&nbsp;if&nbsp;you&nbsp;are&nbsp;wearing&nbsp;a&nbsp;watch&nbsp;with&nbsp;an&nbsp;alarm&nbsp;or&nbsp;have&nbsp;any&nbsp;other&nbsp;alarm&nbsp;device,&nbsp;it&nbsp;must&nbsp;remain&nbsp;turned\n&nbsp;off.&nbsp;If&nbsp;you&nbsp;have&nbsp;a&nbsp;cell&nbsp;phone&nbsp;or&nbsp;other&nbsp;electronic&nbsp;device,&nbsp;it&nbsp;must&nbsp;remain&nbsp;powered&nbsp;off&nbsp;and&nbsp;stored&nbsp;out&nbsp;of&nbsp;sight&nbsp;until&nbsp;you&nbsp;leave&nbsp;the&nbsp;test&nbsp;site.\n\nClear&nbsp;your&nbsp;workstation&nbsp;of&nbsp;everything&nbsp;except&nbsp;your&nbsp;testing&nbsp;computer,&nbsp;scratch&nbsp;paper,&nbsp;and&nbsp;pencil.\n&nbsp;" +
$"<strong>&nbsp;You&nbsp;will&nbsp;have&nbsp;{Section.Duration}&nbsp;minutes&nbsp;to&nbsp;complete&nbsp;this&nbsp;section</strong>&nbsp;\nSECTION&nbsp;DIRECTIONS:&nbsp;The&nbsp;first&nbsp;screen&nbsp;in&nbsp;this&nbsp;section&nbsp;contains&nbsp;instructions&nbsp;about&nbsp;the&nbsp;reading&nbsp;test.&nbsp;That&nbsp;screen&nbsp;is&nbsp;not&nbsp;part&nbsp;of&nbsp;the&nbsp;scored&nbsp;questions.&nbsp;You&nbsp;can&nbsp;return&nbsp;to&nbsp;the&nbsp;instructions&nbsp;at&nbsp;any&nbsp;time&nbsp;by&nbsp;selecting&nbsp;the&nbsp;<strong>&nbsp;Nav&nbsp;</strong>&nbsp;button&nbsp;at&nbsp;the&nbsp;top&nbsp;of&nbsp;the&nbsp;screen&nbsp;and&nbsp;then&nbsp;selecting&nbsp;<strong>&nbsp;Instr&nbsp;</strong>\n\n&nbsp;You&nbsp;may&nbsp;use&nbsp;your&nbsp;scratch&nbsp;paper&nbsp;on&nbsp;this&nbsp;test.&nbsp;You&nbsp;will&nbsp;hand&nbsp;that&nbsp;in&nbsp;to&nbsp;the&nbsp;room&nbsp;supervisor&nbsp;at&nbsp;the&nbsp;end&nbsp;of&nbsp;testing.\n\nSelect&nbsp;the&nbsp;<strong>&nbsp;Next&nbsp;</strong>&nbsp;button&nbsp;to&nbsp;proceed.\n";
        }
        private Instruction ReadingInst()
        {
            return new Instruction()
            {
                Header = $"Begin&nbsp;Reading&nbsp;Test—{Section.Duration}&nbsp;minutes",
                InstructionText =
"There&nbsp;are&nbsp;several&nbsp;passages&nbsp;in&nbsp;this&nbsp;test.&nbsp;Each&nbsp;passage&nbsp;is&nbsp;accompanied&nbsp;by&nbsp;several&nbsp;questions.&nbsp;Some&nbsp;passages&nbsp;are&nbsp;grouped&nbsp;within&nbsp;a\n&nbsp;single&nbsp;scrollable&nbsp;window&nbsp;and&nbsp;the&nbsp;corresponding&nbsp;questions&nbsp;will&nbsp;refer&nbsp;to&nbsp;Passage&nbsp;A,&nbsp;Passage&nbsp;B,&nbsp;or&nbsp;both&nbsp;passages.\n\nRead&nbsp;each&nbsp;passage&nbsp;through&nbsp;once,&nbsp;using&nbsp;the&nbsp;scroll&nbsp;bar&nbsp;to&nbsp;see&nbsp;the&nbsp;entire&nbsp;passage,&nbsp;before&nbsp;you&nbsp;begin&nbsp;to&nbsp;answer&nbsp;the&nbsp;questions&nbsp;that&nbsp;accompany&nbsp;the&nbsp;passage.&nbsp;After&nbsp;reading&nbsp;a&nbsp;passage,&nbsp;choose&nbsp;the&nbsp;best&nbsp;answer&nbsp;to&nbsp;each&nbsp;question,&nbsp;select&nbsp;the&nbsp;circle&nbsp;next&nbsp;to&nbsp;it,&nbsp;then&nbsp;select\n&nbsp;the&nbsp;<strong>&nbsp;Next&nbsp;</strong>&nbsp;&nbsp;button.&nbsp;You&nbsp;may&nbsp;refer&nbsp;to&nbsp;the&nbsp;passages&nbsp;as&nbsp;often&nbsp;as&nbsp;necessary.\nSelect&nbsp;the&nbsp;<strong>&nbsp;Next&nbsp;</strong>&nbsp;button&nbsp;to&nbsp;proceed.\n"
            };
        }
    }
}
