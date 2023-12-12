namespace Aibote4Sharp.sdk
{
    public abstract class ClientManager
    {
        private Dictionary<string, AiboteChannel> dict = new Dictionary<string, AiboteChannel>();


        private Form1? form1;

        public ClientManager() { }


        public void setForm(Form1 form1)
        {
            this.form1 = form1;
        }

        public AiboteChannel? get(string keyId)
        {
            return dict.GetValueOrDefault(keyId);
        }

        public void add(string keyId, AiboteChannel ctc)
        {
            this.dict.Add(keyId, ctc);
            form1.Invoke(new Form1.AddDelegate(form1.AddClient), keyId);
        }

        public void remove(string keyId)
        {
            this.dict.Remove(keyId);
            form1.Invoke(new Form1.RemoveDelegate(form1.RemoveClient), keyId);
        }

        public Dictionary<string, AiboteChannel> getDict()
        {
            return dict;
        }

    }

    public class AndroidClientManager : ClientManager
    {
        private static AndroidClientManager instance = new AndroidClientManager();
        public static ClientManager getInstance()
        {
            return instance;
        }

        private AndroidClientManager() { }

    }
    public class WinClientManager : ClientManager
    {
        private static WinClientManager instance = new WinClientManager();
        public static ClientManager getInstance()
        {
            return instance;
        }

        private WinClientManager() { }
    }
    public class WebClientManager : ClientManager
    {
        private static WebClientManager instance = new WebClientManager();
        public static ClientManager getInstance()
        {
            return instance;
        }

        private WebClientManager() { }
    }
}
