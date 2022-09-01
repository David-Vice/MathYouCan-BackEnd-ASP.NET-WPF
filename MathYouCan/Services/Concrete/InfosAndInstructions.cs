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
            return $"<strong>English Test Directions\n\nYou will have {Section.Duration} minutes to complete this section. </strong> \n " +
"SECTION DIRECTIONS: The first screen in this section contains instructions about the English test." +
" That screen is not part of the\n scored questions. You can return to the instructions at any time by selecting the " +
"<strong> Nav </strong> button at the top of the screen and then selecting <strong> Instr </strong> " +
"\n\nYou may use your scratch paper on this test. You will hand that in to the room supervisor at the end of testing.\n" +
"Select the <strong> Next </strong> button to proceed.\n";
        }

        private Instruction EngInst()
        {
            return new Instruction()
            {

                Header = $"Begin English Test—{Section.Duration} minutes, {Section.Questions.ToList().Count} questions\n",
                InstructionText =
"In the five passages that follow, certain words and phrases are underlined and highlighted. On the right-hand side of the screen," +
" you will find alternatives for the underlined and highlighted part. In most cases, you are to choose the one that best expresses the" +
" idea, makes the statement appropriate for standard written English, or is worded most consistently with the style and tone of the" +
" passage as a whole. If you think the original version is best, choose “NO CHANGE.” In some cases, you will find on the right-hand" +
" side of the screen a question about the underlined and highlighted part. You are to choose the best answer to the question.\n\n" +
"You will also find questions about a section of the passage, or about the passage as a whole. These questions do not refer to an " +
"underlined portion of the passage, but rather refer to a letter or letters, a number or numbers, or an asterisk within square brackets [ ].\n\n" +
"For each question, choose the alternative you consider best, select the circle next to your answer, then select the <strong> Next </strong> " +
"button. Read each passage through once, using the scroll bar to see the entire passage, before you begin to answer the questions that accompany" +
" the passage. For many of the questions, you must read several sentences beyond the question to determine the answer. Be sure that you have read " +
"far enough ahead each time you choose an alternative.\n\n" +
"Select the <strong> Next </strong> button to proceed."
            };
        }

        private string MathInfo()
        {
            return $"<strong>Mathematics Test Directions\n\nYou will have {Section.Duration} minutes to complete this section. </strong>\n" +
"SECTION DIRECTIONS: The first screen in this section contains instructions about the mathematics test." +
" That screen is not part of the\n scored questions. You can return to the instructions at any time by selecting the \n" +
"<strong> Nav </strong> button at the top of the screen and then selecting <strong> Instr </strong>. \n" +
"You are permitted to use a calculator on this test, and you may get it out now. Some types of calculators are prohibited. For example, you may not" +
" use any version of the TI-89. You are responsible for knowing if your calculator is permitted. Testing staff will check your calculator periodically" +
" during the test. If you use a prohibited calculator, you will be dismissed and your tests will not be scored.\n\n" +
"You are also responsible for making sure your calculator is working properly. You will not be provided with backup batteries or a replacement calculator.\n" +
"Do not share your calculator with another examinee. Do not connect your calculator in any way to the computer.\n" +
"If you need to use your backup calculator, raise your hand and testing staff will check it. You may have only one calculator on your workstation or in operation" +
" at a time. If you did not bring a backup calculator and yours malfunctions, continue testing." +
"If your calculator has games or other functions, you may not use those functions during the test; you may use only the mathematics functions. Keep your calculator" +
" flat on your workstation." +
"You may use your scratch paper on this test. You will hand that in to the room supervisor at the end of testing.\n" +
"Select the <strong> Next </strong> button to proceed.\n";
        }
        private Instruction MathInst()
        {
            return new Instruction()
            {
                Header =
$"Begin Mathematics Test—{Section.Duration} minutes, {Section.Questions.ToList().Count} questions",
                InstructionText =
"Solve each problem, choose the correct answer, and then select your answer. Select the <strong> Next </strong> button.\n\n" +
"Do not linger over problems that take too much time. Solve as many as you can; then return to the others in the time you have " +
"left for this test.\n" +
"You may use your calculator for any problems you choose, but some of the problems may best be done without using a calculator.\n" +
"Note: Unless otherwise stated, all of the following should be assumed.\n" +
" 1.Illustrative figures are NOT necessarily drawn to scale.\n" +
" 2.Geometric figures lie in a plane.\n" +
" 3.The word <i> line </i> indicates a straight line.\n" +
" 4.The word <i> average </i> indicates arithmetic mean\n\n" +
"Select the <strong> Next </strong> button to proceed.\n"
            };
        }
        private string ScienceInfo()
        {
            return $"<strong> Science Test Directions\n\nYou will have {Section.Duration} minutes to complete this section. </strong>\n" +
"SECTION DIRECTIONS: The first screen in this section contains instructions about the science test." +
" That screen is not part of the\n scored questions. You can return to the instructions at any time by selecting the \n" +
"<strong> Nav </strong> button at the top of the screen and then selecting <strong> Instr </strong>.\n\n" +
"You may use your scratch paper on this test. You will hand that in to the room supervisor at the end of testing.\n" +
"Select the <strong> Next </strong> button to proceed.\n";
        }
        private Instruction ScienceInst()
        {
            return new Instruction()
            {
                Header =
$"Begin Science Test—{Section.Duration} minutes, {Section.Questions.ToList().Count} questions",
                InstructionText =
"There are several passages in this section. Each passage is followed by several questions. Read each passage through once, using the scroll bar to see" +
" the entire passage, before you begin to answer the questions that accompany it. After reading a passage, choose the best answer to each question, select" +
" the circle next to it, then select the <strong> Next </strong> button. You may refer to the passages as often as necessary.\n" +
"You are NOT permitted to use a calculator on this section.\n" +
"Select the <strong> Next </strong> button to proceed.\n"
            };
        }
        private string ReadingInfo()
        {
            return "<strong> Reading Test Directions </strong> \n" +
"You may now resume testing. Remember, if you are wearing a watch with an alarm or have any other alarm device, it must remain turned\n off. If you have" +
" a cell phone or other electronic device, it must remain powered off and stored out of sight until you leave the test site.\n\n" +
"Clear your workstation of everything except your testing computer, scratch paper, and pencil.\n " +
$"<strong> You will have {Section.Duration} minutes to complete this section</strong> \n" +
"SECTION DIRECTIONS: The first screen in this section contains instructions about the reading test. That screen is not part of the scored questions. You can return to the instructions at any time by selecting the <strong> Nav </strong> button at the top of the screen and then selecting <strong> Instr </strong>\n\n" +
" You may use your scratch paper on this test. You will hand that in to the room supervisor at the end of testing.\n\n" +
"Select the <strong> Next </strong> button to proceed.\n";
        }
        private Instruction ReadingInst()
        {
            return new Instruction()
            {
                Header = $"Begin Reading Test—{Section.Duration} minutes",
                InstructionText =
"There are several passages in this test. Each passage is accompanied by several questions. Some passages are grouped within a\n single scrollable window and the corresponding questions will refer to Passage A, Passage B, or both passages.\n\n" +
"Read each passage through once, using the scroll bar to see the entire passage, before you begin to answer the questions that accompany the passage. After reading a passage, choose the best answer to each question, select the circle next to it, then select\n the " +
"<strong> Next </strong>  button. You may refer to the passages as often as necessary.\n" +
"Select the <strong> Next </strong> button to proceed.\n"
            };
        }
    }
}
