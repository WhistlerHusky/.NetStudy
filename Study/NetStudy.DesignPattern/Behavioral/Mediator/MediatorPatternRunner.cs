using NetStudy.Core;

namespace NetSutdy.DesignPattern.Behavioral.Mediator
{

    public class MediatorPatternRunner : IRunner
    {
        public void Run()
        {
            var stupidMarine1 = new SpeakableStupidMarine();
            stupidMarine1.Name = "Sutpid Marine 1";

            var stupidMarine2 = new SpeakableStupidMarine();
            stupidMarine2.Name = "Sutpid Marine 2";

            var smartMarine1 = new SpeakableSmartMarine();
            smartMarine1.Name = "Smart Marine 1";

            var smartMarine2 = new SpeakableSmartMarine();
            smartMarine2.Name = "Smart Marine 2";
            Mediator mediator = new Mediator();

            mediator.Register(stupidMarine1);
            mediator.Register(stupidMarine2);
            mediator.Register(smartMarine1);
            mediator.Register(smartMarine2);

            stupidMarine1.Speak("I'm a stupid marine");

            smartMarine1.Speak("What? ");
        }
    }
}
