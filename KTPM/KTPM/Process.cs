namespace KTPM
{
    public class Process
    {
        public Process()
        {
        }

        public string Text { set; get; }
        
        public string Username { set; get; }
        
        public string Password { set; get; }
        
        public string Data { set; get; }
        
        public bool Search(string keyword)
        {
            if (this.Text.Contains(keyword))
                return true;
            return false;
        }

        public bool Login(string usr, string pw)
        {
            if (usr == "" || pw == "")
                return false;
            if (this.Username.Equals(usr) && this.Password.Equals(pw))
                return true;
            return false;
        }

        public bool Register(string usr, string pw)
        {
            if (usr == "" || pw == "") return false;
            if (this.Username == usr|| this.Password == pw)
                return false;
            this.Username = usr;
            this.Password = pw;
            return true;
        }
    }
}