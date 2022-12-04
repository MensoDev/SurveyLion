using SurveyLion.Presentation.Terminal;

var survey = new Survey(
    "Formulario do Desbravador", 
    "Questionario sobre a saude do desbravador");

survey.AddQuestion(new ShortTextQuestion("Nome Completo", "Nome completo do desbravador", true, survey));
survey.AddQuestion(new ShortTextQuestion("CPF", "Numero do CPF do desbravador", true, survey));
survey.AddQuestion(new ShortTextQuestion("Registro Geral", "Numero do RG do desbravador", false, survey));
survey.AddQuestion(new ShortTextQuestion("Cidade de Nascimento", "Nome da cidade em que nasceu", false, survey));
survey.AddQuestion(new ShortTextQuestion("Nome do Clube", "Nome do clube de desbravador ao qual pertence", true, survey));

var surveyService = new SurveyService(survey);

survey.AddSurveySession(surveyService.CreateSurveySession());
SurveySessionPrinter.Print(survey.SurveySessions.First());
Console.ReadKey();
SurveySessionPrinter.PrintShort(survey.SurveySessions.First());
