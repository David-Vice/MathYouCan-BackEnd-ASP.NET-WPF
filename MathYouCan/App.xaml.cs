using MathYouCan.Models.Enums;
using MathYouCan.Models.Exams;
using MathYouCan.Views;
using System;
using System.Collections.Generic;
using System.Windows;

namespace MathYouCan
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {


        private void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                //api call and get the OfflineExam Object
                //now just for example I create it for mySelf

                TestSelection testSelectionWindow = new TestSelection();
                testSelectionWindow.ShowDialog();
                //MessageBox.Show(testSelectionWindow.SelectedOfflineExamId.ToString());

                //new ResultsWindow().ShowDialog();

                //new InstructionsWindow(CreateTestExam()).ShowDialog();
            }
            finally
            {
                Shutdown();
            }
        }
        //MethodForTests
        private OfflineExam CreateTestExam()
        {
            return new OfflineExam()
            {
                Date = DateTime.Now,
                Name = "Practise Test 1",
                Sections = new List<Section>()
                {
                    new Section()
                    {
                        Duration=45,
                        Name="English Practise Test",
                        Questions=new List<Question>()
                        {
                            new Question()
                            {
                                Text=$@"He remembers another birthday, his eleventh, the birthday on which he first heard opera, Verdi’s Rigoletto. His father had taken him to Tokyo by train and together they walked to the theater in a steady downpour. It was October 22 and so it was a cold autumn rain and the streets were waxed in a paper-thin layer of wet red leaves. When they arrived at the Tokyo Metropolitan Festival Hall, their undershirts were wet beneath coats and sweaters. The tickets waiting inside Katsumi Hosokawa’s father’s billfold were wet and discolored. They did not have especially good seats, but their view was unobstructed. In 1954, money was precious; train tickets and operas were unimaginable things. They climbed the long set of stairs to their row, careful not to look down into the dizzying void beneath them. They bowed and begged to be excused by every person who stood to let them pass into their seats, and then they unfolded their seats and slipped inside. They were early. They waited, father and son, without speaking, until finally the darkness fell and the first breath of music stirred from someplace far below them. Tiny people, insects, really, slipped out from behind the curtains, opened their mouths, and with their voices gilded the walls with their yearning, their grief, their boundless love. It was during that performance of Rigoletto that opera imprinted itself on Katsumi Hosokawa. Many years later, when everything was business, when he worked harder than anyone in a country whose values are structured on hard work, he believed that life, true life, was something that was stored in music. True life was kept safe in the lines of Tchaikovsky’s Eugene Onegin while you went out into the world and met the obligations required of you. Certainly he knew (though did not completely understand) that opera wasn’t for everyone, but for everyone he hoped there was something. He knew that without opera, part of himself would have vanished altogether. It was early in the second act, when Rigoletto and Gilda sang together, their voices twining, leaping, that he reached out for his father’s hand. He had no idea what they were saying, nor did he know that they played the parts of father and daughter, he only knew that he needed to hold to something. The pull they had on him was so strong he could feel himself falling forward out of the high and distant seats.Such love breeds loyalty, and Mr. Hosokawa was a loyal man. He never forgot the importance of Verdi in his life. He became attached to certain singers, as everyone does. He believed in the genius of Maria Callas above all others. There was never a great deal of time in his days. Custom was that after having dinner with clients and completing paperwork, he would spend thirty minutes listening to music before falling asleep. It was impossibly rare, maybe five Sundays a year, that he found three consecutive hours to listen to one opera start to finish. Once, in his late forties, he ate a spoiled oyster and suffered a vicious bout of food poisoning that kept him home for three days. He remembered this time as happily as any vacation because he played Handel’s Alcina continually, even while he slept.It was his eldest daughter, Kiyomi, who bought him his first recording of Roxane Coss for his birthday. Her father was a nearly impossible man to buy gifts for, and so when she saw the disc and a name she did not recognize, she thought she would take a chance. But it wasn’t the unknown name that drew her, it was the woman’s face. Kiyomi found the pictures of sopranos irritating. They were always peering over the tops of fans or gazing through veils of soft netting. But Roxane Coss looked at her directly, even her chin was straight, her eyes were wide open. Kiyomi gave her money to the girl at the counter.When Mr. Hosokawa put the CD in the player and sat down in his chair to listen, he did not go back to work that night. It was as if he was a boy in those high seats in Tokyo again, his father’s hand large and warm around his own. It was soaring, that voice, warm and complicated, utterly fearless. How could it be at once controlled and so reckless? He called Kiyomi’s name and she came and stood in the doorway of his study. She started to say something—yes? or, what? or, sir?—but before she could make out the words she heard that voice, the straight-ahead woman from the picture. Her father didn’t even say it, he simply gestured towards one speaker with his open hand. She was enormously pleased to have done something so right. Mr. Hosokawa closed his eyes. He dreamed.",
                                Type=QuestionType.Close,

                                Answers=new List<QuestionAnswer>()
                                {
                                    new QuestionAnswer()
                                    {
                                        Id=12,
                                        Text="a young boy with a passion for opera.",
                                        Type=AnswerType.A

                                    },
                                     new QuestionAnswer()
                                    {
                                         Id=43,
                                        Text="the daughter of an extremely busy father.",
                                        Type=AnswerType.B
                                    },
                                      new QuestionAnswer()
                                    {
                                          Id=7,
                                        Text="an omniscient narrator, who knows the thoughts of the characters.",
                                        Type=AnswerType.C
                                    },
                                      new QuestionAnswer()
                                    {
                                          Id=6,
                                        Text="an unnamed narrator who relates events from Mr. Hosokawa’s perspective.",
                                        Type=AnswerType.D
                                    }
                                }
                            },
                             new Question()
                            {
                                Text=$@"He remembers another birthday, his eleventh, the birthday on which he first heard opera, Verdi’s Rigoletto. His father had taken him to Tokyo by train and together they walked to the theater in a steady downpour. It was October 22 and so it was a cold autumn rain and the streets were waxed in a paper-thin layer of wet red leaves. When they arrived at the Tokyo Metropolitan Festival Hall, their undershirts were wet beneath coats and sweaters. The tickets waiting inside Katsumi Hosokawa’s father’s billfold were wet and discolored. They did not have especially good seats, but their view was unobstructed. In 1954, money was precious; train tickets and operas were unimaginable things. They climbed the long set of stairs to their row, careful not to look down into the dizzying void beneath them. They bowed and begged to be excused by every person who stood to let them pass into their seats, and then they unfolded their seats and slipped inside. They were early. They waited, father and son, without speaking, until finally the darkness fell and the first breath of music stirred from someplace far below them. Tiny people, insects, really, slipped out from behind the curtains, opened their mouths, and with their voices gilded the walls with their yearning, their grief, their boundless love. It was during that performance of Rigoletto that opera imprinted itself on Katsumi Hosokawa. Many years later, when everything was business, when he worked harder than anyone in a country whose values are structured on hard work, he believed that life, true life, was something that was stored in music. True life was kept safe in the lines of Tchaikovsky’s Eugene Onegin while you went out into the world and met the obligations required of you. Certainly he knew (though did not completely understand) that opera wasn’t for everyone, but for everyone he hoped there was something. He knew that without opera, part of himself would have vanished altogether. It was early in the second act, when Rigoletto and Gilda sang together, their voices twining, leaping, that he reached out for his father’s hand. He had no idea what they were saying, nor did he know that they played the parts of father and daughter, he only knew that he needed to hold to something. The pull they had on him was so strong he could feel himself falling forward out of the high and distant seats.Such love breeds loyalty, and Mr. Hosokawa was a loyal man. He never forgot the importance of Verdi in his life. He became attached to certain singers, as everyone does. He believed in the genius of Maria Callas above all others. There was never a great deal of time in his days. Custom was that after having dinner with clients and completing paperwork, he would spend thirty minutes listening to music before falling asleep. It was impossibly rare, maybe five Sundays a year, that he found three consecutive hours to listen to one opera start to finish. Once, in his late forties, he ate a spoiled oyster and suffered a vicious bout of food poisoning that kept him home for three days. He remembered this time as happily as any vacation because he played Handel’s Alcina continually, even while he slept.It was his eldest daughter, Kiyomi, who bought him his first recording of Roxane Coss for his birthday. Her father was a nearly impossible man to buy gifts for, and so when she saw the disc and a name she did not recognize, she thought she would take a chance. But it wasn’t the unknown name that drew her, it was the woman’s face. Kiyomi found the pictures of sopranos irritating. They were always peering over the tops of fans or gazing through veils of soft netting. But Roxane Coss looked at her directly, even her chin was straight, her eyes were wide open. Kiyomi gave her money to the girl at the counter.When Mr. Hosokawa put the CD in the player and sat down in his chair to listen, he did not go back to work that night. It was as if he was a boy in those high seats in Tokyo again, his father’s hand large and warm around his own. It was soaring, that voice, warm and complicated, utterly fearless. How could it be at once controlled and so reckless? He called Kiyomi’s name and she came and stood in the doorway of his study. She started to say something—yes? or, what? or, sir?—but before she could make out the words she heard that voice, the straight-ahead woman from the picture. Her father didn’t even say it, he simply gestured towards one speaker with his open hand. She was enormously pleased to have done something so right. Mr. Hosokawa closed his eyes. He dreamed.",
                                PhotoName="https://qph.fs.quoracdn.net/main-qimg-bd20d60d17211cd35fe6558993e4d927",
                                 Type=QuestionType.Close,
                                Answers=new List<QuestionAnswer>()
                                {
                                      new QuestionAnswer()
                                    {
                                        Id=15,
                                        Text="heard his first opera on his eleventh birthday.",
                                        Type=AnswerType.A
                                    },
                                     new QuestionAnswer()
                                    {
                                         Id=16,
                                        Text="appreciated Eugene Onegin.",
                                        Type=AnswerType.B
                                    },
                                      new QuestionAnswer()
                                    {
                                          Id=17,
                                        Text="rarely went out into the world.",

                                        Type=AnswerType.C
                                    },
                                      new QuestionAnswer()
                                    {
                                        Id=18,
                                        Text="didn’t understand the plot of Rigoletto when he saw the opera performed.",
                                        Type=AnswerType.D
                                    }
                                }
                            },
                              new Question()
                            {
                                Text=$@"He remembers another birthday, his eleventh, the birthday on which he first heard opera, Verdi’s Rigoletto. His father had taken him to Tokyo by train and together they walked to the theater in a steady downpour. It was October 22 and so it was a cold autumn rain and the streets were waxed in a paper-thin layer of wet red leaves. When they arrived at the Tokyo Metropolitan Festival Hall, their undershirts were wet beneath coats and sweaters. The tickets waiting inside Katsumi Hosokawa’s father’s billfold were wet and discolored. They did not have especially good seats, but their view was unobstructed. In 1954, money was precious; train tickets and operas were unimaginable things. They climbed the long set of stairs to their row, careful not to look down into the dizzying void beneath them. They bowed and begged to be excused by every person who stood to let them pass into their seats, and then they unfolded their seats and slipped inside. They were early. They waited, father and son, without speaking, until finally the darkness fell and the first breath of music stirred from someplace far below them. Tiny people, insects, really, slipped out from behind the curtains, opened their mouths, and with their voices gilded the walls with their yearning, their grief, their boundless love. It was during that performance of Rigoletto that opera imprinted itself on Katsumi Hosokawa. Many years later, when everything was business, when he worked harder than anyone in a country whose values are structured on hard work, he believed that life, true life, was something that was stored in music. True life was kept safe in the lines of Tchaikovsky’s Eugene Onegin while you went out into the world and met the obligations required of you. Certainly he knew (though did not completely understand) that opera wasn’t for everyone, but for everyone he hoped there was something. He knew that without opera, part of himself would have vanished altogether. It was early in the second act, when Rigoletto and Gilda sang together, their voices twining, leaping, that he reached out for his father’s hand. He had no idea what they were saying, nor did he know that they played the parts of father and daughter, he only knew that he needed to hold to something. The pull they had on him was so strong he could feel himself falling forward out of the high and distant seats.Such love breeds loyalty, and Mr. Hosokawa was a loyal man. He never forgot the importance of Verdi in his life. He became attached to certain singers, as everyone does. He believed in the genius of Maria Callas above all others. There was never a great deal of time in his days. Custom was that after having dinner with clients and completing paperwork, he would spend thirty minutes listening to music before falling asleep. It was impossibly rare, maybe five Sundays a year, that he found three consecutive hours to listen to one opera start to finish. Once, in his late forties, he ate a spoiled oyster and suffered a vicious bout of food poisoning that kept him home for three days. He remembered this time as happily as any vacation because he played Handel’s Alcina continually, even while he slept.It was his eldest daughter, Kiyomi, who bought him his first recording of Roxane Coss for his birthday. Her father was a nearly impossible man to buy gifts for, and so when she saw the disc and a name she did not recognize, she thought she would take a chance. But it wasn’t the unknown name that drew her, it was the woman’s face. Kiyomi found the pictures of sopranos irritating. They were always peering over the tops of fans or gazing through veils of soft netting. But Roxane Coss looked at her directly, even her chin was straight, her eyes were wide open. Kiyomi gave her money to the girl at the counter.When Mr. Hosokawa put the CD in the player and sat down in his chair to listen, he did not go back to work that night. It was as if he was a boy in those high seats in Tokyo again, his father’s hand large and warm around his own. It was soaring, that voice, warm and complicated, utterly fearless. How could it be at once controlled and so reckless? He called Kiyomi’s name and she came and stood in the doorway of his study. She started to say something—yes? or, what? or, sir?—but before she could make out the words she heard that voice, the straight-ahead woman from the picture. Her father didn’t even say it, he simply gestured towards one speaker with his open hand. She was enormously pleased to have done something so right. Mr. Hosokawa closed his eyes. He dreamed.",

                                Type=QuestionType.Close,
                                Answers=new List<QuestionAnswer>()
                                {
                                    new QuestionAnswer()
                                    {
                                        Id=115,
                                        Text="She wants to please him.",
                                        Type=AnswerType.A
                                    },
                                     new QuestionAnswer()
                                    {
                                         Id=17,
                                        Text="She shares his fondness for opera.",
                                        Type=AnswerType.B
                                    },
                                      new QuestionAnswer()
                                    {
                                          Id=145,
                                        Text="She feels increasingly distant from him.",

                                        Type=AnswerType.C
                                    },
                                      new QuestionAnswer()
                                    {
                                          Id=19,
                                        Text="She enjoys spending time with him.",
                                        Type=AnswerType.D
                                    }
                                }
                            },
                               new Question()
                            {
                                Text=$@"He remembers another birthday, his eleventh, the birthday on which he first heard opera, Verdi’s Rigoletto. |~H~|His|~H~| |~H~|father|~H~| |~H~|had|~H~| |~H~|taken|~H~| |~H~|him|~H~| |~H~|to|~H~| |~H~|Tokyo|~H~| |~H~|by|~H~| |~H~|train|~H~| |~H~|and|~H~| |~H~|together|~H~| |~H~|they|~H~| |~H~|walked|~H~| |~H~|to|~H~| |~H~|the|~H~| |~H~|theater|~H~| |~H~|in|~H~| |~H~|a|~H~| |~H~|steady|~H~| |~H~|downpour.|~H~| |~H~|It|~H~| |~H~|was|~H~| |~H~|October|~H~| |~H~|22|~H~| |~H~|and|~H~| |~H~|so|~H~| |~H~|it|~H~| |~H~|was|~H~| |~H~|a|~H~| |~H~|cold|~H~| |~H~|autumn|~H~| |~H~|rain|~H~| |~H~|and|~H~| |~H~|the|~H~| |~H~|streets|~H~| |~H~|were|~H~| |~H~|waxed|~H~| |~H~|in|~H~| |~H~|a|~H~| |~H~|paper-thin|~H~| |~H~|layer|~H~| |~H~|of|~H~| |~H~|wet|~H~| |~H~|red|~H~| |~H~|leaves.|~H~| |~H~|When|~H~| |~H~|they|~H~| |~H~|arrived|~H~| |~H~|at|~H~| |~H~|the|~H~| |~H~|Tokyo|~H~| |~H~|Metropolitan|~H~| |~H~|Festival|~H~| |~H~|Hall,|~H~| |~H~|their|~H~| |~H~|undershirts|~H~| |~H~|were|~H~| |~H~|wet|~H~| |~H~|beneath|~H~| |~H~|coats|~H~| |~H~|and|~H~| |~H~|sweaters.|~H~| |~H~|The|~H~| |~H~|tickets|~H~| |~H~|waiting|~H~| |~H~|inside|~H~| |~H~|Katsumi|~H~| |~H~|Hosokawa’s|~H~| |~H~|father’s|~H~| |~H~|billfold|~H~| |~H~|were|~H~| |~H~|wet|~H~| |~H~|and|~H~| |~H~|discolored.|~H~| |~H~|They|~H~| |~H~|did|~H~| |~H~|not|~H~| |~H~|have|~H~| |~H~|especially|~H~| |~H~|good|~H~| |~H~|seats,|~H~| |~H~|but|~H~| |~H~|their|~H~| |~H~|view|~H~| |~H~|was|~H~| |~H~|unobstructed.|~H~| In 1954, money was precious; train tickets and operas were unimaginable things. They climbed the long set of stairs to their row, careful not to look down into the dizzying void beneath them. They bowed and begged to be excused by every person who stood to let them pass into their seats, and then they unfolded their seats and slipped inside. They were early. They waited, father and son, without speaking, until finally the darkness fell and the first breath of music stirred from someplace far below them. Tiny people, insects, really, slipped out from behind the curtains, opened their mouths, and with their voices gilded the walls with their yearning, their grief, their boundless love. It was during that performance of Rigoletto that opera imprinted itself on Katsumi Hosokawa. Many years later, when everything was business, when he worked harder than anyone in a country whose values are structured on hard work, he believed that life, true life, was something that was stored in music. True life was kept safe in the lines of Tchaikovsky’s Eugene Onegin while you went out into the world and met the obligations required of you. Certainly he knew (though did not completely understand) that opera wasn’t for everyone, but for everyone he hoped there was something. He knew that without opera, part of himself would have vanished altogether. It was early in the second act, when Rigoletto and Gilda sang together, their voices twining, leaping, that he reached out for his father’s hand. He had no idea what they were saying, nor did he know that they played the parts of father and daughter, he only knew that he needed to hold to something. The pull they had on him was so strong he could feel himself falling forward out of the high and distant seats.Such love breeds loyalty, and Mr. Hosokawa was a loyal man. He never forgot the importance of Verdi in his life. He became attached to certain singers, as everyone does. He believed in the genius of Maria Callas above all others. There was never a great deal of time in his days. Custom was that after having dinner with clients and completing paperwork, he would spend thirty minutes listening to music before falling asleep. It was impossibly rare, maybe five Sundays a year, that he found three consecutive hours to listen to one opera start to finish. Once, in his late forties, he ate a spoiled oyster and suffered a vicious bout of food poisoning that kept him home for three days. He remembered this time as happily as any vacation because he played Handel’s Alcina continually, even while he slept.It was his eldest daughter, Kiyomi, who bought him his first recording of Roxane Coss for his birthday. Her father was a nearly impossible man to buy gifts for, and so when she saw the disc and a name she did not recognize, she thought she would take a chance. But it wasn’t the unknown name that drew her, it was the woman’s face. Kiyomi found the pictures of sopranos irritating. They were always peering over the tops of fans or gazing through veils of soft netting. But Roxane Coss looked at her directly, even her chin was straight, her eyes were wide open. Kiyomi gave her money to the girl at the counter.When Mr. Hosokawa put the CD in the player and sat down in his chair to listen, he did not go back to work that night. It was as if he was a boy in those high seats in Tokyo again, his father’s hand large and warm around his own. It was soaring, that voice, warm and complicated, utterly fearless. How could it be at once controlled and so reckless? He called Kiyomi’s name and she came and stood in the doorway of his study. She started to say something—yes? or, what? or, sir?—but before she could make out the words she heard that voice, the straight-ahead woman from the picture. Her father didn’t even say it, he simply gestured towards one speaker with his open hand. She was enormously pleased to have done something so right. Mr. Hosokawa closed his eyes. He dreamed.",
                                Type=QuestionType.Close,

                                Answers=new List<QuestionAnswer>()
                                {
                                    new QuestionAnswer()
                                    {
                                        Id=25,
                                        Text="suggest that the opera was overshadowed by unpleasant weather and bad seats.",
                                        Type=AnswerType.A
                                    },
                                     new QuestionAnswer()
                                    {
                                         Id=16,
                                        Text="describe the typical, rainy October weather in Tokyo in the mid-1950s.",
                                        Type=AnswerType.B
                                    },
                                      new QuestionAnswer()
                                    {
                                          Id=115,
                                        Text="offer sensory details that help set the stage for the important experience to be related.",
                                        Type=AnswerType.C
                                    },
                                     new QuestionAnswer()
                                    {
                                         Id=251,
                                        Text="imply that for Mr. Hosokawa, the train trip was more memorable than the opera.",
                                        Type=AnswerType.D
                                    }
                                }
                            },
                               new Question()
                            {
                                Text=$@"He remembers another birthday, his eleventh, the birthday on which he first heard opera, Verdi’s Rigoletto. His father had taken him to Tokyo by train and together they walked to the theater in a steady downpour. It was October 22 and so it was a cold autumn rain and the streets were waxed in a paper-thin layer of wet red leaves. When they arrived at the Tokyo Metropolitan Festival Hall, their undershirts were wet beneath coats and sweaters. The tickets waiting inside Katsumi Hosokawa’s father’s billfold were wet and discolored. They did not have especially good seats, but their view was unobstructed. In 1954, money was precious; train tickets and operas were unimaginable things. They |~H~|climbed|~H~| |~H~|the|~H~| |~H~|long|~H~| |~H~|set|~H~| |~H~|of|~H~| |~H~|stairs|~H~| |~H~|to|~H~| |~H~|their|~H~| |~H~|row,|~H~| careful not to look down into the dizzying void beneath them. They |~H~|bowed|~H~| |~H~|and|~H~| |~H~|begged|~H~| |~H~|to|~H~| |~H~|be|~H~| |~H~|excused|~H~| |~H~|by|~H~| |~H~|every|~H~| |~H~|person|~H~| |~H~|who|~H~| |~H~|stood|~H~| |~H~|to|~H~| |~H~|let|~H~| |~H~|them|~H~| |~H~|pass|~H~| |~H~|into|~H~| |~H~|their|~H~| |~H~|seats|~H~|, and then they unfolded their seats and slipped inside. They were early. They |~H~|waited,|~H~| |~H~|father|~H~| |~H~|and|~H~| |~H~|son,|~H~| |~H~|without|~H~| |~H~|speaking|~H~|, until finally the darkness fell and the first breath of music stirred from someplace far below them. Tiny people, insects, really, slipped out from behind the curtains, opened their mouths, and with their voices gilded the walls with their yearning, their grief, their boundless love. It was during that performance of Rigoletto that opera imprinted itself on Katsumi Hosokawa. Many years later, when everything was business, when he worked harder than anyone in a country whose values are structured on hard work, he believed that life, true life, was something that was stored in music. True life was kept safe in the lines of Tchaikovsky’s Eugene Onegin while you went out into the world and met the obligations required of you. Certainly he knew (though did not completely understand) that opera wasn’t for everyone, but for everyone he hoped there was something. He knew that without opera, part of himself would have vanished altogether. It was early in the second act, when Rigoletto and Gilda sang together, their voices twining, leaping, that he |~H~|reached|~H~| |~H~|out|~H~| |~H~|for|~H~| |~H~|his|~H~| |~H~|father’s|~H~| |~H~|hand.|~H~| He had no idea what they were saying, nor did he know that they played the parts of father and daughter, he only knew that he needed to hold to something. The pull they had on him was so strong he could feel himself falling forward out of the high and distant seats.Such love breeds loyalty, and Mr. Hosokawa was a loyal man. He never forgot the importance of Verdi in his life. He became attached to certain singers, as everyone does. He believed in the genius of Maria Callas above all others. There was never a great deal of time in his days. Custom was that after having dinner with clients and completing paperwork, he would spend thirty minutes listening to music before falling asleep. It was impossibly rare, maybe five Sundays a year, that he found three consecutive hours to listen to one opera start to finish. Once, in his late forties, he ate a spoiled oyster and suffered a vicious bout of food poisoning that kept him home for three days. He remembered this time as happily as any vacation because he played Handel’s Alcina continually, even while he slept.It was his eldest daughter, Kiyomi, who bought him his first recording of Roxane Coss for his birthday. Her father was a nearly impossible man to buy gifts for, and so when she saw the disc and a name she did not recognize, she thought she would take a chance. But it wasn’t the unknown name that drew her, it was the woman’s face. Kiyomi found the pictures of sopranos irritating. They were always peering over the tops of fans or gazing through veils of soft netting. But Roxane Coss looked at her directly, even her chin was straight, her eyes were wide open. Kiyomi gave her money to the girl at the counter.When Mr. Hosokawa put the CD in the player and sat down in his chair to listen, he did not go back to work that night. It was as if he was a boy in those high seats in Tokyo again, his father’s hand large and warm around his own. It was soaring, that voice, warm and complicated, utterly fearless. How could it be at once controlled and so reckless? He called Kiyomi’s name and she came and stood in the doorway of his study. She started to say something—yes? or, what? or, sir?—but before she could make out the words she heard that voice, the straight-ahead woman from the picture. Her father didn’t even say it, he simply gestured towards one speaker with his open hand. She was enormously pleased to have done something so right. Mr. Hosokawa closed his eyes. He dreamed.",
                                Type=QuestionType.Close,

                                Answers=new List<QuestionAnswer>()
                                {
                                    new QuestionAnswer()
                                    {
                                        Id=152,
                                        Text="“climbed the long set of stairs to their row” (see highlighted text).",
                                        Type=AnswerType.A
                                    },
                                     new QuestionAnswer()
                                    {
                                         Id=153,
                                        Text="“bowed and begged to be excused by every person who stood to let them pass into their seats” (see highlighted text).",
                                        Type=AnswerType.B
                                    },
                                      new QuestionAnswer()
                                    {
                                          Id=154,
                                        Text="“waited . . . without speaking” (see highlighted text).",
                                        Type=AnswerType.C
                                    },
                                     new QuestionAnswer()
                                    {
                                         Id=155,
                                        Text="“reached out for his father’s hand” (see highlighted text).",
                                        Type=AnswerType.D
                                    }
                                }
                            }
                        }
                    },
                    new Section()
                    {
                        Duration=30*60,
                        Name="Mathematics Practise Test",
                        Questions=new List<Question>()
                        {
                            new Question()
                            {
                                Text="Question1",
                                PhotoName="https://i.ytimg.com/vi/0e39N_n94Lo/maxresdefault.jpg",

                                Type=QuestionType.Close,
                                Answers=new List<QuestionAnswer>()
                                {
                                    new QuestionAnswer()
                                    {

                                        Type=AnswerType.A,
                                        PhotoName="https://i.ytimg.com/vi/0e39N_n94Lo/maxresdefault.jpg"
                                    },
                                     new QuestionAnswer()
                                    {

                                        Type=AnswerType.B,
                                        PhotoName="https://i.ytimg.com/vi/0e39N_n94Lo/maxresdefault.jpg"
                                    },
                                      new QuestionAnswer()
                                    {

                                        Type=AnswerType.C,
                                        PhotoName="https://i.ytimg.com/vi/0e39N_n94Lo/maxresdefault.jpg"
                                    }
                                }
                            },
                             new Question()
                            {
                                Text="Question2",
                                Type=QuestionType.Close,
                                Answers=new List<QuestionAnswer>()
                                {
                                    new QuestionAnswer()
                                    {
                                        Text="Answer1",
                                        Type=AnswerType.A
                                    },
                                     new QuestionAnswer()
                                    {
                                        Text="Answer2",
                                        Type=AnswerType.B
                                    },
                                      new QuestionAnswer()
                                    {
                                        Text="Answer3",
                                        Type=AnswerType.C
                                    }
                                }
                            },
                              new Question()
                            {
                                Text="Question3",
                                Type=QuestionType.Close,
                                Answers=new List<QuestionAnswer>()
                                {
                                    new QuestionAnswer()
                                    {
                                        Text="Answer1",
                                        Type=AnswerType.A
                                    },
                                     new QuestionAnswer()
                                    {
                                        Text="Answer2",
                                        Type=AnswerType.B
                                    },
                                      new QuestionAnswer()
                                    {
                                        Text="Answer3",
                                        Type=AnswerType.C
                                    }
                                }
                            },
                               new Question()
                            {
                                Text="Question4",
                                Type=QuestionType.Close,
                                Answers=new List<QuestionAnswer>()
                                {
                                    new QuestionAnswer()
                                    {
                                        Text="Answer1",
                                        Type=AnswerType.A
                                    },
                                     new QuestionAnswer()
                                    {
                                        Text="Answer2",
                                        Type=AnswerType.B
                                    },
                                      new QuestionAnswer()
                                    {
                                        Text="Answer3",
                                        Type=AnswerType.C
                                    }
                                }
                            }
                        }
                    },
                    //  new Section()
                    //{
                    //    Duration=30*60,
                    //    Name="Science Practise Test",
                    //    Questions=new List<Question>()
                    //    {
                    //        new Question()
                    //        {
                    //            Text="Question1",
                    //            PhotoName="https://i.ytimg.com/vi/0e39N_n94Lo/maxresdefault.jpg",

                    //            Type=QuestionType.Close,
                    //            Answers=new List<QuestionAnswer>()
                    //            {
                    //                new QuestionAnswer()
                    //                {

                    //                    Type=AnswerType.A,
                    //                    PhotoName="https://i.ytimg.com/vi/0e39N_n94Lo/maxresdefault.jpg"
                    //                },
                    //                 new QuestionAnswer()
                    //                {

                    //                    Type=AnswerType.B,
                    //                    PhotoName="https://i.ytimg.com/vi/0e39N_n94Lo/maxresdefault.jpg"
                    //                },
                    //                  new QuestionAnswer()
                    //                {

                    //                    Type=AnswerType.C,
                    //                    PhotoName="https://i.ytimg.com/vi/0e39N_n94Lo/maxresdefault.jpg"
                    //                }
                    //            }
                    //        },
                    //         new Question()
                    //        {
                    //            Text="Question2",
                    //            Type=QuestionType.Close,
                    //            Answers=new List<QuestionAnswer>()
                    //            {
                    //                new QuestionAnswer()
                    //                {
                    //                    Text="Answer1",
                    //                    Type=AnswerType.A
                    //                },
                    //                 new QuestionAnswer()
                    //                {
                    //                    Text="Answer2",
                    //                    Type=AnswerType.B
                    //                },
                    //                  new QuestionAnswer()
                    //                {
                    //                    Text="Answer3",
                    //                    Type=AnswerType.C
                    //                }
                    //            }
                    //        },
                    //          new Question()
                    //        {
                    //            Text="Question3",
                    //            Type=QuestionType.Close,
                    //            Answers=new List<QuestionAnswer>()
                    //            {
                    //                new QuestionAnswer()
                    //                {
                    //                    Text="Answer1",
                    //                    Type=AnswerType.A
                    //                },
                    //                 new QuestionAnswer()
                    //                {
                    //                    Text="Answer2",
                    //                    Type=AnswerType.B
                    //                },
                    //                  new QuestionAnswer()
                    //                {
                    //                    Text="Answer3",
                    //                    Type=AnswerType.C
                    //                }
                    //            }
                    //        },
                    //           new Question()
                    //        {
                    //            Text="Question4",
                    //            Type=QuestionType.Close,
                    //            Answers=new List<QuestionAnswer>()
                    //            {
                    //                new QuestionAnswer()
                    //                {
                    //                    Text="Answer1",
                    //                    Type=AnswerType.A
                    //                },
                    //                 new QuestionAnswer()
                    //                {
                    //                    Text="Answer2",
                    //                    Type=AnswerType.B
                    //                },
                    //                  new QuestionAnswer()
                    //                {
                    //                    Text="Answer3",
                    //                    Type=AnswerType.C
                    //                }
                    //            }
                    //        }
                    //    }
                    //}
                }

            };

        }
    }
}
