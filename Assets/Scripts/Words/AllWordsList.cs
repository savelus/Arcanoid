﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Words
{
    public class AllWordsList
    {
        #region facts

        public string facts = "Игра S.T.A.L.K.E.R. 2 разрабатывается больше 10 лет.;" +
                              "Мем “ПОТРАЧЕНО” появился из-за ошибки перевода текста для игры GTA: San Andreas.;" +
                              "В 1997 году Национальный музей науки и технологии включил игру \"Tetris\" в свою постоянную коллекцию, признав ее историческим искусством. Игры – это искусство.;" +
                              "Московский филармонический оркестр и хор создают музыку для видеоигр.;" +
                              "Известная студия озвучки сериалов и фильмов “Кураж-Бамбей” также озвучивает видеоигры.;" +
                              "Британец Фейз Чопдат отсидел четыре месяца из-за того, что проигнорировал требования бортпроводников и продолжил играть в «Тетрис» во время полета.;" +
                              "Российский разработчик Антон Ломакин первый смог “остановить” дождь в игре.;" +
                              "Название игры S.T.A.L.K.E.R выглядит как аббревиатура только из-за того, что слово “сталкер” могло вызвать проблемы с авторским правом.;" +
                              "По игре S.T.A.L.K.E.R существует большая серия книг, которая рассказывает читателям о приключениях сталкеров на запретной радиоактивной зоне.;" +
                              "Игра “Твиггер” первой российской студии по разработке игр была в космосе, на космической станции МИР.;" +
                              "Сотрудников игровой студии ICE-PICK LODGE называют “ледорубами”.;" +
                              "Известный персонаж “Ам Ням”, зеленый монстрик, который кушает леденцы, на самом деле персонаж российской игры.;" +
                              "«Тетрис» – первая видеоигра, побывавшая в космосе. В 1993 году космонавт Александр Серебров отправился на станцию Мир вместе с этой игро. Тетрис провел в космосе 196 дней и совершил более 3000 облетов вокруг Земли.;" +
                              "В 1950 годах Алан Тьюринг и Дэйвид Чампернаун разработали алгоритм шахматной игры, который мог стать первой шахматной видеоигрой. Но компьютеры того времени были недостаточно мощными, чтобы запустить эту игру.;" +
                              "Машина, на которой Тьюринг пробовал запустить первые шахматы в 1950, весила 30 тонн и занимала площадь больше 60 квадратных метров.;" +
                              "Первые компьютерные шашки мир увидел аж в 1952 году, очень давно.;" +
                              "Игровые автоматы в СССР делали… На военных и других заводах. Каждый завод делал 1 вид игровых автоматов.;" +
                              "На военной подлодке СССР стоял игровой автомат “Морской Бой”. Военные использовали его как тренажер и для отдыха.;" +
                              "Легендарную игру Pong на самом деле разработал стажер компании Atari, а не те, кому приписывается авторство.;" +
                              "В игре \"Pac-Man\" пять призраков имеют уникальные имена: Блинки, Рози, Инки, Клайд и Сью.;" +
                              "В 1974 году был создан первый игровой симулятор, это был симулятор охоты Qwak!;" +
                              "Согласно исследованиям, игровая индустрия в 2020 году превысила мировую кинематографическую индустрию по доходам, став самой прибыльной развлекательной отраслью. Игры зарабатывают больше фильмов!;" +
                              "В 2008 году в игре \"Fallout 3\" была создана национальная капсула времени. Игроки смогут открыть ее через 200 лет. Интересно, что они положили в эту капсулу?;" +
                              "В игре \"The Legend of Zelda: Ocarina of Time\"  часть музыкальных звуков были созданы путем обратного проигрывания звуков женского хора.;" +
                              "На Международной космической станции (МКС) астронавты играли в видеоигры для развлечения.;" +
                              "В 1997 году в России открылся первый геймерский клуб, он назывался “ОРКИ”. А как бы вы назвали свой игровой клуб?;" +
                              "Прародитель игровых автоматов выглядеть как большая машина с лампочками. В нее даже играл знаменитый физик Альберт Эйнштейн.;" +
                              "В 2002 году российская студия разработки игр “Акелла” сделала игру для голливуда, по мотивам фильма “Пираты Карибского моря”;" +
                              "19 января 2014 года в игру World of Tanks зашло рекордное количество игроков. Одновременно в эту игру играли 1 114 000 игроков. Это больше населения Челябинска.;" +
                              "В игре \"Королевская битва: Fortnite\" игроки провели суммарное время равное 349 000 лет!;" +
                              "Игра World of Warship содержит в себе крупнейшую коллекцию виртуальных военных кораблей в мире, эта игра была выпущена в 2015 году и может считаться настоящим виртуальным музеем, такие достоверные в ней модели кораблей.;" +
                              "\"Майнкрафт\" - самая продаваемая видеоигра всех времен. Она разработана в одиночку Маркусом Перссоном и продана более 200 миллионов копий.;" +
                              "Раньше игры выпускали на дисках, но не на одном, а на 2 или 3 сразу. Чтобы сыграть в игру, вам нужно было установить ее с 3 разных дисков.;" +
                              "В 2014 году вышла уникальная игра, визуальная новелла “Бесконечное лето”. Прототипом  локации стал настоящий лагерь “Волга” в Тверской области.;" +
                              "В 2001 году Россия стала первой страной, которая признала киберспорт официальным видом спорта, но потом это решение отменили.;" +
                              "В Москве и Санкт-Петербурге существуют музеи советских игровых автоматов, в эти музеи можно прийти и поиграть в автоматы, в которые играли в детстве наши родители.;" +
                              "В сфере разработки видеоигр существуют такие редкие профессии: дизайнер звука, Геймдизайнер искусственного интеллекта, дизайнер уровней, Аниматор света.;" +
                              "В сфере разработки видеоигр существует профессия “инженер физики игровых миров, эти люди создают новые законы физики для уникальных игровых миров.;" +
                              "В сфере разработки видеоигр существует профессия “исследователь и архитектор игрового мира”, эти люди изучают и создают миры для видеоигр.;" +
                              "Никто не знает, как создавали советские игровые автоматы, ведь их создавали на военных заводах. Поэтому схемы этих автоматов навсегда утеряны.;" +
                              "На фоне ТЕТРИСа играет русская народная песня “Коробейники”.;" +
                              "В СССР существовала игра по мотивам программы “Поле Чудес”, персонажами в ней были Карлсон, Винни-Пух и другие сказочные герои. Интересно, что на фоне этой игры стояли текстуры из игры Wolfenstein, игры стрелялки про демонов и ад. Как так получилось?;" +
                              "Многие игровые компании создают маскотов, чтобы продвигать себя и свой имидж. Порой маскоты становятся популярнее своих студий.;" +
                              "Когда в СССР начали выпускать игровые приставки – интернета еще не существовало.;" +
                              "Название игровой студии \"Rockstar Games\" было придумано из-за  песни \"Rockstar\" (звезда рока) группы \"Gang of Four\".;" +
                              "Название игровой студии \"Electronic Arts\" (EA) было придумано основателем компании Трипом Хокинсом. В 1982 году, когда Хокинс основал компанию, он и его партнеры решили создать студию, которая объединяет искусство и высокую технологию в области интерактивного развлечения.;" +
                              "В 1993 году была создана российская студия разработки игр Б.У.К.А., ее название было собрано из первых букв фамилии основателей компании: Белодородов, Устинов, Капустина-Ревун, Антонов.";

        #endregion


        public List<string> allFacts = new();
        public readonly List<Word> _wordList = new();
        public readonly List<Fact> _facts = new();

        private int _counter;
        private int _currentFact;
        public AllWordsList()
        {
            allFacts = new(facts.Split(";"));

            for (var i = 0; i < allFacts.Count; i++)
            {
                var fact = allFacts[i];
                var wordString = fact.Split(' ');
                List<Word> words = new();
                foreach (var word in wordString)
                {
                    var completeWord = new Word(word, _counter);
                    _wordList.Add(completeWord);
                    words.Add(completeWord);
                    _counter++;
                }

                _facts.Add(new Fact(words, i));
            }
        }

        
        public Word GetWord(int id)
        {
            return _wordList[id];
        }

        public Word GetRandomWord()
        {
            var notUnlockedWords = _wordList.Where(x => x.IsUnlocked = false).ToList();
            return notUnlockedWords[Random.Range(0, _wordList.Count - 1)];
        }


        public Fact GetFact(int factNumber) => 
            _facts[(factNumber + _facts.Count) % _facts.Count];

        public void SaveAllUnlockedWordsId()
        {
            StringBuilder stringBuilder = new();
            for (var i = 0; i < _wordList.Count; i++)
            {
                if (_wordList[i].IsUnlocked)
                    stringBuilder.Append(i + ";");
            }
            PlayerPrefs.SetString("savedWords", stringBuilder.ToString());
        }

        public List<Word> GetRandomWords(int countWords)
        {
            var wordsList = new List<Word>();
            var notUnlockedWords =  _wordList.Where(x => x.IsUnlocked == false).ToList();
            for (int i = 0; i < countWords; i++)
            {

                wordsList.Add(notUnlockedWords[Random.Range(0, notUnlockedWords.Count - 1)]);
            }

            return wordsList;
        }
    }
}

