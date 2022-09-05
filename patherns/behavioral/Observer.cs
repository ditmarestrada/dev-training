using System;

namespace Patherns.Behavioral{

    public interface IObserver{
        void update();
    }

    public abstract class IObservable{
        private List<IObserver> observers = new List<IObserver>(); 
        public void subscribe(IObserver obs){
             this.observers.Add(obs);
        }
        public void unsubscribe(IObserver obs){
            this.observers.Remove(obs);
        }
        public void notify(){

            foreach(var obs in observers){

                obs.update();

            }
        }

    }


    public class YoutubeChannelSubject : IObservable{

        public List<string> peoples = new List<string>(); 
        
        public void setPeoble(string name){

            peoples.Add(name);
            base.notify();

        }       

    }

    public class TotalObserver : IObserver{

        private YoutubeChannelSubject subject;
        public TotalObserver(YoutubeChannelSubject subject){

            this.subject =  subject;

        }

        public void update(){
            
            Console.WriteLine("total :[ " + this.subject.peoples.Count+" ]");

        }

    }

    public class YoutubeChannelObserver : IObserver{

        private YoutubeChannelSubject subject;
        public YoutubeChannelObserver(YoutubeChannelSubject subject){

            this.subject =  subject;

        }

        public void update(){
            
            Console.WriteLine("observador :[");
            foreach(var pep in this.subject.peoples)
            Console.WriteLine(" - "+ pep);

            Console.WriteLine(" ] ");

        }

    }


    public static class DemoObserver{
        
        public static void main(){

            var subject = new YoutubeChannelSubject();

            var youtubeChannelObserver = new YoutubeChannelObserver(subject);
            var totalObserver = new TotalObserver(subject);

            subject.subscribe(youtubeChannelObserver);
            subject.subscribe(totalObserver);

            subject.setPeoble("juanito");

            subject.setPeoble("benito");

            subject.setPeoble("benito");

            subject.setPeoble("badbuny");

        }
    }

}