using SurveyLion.Presentation.Terminal;

var survey = new Survey(
    "Formulario do Desbravador", 
    "Questionario sobre a saude do desbravador");

survey.AddQuestion(new ShortTextQuestion("Nome Completo", "Nome completo do desbravador", true, survey));
survey.AddQuestion(new NumberQuestion("Idade", "Qual a sua idade", true, 0,120, survey));
survey.AddQuestion(new ShortTextQuestion("Nome do Clube", "Nome do clube de desbravador ao qual pertence", true, survey));

var surveyService = new SurveyService(survey);

survey.AddSurveySession(surveyService.CreateSurveySession());
SurveySessionPrinter.PrintShort(survey.SurveySessions.First());
