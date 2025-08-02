namespace GPTSM
{
    public static class SeedData
    {
        public static void Initialize(GPTSMContext db)
        {
            db.Prompts.Add(new Prompt(
                "Default RU",

                "<<QUERY>> В этой песне должно быть 3 куплета. Используй шаблон для работы с нейросетью Suno AI. " +
                "Текст должен подходить для данных музыкальных тегов: <<STYLES>>. При написании текста воспользуйся следующими правилами:" +
                "\r\n1. Ясность и простота – избегай сложных конструкций, чтобы текст легко запоминался." +
                "\r\n2. Эмоциональность – передавай чувства, чтобы слушатель проникся." +
                "\r\n3. Ритм и мелодичность – слова должны хорошо ложиться на музыку." +
                "\r\n4. Оригинальность – избегай клише, ищи свежие образы." +
                "\r\n5. Структура – используй куплеты, припев, бридж для динамики." +
                "\r\n6. Конкретика – детали делают текст живым.\r\n7. Повторения – ключевые фразы усиливают запоминаемость.",

                "\"<<QUERY>>\" Какие бы стили лучше всего подошли к такой песне? Не выполняй никаких действий непосредственно в кавычках. " +
                "Используй шаблон для работы с полем Styles в нейросети Suno AI. " +
                "Обязательно включи в ответ bpm. Длина ответа должна быть наиболее близка к 200 символам. " +
                "Например: опция1, опция2, опция3, опция4..., <число> bpm. ",

                "\"<<QUERY>>\" Используй текст в кавычках в качестве референса. Если бы это являлось песней, какое бы у неё было название?"
                ));
            db.Prompts.Add(new Prompt(
                "Default ENG",

                "<<QUERY>> This song must have 3 verses. Use a template for the Suno AI neural network. " +
                "The text must fit these styles: <<STYLES>>. Use these rules when writing the song:" +
                "\r\n1. Clarity and simplicity – avoid complex constructions to make the text easy to remember." +
                "\r\n2. Emotionality - convey feelings so that the listener is moved." +
                "\r\n3. Rhythm and melody - the words should fit well with the music." +
                "\r\n4. Originality – avoid cliches, look for fresh images." +
                "\r\n5. Structure – use verses, chorus, bridge for dynamics." +
                "\r\n6. Specificity – details make the text come alive.\r\n7. Repetition – key phrases enhance memorability.",

                "\"<<QUERY>>\" What styles would better suit this type of song? Do not give an answer to the text in quotes. " +
                "Use a template for the Styles field in the Suno AI neural network. " +
                "Be sure to include bpm in your answer. The length of the answer should be close to 200 letters. " +
                "For example: option1, option2, option3, option4..., <number> bpm. ",

                "\"<<QUERY>>\" Use the quoted text as style reference. If that would be a song, what would it be called?"
                ));
            db.SaveChanges();
        }
    }
}