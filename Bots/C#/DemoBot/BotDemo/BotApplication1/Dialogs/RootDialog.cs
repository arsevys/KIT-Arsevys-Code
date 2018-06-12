using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

using Microsoft.Bot.Connector;

namespace BotApplication1.Dialogs
{
    [Serializable]
    //96aa24ab-e3f6-46df-9ef2-81445a4f2dcb    - 96dcf98e02974c08b0178ef88c9c4c9a
    //f9c1259a-de5b-4448-9565-42f368c82445
    //f9c1259a-de5b-4448-9565-42f368c82445  -   14ce41ae43fb4064943d8adf5a25f5a1
    [LuisModel("f9c1259a-de5b-4448-9565-42f368c82445", "14ce41ae43fb4064943d8adf5a25f5a1")]
    public class RootDialog : LuisDialog<object>
    {
        /*
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }
        */
     
        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            // Calculate something for us to return
            int length = (activity.Text ?? string.Empty).Length;
            Console.WriteLine(activity);
            // Return our reply to the user
            await context.PostAsync($"You sent {activity.Text} which was {length} characters");
           
            context.Wait(MessageReceivedAsync);
        }
        /*
        private static Attachment GetHeroCard(string title, string subtitle, string text, CardImage cardImage, CardAction cardAction)
        {
            var heroCard = new HeroCard
            {
                Title = title,
                Subtitle = subtitle,
                Text = text,
                Images = new List<CardImage>() { cardImage },
                Buttons = new List<CardAction>() { cardAction },
            };

            return heroCard.ToAttachment();
        }*/

        private static Attachment armarCard(string title,  List<CardAction> cardAction)
        {
            var heroCard = new HeroCard
            {
                Title = title,
                
                Buttons =cardAction 
            };

            return heroCard.ToAttachment();
        }


        /*
            private static Attachment GetHeroCard()
        {
            var heroCard = new HeroCard
            {
                Title = "BotFramework Hero Card",
                Subtitle = "Your bots — wherever your users are talking",
                Text = "Build and connect intelligent bots to interact with your users naturally wherever they are, from text/sms to Skype, Slack, Office 365 mail and other popular services.",
                Images = new List<CardImage> { new CardImage("https://sec.ch9.ms/ch9/7ff5/e07cfef0-aa3b-40bb-9baa-7c9ef8ff7ff5/buildreactionbotframework_960.jpg") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "Get Started", value: "https://docs.microsoft.com/bot-framework") }
            };
            

            return heroCard.ToAttachment();
        }
        */


        private static IList<Attachment> GetCardsAttachments()
        {

            List<Attachment> ok = new List<Attachment>();
            ok.Add(armarCard("Mi Fondo", new List<CardAction> {
                  new CardAction(ActionTypes.ImBack, "Estado de cuenta", value: "estado de cuenta"),
                    new CardAction(ActionTypes.OpenUrl, "Hipotecario 25%", value: "https://azure.microsoft.com/en-us/services/storage/"),
                      new CardAction(ActionTypes.OpenUrl, "Retiro 95.5%", value: "https://azure.microsoft.com/en-us/services/storage/")}
            ));
            ok.Add(armarCard("Datos de Afiliado", new List<CardAction> {
                  new CardAction(ActionTypes.OpenUrl, "Contraseña Web", value: "https://azure.microsoft.com/en-us/services/storage/"),
                    new CardAction(ActionTypes.OpenUrl, "Actualizar Datos", value: "https://azure.microsoft.com/en-us/services/storage/"),
                      new CardAction(ActionTypes.OpenUrl, "CUSPP", value: "https://azure.microsoft.com/en-us/services/storage/")}
          ));
            ok.Add(armarCard("Jubiliacion", new List<CardAction> {
                  new CardAction(ActionTypes.OpenUrl, "Pensiones", value: "https://azure.microsoft.com/en-us/services/storage/"),
                    new CardAction(ActionTypes.OpenUrl, "Beneficios", value: "https://azure.microsoft.com/en-us/services/storage/"),
                      new CardAction(ActionTypes.OpenUrl, "Constacioncia Afiliación", value: "https://azure.microsoft.com/en-us/services/storage/")}
          ));
            ok.Add(armarCard("Derívame con un asesor", new List<CardAction> {
                  new CardAction(ActionTypes.OpenUrl, "Derivar", value: "https://azure.microsoft.com/en-us/services/storage/")}
          ));

            return ok;
        }
    



    [LuisIntent("hola")]
        private async Task Hola(IDialogContext context, LuisResult result)
        {
            Console.Write(result);
            Debug.Print("sdasda46565");
            var message = context.MakeMessage();
            //var attachment = GetSelectedCard(selectedCard);
            message.Attachments = GetCardsAttachments();
            /*
            await context.PostAsync(result.Entities.ToString());
            await context.PostAsync(result.TopScoringIntent.Intent.ToString());
            await context.PostAsync(result.TopScoringIntent.Score.ToString());*/
            var typingMsg = context.MakeMessage();
            typingMsg.Type = ActivityTypes.Typing;
            typingMsg.Text = null;
            await context.PostAsync(typingMsg);
            await Task.Delay(2000);
            await context.PostAsync("¡Hola, soy Irene!, la asistente virtual de AFP Integra. Permíteme ayudarte en los siguientes temas:");
            await context.PostAsync(message);
       
          //  context.Wait(MessageReceivedAsync);
        }
        [LuisIntent("estadoDeCuenta")]
        private async Task EstadoDeCuenta(IDialogContext context, LuisResult result)
        {
            Console.Write(result);
            /*
            var message = context.MakeMessage();
            //var attachment = GetSelectedCard(selectedCard);
            message.Attachments = GetCardsAttachments();
            await context.PostAsync("¡Hola, soy Irene!, la asistente virtual de AFP Integra. Permíteme ayudarte en los siguientes temas:");
            await context.PostAsync(message);*/
            var typingMsg = context.MakeMessage();
            typingMsg.Type = ActivityTypes.Typing;
            typingMsg.Text = null;
            await context.PostAsync(typingMsg);
            await Task.Delay(2000);
            await context.PostAsync("Encantada de poder ayudarte en este tema. A través de tu Estado de Cuenta podrás conocer los últimos aportes realizados por tu empleador, el saldo que tienes a la fecha y el tipo de fondo al que perteneces.");
            await Task.Delay(500);
            await context.PostAsync("Para acceder a tu Estado de Cuenta, solo debes ingresar a tu Zona Privada con las credenciales de tu cuenta y seguir estos pasos.");
            var message = context.MakeMessage();
            message.Attachments.Add(new Attachment()
            {
                ContentUrl = "http://cdn01.sura.net.pe/corporativo/imagenes/chatbot/mi-cuenta-eecc.png",
                ContentType = "image/png",
                Name = "mi-cuenta-eecc.png"
            });
            await context.PostAsync(message);

            new CallLogicApps().correo();

            //  context.Wait(MessageReceivedAsync);
        }
    }
}