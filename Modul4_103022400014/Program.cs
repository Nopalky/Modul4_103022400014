// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography.X509Certificates;

public class KodePaket {

    public enum namaPaket { Basic, Standar, Premium, Unlimited, Gaming, Streaming, Family, Business, Student, Teacher};

    public static string getKodePaket(string namapaket)
    {
        string[] kodePaket = { "P201", "P202", "P203", "P204", "P205", "P206", "P207", "P208", "P209", "P210"};

        return kodePaket[(int)Enum.Parse(typeof(namaPaket), namapaket)];
    }
}

public class MesinKopi
{
    public enum kondisiMesin { OFF, STANDBY, BREWING, MAINTENANCE };
    public enum Trigger { POWER_ON, POWER_OFF, START_BREW, FINISH_BREW, START_MAINTENANCE, FINISH_MAINTENANCE };

    class transition
    {
        public kondisiMesin prevState;
        public kondisiMesin nextState;
        public Trigger transisi;

        public transition(kondisiMesin prevState, kondisiMesin nextState, Trigger transisi)
        {
            this.prevState = prevState;
            this.nextState = nextState;
            this.transisi = transisi;
        }
    }

    transition[] transitions = {
        new transition(kondisiMesin.OFF, kondisiMesin.STANDBY, Trigger.POWER_ON),
        new transition(kondisiMesin.STANDBY, kondisiMesin.OFF, Trigger.POWER_OFF),
        new transition(kondisiMesin.STANDBY, kondisiMesin.BREWING, Trigger.START_BREW),
        new transition(kondisiMesin.BREWING, kondisiMesin.STANDBY, Trigger.FINISH_BREW),
        new transition(kondisiMesin.STANDBY, kondisiMesin.MAINTENANCE, Trigger.START_MAINTENANCE),
        new transition(kondisiMesin.MAINTENANCE, kondisiMesin.STANDBY, Trigger.FINISH_MAINTENANCE)
     };

    public kondisiMesin currentState;

    public MesinKopi()
    {
        currentState = kondisiMesin.OFF;
    }

    public kondisiMesin getNextState(kondisiMesin prevState, Trigger transition)
    {
        kondisiMesin nextState = prevState;

        for (int i = 0; i < transitions.Length; i++)
        {
            if (transitions[i].prevState == prevState && transitions[i].transisi == transition)
            {
                return transitions[i].nextState;
            }
        }
        return prevState;

    }
    public void activateTrigger(Trigger trigger)
    {

        kondisiMesin nextState = getNextState(currentState, trigger);
        currentState = nextState;

        if (currentState == kondisiMesin.OFF)
        {
            Console.WriteLine("Mesin Off berubah menjadi Standby");
        }
        else if (currentState == kondisiMesin.STANDBY)
        {
            Console.WriteLine("Mesin Standby berubah menjadi Brewing");
        }
        else if (currentState == kondisiMesin.BREWING)
        {
            Console.WriteLine("Mesin Brewing berubah menjadi Standby");
        }
        else if (currentState == kondisiMesin.MAINTENANCE)
        {
            Console.WriteLine("Mesin Standby berubah menjadi Maintenance");
        }

    }
    
 public static void Main(string[] args)
        {
            Console.WriteLine("====================== Program Kode Paket ======================");
            Console.WriteLine("Masukkan nama paket (Basic, Standar, Premium, Unlimited, Gaming, Streaming, Family, Business, Student, Teacher): ");
            string namapaket = Console.ReadLine();
            string kodePaket = KodePaket.getKodePaket(namapaket);
            Console.WriteLine($"Kode paket untuk {namapaket} adalah: {kodePaket}");

            MesinKopi mesinKopi = new MesinKopi();

            Console.WriteLine("====================== Program Mesin Kopi ======================");
            Console.WriteLine("State Awal: OFF");
            mesinKopi.activateTrigger(MesinKopi.Trigger.POWER_ON);
            Console.WriteLine("State Saat Ini: " + mesinKopi.currentState);
            mesinKopi.activateTrigger(MesinKopi.Trigger.START_BREW);


    }
    }
